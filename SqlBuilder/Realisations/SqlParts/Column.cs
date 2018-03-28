using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder
{

	public class Column : Interfaces.IColumn
	{
		public string Name { get; set; }
		public string Alias { get; set; }
	}

}