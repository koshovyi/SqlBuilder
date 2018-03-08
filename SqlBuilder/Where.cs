using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder
{
	public class Where : IWhere
	{

		private List<IWhereExpression> _expressions;

		public IParameters Parameters { get; set; }
		public WhereExpressionLogic LogicOperator { get; private set; } = WhereExpressionLogic.AND;
		public bool HasOpenedParenthesis { get; private set; }
		public int Level { get; private set; }
		public IEnumerable<IWhereExpression> Expressions
		{
			get { return this.Expressions; }
		}

		#region Construcor

		public Where()
		{
			this._expressions = new List<IWhereExpression>();
			this.Parameters = ParametersLibrary.MsSQL;
		}

		#endregion

		#region Logic operators

		public IWhere And()
		{
			this.LogicOperator = WhereExpressionLogic.AND;
			return this;
		}

		public IWhere Or()
		{
			this.LogicOperator = WhereExpressionLogic.OR;
			return this;
		}

		public IWhere Not()
		{
			this.LogicOperator = WhereExpressionLogic.NOT;
			return this;
		}

		#endregion

		#region Expressions List

		public void Append(IWhereExpression Expression)
		{
			this._expressions.Add(Expression);
		}

		public void Clear()
		{
			this._expressions.Clear();
		}

		private IWhereExpression CreateExpression(WhereExpressionType Type, string Value)
		{
			IWhereExpression exp = new WhereExpression(Type, this.LogicOperator);
			exp.Value = Value;
			this.Append(exp);
			return exp;
		}

		private IWhereExpression CreateParenthesis(StatementParenthesis Parenthesis)
		{
			IWhereExpression exp = new WhereExpression(WhereExpressionType.Unknown, WhereExpressionLogic.Unknown, Parenthesis);
			exp.Value = string.Empty;
			this.Append(exp);
			return exp;
		}

		#endregion

		#region Expressions

		public IWhere EqualParam(string Param, string Value)
		{
			IWhereExpression exp = CreateExpression(WhereExpressionType.Equal, Param + '=' + Value);
			return this;
		}

		public IWhere Equal(params string[] Expressions)
		{
			foreach (string expression in Expressions)
				this.EqualParam(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhere NotEqualParam(string Param, string Value)
		{
			IWhereExpression exp = CreateExpression(WhereExpressionType.NotEqual, Param + "!=" + Value);
			return this;
		}

		public IWhere NotEqual(params string[] Expressions)
		{
			foreach (string expression in Expressions)
				this.NotEqualParam(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhere EqualLess(string Param, string Value)
		{
			IWhereExpression exp = CreateExpression(WhereExpressionType.EqualLess, Param + "<=" + Value);
			return this;
		}

		public IWhere EqualLess(params string[] Expressions)
		{
			foreach(string expression in Expressions)
				EqualLess(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public IWhere EqualGreater(string Param, string Value)
		{
			CreateExpression(WhereExpressionType.EqualGreater, Param + ">=" + Value);
			return this;
		}

		public IWhere EqualGreater(params string[] Expressions)
		{
			foreach (string expression in Expressions)
				this.EqualGreater(expression, this.Parameters + expression);
			return this;
		}

		public IWhere Less(string Param, string Value)
		{
			CreateExpression(WhereExpressionType.Less, Param + "<" + Value);
			return this;
		}

		public IWhere Less(params string[] Expressions)
		{
			foreach (string expression in Expressions)
				this.Less(expression, this.Parameters + expression);
			return this;
		}

		public IWhere Greater(string Param, string Value)
		{
			CreateExpression(WhereExpressionType.Less, Param + ">" + Value);
			return this;
		}

		public IWhere Greater(params string[] Expressions)
		{
			foreach (string expression in Expressions)
				Greater(expression, expression);
			return this;
		}

		public IWhere Like(string Name, string Pattern)
		{
			string value = this.Parameters.Parameter + Name + " LIKE " + Pattern;
			CreateExpression(WhereExpressionType.Like, value);
			return this;
		}

		public IWhere NotLike(string Name, string Pattern)
		{
			string value = this.Parameters.Parameter + Name + " NOT LIKE " + Pattern;
			CreateExpression(WhereExpressionType.Like, value);
			return this;
		}

		public IWhere IsNULL(params string[] Expressions)
		{
			foreach (string expression in Expressions)
			{
				string value = this.Parameters.Parameter + expression + " IS NULL";
				CreateExpression(WhereExpressionType.IsNULL, value);
			}
			return this;
		}

		public IWhere IsNotNULL(params string[] Expressions)
		{
			foreach (string expression in Expressions)
			{
				string value = this.Parameters.Parameter + expression + " IS NOT NULL";
				CreateExpression(WhereExpressionType.IsNotNULL, value);
			}
			return this;
		}

		public IWhere Between(string Name, string Begin, string End)
		{
			string value = Name + " BETWEEN " + this.Parameters.Parameter + Begin + " AND " + this.Parameters.Parameter + End;
			CreateExpression(WhereExpressionType.Between, value);
			return this;
		}

		public IWhere NotBetween(string Name, string Begin, string End)
		{
			string value = Name + " NOT BETWEEN " + this.Parameters.Parameter + Begin + " AND " + this.Parameters.Parameter + End;
			CreateExpression(WhereExpressionType.NotBetween, value);
			return this;
		}

		#endregion

		#region Parenthesis

		public IWhere OpenParenthesis()
		{
			this.CreateParenthesis(StatementParenthesis.OpenParenthesis);
			this.HasOpenedParenthesis = true;
			this.Level++;
			return this;
		}

		public IWhere CloseParenthesis()
		{
			if (this.Level > 0)
			{
				this.CreateParenthesis(StatementParenthesis.CloseParenthesis);
				this.Level--;
				this.HasOpenedParenthesis = this.Level > 0;
			}
			else
				throw new Exception("Close Parenthesis");
			return this;
		}

		#endregion

		#region Render SQL

		public string GetSQL(bool Where = false)
		{
			StringBuilder sb = new StringBuilder();
			if (Where && this._expressions.Count > 0)
				sb.Append("WHERE");

			bool logic = false;
			foreach(IWhereExpression expression in this._expressions)
			{
				if (expression.Parenthesis == StatementParenthesis.OpenParenthesis)
					sb.Append('(');
				else if (expression.Parenthesis == StatementParenthesis.CloseParenthesis)
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
				case WhereExpressionLogic.AND:
					return "AND";
				case WhereExpressionLogic.NOT:
					return "NOT";
				case WhereExpressionLogic.OR:
					return "OR";
				default:
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
