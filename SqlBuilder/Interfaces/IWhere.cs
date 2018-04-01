using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{
	public interface IWhere
	{

		Enums.WhereExpressionLogic Logic { get; }
		Enums.WhereExpressionType Type { get; }
		Enums.StatementParenthesis Parenthesis { get; }
		string Value { get; set; }

	}

}