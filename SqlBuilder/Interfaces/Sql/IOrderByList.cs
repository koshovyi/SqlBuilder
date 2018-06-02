using System.Collections.Generic;

namespace SqlBuilder.Interfaces
{

	public interface IOrderByList
	{

		IParameters Parameters { get; }
		IEnumerable<IOrderBy> Expressions { get; }
		string GetSql(bool OrderBy = false);

		int Count { get; }
		void Clear();
		void Append(IOrderBy Expression);

		IOrderByList Ascending(params string[] Columns);
		IOrderByList Descending(params string[] Columns);

	}

}