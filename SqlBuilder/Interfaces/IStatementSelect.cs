using SqlBuilder.Sql;

namespace SqlBuilder.Interfaces
{

	public interface IStatementSelect : IStatementTable
	{

		IColumnsListAggregation Columns { get; set; }

		JoinList Join { get; set; }

		WhereList Where { get; set; }

		GroupByList GroupBy { get; set; }

		OrderByList OrderBy { get; set; }

		string GetSql(bool isSubQuery = false);

	}

}
