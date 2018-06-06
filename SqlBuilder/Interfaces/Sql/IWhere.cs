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

		string Prefix { get; set; }

		string Postfix { get; set; }

		bool IsColumn { get; set; }

		string Column { get; set; }

		string Value { get; set; }

	}

}