namespace SqlBuilder.Interfaces
{

	public interface IStatementInsert : IStatement, IStatementTableAlias
	{

		IColumnsListSimple Columns { get; set; }

		IValueList Values { get; set; }

		IStatementInsert AppendParameters(params string[] parameters);

	}

}