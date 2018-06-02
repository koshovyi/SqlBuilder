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

	}

	public interface IColumnsListSimple : IColumnsList
	{
		IColumnsListSimple Append(IColumn expression);

		IColumnsListSimple Append(params string[] names);

		IColumnsListSimple AppendAlias(string name, string alias, string prefix = "", string postfix = "");
	}

	public interface IColumnsListAggregation : IColumnsList, IAggregateFunctions
	{
		IColumnsListAggregation Append(IColumn expression);

		IColumnsListAggregation Append(params string[] names);

		IColumnsListAggregation AppendAlias(string name, string alias, string prefix = "", string postfix = "");
	}

}