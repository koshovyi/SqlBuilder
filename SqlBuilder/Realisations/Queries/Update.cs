using SqlBuilder.Attributes;
using SqlBuilder.Interfaces;
using SqlBuilder.Sql;
using SqlBuilder.Templates;
using System;
using System.Reflection;

namespace SqlBuilder
{

	public class Update : IStatementUpdate
	{

		public Format Format { get; set; }

		public Enums.SqlQuery Query { get; private set; }

		public string TableName { get; set; }

		public string TableAlias { get; set; }

		public SetList Sets { get; set; }

		public WhereList Where { get; set; }

		public Update(Format parameters, string tableName, string tableAlias = "")
		{
			this.Query = Enums.SqlQuery.Update;
			this.Format = parameters;
			this.TableName = tableName;
			this.TableAlias = tableAlias;
			this.Sets = new SetList(this.Format);
			this.Where = new WhereList(this.Format);
		}

		public string GetSql()
		{
			Template result = TemplateLibrary.Update;
			result.Append(SnippetLibrary.Table(this.TableName, this.Format, this.TableAlias));
			result.Append(SnippetLibrary.Sets(this.Sets.GetSql(this.TableAlias)));
			if (this.Where.Count > 0)
				result.Append(SnippetLibrary.Where(this.Where.GetSql(this.TableAlias)));

			return result.GetSql(this.Format);
		}

		public override string ToString()
		{
			return this.GetSql();
		}

	}

	public class Update<T> : Update
	{

		public Update(Format format) : base(format, Reflection.GetTableName<T>(), Reflection.GetTableAlias<T>())
		{
			this.Mapping();
		}

		public Update(Format format, string tableAlias) : base(format, Reflection.GetTableName<T>(), tableAlias)
		{
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
					if (attribute is IgnoreUpdateAttribute)
						ignore = true;
					if (attribute is UpdateDefaultAttribute insertDefault)
						defaultValue = insertDefault.DefaultValue;
					if (attribute is ColumnNameAttribute clm)
						columnName = clm.Name.ToLower();
				}

				if (!ignore)
				{
					if (defaultValue == string.Empty)
						this.Sets.AppendValue(columnName, this.Format.Parameter + columnName);
					else
						this.Sets.AppendValue(columnName, defaultValue);
				}
			}
		}

	}

}
