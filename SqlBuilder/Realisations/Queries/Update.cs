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

		public Update(bool autoMapping = false, string tableAlias = "") : this(SqlBuilder.DefaultFormatter, autoMapping, tableAlias)
		{
		}

		public Update(IFormatter parameters, bool autoMapping = false, string tableAlias = "")
		{
			this.Query = Enums.SqlQuery.Update;
			this.Formatter = parameters;
			this.TableAlias = tableAlias;
			this.Sets = new SetList(this.Formatter);
			this.Where = new WhereList(this.Formatter);

			if (autoMapping)
				this.Mapping();
		}

		private void Mapping()
		{
			bool ignore;
			string columnName, defaultValue;
			Type type = typeof(T);
			foreach (PropertyInfo property in type.GetProperties())
			{
				ignore = false;
				defaultValue = string.Empty;
				columnName = property.Name.ToLower();

				foreach (Attribute attribute in property.GetCustomAttributes())
				{
					if (attribute is IgnoreInsertAttribute)
						ignore = true;
					if (attribute is InsertDefaultAttribute insertDefault)
						defaultValue = insertDefault.DefaultValue;
					if (attribute is ColumnAttribute clm)
						columnName = clm.ColumnName.ToLower();
				}

				if (!ignore)
				{
					this.Sets.AppendValue(columnName, this.Formatter.Parameter + columnName);
					//this.Columns.Append(columnName == string.Empty ? property.Name.ToLower() : columnName);
					//if (defaultValue == string.Empty)
					//	this.Values.Append(this.Formatter.Parameter + property.Name.ToLower());
					//else
					//	this.Values.Append(defaultValue);
				}
			}
		}

		public string GetSql()
		{
			string table = Reflection.GetTableName<T>();

			ITemplate result = TemplateLibrary.Update;
			result.Append(SnippetLibrary.Table(table, this.TableAlias));
			result.Append(SnippetLibrary.Sets(this.Sets.GetSql(this.TableAlias)));
			if (this.Where.Count > 0)
				result.Append(SnippetLibrary.Where(this.Where.GetSql(this.TableAlias)));

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