using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{
	public interface IStatement
	{
		IParameters Parameters { get; set; }
		string TableName { get; }
		string TableAlias { get; set; }
		string GetSql();
	}

	public interface IStatementSelect : IStatement
	{

		IColumnsList Columns { get; set; }
		IWhereList Where { get; set; }
		IOrderByList OrderBy { get; set; }


	}

	public interface IStatementInsert : IStatement
	{
	}

}