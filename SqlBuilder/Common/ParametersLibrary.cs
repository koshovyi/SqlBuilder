using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class ParametersLibrary
	{

		/// <summary>
		/// MySql configuration defaults
		/// </summary>
		public static IParameters MySql
		{
			get
			{
				return new Parameters()
				{
					Type = Enums.SqlVersion.MySql,
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
		public static IParameters MsSql
		{
			get
			{
				return new Parameters()
				{
					Type = Enums.SqlVersion.MsSql,
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
