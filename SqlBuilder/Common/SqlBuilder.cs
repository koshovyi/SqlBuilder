using System.Text;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public static partial class SqlBuilder
	{

		public static IFormatter DefaultFormatter { get; set; }

		static SqlBuilder()
		{
			DefaultFormatter = FormatterLibrary.MsSql;
		}

		public static string FormatColumn(string column, string tableAlias = "")
		{
			return FormatColumn(column, SqlBuilder.DefaultFormatter, tableAlias);
		}

		public static string FormatColumn(string column, IFormatter parameters, string tableAlias = "")
		{
			if (!string.IsNullOrEmpty(tableAlias))
				tableAlias = FormatAlias(tableAlias) + '.';

			column = parameters.EscapeEnabled
				? parameters.ColumnEscapeLeft + column + parameters.ColumnEscapeRight
				: column;

			return tableAlias + column;
		}

		public static string FormatParameter(string column)
		{
			return FormatParameter(column, SqlBuilder.DefaultFormatter);
		}

		public static string FormatParameter(string column, IFormatter parameters)
		{
			return parameters.Parameter + column;
		}

		public static string FormatTable(string tableName)
		{
			return FormatTable(tableName, SqlBuilder.DefaultFormatter);
		}

		public static string FormatTable(string tableName, IFormatter parameters)
		{
			return parameters.EscapeEnabled
				? parameters.TableEscapeLeft + tableName + parameters.TableEscapeRight
				: tableName;
		}

		public static string FormatAlias(string value)
		{
			return FormatAlias(value, SqlBuilder.DefaultFormatter);
		}

		public static string FormatAlias(string value, IFormatter parameters)
		{
			return parameters.AliasEscape + value + parameters.AliasEscape;
		}

	}

}