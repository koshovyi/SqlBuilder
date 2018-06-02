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

		IColumnsListAggregation Columns { get; set; }

		IWhereList Where { get; set; }

		IGroupByList GroupBy { get; set; }

		IOrderByList OrderBy { get; set; }

	}

	public interface IStatementInsert : IStatement
	{

		IColumnsListSimple Columns { get; set; }

		IValueList Values { get; set; }

		IStatementInsert AppendParameters(params string[] parameters);

	}

	public interface IStatementDelete : IStatement
	{

		IWhereList Where { get; set; }

	}

	public interface IStatementUpdate : IStatement
	{

		IColumnsListSimple Columns { get; set; }

		IWhereList Where { get; set; }

	}

}