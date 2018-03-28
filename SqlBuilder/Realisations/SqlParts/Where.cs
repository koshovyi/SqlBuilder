using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{
	public class Where : IWhereList
	{

		private List<IWhere> _expressions;

		public IParameters Parameters { get; set; }
		public Enums.WhereExpressionLogic LogicOperator { get; private set; } = Enums.WhereExpressionLogic.AND;
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

		public Where()
		{
			this._expressions = new List<IWhere>();
			this.Parameters = ParametersLibrary.MsSql;
		}

		#endregion

		#region Logic operators

		public IWhereList And()
		{
			this.LogicOperator = Enums.WhereExpressionLogic.AND;
			return this;
		}

		public IWhereList Or()
		{
			this.LogicOperator = Enums.WhereExpressionLogic.OR;
			return this;
		}

		public IWhereList Not()
		{
			this.LogicOperator = Enums.WhereExpressionLogic.NOT;
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

		private IWhere CreateExpression(Enums.WhereExpressionType Type, string Value)
		{
			IWhere exp = new WhereExpression(Type, this.LogicOperator);
			exp.Value = Value;
			this.Append(exp);
			return exp;
		}

		private IWhere CreateParenthesis(Enums.StatementParenthesis Parenthesis)
		{
			IWhere exp = new WhereExpression(Enums.WhereExpressionType.Unknown, Enums.WhereExpressionLogic.Unknown, Parenthesis);
			exp.Value = string.Empty;
			this.Append(exp);
			return exp;
		}

		#endregion

		#region Expressions

		public IWhereList EqualParam(string Column, string Value)
		{
			IWhere exp = CreateExpression(Enums.WhereExpressionType.Equal, Column + '=' + Value);
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
			IWhere exp = CreateExpression(Enums.WhereExpressionType.NotEqual, Column + "!=" + Value);
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
			IWhere exp = CreateExpression(Enums.WhereExpressionType.EqualLess, Column + "<=" + Value);
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
			CreateExpression(Enums.WhereExpressionType.EqualGreater, Column + ">=" + Value);
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
			CreateExpression(Enums.WhereExpressionType.Less, Column + "<" + Value);
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
			CreateExpression(Enums.WhereExpressionType.Less, Column + ">" + Value);
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
				string value = this.Parameters.Parameter + expression + " IS NULL";
				CreateExpression(Enums.WhereExpressionType.IsNULL, value);
			}
			return this;
		}

		public IWhereList IsNotNULL(params string[] Columns)
		{
			foreach (string expression in Columns)
			{
				string value = this.Parameters.Parameter + expression + " IS NOT NULL";
				CreateExpression(Enums.WhereExpressionType.IsNotNULL, value);
			}
			return this;
		}

		public IWhereList Between(string Name, string Begin, string End)
		{
			string value = Name + " BETWEEN " + this.Parameters.Parameter + Begin + " AND " + this.Parameters.Parameter + End;
			CreateExpression(Enums.WhereExpressionType.Between, value);
			return this;
		}

		public IWhereList NotBetween(string Name, string Begin, string End)
		{
			string value = Name + " NOT BETWEEN " + this.Parameters.Parameter + Begin + " AND " + this.Parameters.Parameter + End;
			CreateExpression(Enums.WhereExpressionType.NotBetween, value);
			return this;
		}

		public IWhereList Like(string Name, string Pattern)
		{
			string value = this.Parameters.Parameter + Name + " LIKE " + Pattern;
			CreateExpression(Enums.WhereExpressionType.Like, value);
			return this;
		}

		public IWhereList NotLike(string Name, string Pattern)
		{
			string value = this.Parameters.Parameter + Name + " NOT LIKE " + Pattern;
			CreateExpression(Enums.WhereExpressionType.Like, value);
			return this;
		}

		#endregion

		#region Parenthesis

		public IWhereList OpenParenthesis()
		{
			this.CreateParenthesis(Enums.StatementParenthesis.OpenParenthesis);
			this.HasOpenedParenthesis = true;
			this.Level++;
			return this;
		}

		public IWhereList CloseParenthesis()
		{
			if (this.Level > 0)
			{
				this.CreateParenthesis(Enums.StatementParenthesis.CloseParenthesis);
				this.Level--;
				this.HasOpenedParenthesis = this.Level > 0;
			}
			else
				throw new Exception("Close Parenthesis");
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
				if (expression.Parenthesis == Enums.StatementParenthesis.OpenParenthesis)
					sb.Append('(');
				else if (expression.Parenthesis == Enums.StatementParenthesis.CloseParenthesis)
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
				case Enums.WhereExpressionLogic.NOT:
					return "NOT";
				case Enums.WhereExpressionLogic.OR:
					return "OR";
				default:
				case Enums.WhereExpressionLogic.AND:
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
