using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder
{

	public class InsertDefaultAttribute : Attribute
	{

		public string Default { get; set; }

		public InsertDefaultAttribute(string Default)
		{
			this.Default = Default;
		}

	}

}
