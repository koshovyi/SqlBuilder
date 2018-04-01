using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Enums;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class OrderByExpression : IOrderBy
	{

		public OrderDirection Direction { get; set; }

		public string Column { get; set; }

		public OrderByExpression(string Column, OrderDirection Direction = OrderDirection.ASC)
		{
			this.Column = Column;
			this.Direction = Direction;
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

		public static IOrderBy Ascending(string Column)
		{
			return new OrderByExpression(Column, OrderDirection.ASC);
		}

		public static IOrderBy Descending(string Column)
		{
			return new OrderByExpression(Column, OrderDirection.DESC);
		}

	}

}