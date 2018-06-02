using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IStatement
	{

		IParameters Parameters { get; set; }

		string GetSql();

	}

}