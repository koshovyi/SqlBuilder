using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IWhereList
	{

		IFormatter Parameters { get; }

		IEnumerable<IWhere> Expressions { get; }

		string GetSql(bool where = false, string tableAlias = "");

		int Count { get; }

		void Clear();

		void Append(IWhere expression);

		//Flags
		Enums.WhereLogic LogicOperator { get; }

		//Parenthesis
		int Level { get; }

		bool HasOpenedParenthesis { get; }

		IWhereList OpenParenthesis(int count = 1);

		IWhereList CloseParenthesis(int count = 1);

		//Logic
		IWhereList And();

		IWhereList Or();

		IWhereList Not();

		//Exp eq
		IWhereList Equal(params string[] Columns);

		IWhereList EqualValue(string Column, string Value);

		IWhereList NotEqual(params string[] Columns);

		IWhereList NotEqualValue(string Column, string Value);

		//Exp less/greater
		IWhereList EqualGreater(params string[] Columns);

		IWhereList EqualGreaterValue(string Column, string Value);

		IWhereList EqualLess(params string[] Columns);

		IWhereList EqualLessValue(string Column, string Value);

		IWhereList Greater(params string[] Columns);

		IWhereList GreaterValue(string Column, string Value);

		IWhereList Less(params string[] Columns);

		IWhereList LessValue(string Column, string Value);

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