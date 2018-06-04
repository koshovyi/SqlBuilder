using System;
using SqlBuilder;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Linq
{

	public static partial class Linq
	{

		public static IStatementInsert ColumnsLinq(this IStatementInsert q, Func<IColumnsListSimple, IColumnsListSimple> f)
		{
			f.Invoke(q.Columns);
			return q;
		}

		public static IStatementInsert ValuesLinq(this IStatementInsert q, Func<IValueList, IValueList> f)
		{
			f.Invoke(q.Values);
			return q;
		}

	}

}