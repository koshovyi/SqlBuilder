using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IStatementInsert : IStatement
	{

		IColumnsListSimple Columns { get; set; }

		IValueList Values { get; set; }

		IStatementInsert AppendParameters(params string[] parameters);

	}

}