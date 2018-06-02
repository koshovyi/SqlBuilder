using SqlBuilder.Interfaces;
using SqlBuilder.Sql;
using SqlBuilder.Templates;

namespace SqlBuilder
{

	public class Select<T> : IStatementSelect
	{

		public string TableAlias { get; set; }

		public IParameters Parameters { get; set; }

		public IColumnsListAggregation Columns { get; set; }

		public IWhereList Where { get; set; }

		public IGroupByList GroupBy { get; set; }

		public IOrderByList OrderBy { get; set; }

		public Select(string tableAlias = "") : this(SqlBuilder.Parameters, tableAlias)
		{
		}

		public Select(IParameters parameters, string tableAlias = "")
		{
			this.Parameters = parameters;
			this.TableAlias = tableAlias;
			this.Columns = new ColumnsListAggregation(this.Parameters);
			this.Where = new WhereList(this.Parameters);
			this.OrderBy = new OrderByList(this.Parameters);
			this.GroupBy = new GroupByList(this.Parameters, this.Columns);
		}

		public string GetSql()
		{
			string table = Reflection.GetTableName<T>();

			ITemplate result = TemplateLibrary.Select;
			result.Append(SnippetLibrary.Table(table, this.TableAlias));
			result.Append(SnippetLibrary.Columns(this.Columns.GetSql(this.TableAlias)));

			if (this.Where.Count > 0)
				result.Append(SnippetLibrary.Where(this.Where.GetSql()));
			if (this.GroupBy.Count > 0)
				result.Append(SnippetLibrary.GroupBy(this.GroupBy.GetSql()));
			if (this.OrderBy.Count > 0)
				result.Append(SnippetLibrary.OrderBy(this.OrderBy.GetSql()));

			return result.GetSql();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

		public static Select<T> SelectAll(params string[] Columns)
		{
			Select<T> result = new Select<T>();
			result.Columns.Append(Columns);
			return result;
		}

		public static Select<T> SelectWherePK(params string[] Columns)
		{
			return SelectWherePK(SqlBuilder.Parameters, Columns);
		}

		public static Select<T> SelectWherePK(IParameters parameters, params string[] Columns)
		{
			string pk = Reflection.GetPrimaryKey<T>();
			Select<T> result = new Select<T>(parameters);
			result.Columns.Append(Columns);
			result.Where.Equal(pk);
			return result;
		}

	}

}