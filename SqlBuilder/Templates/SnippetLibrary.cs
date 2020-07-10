using System;

namespace SqlBuilder.Templates
{

	public static class SnippetLibrary
	{

		#region Text injection

		public static Snippet Start(string value)
		{
			return new Snippet("START", value);
		}

		public static Snippet End(string value)
		{
			return new Snippet("END", value);
		}

		public static Snippet NF()
		{
			return new Snippet("NF", Environment.NewLine);
		}

		#endregion

		#region SQL

		public static Snippet DataBase(string value)
		{
			return new Snippet("DATABASE", value);
		}

		public static Snippet Table(string table, Format parameters, string tableAlias = "")
		{
			table = SqlBuilder.FormatTable(table, parameters);
			if(!string.IsNullOrEmpty(tableAlias))
				tableAlias = SqlBuilder.FormatTableAlias(tableAlias, parameters);

			if(string.IsNullOrEmpty(tableAlias))
				return new Snippet("TABLE", table);
			else
				return new Snippet("TABLE", table + parameters.AliasOperator + tableAlias);
		}

		public static Snippet Columns(string value)
		{
			return new Snippet("COLUMNS", value);
		}

		public static Snippet Sets(string value)
		{
			return new Snippet("SETS", value);
		}

		public static Snippet Join(string value)
		{
			return new Snippet("JOINS", ' ' + value);
		}

		public static Snippet Values(string columns = "")
		{
			return new Snippet("VALUES", columns);
		}

		public static Snippet Where(string value)
		{
			return new Snippet("WHERE", value, " WHERE ");
		}

		public static Snippet OrderBy(string value)
		{
			return new Snippet("ORDERBY", value, " ORDER BY ");
		}

		public static Snippet GroupBy(string value)
		{
			return new Snippet("GROUPBY", value, " GROUP BY ");
		}

		#endregion

	}

}
