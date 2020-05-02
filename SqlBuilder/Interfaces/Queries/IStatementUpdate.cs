namespace SqlBuilder.Interfaces
{

	public interface IStatementUpdate : IStatement, IStatementTableAlias
	{

		ISetList Sets { get; set; }

		IWhereList Where { get; set; }

	}

}