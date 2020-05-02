using SqlBuilder.Interfaces;
using System;

namespace SqlBuilder.Linq
{

	public static partial class Linq
	{

		public static IStatementDelete WhereLinq(this IStatementDelete q, Func<IWhereList, IWhereList> f)
		{
			f.Invoke(q.Where);
			return q;
		}

	}

}