using SqlBuilder.Interfaces;
using SqlBuilder.Sql;
using System;

namespace SqlBuilder.Linq
{

	public static partial class Linq
	{

		public static IStatementDelete Where(this IStatementDelete q, Func<WhereList, WhereList> f)
		{
			f.Invoke(q.Where);
			return q;
		}

		public static IStatementDelete Where(this IStatementDelete q, params string[] equals)
		{
			q.Where.Equal(equals);
			return q;
		}

	}

}
