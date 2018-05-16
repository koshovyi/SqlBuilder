using System;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public static class SnippetLibrary
	{

		#region Text injection

		public static ITemplateSnippet Start(string Value)
		{
			return new Snippet("START", Value);
		}

		public static ITemplateSnippet End(string Value)
		{
			return new Snippet("END", Value);
		}

		public static ITemplateSnippet NF()
		{
			return new Snippet("NF", Environment.NewLine);
		}

		#endregion

		#region SQL

		public static ITemplateSnippet DataBase(string Value)
		{
			return new Snippet("DATABASE", Value);
		}

		public static ITemplateSnippet Table(string Table, string Alias = "")
		{
			Table = SqlBuilder.FormatTable(Table);
			if(!string.IsNullOrEmpty(Alias))
				Alias = SqlBuilder.FormatAlias(Alias);

			if(string.IsNullOrEmpty(Alias))
				return new Snippet("TABLE", Table);
			else
				return new Snippet("TABLE", Table + " as " + Alias);
		}

		public static ITemplateSnippet Columns(string Value)
		{
			return new Snippet("COLUMNS", Value);
		}

		public static ITemplateSnippet Sets(string Value)
		{
			return new Snippet("SETS", Value);
		}

		public static ITemplateSnippet Values(string Columns = "")
		{
			return new Snippet("VALUES", Columns);
		}

		public static ITemplateSnippet Where(string Value)
		{
			return new Snippet("WHERE", Value, " WHERE ");
		}

		public static ITemplateSnippet OrderBy(string Value)
		{
			return new Snippet("ORDERBY", Value, " ORDER BY ");
		}

		public static ITemplateSnippet GroupBy(string Value)
		{
			return new Snippet("GROUPBY", Value, " GROUP BY ");
		}

		#endregion

	}

}