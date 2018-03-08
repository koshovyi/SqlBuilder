using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder
{

	public interface IParameters
	{
		SqlType Type { get; set; }
		SqlFormat ColumnFormat { get; set; }
		SqlFormat ColumnTable { get; set; }
		char Parameter { get; set; }
		char ColumnEscapeLeft { get; set; }
		char ColumnEscapeRight { get; set; }
		char TableEscapeLeft { get; set; }
		char TableEscapeRight { get; set; }
		char EndOfStatement { get; set; }
	}

}