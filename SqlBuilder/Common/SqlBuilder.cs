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

		public static string FormatColumn(string Column, bool Escape = false)
		{
			if(Escape)
				return Parameters.ColumnEscapeLeft + Column + Parameters.ColumnEscapeRight;
			else
				return Column;
		}

		public static string FormatParameter(string Column)
		{
			return Parameters.Parameter + Column;
		}

		public static string FormatTable(string TableName)
		{
			return Parameters.TableEscapeLeft + TableName + Parameters.TableEscapeRight;
		}

		public static string GetColumnsList(string[] Columns, bool Escape = false, bool Parameter = false)
		{
			return GetColumnsList(Columns, SqlBuilder.Parameters, Escape, Parameter);
		}

		public static string GetColumnsList(string[] Columns, Parameters Parameters, bool Escape = false, bool Parameter = false)
		{
			if (Columns.Length == 0)
				return "*";

			StringBuilder sb = new StringBuilder();
			foreach (string column in Columns)
			{
				if (sb.Length > 0)
					sb.Append(',');
				if (Parameter)
					sb.Append(Parameters.Parameter);
				sb.Append(FormatColumn(column, Escape));
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

		public static string GetColumnsParametresList(params string[] Columns)
		{
			return GetColumnsParametresList(SqlBuilder.Parameters, Columns);
		}

		public static string GetColumnsParametresList(Parameters Parameters, params string[] Columns)
		{
			StringBuilder sb = new StringBuilder();
			foreach (string Column in Columns)
			{
				if (sb.Length > 0)
					sb.Append(',');
				sb.Append(FormatColumn(Column) + "=" + Parameters.Parameter + Column);
			}
			return sb.ToString();
		}

	}

}