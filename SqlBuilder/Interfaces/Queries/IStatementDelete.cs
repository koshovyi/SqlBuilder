using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IStatementDelete : IStatement, IStatementTableAlias
	{

		IWhereList Where { get; set; }

	}

}