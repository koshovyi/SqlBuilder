using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IWhereList
	{

		IParameters Parameters { get; }

		IEnumerable<IWhere> Expressions { get; }

		string GetSql(bool Where = false);

		int Count { get; }

		void Clear();

		void Append(IWhere Expression);

		//Flags
		Enums.WhereLogic LogicOperator { get; }

		//Parenthesis
		int Level { get; }

		bool HasOpenedParenthesis { get; }

		IWhereList OpenParenthesis();

		IWhereList CloseParenthesis();

		//Logic
		IWhereList And();

		IWhereList Or();

		IWhereList Not();

		//Exp eq
		IWhereList Equal(params string[] Columns);

		IWhereList EqualParam(string Column, string Value);

		IWhereList NotEqual(params string[] Columns);

		IWhereList NotEqualParam(string Column, string Value);

		//Exp less/greater
		IWhereList EqualGreater(params string[] Columns);

		IWhereList EqualGreaterParam(string Column, string Value);

		IWhereList EqualLess(params string[] Columns);

		IWhereList EqualLessParam(string Column, string Value);

		IWhereList Greater(params string[] Columns);

		IWhereList GreaterParam(string Column, string Value);

		IWhereList Less(params string[] Columns);

		IWhereList LessParam(string Column, string Value);

		//Exp null
		IWhereList IsNULL(params string[] Columns);

		IWhereList IsNotNULL(params string[] Columns);

		//Exp between/like
		IWhereList Between(string Name, string Begin, string End);

		IWhereList NotBetween(string Name, string Begin, string End);

		IWhereList Like(string Name, string Pattern);

		IWhereList NotLike(string Name, string Pattern);

	}

}