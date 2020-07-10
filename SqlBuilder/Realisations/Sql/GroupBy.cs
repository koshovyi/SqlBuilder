namespace SqlBuilder.Sql
{

	public class GroupBy
	{

		public string Column { get; set; }

		internal GroupBy(string column)
		{
			this.Column = column;
		}

	}

}
