using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IGroupByList : IAggregateFunctions<IGroupByList>
	{

		IFormatter Parameters { get; }

		IColumnsListAggregation Columns { get; }

		IEnumerable<IGroupBy> Expressions { get; }

		string GetSql(string tableAlias = "");

		int Count { get; }

		void Clear();

		IGroupByList Append(IGroupBy expression, bool copyToColumns = false);

		IGroupByList Append(bool copyToColumns = false, params string[] columns);

		IGroupByList AppendWithColumn(IGroupBy expression, string column, string columnAlias, string prefix = "", string postfix = "");

	}

}