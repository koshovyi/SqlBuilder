using SqlBuilder.Interfaces;
using SqlBuilder.Sql;
using SqlBuilder.Templates;

namespace SqlBuilder
{

	public class Select<T> : IStatementSelect
	{

		public IFormatter Formatter { get; set; }

		public Enums.SqlQuery Query { get; private set; }

		public string TableAlias { get; set; }

		public IColumnsListAggregation Columns { get; set; }

		public IWhereList Where { get; set; }

		public IGroupByList GroupBy { get; set; }

		public IOrderByList OrderBy { get; set; }

		public Select(string tableAlias = "") : this(SqlBuilder.DefaultFormatter, tableAlias)
		{
		}

		public Select(IFormatter parameters, string tableAlias = "")
		{
			this.Query = Enums.SqlQuery.Select;
			this.Formatter = parameters;
			this.TableAlias = tableAlias;
			this.Columns = new ColumnsListAggregation(this.Formatter);
			this.Where = new WhereList(this.Formatter);
			this.OrderBy = new OrderByList(this.Formatter);
			this.GroupBy = new GroupByList(this.Formatter, this.Columns);
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

		public static Select<T> SelectAll(params string[] columns)
		{
			Select<T> result = new Select<T>();
			result.Columns.Append(columns);
			return result;
		}

		public static Select<T> SelectWhere(params string[] columns)
		{
			return SelectWhere(SqlBuilder.DefaultFormatter, columns);
		}

		public static Select<T> SelectWhere(IFormatter parameters, params string[] columns)
		{
			string pk = Reflection.GetPrimaryKey<T>();
			Select<T> result = new Select<T>(parameters);
			result.Columns.Append(columns);
			result.Where.Equal(pk);
			return result;
		}

	}

}