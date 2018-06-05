using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public static class FormatterLibrary
	{

		/// <summary>
		/// MySql configuration defaults
		/// </summary>
		public static IFormatter MySql
		{
			get
			{
				return new Formatter()
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
				};
			}
		}

		/// <summary>
		/// MsSql configuration defaults
		/// </summary>
		public static IFormatter MsSql
		{
			get
			{
				return new Formatter()
				{
					Type = Enums.SqlType.MsSql,
					EscapeEnabled = true,
					TableEscapeLeft = '[',
					TableEscapeRight = ']',
					ColumnEscapeLeft = '[',
					ColumnEscapeRight = ']',
					Parameter = '@',
					EndOfStatement = ';',
					AliasEscape = '\''
				};
			}
		}

	}

}
