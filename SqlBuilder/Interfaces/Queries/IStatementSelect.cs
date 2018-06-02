using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IStatementSelect : IStatement
	{

		string TableAlias { get; set; }

		IColumnsListAggregation Columns { get; set; }

		IWhereList Where { get; set; }

		IGroupByList GroupBy { get; set; }

		IOrderByList OrderBy { get; set; }

	}

}