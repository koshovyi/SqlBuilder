using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IAggregateFunctions<T>
	{

		T FuncMax(string Name, string Alias = "");
		T FuncMin(string Name, string Alias = "");
		T FuncCount(string Name, string Alias = "");
		T FuncSum(string Name, string Alias = "");

	}

}