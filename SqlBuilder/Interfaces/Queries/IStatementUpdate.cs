using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IStatementUpdate : IStatement, IStatementTableAlias
	{

		ISetList Sets { get; set; }

		IWhereList Where { get; set; }

	}

}