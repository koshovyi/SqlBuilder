using System;
using System.Collections.Generic;
using System.Text;

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