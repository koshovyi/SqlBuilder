using System;
using System.Collections.Generic;
using System.Reflection;

namespace SqlBuilder
{

	public static partial class SqlBuilder
	{
		public static Parameters Parameters { get; set; }

		static SqlBuilder()
		{
			Parameters = ParametersLibrary.MsSQL;
		}

		private static IEnumerable<A> GetAttributes<T, A>()
		{
			Type type = typeof(T);
			foreach(A attr in type.GetCustomAttributes(typeof(A), false))
			{
				yield return attr;
			}
		}

		public static string GetTableName<T>(bool Escape = false)
		{
			string result = typeof(T).Name.ToLower();
			foreach (TableNameAttribute a in typeof(T).GetCustomAttributes(typeof(TableNameAttribute), false))
			{
				result = a.TableName;
				break;
			}
			return Escape
				? FormatTable(result)
				: result;
		}

		public static string GetPrimaryKey<T>()
		{
			Type type = typeof(T);
			foreach (PropertyInfo property in type.GetProperties())
			{
				foreach(PrimaryKeyAttribute pk in property.GetCustomAttributes(typeof(PrimaryKeyAttribute), false))
				{
					return property.Name;
				}
			}
			throw new Exception();
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
			if (Escape)
			{
				string result = string.Empty;
				foreach (string column in Columns)
				{
					result += Parameters.ColumnEscapeLeft + column + Parameters.ColumnEscapeRight;
				}
				return result;
			}
			else
				return string.Join(',', Columns);
		}

		public static string SelectAll<T>()
		{
			return "SELECT * FROM " + GetTableName<T>(true) + Parameters.EndOfStatement;
		}

		public static string SelectAll<T>(params string[] Columns)
		{
			return "SELECT " + GetColumnsList(Columns, true) + " FROM " + GetTableName<T>(true) + Parameters.EndOfStatement;
		}

		public static string SelectWherePK<T>()
		{
			string pk = GetPrimaryKey<T>();
			return "SELECT * FROM " + GetTableName<T>(true) + " WHERE " + FormatColumn(pk) + '=' + FormatParameter(pk) + Parameters.EndOfStatement;
		}

	}

}