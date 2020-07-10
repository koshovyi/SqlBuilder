using SqlBuilder.Interfaces;
using SqlBuilder.Sql;
using System;

namespace SqlBuilder.Linq
{

	public static partial class Linq
	{

		public static IStatementInsert Columns(this IStatementInsert q, Func<IColumnsListSimple, IColumnsListSimple> f)
		{
			f.Invoke(q.Columns);
			return q;
		}

		public static IStatementInsert Columns(this IStatementInsert q, params string[] columns)
		{
			q.Columns.Append(columns);
			return q;
		}

		public static IStatementInsert Values(this IStatementInsert q, Func<ValueList, ValueList> f)
		{
			f.Invoke(q.Values);
			return q;
		}

		public static IStatementInsert Values(this IStatementInsert q, params string[] values)
		{
			q.Values.Append(values);
			return q;
		}

	}

}
