using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Enums;
using SqlBuilder.Interfaces;

namespace SqlBuilder
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