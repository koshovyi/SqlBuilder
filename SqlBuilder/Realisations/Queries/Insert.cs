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

	public class Insert<T> : IStatementInsert
	{

		public IFormatter Formatter { get; set; }

		public string TableAlias { get; set; }

		public IColumnsListSimple Columns { get; set; }

		public IValueList Values { get; set; }

		public Insert(bool AutoMapping = true) : this(SqlBuilder.DefaultFormatter, AutoMapping)
		{
		}

		public Insert(IFormatter formatter, bool AutoMapping = true)
		{
			this.Formatter = formatter;
			this.Columns = new ColumnsListSimple(this.Formatter);
			this.Values = new ValueList(this.Formatter);
			if (AutoMapping)
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
				columnName = string.Empty;
				defaultValue = string.Empty;

				foreach (Attribute attribute in property.GetCustomAttributes())
				{
					if (attribute is IgnoreInsertAttribute)
						ignore = true;
					if (attribute is InsertDefaultAttribute insertDefault)
						defaultValue = insertDefault.Default;
					if (attribute is ColumnAttribute clm)
						columnName = clm.ColumnName.ToLower();
				}

				if (!ignore)
				{
					this.Columns.Append(columnName == string.Empty ? property.Name.ToLower() : columnName);
					if (defaultValue == string.Empty)
						this.Values.Append(this.Formatter.Parameter + property.Name.ToLower());
					else
						this.Values.Append(defaultValue);
				}
			}
		}

		public IStatementInsert AppendParameters(params string[] parameters)
		{
			this.Columns.Append(parameters);
			this.Values.AppendParameters(parameters);
			return this;
		}

		public string GetSql()
		{
			string table = Reflection.GetTableName<T>();

			ITemplate result = TemplateLibrary.Insert;
			result.Append(SnippetLibrary.Table(table));
			result.Append(SnippetLibrary.Columns(this.Columns.GetSql()));
			result.Append(SnippetLibrary.Values(this.Values.GetSql()));

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