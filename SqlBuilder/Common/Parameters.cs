namespace SqlBuilder
{

	public class Parameters : IParameters
	{

		public Enums.SqlVersion Type { get; set; } = Enums.SqlVersion.Unknown;
		public Enums.SqlFormat ColumnFormat { get; set; } = Enums.SqlFormat.None;
		public Enums.SqlFormat ColumnTable { get; set; } = Enums.SqlFormat.None;

		public char Parameter { get; set; }
		public char ColumnEscapeLeft { get; set; }
		public char ColumnEscapeRight { get; set; }
		public char TableEscapeLeft { get; set; }
		public char TableEscapeRight { get; set; }
		public char EndOfStatement { get; set; }
		public char AliasEscape { get; set; }

	}

}