using SqlBuilder.Interfaces;

namespace SqlBuilder.Sql
{
	public class Where : IWhere
	{

		public Enums.WhereType Type { get; private set; }

		public Enums.WhereLogic Logic { get; private set; }

		public Enums.Parenthesis Parenthesis { get; private set; }

		public string Value { get; set; }

		public bool IsColumn { get; set; }
		public string Column { get; set; }

		public Where(Enums.WhereType Type, Enums.WhereLogic Logic, Enums.Parenthesis Parenthesis = Enums.Parenthesis.None)
		{
			this.Type = Type;
			this.Logic = Logic;
			this.Parenthesis = Parenthesis;
		}

	}
}