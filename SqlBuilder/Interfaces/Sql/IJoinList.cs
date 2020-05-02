using System.Collections.Generic;

namespace SqlBuilder.Interfaces
{

	public interface IJoinList
	{

		IFormatter Parameters { get; }

		IEnumerable<IJoin> Expressions { get; }

		string GetSql(string sourceTable);

		int Count { get; }

		void Clear();

		IJoinList Append(IJoin expression);

		IJoin InnerJoin(string table, string tableAlias = "");
		IJoin InnerJoin(string table, string sourceColumn, string destColumn, string tableAlias = "");

		IJoin LeftJoin(string table, string tableAlias = "");
		IJoin LeftJoin(string table, string sourceColumn, string destColumn, string tableAlias = "");

		IJoin RightJoin(string table, string tableAlias = "");
		IJoin RightJoin(string table, string sourceColumn, string destColumn, string tableAlias = "");

		IJoin FullJoin(string table, string tableAlias = "");
		IJoin FullJoin(string table, string sourceColumn, string destColumn, string tableAlias = "");

	}

}