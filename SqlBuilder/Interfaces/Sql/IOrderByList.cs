using System.Collections.Generic;

namespace SqlBuilder.Interfaces
{

	public interface IOrderByList
	{

		IFormatter Parameters { get; }

		IEnumerable<IOrderBy> Expressions { get; }

		string GetSql(string tableAlias = "");

		int Count { get; }

		void Clear();

		void Append(IOrderBy expression);

		IOrderByList Ascending(params string[] columns);

		IOrderByList Descending(params string[] columns);

	}

}