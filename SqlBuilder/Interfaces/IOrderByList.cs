using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{
	public interface IOrderByList
	{
		IParameters Parameters { get; set; }
		IEnumerable<IOrderBy> Expressions { get; }
		string GetSql(bool OrderBy = false);

		int Count { get; }
		void Clear();
		void Append(IOrderBy Expression);

		IOrderByList Ascending(params string[] Columns);
		IOrderByList Descending(params string[] Columns);
	}

}
