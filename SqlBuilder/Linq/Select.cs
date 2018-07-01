using System;
using SqlBuilder;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Linq
{

	public static partial class Linq
	{

		public static IStatementSelect ColumnsLinq(this IStatementSelect q, Func<IColumnsListAggregation, IColumnsListAggregation> f)
		{
			f.Invoke(q.Columns);
			return q;
		}

		public static IStatementSelect WhereLinq(this IStatementSelect q, Func<IWhereList, IWhereList> f)
		{
			f.Invoke(q.Where);
			return q;
		}

		public static IStatementSelect OrderByLinq(this IStatementSelect q, Func<IOrderByList, IOrderByList> f)
		{
			f.Invoke(q.OrderBy);
			return q;
		}

		public static IStatementSelect GroupByLinq(this IStatementSelect q, Func<IGroupByList, IGroupByList> f)
		{
			f.Invoke(q.GroupBy);
			return q;
		}

		public static IStatementSelect JoinLinq(this IStatementSelect q, Func<IJoinList, IJoin> f)
		{
			f.Invoke(q.Join);
			return q;
		}

	}

}