using SqlBuilder.Attributes;
using SqlBuilder.Interfaces;
using SqlBuilder.Sql;
using SqlBuilder.Templates;
using System;
using System.Reflection;

namespace SqlBuilder
{

	public class Insert : IStatementInsert
	{

		public Format Format { get; set; }

		public Enums.SqlQuery Query { get; private set; }

		public string TableName { get; set; }

		public string TableAlias { get; set; }

		public IColumnsListSimple Columns { get; set; }

		public ValueList Values { get; set; }

		public Insert(Format formatter, string tableName)
		{
			this.Query = Enums.SqlQuery.Insert;
			this.Format = formatter;
			this.TableName = tableName;
			this.Columns = new ColumnsListSimple(this.Format);
			this.Values = new ValueList(this.Format);
		}

		public IStatementInsert AppendParameters(params string[] parameters)
		{
			this.Columns.Append(parameters);
			this.Values.AppendParameters(parameters);
			return this;
		}

		public string GetSql()
		{
			Template result = TemplateLibrary.Insert;
			result.Append(SnippetLibrary.Table(this.TableName, this.Format));
			result.Append(SnippetLibrary.Columns(this.Columns.GetSql(this.TableAlias)));
			result.Append(SnippetLibrary.Values(this.Values.GetSql()));

			return result.GetSql(this.Format);
		}

		public override string ToString()
		{
			return this.GetSql();
		}

	}

	public class Insert<T> : Insert
	{

		public Insert(Format format) : base(format, Reflection.GetTableName<T>())
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
					if (attribute is IgnoreInsertAttribute)
						ignore = true;
					if (attribute is InsertDefaultAttribute insertDefault)
						defaultValue = insertDefault.DefaultValue;
					if (attribute is ColumnNameAttribute clm)
						columnName = clm.Name.ToLower();
				}

				if (!ignore)
				{
					this.Columns.Append(columnName);
					if (defaultValue == string.Empty)
						this.Values.Append(this.Format.Parameter + columnName);
					else
						this.Values.Append(defaultValue);
				}
			}
		}

	}

}
