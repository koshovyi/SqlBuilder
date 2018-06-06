using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IWhereList
	{

		IFormatter Parameters { get; }

		IEnumerable<IWhere> Expressions { get; }

		string GetSql(string tableAlias = "");

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
		IWhereList Equal(params string[] columns);

		IWhereList EqualValue(string column, string value);

		IWhereList NotEqual(params string[] columns);

		IWhereList NotEqualValue(string column, string value);

		//Exp less/greater
		IWhereList EqualGreater(params string[] columns);

		IWhereList EqualGreaterValue(string column, string value);

		IWhereList EqualLess(params string[] columns);

		IWhereList EqualLessValue(string column, string value);

		IWhereList Greater(params string[] columns);

		IWhereList GreaterValue(string column, string value);

		IWhereList Less(params string[] columns);

		IWhereList LessValue(string column, string value);

		//Exp null
		IWhereList IsNULL(params string[] columns);

		IWhereList IsNotNULL(params string[] columns);

		//Exp between/like
		IWhereList Between(string name, string begin, string end);

		IWhereList NotBetween(string name, string begin, string end);

		IWhereList Like(string name, string pattern);

		IWhereList NotLike(string name, string pattern);

	}

}