namespace SqlBuilder
{

	public class Parameters :IParameters
	{
		public char Parameter { get; set; }
		public SqlType Type { get; set; } = SqlType.Unknown;
		public SqlFormat ColumnFormat { get; set; } = SqlFormat.None;
		public SqlFormat ColumnTable { get; set; } = SqlFormat.None;
		public char ColumnEscapeLeft { get; set; }
		public char ColumnEscapeRight { get; set; }
		public char TableEscapeLeft { get; set; }
		public char TableEscapeRight { get; set; }
		public char EndOfStatement { get; set; }
	}

}