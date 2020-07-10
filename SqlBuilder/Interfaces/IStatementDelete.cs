using SqlBuilder.Sql;

namespace SqlBuilder.Interfaces
{

	public interface IStatementDelete : IStatementTable
	{

		WhereList Where { get; set; }

	}

}
