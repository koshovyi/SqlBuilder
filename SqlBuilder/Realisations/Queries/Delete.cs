using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SqlBuilder.Attributes;
using SqlBuilder.Interfaces;
using SqlBuilder.Sql;
using SqlBuilder.Templates;

namespace SqlBuilder
{

	public class Delete<T> : IStatementDelete
	{

		public IFormatter Formatter { get; set; }

		public IWhereList Where { get; set; }

		public Delete() : this(SqlBuilder.DefaultFormatter)
		{
		}

		public Delete(IFormatter parameters)
		{
			this.Formatter = parameters;
			this.Where = new WhereList(this.Formatter);
		}

		public string GetSql()
		{
			string table = Reflection.GetTableName<T>();

			ITemplate result = TemplateLibrary.Delete;
			result.Append(SnippetLibrary.Table(table));
			if(this.Where.Count > 0)
				result.Append(SnippetLibrary.Where(this.Where.GetSql()));

			return result.GetSql();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

		public static Delete<T> DeleteAll()
		{
			Delete<T> result = new Delete<T>();
			return result;
		}

	}

}