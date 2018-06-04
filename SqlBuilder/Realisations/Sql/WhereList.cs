using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Sql
{
	public class WhereList : IWhereList
	{

		private readonly List<IWhere> _expressions;

		public IParameters Parameters { get; private set; }

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

		public WhereList(IParameters parameters)
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

		public void Append(IWhere Expression)
		{
			this._expressions.Add(Expression);
		}

		public void Clear()
		{
			this._expressions.Clear();
		}

		private IWhere CreateExpression(Enums.WhereType Type, string Value)
		{
			IWhere exp = new Where(Type, this.LogicOperator);
			exp.Value = Value;
			this.Append(exp);
			return exp;
		}

		private IWhere CreateParenthesis(Enums.Parenthesis Parenthesis)
		{
			IWhere exp = new Where(Enums.WhereType.Unknown, Enums.WhereLogic.Unknown, Parenthesis);
			exp.Value = string.Empty;
			this.Append(exp);
			return exp;
		}

		#endregion

		#region Expressions

		public IWhereList EqualParam(string Column, string Value)
		{
			Column = SqlBuilder.FormatColumn(Column, this.Parameters);
			IWhere exp = CreateExpression(Enums.WhereType.Equal, Column + '=' + Value);
			return this;
		}

		public IWhereList Equal(params string[] Columns)
		{
			foreach (string expression in Columns)
				this.EqualParam(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList NotEqualParam(string Column, string Value)
		{
			Column = SqlBuilder.FormatColumn(Column, this.Parameters);
			IWhere exp = CreateExpression(Enums.WhereType.NotEqual, Column + "!=" + Value);
			return this;
		}

		public IWhereList NotEqual(params string[] Columns)
		{
			foreach (string expression in Columns)
				this.NotEqualParam(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList EqualLessParam(string Column, string Value)
		{
			Column = SqlBuilder.FormatColumn(Column, this.Parameters);
			IWhere exp = CreateExpression(Enums.WhereType.EqualLess, Column + "<=" + Value);
			return this;
		}

		public IWhereList EqualLess(params string[] Columns)
		{
			foreach(string expression in Columns)
				this.EqualLessParam(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList EqualGreaterParam(string Column, string Value)
		{
			Column = SqlBuilder.FormatColumn(Column, this.Parameters);
			CreateExpression(Enums.WhereType.EqualGreater, Column + ">=" + Value);
			return this;
		}

		public IWhereList EqualGreater(params string[] Columns)
		{
			foreach (string expression in Columns)
				this.EqualGreaterParam(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList LessParam(string Column, string Value)
		{
			Column = SqlBuilder.FormatColumn(Column, this.Parameters);
			CreateExpression(Enums.WhereType.Less, Column + "<" + Value);
			return this;
		}

		public IWhereList Less(params string[] Columns)
		{
			foreach (string expression in Columns)
				this.LessParam(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList GreaterParam(string Column, string Value)
		{
			Column = SqlBuilder.FormatColumn(Column, this.Parameters);
			CreateExpression(Enums.WhereType.Less, Column + ">" + Value);
			return this;
		}

		public IWhereList Greater(params string[] Columns)
		{
			foreach (string expression in Columns)
				this.GreaterParam(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhereList IsNULL(params string[] Columns)
		{
			foreach (string expression in Columns)
			{
				string value = SqlBuilder.FormatColumn(expression, this.Parameters) + " IS NULL";
				CreateExpression(Enums.WhereType.IsNULL, value);
			}
			return this;
		}

		public IWhereList IsNotNULL(params string[] Columns)
		{
			foreach (string expression in Columns)
			{
				string value = SqlBuilder.FormatColumn(expression, this.Parameters) + " IS NOT NULL";
				CreateExpression(Enums.WhereType.IsNotNULL, value);
			}
			return this;
		}

		public IWhereList Between(string Name, string Begin, string End)
		{
			string value = Name + " BETWEEN " + this.Parameters.Parameter + Begin + " AND " + this.Parameters.Parameter + End;
			CreateExpression(Enums.WhereType.Between, value);
			return this;
		}

		public IWhereList NotBetween(string Name, string Begin, string End)
		{
			string value = Name + " NOT BETWEEN " + this.Parameters.Parameter + Begin + " AND " + this.Parameters.Parameter + End;
			CreateExpression(Enums.WhereType.NotBetween, value);
			return this;
		}

		public IWhereList Like(string Name, string Pattern)
		{
			string value = this.Parameters.Parameter + Name + " LIKE " + Pattern;
			CreateExpression(Enums.WhereType.Like, value);
			return this;
		}

		public IWhereList NotLike(string Name, string Pattern)
		{
			string value = this.Parameters.Parameter + Name + " NOT LIKE " + Pattern;
			CreateExpression(Enums.WhereType.Like, value);
			return this;
		}

		#endregion

		#region Parenthesis

		public IWhereList OpenParenthesis()
		{
			this.CreateParenthesis(Enums.Parenthesis.OpenParenthesis);
			this.HasOpenedParenthesis = true;
			this.Level++;
			return this;
		}

		public IWhereList CloseParenthesis()
		{
			if (this.Level == 0)
				throw new Exceptions.ParenthesisExpectedException();

			this.CreateParenthesis(Enums.Parenthesis.CloseParenthesis);
			this.Level--;
			this.HasOpenedParenthesis = this.Level > 0;

			return this;
		}

		#endregion

		#region Render SQL

		public string GetSql(bool Where = false)
		{
			StringBuilder sb = new StringBuilder();
			if (Where && this._expressions.Count > 0)
				sb.Append("WHERE ");

			bool logic = false;
			foreach(IWhere expression in this._expressions)
			{
				if (expression.Parenthesis == Enums.Parenthesis.OpenParenthesis)
					sb.Append('(');
				else if (expression.Parenthesis == Enums.Parenthesis.CloseParenthesis)
					sb.Append(')');
				else
				{
					if (logic)
						sb.Append(" " + GetSQLCurrentLogic() + " ");
					else
						logic = true;
					sb.Append(expression.Value);
				}
			}

			return sb.ToString();
		}

		public string GetSQLCurrentLogic()
		{
			switch (this.LogicOperator)
			{
				case Enums.WhereLogic.NOT:
					return "NOT";
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
			return base.ToString();
		}

	}

}
