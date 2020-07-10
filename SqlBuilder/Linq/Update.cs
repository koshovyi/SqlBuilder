using SqlBuilder.Interfaces;
using SqlBuilder.Sql;
using System;

namespace SqlBuilder.Linq
{

	public static partial class Linq
	{

		public static IStatementUpdate Where(this IStatementUpdate q, Func<WhereList, WhereList> f)
		{
			f.Invoke(q.Where);
			return q;
		}

		public static IStatementUpdate Where(this IStatementUpdate q, params string [] equals)
		{
			q.Where.Equal(equals);
			return q;
		}

		public static IStatementUpdate Sets(this IStatementUpdate q, Func<SetList, SetList> f)
		{
			f.Invoke(q.Sets);
			return q;
		}

		public static IStatementUpdate Sets(this IStatementUpdate q, params string[] values)
		{
			q.Sets.Append(values);
			return q;
		}

	}

}
