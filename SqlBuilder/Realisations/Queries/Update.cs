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

	public class Update<T> : IStatementUpdate
	{

		public IFormatter Formatter { get; set; }

		public Enums.SqlQuery Query { get; private set; }

		public string TableAlias { get; set; }

		public ISetList Sets { get; set; }

		public IWhereList Where { get; set; }

		public Update(string tableAlias = "") : this(SqlBuilder.DefaultFormatter, tableAlias)
		{
		}

		public Update(IFormatter parameters, string tableAlias = "")
		{
			this.Query = Enums.SqlQuery.Update;
			this.Formatter = parameters;
			this.TableAlias = tableAlias;
			this.Sets = new SetList(this.Formatter);
			this.Where = new WhereList(this.Formatter);
		}

		public string GetSql()
		{
			string table = Reflection.GetTableName<T>();

			ITemplate result = TemplateLibrary.Update;
			result.Append(SnippetLibrary.Table(table, this.TableAlias));
			result.Append(SnippetLibrary.Sets(this.Sets.GetSql()));
			if (this.Where.Count > 0)
				result.Append(SnippetLibrary.Where(this.Where.GetSql()));

			return result.GetSql();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

		public static Insert<T> InsertWithMapping(params string[] parameters)
		{
			Insert<T> result = new Insert<T>();
			result.AppendParameters(parameters);
			return result;
		}

		public static Insert<T> InsertWithoutMapping(params string[] parameters)
		{
			Insert<T> result = new Insert<T>(false);
			result.AppendParameters(parameters);
			return result;
		}

	}

}