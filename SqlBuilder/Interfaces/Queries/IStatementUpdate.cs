using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IStatementUpdate : IStatement
	{

		IColumnsListSimple Columns { get; set; }

		IWhereList Where { get; set; }

	}

}