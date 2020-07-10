using SqlBuilder.Sql;

namespace SqlBuilder.Interfaces
{

	public interface IStatementUpdate : IStatementTable
	{

		SetList Sets { get; set; }

		WhereList Where { get; set; }

	}

}
