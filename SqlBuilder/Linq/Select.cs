using SqlBuilder.Interfaces;
using SqlBuilder.Sql;
using System;

namespace SqlBuilder.Linq
{

	public static partial class Linq
	{

		public static IStatementSelect Columns(this IStatementSelect q, Action<IColumnsListAggregation> f)
		{
			f.Invoke(q.Columns);
			return q;
		}

		public static IStatementSelect Columns(this IStatementSelect q, params string[] columns)
		{
			q.Columns.Append(columns);
			return q;
		}

		public static IStatementSelect Where(this IStatementSelect q, Action<WhereList> f)
		{
			f.Invoke(q.Where);
			return q;
		}

		public static IStatementSelect Where(this IStatementSelect q, params string[] columns)
		{
			q.Where.Equal(columns);
			return q;
		}

		public static IStatementSelect OrderBy(this IStatementSelect q, Action<OrderByList> f)
		{
			f.Invoke(q.OrderBy);
			return q;
		}

		public static IStatementSelect OrderBy(this IStatementSelect q, params string[] columns)
		{
			q.OrderBy.Ascending(columns);
			return q;
		}

		public static IStatementSelect GroupBy(this IStatementSelect q, Action<GroupByList> f)
		{
			f.Invoke(q.GroupBy);
			return q;
		}

		public static IStatementSelect GroupBy(this IStatementSelect q, bool copyToColumns = false, params string[] columns)
		{
			q.GroupBy.Append(copyToColumns, columns);
			return q;
		}

		public static IStatementSelect Join(this IStatementSelect q, Func<JoinList, Join> f)
		{
			f.Invoke(q.Join);
			return q;
		}

	}

}
