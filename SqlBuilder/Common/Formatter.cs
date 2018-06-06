using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class Formatter : IFormatter
	{

		public Enums.SqlType Type { get; set; } = Enums.SqlType.Unknown;

		public char Parameter { get; set; }

		public bool EscapeEnabled { get; set; }

		public char ColumnEscapeLeft { get; set; }

		public char ColumnEscapeRight { get; set; }

		public char TableEscapeLeft { get; set; }

		public char TableEscapeRight { get; set; }

		public char EndOfStatement { get; set; }

		public char AliasEscape { get; set; }

	}

}