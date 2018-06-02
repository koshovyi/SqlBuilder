using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IAggregateFunctions
	{

		void FuncMax(string Name, string Alias = "");
		void FuncMin(string Name, string Alias = "");
		void FuncCount(string Name, string Alias = "");
		void FuncSum(string Name, string Alias = "");

	}

}