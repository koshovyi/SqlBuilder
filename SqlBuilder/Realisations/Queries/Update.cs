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

		public IParameters Parameters { get; set; }

		public ISetList Sets { get; set; }

		public IWhereList Where { get; set; }

		public Update() : this(SqlBuilder.Parameters)
		{
		}

		public Update(IParameters parameters)
		{
			this.Parameters = parameters;
			this.Sets = new SetList(this.Parameters);
			this.Where = new WhereList(this.Parameters);
		}

		public string GetSql()
		{
			string table = Reflection.GetTableName<T>();

			ITemplate result = TemplateLibrary.Update;
			result.Append(SnippetLibrary.Table(table));
			result.Append(SnippetLibrary.Sets(this.Sets.GetSql()));
			if (this.Where.Count > 0)
				result.Append(SnippetLibrary.Where(this.Where.GetSql()));

			return result.GetSql();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

		public static Insert<T> InsertWithMap(params string[] parameters)
		{
			Insert<T> result = new Insert<T>();
			result.AppendParameters(parameters);
			return result;
		}

		public static Insert<T> InsertWithoutMap(params string[] parameters)
		{
			Insert<T> result = new Insert<T>(false);
			result.AppendParameters(parameters);
			return result;
		}

	}

}