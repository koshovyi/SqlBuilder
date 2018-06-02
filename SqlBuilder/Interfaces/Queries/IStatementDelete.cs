using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IStatementDelete : IStatement
	{

		IWhereList Where { get; set; }

	}

}