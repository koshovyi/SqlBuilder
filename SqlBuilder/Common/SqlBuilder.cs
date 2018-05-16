using System.Text;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public partial class SqlBuilder
	{

		public static IParameters Parameters { get; set; }

		static SqlBuilder()
		{
			Parameters = ParametersLibrary.MsSql;
		}

		public static string FormatColumn(string column)
		{
			return FormatColumn(column, SqlBuilder.Parameters);
		}

		public static string FormatColumn(string column, IParameters parameters)
		{
			return parameters.EscapeEnabled
				? parameters.ColumnEscapeLeft + column + parameters.ColumnEscapeRight
				: column;
		}

		public static string FormatParameter(string column)
		{
			return FormatParameter(column, SqlBuilder.Parameters);
		}

		public static string FormatParameter(string column, IParameters parameters)
		{
			return parameters.Parameter + column;
		}

		public static string FormatTable(string tableName)
		{
			return FormatTable(tableName, SqlBuilder.Parameters);
		}

		public static string FormatTable(string tableName, IParameters parameters)
		{
			return parameters.EscapeEnabled
				? parameters.TableEscapeLeft + tableName + parameters.TableEscapeRight
				: tableName;
		}

		public static string FormatAlias(string aliasName)
		{
			return FormatAlias(aliasName, SqlBuilder.Parameters);
		}

		public static string FormatAlias(string aliasName, IParameters parameters)
		{
			return parameters.AliasEscape + aliasName + parameters.AliasEscape;
		}

		public static string GetColumnsList(IColumnsList columns, string tableAlias = "")
		{
			return GetColumnsList(columns, SqlBuilder.Parameters, tableAlias);
		}

		public static string GetColumnsList(IColumnsList columns, IParameters parameters, string tableAlias = "")
		{
			if (columns.Count == 0)
			{
				return string.IsNullOrEmpty(tableAlias)
					? "*"
					: SqlBuilder.FormatAlias(tableAlias, parameters) + ".*";
			}

			StringBuilder sb = new StringBuilder();
			foreach (IColumn column in columns.Expressions)
			{
				if (sb.Length > 0)
					sb.Append(", ");
				if (!string.IsNullOrEmpty(tableAlias))
					sb.Append(FormatAlias(tableAlias, parameters));
				if(string.IsNullOrEmpty(column.Alias))
					sb.Append(column.Prefix + FormatColumn(column.Name, parameters) + column.Postfix);
				else
					sb.Append(column.Prefix + FormatColumn(column.Name, parameters) + column.Postfix + " as " + parameters.AliasEscape + column.Alias + parameters.AliasEscape);
			}
			return sb.ToString();
		}

		public static string GetColumnsParametersList(params string[] columns)
		{
			return GetColumnsParametersList(SqlBuilder.Parameters, columns);
		}

		public static string GetColumnsParametersList(IParameters parameters, params string[] columns)
		{
			StringBuilder sb = new StringBuilder();
			foreach (string Column in columns)
			{
				if (sb.Length > 0)
					sb.Append(", ");
				sb.Append(FormatColumn(Column, parameters) + "=" + FormatParameter(Column, parameters));
			}
			return sb.ToString();
		}

	}

}