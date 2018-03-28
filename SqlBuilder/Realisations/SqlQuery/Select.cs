using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Enums;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class Select<T> : Interfaces.IStatementSelect
	{
		public string TableName { get; }
		public string TableAlias { get; set; }
		public IParameters Parameters { get; set; }

		public IColumnsList Columns { get; set; }
		public IWhereList Where { get; set; }
		public IOrderByList OrderBy { get; set; }

		public Select()
		{
			this.Parameters = SqlBuilder.Parameters;
			this.Columns = new Columns();
			this.Where = new Where();
			this.OrderBy = new OrderBy();
		}

		public string GetSql()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT " + SqlBuilder.GetColumnsList(this.Columns) + " FROM " + Reflection.GetTableName<T>());
			if (this.Where.Count > 0)
				sb.Append(" " + this.Where.GetSql(true));
			if (this.OrderBy.Count > 0)
				sb.Append(" " + this.OrderBy.GetSql(true));
			sb.Append(this.Parameters.EndOfStatement);
			return sb.ToString();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

		public static Select<T> SelectAll(params string[] Columns)
		{
			Select<T> result = new Select<T>();
			result.Columns.Append(Columns);
			return result;
		}

		public static Select<T> SelectWherePK(params string[] Columns)
		{
			Select<T> result = new Select<T>();
			result.Columns.Append(Columns);
			result.Where.Equal(Reflection.GetPrimaryKey<T>());
			return result;
		}

	}

}