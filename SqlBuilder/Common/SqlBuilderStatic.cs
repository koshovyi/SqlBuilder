using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SqlBuilder
{

	public partial class SqlBuilder
	{
		public static Parameters Parameters { get; set; }

		static SqlBuilder()
		{
			Parameters = ParametersLibrary.MsSql;
		}

		public static string FormatColumn(string Column)
		{
			return Parameters.ColumnEscapeLeft + Column + Parameters.ColumnEscapeRight;
		}

		public static string FormatParameter(string Column)
		{
			return Parameters.Parameter + Column;
		}

		public static string FormatTable(string TableName)
		{
			return Parameters.TableEscapeLeft + TableName + Parameters.TableEscapeRight;
		}

		public static string GetColumnsList(string[] Columns, bool Escape = false)
		{
			if (Columns.Length == 0)
				return "*";

			StringBuilder sb = new StringBuilder();
			foreach (string column in Columns)
			{
				if (sb.Length > 0)
					sb.Append(',');
				sb.Append(FormatColumn(column));
			}
			return sb.ToString();
		}

		public static string GetColumnsList(Interfaces.IColumnsList Columns)
		{
			if (Columns.Count == 0)
				return "*";

			StringBuilder sb = new StringBuilder();
			foreach (Interfaces.IColumn column in Columns.Expressions)
			{
				if (sb.Length > 0)
					sb.Append(',');
				if(string.IsNullOrEmpty(column.Alias))
					sb.Append(FormatColumn(column.Name));
				else
					sb.Append(FormatColumn(column.Name) + " as " + column.Alias);
			}
			return sb.ToString();
		}

	}

}