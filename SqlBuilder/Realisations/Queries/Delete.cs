using SqlBuilder.Interfaces;
using SqlBuilder.Sql;
using SqlBuilder.Templates;

namespace SqlBuilder
{

	public class Delete : IStatementDelete
	{

		public Format Format { get; set; }

		public Enums.SqlQuery Query { get; protected set; }

		public string TableName { get; set; }

		public string TableAlias { get; set; }

		public WhereList Where { get; set; }

		public Delete(Format format, string tableName, string tableAlias = "")
		{
			this.Query = Enums.SqlQuery.Delete;
			this.TableName = tableName;
			this.TableAlias = tableAlias;
			this.Format = format;
			this.Where = new WhereList(this.Format);
		}

		public string GetSql()
		{
			Template result = TemplateLibrary.Delete;
			result.Append(SnippetLibrary.Table(this.TableName, this.Format, this.TableAlias));

			if (this.Where.Count > 0)
			{
				string whereSql = this.Where.GetSql(tableAlias: this.TableAlias);
				Snippet whereSnipper = SnippetLibrary.Where(whereSql);
				result.Append(whereSnipper);
			}

			return result.GetSql(this.Format);
		}

		public override string ToString()
		{
			return this.GetSql();
		}

	}

	public class Delete<T> : Delete
	{

		public Delete(Format parameters) : base(parameters, Reflection.GetTableName<T>(), Reflection.GetTableAlias<T>())
		{
		}

		public Delete(Format parameters, string tableAlias) : base(parameters, Reflection.GetTableName<T>(), tableAlias)
		{
		}

	}

}
