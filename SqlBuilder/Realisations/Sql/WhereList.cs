using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Sql
{
	public class WhereList : IWhereList
	{

		private readonly List<IWhere> _expressions;

		public IFormatter Parameters { get; private set; }

		public Enums.WhereLogic LogicOperator { get; private set; } = Enums.WhereLogic.AND;

		public bool HasOpenedParenthesis { get; private set; }

		public int Level { get; private set; }

		public IEnumerable<IWhere> Expressions
		{
			get
			{
				return this.Expressions;
			}
		}

		#region Construcor

		public WhereList(IFormatter parameters)
		{
			this._expressions = new List<IWhere>();
			this.Parameters = parameters;
		}

		#endregion

		#region Logic operators

		public IWhereList And()
		{
			this.LogicOperator = Enums.WhereLogic.AND;
			return this;
		}

		public IWhereList Or()
		{
			this.LogicOperator = Enums.WhereLogic.OR;
			return this;
		}

		public IWhereList Not()
		{
			this.LogicOperator = Enums.WhereLogic.NOT;
			return this;
		}

		#endregion

		#region Expressions List

		public int Count
		{
			get
			{
				return this._expressions.Count;
			}
		}

		public void Append(IWhere expression)
		{
			this._expressions.Add(expression);
		}

		public void Clear()
		{
			this._expressions.Clear();
		}

		private IWhere CreateExpression(Enums.WhereType Type, string Column, string Value)
		{
			IWhere exp = new Where(Type, this.LogicOperator);
			exp.Column = Column;
			exp.IsColumn = true;
			exp.Value = Value;
			this.Append(exp);
			return exp;
		}

		private IWhere CreateParenthesis(Enums.Parenthesis Parenthesis)
		{
			IWhere exp = new Where(Enums.WhereType.Unknown, this.LogicOperator, Parenthesis);
			exp.Value = string.Empty;
			this.Append(exp);
			return exp;
		}

		#endregion

		#region Expressions

		public IWhereList EqualValue(string Column, string Value)
		{
			//Column = SqlBuilder.FormatColumn(Column, this.Parameters);
			IWhere exp = CreateExpression(Enums.WhereType.Equal, Column, '=' + Value);
			return this;
		}

		public IWhereList Equal(params string[] Columns)
		{
			foreach (string expression in Columns)
				this.EqualValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList NotEqualValue(string Column, string Value)
		{
			//Column = SqlBuilder.FormatColumn(Column, this.Parameters);
			IWhere exp = CreateExpression(Enums.WhereType.NotEqual, Column, "!=" + Value);
			return this;
		}

		public IWhereList NotEqual(params string[] Columns)
		{
			foreach (string expression in Columns)
				this.NotEqualValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList EqualLessValue(string Column, string Value)
		{
			//Column = SqlBuilder.FormatColumn(Column, this.Parameters);
			IWhere exp = CreateExpression(Enums.WhereType.EqualLess, Column, "<=" + Value);
			return this;
		}

		public IWhereList EqualLess(params string[] Columns)
		{
			foreach(string expression in Columns)
				this.EqualLessValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList EqualGreaterValue(string Column, string Value)
		{
			//Column = SqlBuilder.FormatColumn(Column, this.Parameters);
			CreateExpression(Enums.WhereType.EqualGreater, Column, ">=" + Value);
			return this;
		}

		public IWhereList EqualGreater(params string[] Columns)
		{
			foreach (string expression in Columns)
				this.EqualGreaterValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList LessValue(string Column, string Value)
		{
			//Column = SqlBuilder.FormatColumn(Column, this.Parameters);
			CreateExpression(Enums.WhereType.Less, Column, "<" + Value);
			return this;
		}

		public IWhereList Less(params string[] Columns)
		{
			foreach (string expression in Columns)
				this.LessValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList GreaterValue(string Column, string Value)
		{
			//Column = SqlBuilder.FormatColumn(Column, this.Parameters);
			CreateExpression(Enums.WhereType.Less, Column, ">" + Value);
			return this;
		}

		public IWhereList Greater(params string[] Columns)
		{
			foreach (string expression in Columns)
				this.GreaterValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList IsNULL(params string[] Columns)
		{
			foreach (string expression in Columns)
			{
				CreateExpression(Enums.WhereType.IsNULL, expression, " IS NULL");
			}
			return this;
		}

		public IWhereList IsNotNULL(params string[] Columns)
		{
			foreach (string expression in Columns)
			{
				CreateExpression(Enums.WhereType.IsNotNULL, expression, " IS NOT NULL");
			}
			return this;
		}

		public IWhereList Between(string Name, string Begin, string End)
		{
			string value = " BETWEEN " + this.Parameters.Parameter + Begin + " AND " + this.Parameters.Parameter + End;
			CreateExpression(Enums.WhereType.Between, Name, value);
			return this;
		}

		public IWhereList NotBetween(string Name, string Begin, string End)
		{
			string value = " NOT BETWEEN " + this.Parameters.Parameter + Begin + " AND " + this.Parameters.Parameter + End;
			CreateExpression(Enums.WhereType.NotBetween, Name, value);
			return this;
		}

		public IWhereList Like(string Name, string Pattern)
		{
			string value = this.Parameters.Parameter + Name + " LIKE " + Pattern;
			CreateExpression(Enums.WhereType.Like, "", value);
			return this;
		}

		public IWhereList NotLike(string Name, string Pattern)
		{
			string value = this.Parameters.Parameter + Name + " NOT LIKE " + Pattern;
			CreateExpression(Enums.WhereType.NotLike, "", value);
			return this;
		}

		#endregion

		#region Parenthesis

		public IWhereList OpenParenthesis(int count = 1)
		{
			for (int i = 0; i < count; i++)
			{
				this.CreateParenthesis(Enums.Parenthesis.OpenParenthesis);
				this.HasOpenedParenthesis = true;
				this.Level++;
			}
			return this;
		}

		public IWhereList CloseParenthesis(int count = 1)
		{
			for (int i = 0; i < count; i++)
			{
				if (this.Level == 0)
					throw new Exceptions.ParenthesisExpectedException();

				this.CreateParenthesis(Enums.Parenthesis.CloseParenthesis);
				this.Level--;
				this.HasOpenedParenthesis = this.Level > 0;
			}
			return this;
		}

		#endregion

		#region Render SQL

		public string GetSql(bool where = false, string tableAlias = "")
		{
			StringBuilder sb = new StringBuilder();
			if (where && this._expressions.Count > 0)
				sb.Append("WHERE ");

			if (!string.IsNullOrEmpty(tableAlias))
				tableAlias = SqlBuilder.FormatAlias(tableAlias) + '.';

			bool logic = false, lastparenthesis = false;
			foreach(IWhere expression in this._expressions)
			{
				if (logic && !lastparenthesis && expression.Parenthesis != Enums.Parenthesis.CloseParenthesis)
				{
					sb.Append(' ');
					sb.Append(GetSqlCurrentLogic(expression.Logic));
					sb.Append(' ');
				}
				else
					logic = true;

				if (expression.Parenthesis == Enums.Parenthesis.OpenParenthesis)
				{
					sb.Append('(');
					lastparenthesis = true;
				}
				else if (expression.Parenthesis == Enums.Parenthesis.CloseParenthesis)
				{
					sb.Append(')');
					lastparenthesis = false;
				}
				else
				{
					if (expression.IsColumn)
						sb.Append(SqlBuilder.FormatColumn(expression.Column, tableAlias));

					sb.Append(expression.Value);
					lastparenthesis = false;
				}
			}

			return sb.ToString();
		}

		private string GetSqlCurrentLogic(Enums.WhereLogic logic)
		{
			switch (logic)
			{
				case Enums.WhereLogic.NOT:
					return "AND NOT";
				case Enums.WhereLogic.OR:
					return "OR";
				default:
				case Enums.WhereLogic.AND:
					return "AND";
			}
		}

		#endregion

		public override string ToString()
		{
			return this.GetSql();
		}

	}

}
