using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder
{

	public static class SnippetLibrary
	{

		public static Interfaces.ITemplateSnippet Start(string Expression)
		{
			return new Snippet("START", Expression);
		}

		public static Interfaces.ITemplateSnippet End(string Expression)
		{
			return new Snippet("END", Expression);
		}

		public static Interfaces.ITemplateSnippet DataBase(string Expression)
		{
			return new Snippet("DATABASE", Expression);
		}

		public static Interfaces.ITemplateSnippet Table(string Table, string Alias = "")
		{
			if(string.IsNullOrEmpty(Alias))
				return new Snippet("TABLE", Table);
			else
				return new Snippet("TABLE", Table + " as " + Alias);
		}

		public static Interfaces.ITemplateSnippet Columns(params string[] Columns)
		{
			return new Snippet("COLUMNS", SqlBuilder.GetColumnsList(Columns));
		}

		public static Interfaces.ITemplateSnippet Sets(params string[] Columns)
		{
			return new Snippet("SETS", SqlBuilder.GetColumnsParametresList(Columns));
		}

		public static Interfaces.ITemplateSnippet Values(params string[] Columns)
		{
			return new Snippet("VALUES", SqlBuilder.GetColumnsList(Columns, false, true));
		}

		public static Interfaces.ITemplateSnippet Where(string Expression)
		{
			return new Snippet("WHERE", Expression, " WHERE ");
		}

		public static Interfaces.ITemplateSnippet OrderBy(string Expression)
		{
			return new Snippet("ORDERBY", Expression, " ORDER BY ");
		}

		public static Interfaces.ITemplateSnippet GroupBy(string Expression)
		{
			return new Snippet("GROUPBY", Expression, " GROUP BY ");
		}

	}

}