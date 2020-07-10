using SqlBuilder.Sql;

namespace SqlBuilder.Interfaces
{

	public interface IStatementInsert : IStatementTable
	{

		IColumnsListSimple Columns { get; set; }

		ValueList Values { get; set; }

		IStatementInsert AppendParameters(params string[] parameters);

	}

}
