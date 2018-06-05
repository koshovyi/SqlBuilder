using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface ISetList
	{

		IFormatter Parameters { get; }

		string GetSql();

		int Count { get; }

		void Clear();

		ISetList Append(ISet expression);

		ISetList Append(params string[] values);

		ISetList Append(string name, string value);

	}

}