using SqlBuilder.Sql;
using System.Collections.Generic;

namespace SqlBuilder.Interfaces
{

	public interface IColumnsList
	{

		Format Parameters { get; }

		IEnumerable<Column> Expressions { get; }

		string GetSql(string tableAlias = "");

		int Count { get; }

		void Clear();

	}

	public interface IColumnsList<out T> where T: IColumnsList
	{
		T Append(Column expression);

		T Append(params string[] columns);

		T AppendAlias(string name, string alias, string prefix = "", string postfix = "");

		T Raw(string rawSql, string alias = "");

		T Raw(params string[] rawSql);

		T SubQuery(IStatementSelect select, string alias = "");
	}

	public interface IColumnsListSimple : IColumnsList, IColumnsList<IColumnsListSimple>
	{
	}

	public interface IColumnsListAggregation : IColumnsList, IColumnsList<IColumnsListAggregation>, IAggregateFunctions<IColumnsListAggregation>
	{
	}

}
