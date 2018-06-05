using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IColumnsList
	{

		IFormatter Parameters { get; }

		IEnumerable<IColumn> Expressions { get; }

		string GetSql(string tableAlias = "");

		int Count { get; }

		void Clear();

	}

	public interface IColumnsList<out T> where T: IColumnsList
	{
		T Append(IColumn expression);

		T Append(params string[] names);

		T AppendAlias(string name, string alias, string prefix = "", string postfix = "");
	}

	public interface IColumnsListSimple : IColumnsList, IColumnsList<IColumnsListSimple>
	{
	}

	public interface IColumnsListAggregation : IColumnsList, IColumnsList<IColumnsListAggregation>, IAggregateFunctions<IColumnsListAggregation>
	{
	}

}