using System;

namespace SqlBuilder
{

	public class StatementIgnoreAttribute : Attribute
	{

		public bool Insert { get; set; }
		public bool Update { get; set; }

		public StatementIgnoreAttribute(bool Insert = true, bool Update = true)
		{
			this.Insert = Insert;
			this.Update = Update;
		}

	}

}