using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Enums;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class Insert<T> : Interfaces.IStatementInsert
	{
		public string TableName { get; }
		public string TableAlias { get; set; }
		public IParameters Parameters { get; set; }

		public Insert()
		{
			this.Parameters = SqlBuilder.Parameters;
		}

		private string[] GetColumns()
		{
			List<string> result = new List<string>();

			return result.ToArray();
		}

		public string GetSql()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("INSERT INTO " + Reflection.GetTableName<T>() + "() VALUES() " + Reflection.GetTableName<T>());
			return sb.ToString();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

		public static Select<T> InsertDefault(params string[] Columns)
		{
			Select<T> result = new Select<T>();
			result.Columns.Append(Columns);
			return result;
		}

	}

}