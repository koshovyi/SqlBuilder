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

		public Enums.SqlQuery Query { get; private set; }

		public string TableAlias { get; set; }

		public IWhereList Where { get; set; }

		public Delete(string tableAlias = "") : this(SqlBuilder.DefaultFormatter, tableAlias)
		{
		}

		public Delete(IFormatter parameters, string tableAlias = "")
		{
			this.Query = Enums.SqlQuery.Delete;
			this.TableAlias = tableAlias;
			this.Formatter = parameters;
			this.Where = new WhereList(this.Formatter);
		}

		public string GetSql()
		{
			string table = Reflection.GetTableName<T>();

			ITemplate result = TemplateLibrary.Delete;
			result.Append(SnippetLibrary.Table(table));
			if(this.Where.Count > 0)
				result.Append(SnippetLibrary.Where(this.Where.GetSql(tableAlias: this.TableAlias)));

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