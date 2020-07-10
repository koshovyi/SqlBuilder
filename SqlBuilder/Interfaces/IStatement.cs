namespace SqlBuilder.Interfaces
{

	public interface IStatement
	{

		Format Format { get; set; }

		Enums.SqlQuery Query { get; }

		string GetSql();

	}

	public interface IStatementTable : IStatement
	{

		string TableAlias { get; set; }

		string TableName { get; set; }

	}

}
