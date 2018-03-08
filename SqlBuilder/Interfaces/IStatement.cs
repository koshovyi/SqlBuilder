using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder
{
	public interface IStatement
	{
		SqlType Type { get; set; }
	}

	public interface ITableName
	{
		string TableName { get; set; }
	}

	public interface IWhere
	{
		IParameters Parameters { get; set; }
		IEnumerable<IWhereExpression> Expressions { get; }
		
		void Clear();
		void Append(IWhereExpression Expression);

		//Flags
		WhereExpressionLogic LogicOperator { get; }

		//Parenthesis
		int Level { get; }
		bool HasOpenedParenthesis { get; }
		IWhere OpenParenthesis();
		IWhere CloseParenthesis();

		//Logic
		IWhere And();
		IWhere Or();
		IWhere Not();

		//Exp eq
		IWhere Equal(params string[] Expressions);
		IWhere EqualParam(string Column, string Value);
		IWhere NotEqual(params string[] Expressions);
		IWhere NotEqualParam(string Column, string Value);

		//Exp less/greater
		IWhere EqualGreater(params string[] Expressions);
		IWhere EqualLess(params string[] Expressions);
		IWhere Less(params string[] Expressions);
		IWhere Greater(params string[] Expressions);

		//Exp null
		IWhere IsNULL(params string[] Expressions);
		IWhere IsNotNULL(params string[] Expressions);

		//Exp between/like
		IWhere Between(string Name, string Begin, string End);
		IWhere NotBetween(string Name, string Begin, string End);
		IWhere Like(string Name, string Pattern);
		IWhere NotLike(string Name, string Pattern);

	}

	public enum WhereExpressionLogic : uint
	{
		Unknown = 0,
		AND = 1,
		OR = 2,
		NOT = 3,
	}

	public enum WhereExpressionType : uint
	{
		Unknown = 0,
		Equal,
		NotEqual,
		EqualGreater,
		EqualLess,
		Greater,
		Less,
		IsNULL,
		IsNotNULL,
		Between,
		NotBetween,
		Like,
		NotLike,
	}

	public enum StatementParenthesis : uint
	{
		Unknown = 0,
		OpenParenthesis = 1,
		CloseParenthesis = 2,
	}

	public interface IWhereExpression
	{
		WhereExpressionLogic Logic { get; }
		WhereExpressionType Type { get; }
		StatementParenthesis Parenthesis { get; }
		string Value { get; set; }
		
	}

	public interface IStatementSelect : IStatement, ITableName, IWhere
	{
	}

	public interface IStatementDelete : IStatement, ITableName, IWhere
	{
	}

	public interface IStatementUpdate : IStatement, ITableName, IWhere
	{
	}

	public interface IStatementString : IStatement
	{
		string Statement { get; set; }
	}


}
