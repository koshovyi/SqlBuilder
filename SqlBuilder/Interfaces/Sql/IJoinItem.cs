using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IJoinItem
	{

		bool IsRaw { get; }

		string Column { get; set; }

		string Value { get; set; }

	}

}