namespace SqlBuilder
{

	public class Format
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

		public string AliasOperator { get; set; }

		/// <summary>
		/// MySQL configuration
		/// </summary>
		public static Format MySQL
		{
			get
			{
				return new Format()
				{
					Type = Enums.SqlType.MySql,
					EscapeEnabled = true,
					TableEscapeLeft = '`',
					TableEscapeRight = '`',
					ColumnEscapeLeft = '`',
					ColumnEscapeRight = '`',
					Parameter = '?',
					EndOfStatement = ';',
					AliasEscape = '\"',
					AliasOperator = " as ",
				};
			}
		}

		/// <summary>
		/// Microsoft SQL Server configuration
		/// </summary>
		public static Format MsSQL
		{
			get
			{
				return new Format()
				{
					Type = Enums.SqlType.MsSql,
					EscapeEnabled = true,
					TableEscapeLeft = '[',
					TableEscapeRight = ']',
					ColumnEscapeLeft = '[',
					ColumnEscapeRight = ']',
					Parameter = '@',
					EndOfStatement = ';',
					AliasEscape = '\'',
					AliasOperator = " as ",
				};
			}
		}

		/// <summary>
		/// PostgreSQL configuration
		/// </summary>
		public static Format PostgreSQL
		{
			get
			{
				return new Format()
				{
					Type = Enums.SqlType.PostgreSql,
					EscapeEnabled = false,
					TableEscapeLeft = '\0',
					TableEscapeRight = '\0',
					ColumnEscapeLeft = '\0',
					ColumnEscapeRight = '\0',
					Parameter = '@',
					EndOfStatement = ';',
					AliasEscape = '\0',
					AliasOperator = " as ",
				};
			}
		}

	}

}
