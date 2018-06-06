using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Enums;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Sql
{

	public class OrderBy : IOrderBy
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

		public static IOrderBy Ascending(string column)
		{
			return new OrderBy(column, OrderDirection.ASC);
		}

		public static IOrderBy Descending(string column)
		{
			return new OrderBy(column, OrderDirection.DESC);
		}

	}

}