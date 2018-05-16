using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IStatement
	{

		IParameters Parameters { get; set; }

		string GetSql();

	}

	public interface IStatementSelect : IStatement
	{

		string TableAlias { get; set; }

		IColumnsAggregationList Columns { get; set; }

		IWhereList Where { get; set; }

		GroupByList GroupBy { get; set; }

		IOrderByList OrderBy { get; set; }

	}

	public interface IStatementInsert : IStatement
	{

		IColumnsList Columns { get; set; }

		IValueList Values { get; set; }

		IStatementInsert AppendParameters(params string[] parameters);

	}

	public interface IStatementDelete : IStatement
	{

		IWhereList Where { get; set; }

	}

	public interface IStatementUpdate : IStatement
	{

		IColumnsList Columns { get; set; }

		IWhereList Where { get; set; }

	}

}