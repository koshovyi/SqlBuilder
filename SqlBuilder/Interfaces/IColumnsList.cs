using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IColumnsList
	{

		IParameters Parameters { get; }

		IEnumerable<IColumn> Expressions { get; }

		string GetSql(string aliasTable = "");

		int Count { get; }

		void Clear();

		IColumnsList Append(IColumn expression);

		IColumnsList Append(params string[] names);

		IColumnsList AppendAlias(string name, string alias, string prefix = "", string postfix = "");

	}

	public interface IColumnsAggregationList : IColumnsList, IAggregateFunctions
	{

		new IColumnsAggregationList Append(IColumn expression);

		new IColumnsAggregationList Append(params string[] names);

		new IColumnsAggregationList AppendAlias(string name, string alias, string prefix = "", string postfix = "");

	}

}