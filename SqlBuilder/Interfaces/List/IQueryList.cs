using System.Collections.Generic;

namespace SqlBuilder.Interfaces
{

	public interface IQueryList
	{

		IEnumerable<IStatement> Queries { get; }

		int Count { get; }

		void Clear();

		IQueryList Append(params IStatement[] queries);

		string GetSql();

	}

}