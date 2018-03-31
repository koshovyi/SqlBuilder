using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IColumn
	{
		string Name { get; set; }
		string Alias { get; set; }
	}

}