using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{
	public interface IColumnsList
	{
		IParameters Parameters { get; set; }
		IEnumerable<IColumn> Expressions { get; }
		string GetSql();

		int Count { get; }
		void Clear();
		IColumnsList Append(IColumn Expression);
		IColumnsList Append(string Name);
		IColumnsList Append(params string[] Names);
		IColumnsList AppendAlias(string Name, string Alias);

		//IColumns FuncMax(string Name);
		//IColumns FuncMax(string Name, string Alias);
		//IColumns FuncMin(string Name);
		//IColumns FuncMin(string Name, string Alias);
		//IColumns FuncCount(string Name);
		//IColumns FuncCount(string Name, string Alias);
		//IColumns FuncCountAll(string Name);
		//IColumns FuncCountAll(string Name, string Alias);
		//IColumns FuncSum(string Name);
		//IColumns FuncSum(string Name, string Alias);

	}

}