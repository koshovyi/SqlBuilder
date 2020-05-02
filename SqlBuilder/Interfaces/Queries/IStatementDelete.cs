namespace SqlBuilder.Interfaces
{

	public interface IStatementDelete : IStatement, IStatementTableAlias
	{

		IWhereList Where { get; set; }

	}

}