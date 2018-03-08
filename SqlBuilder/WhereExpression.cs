using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder
{
	public class WhereExpression : IWhereExpression
	{
		public WhereExpressionType Type { get; private set; }
		public WhereExpressionLogic Logic { get; private set; }
		public StatementParenthesis Parenthesis { get; private set; }
		public string Value { get; set; }

		public WhereExpression(WhereExpressionType Type, WhereExpressionLogic Logic, StatementParenthesis Parenthesis = StatementParenthesis.Unknown)
		{
			this.Type = Type;
			this.Logic = Logic;
			this.Parenthesis = StatementParenthesis.Unknown;
		}

	}
}
