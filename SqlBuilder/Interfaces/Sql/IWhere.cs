using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{
	public interface IWhere
	{

		Enums.WhereLogic Logic { get; }

		Enums.WhereType Type { get; }

		Enums.Parenthesis Parenthesis { get; }

		string Value { get; set; }

	}

}