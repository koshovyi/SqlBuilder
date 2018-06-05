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

		string GetSql(bool GroupBy = false, string aliasTable = "");

		int Count { get; }

		void Clear();

		IGroupByList Append(IGroupBy expression, bool copyToColumns = false);

		IGroupByList Append(bool copyToColumns = false, params string[] columns);

		IGroupByList AppendWithColumn(IGroupBy expression, string Column, string ColumnAlias, string Prefix = "", string Postfix = "");

	}

}