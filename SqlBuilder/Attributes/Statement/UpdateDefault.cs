using System;

namespace SqlBuilder.Attributes
{

	[AttributeUsage(AttributeTargets.Property)]
	public class UpdateDefaultAttribute : Attribute
	{

		public string DefaultValue { get; set; }

		public UpdateDefaultAttribute(string defaultValue)
		{
			this.DefaultValue = defaultValue;
		}

	}

}
