using SqlBuilder.Interfaces;
using SqlBuilder.Sql;
using SqlBuilder.Templates;

namespace SqlBuilder
{

	public class Select : IStatementSelect
	{

		public Format Format { get; set; }

		public Enums.SqlQuery Query { get; private set; }

		public string TableName { get; set; }

		public string TableAlias { get; set; }

		public IColumnsListAggregation Columns { get; set; }

		public JoinList Join { get; set; }

		public WhereList Where { get; set; }

		public GroupByList GroupBy { get; set; }

		public OrderByList OrderBy { get; set; }

		public Select(Format parameters, string tableName, string tableAlias = "")
		{
			this.Query = Enums.SqlQuery.Select;
			this.Format = parameters;
			this.TableName = tableName;
			this.TableAlias = tableAlias;
			this.Columns = new ColumnsListAggregation(this.Format);
			this.Join = new JoinList(this.Format);
			this.Where = new WhereList(this.Format);
			this.OrderBy = new OrderByList(this.Format);
			this.GroupBy = new GroupByList(this.Format, this.Columns);
		}

		public string GetSql()
		{
			Template result = TemplateLibrary.Select;
			result.Append(SnippetLibrary.Table(this.TableName, this.Format, this.TableAlias));
			result.Append(SnippetLibrary.Columns(this.Columns.GetSql(this.TableAlias)));

			if (this.Join.Count > 0)
			{
				string joinTable = string.IsNullOrEmpty(this.TableAlias) ? this.TableName : this.TableAlias;
				result.Append(SnippetLibrary.Join(this.Join.GetSql(joinTable)));
			}
			if (this.Where.Count > 0)
				result.Append(SnippetLibrary.Where(this.Where.GetSql(this.TableAlias)));
			if (this.GroupBy.Count > 0)
				result.Append(SnippetLibrary.GroupBy(this.GroupBy.GetSql(this.TableAlias)));
			if (this.OrderBy.Count > 0)
				result.Append(SnippetLibrary.OrderBy(this.OrderBy.GetSql(this.TableAlias)));

			return result.GetSql(this.Format);
		}

		public string GetSql(bool isSubQuery)
		{
			if (isSubQuery)
				return GetSql().TrimEnd(Format.EndOfStatement);
			return GetSql();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

	}

	public class Select<T> : Select
	{

		public Select(Format format) : base(format, Reflection.GetTableName<T>())
		{
		}

		public Select(Format format, string tableAlias) : base(format, Reflection.GetTableName<T>(), tableAlias)
		{
		}

	}

}
