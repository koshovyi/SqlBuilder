using SqlBuilder.Interfaces;
using System;

namespace SqlBuilder.Linq
{

	public static partial class Linq
	{

		public static IStatementUpdate WhereLinq(this IStatementUpdate q, Func<IWhereList, IWhereList> f)
		{
			f.Invoke(q.Where);
			return q;
		}

		public static IStatementUpdate SetsLinq(this IStatementUpdate q, Func<ISetList, ISetList> f)
		{
			f.Invoke(q.Sets);
			return q;
		}

	}

}