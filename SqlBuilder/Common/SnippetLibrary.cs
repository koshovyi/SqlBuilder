using System;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Templates
{

	public static class SnippetLibrary
	{

		#region Text injection

		public static ITemplateSnippet Start(string value)
		{
			return new Snippet("START", value);
		}

		public static ITemplateSnippet End(string value)
		{
			return new Snippet("END", value);
		}

		public static ITemplateSnippet NF()
		{
			return new Snippet("NF", Environment.NewLine);
		}

		#endregion

		#region SQL

		public static ITemplateSnippet DataBase(string value)
		{
			return new Snippet("DATABASE", value);
		}

		public static ITemplateSnippet Table(string table, string tableAlias = "")
		{
			table = SqlBuilder.FormatTable(table);
			if(!string.IsNullOrEmpty(tableAlias))
				tableAlias = SqlBuilder.FormatTableAlias(tableAlias);

			if(string.IsNullOrEmpty(tableAlias))
				return new Snippet("TABLE", table);
			else
				return new Snippet("TABLE", table + " as " + tableAlias);
		}

		public static ITemplateSnippet Columns(string value)
		{
			return new Snippet("COLUMNS", value);
		}

		public static ITemplateSnippet Sets(string value)
		{
			return new Snippet("SETS", value);
		}

		public static ITemplateSnippet Join(string value)
		{
			return new Snippet("JOINS", ' ' + value);
		}

		public static ITemplateSnippet Values(string columns = "")
		{
			return new Snippet("VALUES", columns);
		}

		public static ITemplateSnippet Where(string value)
		{
			return new Snippet("WHERE", value, " WHERE ");
		}

		public static ITemplateSnippet OrderBy(string value)
		{
			return new Snippet("ORDERBY", value, " ORDER BY ");
		}

		public static ITemplateSnippet GroupBy(string value)
		{
			return new Snippet("GROUPBY", value, " GROUP BY ");
		}

		#endregion

	}

}