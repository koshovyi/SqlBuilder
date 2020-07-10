namespace SqlBuilder
{

	public static partial class SqlBuilder
	{

		static SqlBuilder()
		{
		}

		public static string FormatColumn(string column, Format formatter, string tableAlias = "")
		{
			if (!string.IsNullOrEmpty(tableAlias))
				tableAlias = FormatTableAlias(tableAlias, formatter) + '.';

			column = formatter.EscapeEnabled
				? formatter.ColumnEscapeLeft + column + formatter.ColumnEscapeRight
				: column;

			return tableAlias + column;
		}

		public static string FormatParameter(string column, Format formatter)
		{
			return formatter.Parameter + column;
		}

		public static string FormatTable(string tableName, Format formatter)
		{
			return formatter.EscapeEnabled
				? formatter.TableEscapeLeft + tableName + formatter.TableEscapeRight
				: tableName;
		}

		public static string FormatTableAlias(string value, Format formatter)
		{
			return formatter.TableEscapeLeft + value + formatter.TableEscapeRight;
		}

		public static string FormatColumnAlias(string value, Format formatter)
		{
			return formatter.AliasEscape + value + formatter.AliasEscape;
		}

	}

}
