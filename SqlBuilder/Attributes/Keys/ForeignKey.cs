using System;

namespace SqlBuilder.Attributes
{

	[AttributeUsage(AttributeTargets.Property)]
	public class ForeignKeyAttribute : Attribute
	{

		public string Name { get; private set; }

		public bool ToLowerCase { get; private set; }

		public ForeignKeyAttribute(bool toLowerCase = false)
		{
			this.Name = string.Empty;
			this.ToLowerCase = toLowerCase;
		}

		public ForeignKeyAttribute(string name)
		{
			this.Name = name;
			this.ToLowerCase = false;
		}

	}

}
