namespace SqlBuilder.Interfaces
{

	public interface IStatementSelect : IStatement, IStatementTableAlias
	{

		IColumnsListAggregation Columns { get; set; }

		IJoinList Join { get; set; }

		IWhereList Where { get; set; }

		IGroupByList GroupBy { get; set; }

		IOrderByList OrderBy { get; set; }

	}

}