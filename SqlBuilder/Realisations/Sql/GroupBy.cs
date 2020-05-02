using SqlBuilder.Interfaces;

namespace SqlBuilder.Sql
{

	public class GroupBy : IGroupBy
	{

		public string Column { get; set; }

		public GroupBy(string column)
		{
			this.Column = column;
		}

	}

}