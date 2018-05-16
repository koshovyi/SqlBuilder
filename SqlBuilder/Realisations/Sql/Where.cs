using SqlBuilder.Interfaces;

namespace SqlBuilder
{
	public class Where : IWhere
	{

		public Enums.WhereExpressionType Type { get; private set; }

		public Enums.WhereExpressionLogic Logic { get; private set; }

		public Enums.StatementParenthesis Parenthesis { get; private set; }

		public string Value { get; set; }

		public Where(Enums.WhereExpressionType Type, Enums.WhereExpressionLogic Logic, Enums.StatementParenthesis Parenthesis = Enums.StatementParenthesis.Unknown)
		{
			this.Type = Type;
			this.Logic = Logic;
			this.Parenthesis = Enums.StatementParenthesis.Unknown;
		}

	}
}