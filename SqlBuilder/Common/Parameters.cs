namespace SqlBuilder
{

	public class Parameters :IParameters
	{
		public char Parameter { get; set; }
		public Enums.SqlVersion Type { get; set; } = Enums.SqlVersion.Unknown;
		public Enums.SqlFormat ColumnFormat { get; set; } = Enums.SqlFormat.None;
		public Enums.SqlFormat ColumnTable { get; set; } = Enums.SqlFormat.None;
		public char ColumnEscapeLeft { get; set; }
		public char ColumnEscapeRight { get; set; }
		public char TableEscapeLeft { get; set; }
		public char TableEscapeRight { get; set; }
		public char EndOfStatement { get; set; }
	}

}