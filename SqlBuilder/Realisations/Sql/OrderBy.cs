using SqlBuilder.Enums;

namespace SqlBuilder.Sql
{

	public class OrderBy
	{

		public OrderDirection Direction { get; set; }

		public string Column { get; set; }

		public OrderBy(string column, OrderDirection direction = OrderDirection.ASC)
		{
			this.Column = column;
			this.Direction = direction;
		}

		public string GetDirection()
		{
			switch(this.Direction)
			{
				case OrderDirection.DESC:
					return "DESC";
				default:
				case OrderDirection.ASC:
					return "ASC";
			}
		}

		public static OrderBy Ascending(string column)
		{
			return new OrderBy(column, OrderDirection.ASC);
		}

		public static OrderBy Descending(string column)
		{
			return new OrderBy(column, OrderDirection.DESC);
		}

	}

}
