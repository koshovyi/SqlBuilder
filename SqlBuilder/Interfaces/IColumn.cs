using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IColumn
	{

		string Name { get; set; }

		string Prefix { get; set; }

		string Postfix { get; set; }

		string Alias { get; set; }

	}

}