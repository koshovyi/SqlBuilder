using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class Value : IValue
	{

		public string Expression { get; set; }

		public Value(string expression)
		{
			this.Expression = expression;
		}

	}

}