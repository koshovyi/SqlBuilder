using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder
{

	public class ParametersLibrary
	{

		public static Parameters MySql
		{
			get
			{
				return new Parameters()
				{
					Type = Enums.SqlVersion.MySql,
					TableEscapeLeft = '`',
					TableEscapeRight = '`',
					ColumnEscapeLeft = '`',
					ColumnEscapeRight = '`',
					Parameter = '?',
					EndOfStatement = ';',
					AliasEscape = '\"'
				};
			}
		}

		public static Parameters MsSql
		{
			get
			{
				return new Parameters()
				{
					Type = Enums.SqlVersion.MsSql,
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
