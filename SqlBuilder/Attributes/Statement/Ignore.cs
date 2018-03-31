using System;

namespace SqlBuilder.Attributes
{

	public class IgnoreAttribute : Attribute
	{

		public bool Insert { get; set; }
		public bool Update { get; set; }

		public IgnoreAttribute(bool Insert = true, bool Update = true)
		{
			this.Insert = Insert;
			this.Update = Update;
		}

	}

}