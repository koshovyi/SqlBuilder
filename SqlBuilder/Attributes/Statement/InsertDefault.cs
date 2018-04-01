using System;

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