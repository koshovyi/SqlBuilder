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
				return this._expressions;
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

		private void CreateExpression(Enums.WhereType type, string column, string value, string prefix = "", string postfix = "")
		{
			IWhere exp = new Where(type, this.LogicOperator);
			exp.Column = column;
			exp.IsColumn = true;
			exp.Value = value;
			exp.Prefix = prefix;
			exp.Postfix = postfix;
			this.Append(exp);
		}

		private void CreateParenthesis(Enums.Parenthesis parenthesis, string value = "")
		{
			IWhere exp = new Where(Enums.WhereType.None, this.LogicOperator, parenthesis);
			exp.Value = value;
			this.Append(exp);
		}

		#endregion

		#region Expressions

		public IWhereList Raw(string rawSql)
		{
			IWhere exp = new Where(Enums.WhereType.Raw, this.LogicOperator);
			exp.IsColumn = false;
			exp.Value = rawSql;
			this.Append(exp);
			return this;
		}

		public IWhereList EqualValue(string column, string value)
		{
			CreateExpression(Enums.WhereType.Equal, column, '=' + value);
			return this;
		}

		public IWhereList Equal(params string[] columns)
		{
			foreach (string expression in columns)
				this.EqualValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList NotEqualValue(string column, string value)
		{
			CreateExpression(Enums.WhereType.NotEqual, column, "!=" + value);
			return this;
		}

		public IWhereList NotEqual(params string[] columns)
		{
			foreach (string expression in columns)
				this.NotEqualValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList EqualLessValue(string column, string value)
		{
			CreateExpression(Enums.WhereType.EqualLess, column, "<=" + value);
			return this;
		}

		public IWhereList EqualLess(params string[] columns)
		{
			foreach(string expression in columns)
				this.EqualLessValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList EqualGreaterValue(string column, string value)
		{
			CreateExpression(Enums.WhereType.EqualGreater, column, ">=" + value);
			return this;
		}

		public IWhereList EqualGreater(params string[] columns)
		{
			foreach (string expression in columns)
				this.EqualGreaterValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList LessValue(string column, string value)
		{
			CreateExpression(Enums.WhereType.Less, column, "<" + value);
			return this;
		}

		public IWhereList Less(params string[] columns)
		{
			foreach (string expression in columns)
				this.LessValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList GreaterValue(string column, string value)
		{
			CreateExpression(Enums.WhereType.Less, column, ">" + value);
			return this;
		}

		public IWhereList Greater(params string[] columns)
		{
			foreach (string expression in columns)
				this.GreaterValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList IsNULL(params string[] columns)
		{
			foreach (string expression in columns)
			{
				CreateExpression(Enums.WhereType.IsNULL, expression, " IS NULL");
			}
			return this;
		}

		public IWhereList IsNotNULL(params string[] columns)
		{
			foreach (string expression in columns)
			{
				CreateExpression(Enums.WhereType.IsNotNULL, expression, " IS NOT NULL");
			}
			return this;
		}

		public IWhereList Between(string name, string begin, string end)
		{
			string value = " BETWEEN " + this.Parameters.Parameter + begin + " AND " + this.Parameters.Parameter + end;
			CreateExpression(Enums.WhereType.Between, name, value);
			return this;
		}

		public IWhereList NotBetween(string name, string begin, string end)
		{
			string value = " NOT BETWEEN " + this.Parameters.Parameter + begin + " AND " + this.Parameters.Parameter + end;
			CreateExpression(Enums.WhereType.NotBetween, name, value);
			return this;
		}

		public IWhereList Like(string name, string pattern)
		{
			string value = this.Parameters.Parameter + name + " LIKE " + pattern;
			CreateExpression(Enums.WhereType.Like, "", value);
			return this;
		}

		public IWhereList NotLike(string name, string pattern)
		{
			string value = this.Parameters.Parameter + name + " NOT LIKE " + pattern;
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

		public IWhereList RawParenthesis(string rawSql)
		{
			this.OpenParenthesis();
			this.Raw(rawSql);
			this.CloseParenthesis();
			return this;
		}

		#endregion

		#region Render SQL

		public string GetSql(string tableAlias = "")
		{
			StringBuilder sb = new StringBuilder();

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
