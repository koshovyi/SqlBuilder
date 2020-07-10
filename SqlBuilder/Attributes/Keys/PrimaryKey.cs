using System;

namespace SqlBuilder.Attributes
{

	[AttributeUsage(AttributeTargets.Property)]
	public class PrimaryKeyAttribute : Attribute
	{

		public string Name { get; private set; }

		public bool ToLowerCase { get; private set; }

		public PrimaryKeyAttribute(bool toLowerCase = false)
		{
			this.Name = string.Empty;
			this.ToLowerCase = toLowerCase;
		}

		public PrimaryKeyAttribute(string name)
		{
			this.Name = name;
			this.ToLowerCase = false;
		}

	}

}
