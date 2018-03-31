using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IGroup
	{
		IParameters Parameters { get; set; }
		IColumnsList Columns { get; }
		IEnumerable<IColumn> Expressions { get; }
		string GetSql();

		void Clear();
		IGroup Append(IColumn Expression);
		IGroup Append(string Name);
		IGroup Append(params string[] Names);
		IGroup AppendAlias(string Name, string Alias);

		//IColumns FuncMax(string Name);
		//IColumns FuncMax(string Name, string Alias);
		//IColumns FuncMin(string Name);
		//IColumns FuncMin(string Name, string Alias);
		//IColumns FuncCount(string Name);
		//IColumns FuncCount(string Name, string Alias);
		//IColumns FuncSum(string Name);
		//IColumns FuncSum(string Name, string Alias);

	}

}