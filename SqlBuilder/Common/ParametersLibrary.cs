using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder
{

	public class ParametersLibrary
	{

		public static Parameters MySQL
		{
			get
			{
				return new Parameters()
				{
					Type = SqlType.MySql,
					TableEscapeLeft = '`',
					TableEscapeRight = '`',
					ColumnEscapeLeft = '`',
					ColumnEscapeRight = '`',
					Parameter = '?',
				};
			}
		}

		public static Parameters MsSQL
		{
			get
			{
				return new Parameters()
				{
					Type = SqlType.MsSql,
					TableEscapeLeft = '[',
					TableEscapeRight = ']',
					ColumnEscapeLeft = '[',
					ColumnEscapeRight = ']',
					Parameter = '@',
				};
			}
		}

	}

}
