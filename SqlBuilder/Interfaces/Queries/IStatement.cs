namespace SqlBuilder.Interfaces
{

	public interface IStatement
	{

		IFormatter Formatter { get; set; }

		Enums.SqlQuery Query { get; }

		string GetSql();

	}

	public interface IStatementTableAlias
	{

		string TableAlias { get; set; }

	}

}