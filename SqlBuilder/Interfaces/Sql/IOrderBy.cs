using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IOrderBy
	{

		Enums.OrderDirection Direction { get; set; }

		string Column { get; }

		string GetDirection();

	}

}