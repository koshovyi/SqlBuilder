using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IStatement
	{

		IFormatter Formatter { get; set; }

		string GetSql();

	}

}