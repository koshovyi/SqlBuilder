using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Attributes
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
