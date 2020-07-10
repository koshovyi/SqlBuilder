using System;

namespace SqlBuilder.Attributes
{

	[AttributeUsage(AttributeTargets.Property)]
	public class InsertDefaultAttribute : Attribute
	{

		public string DefaultValue { get; set; }

		public InsertDefaultAttribute(string defaultValue)
		{
			this.DefaultValue = defaultValue;
		}

	}

}
