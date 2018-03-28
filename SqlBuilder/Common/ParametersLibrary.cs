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
					Type = Enums.SqlType.MySql,
					TableEscapeLeft = '`',
					TableEscapeRight = '`',
					ColumnEscapeLeft = '`',
					ColumnEscapeRight = '`',
					Parameter = '?',
					EndOfStatement = ';'
				};
			}
		}

		public static Parameters MsSql
		{
			get
			{
				return new Parameters()
				{
					Type = Enums.SqlType.MsSql,
					TableEscapeLeft = '[',
					TableEscapeRight = ']',
					ColumnEscapeLeft = '[',
					ColumnEscapeRight = ']',
					Parameter = '@',
					EndOfStatement = ';'
				};
			}
		}

	}

}
