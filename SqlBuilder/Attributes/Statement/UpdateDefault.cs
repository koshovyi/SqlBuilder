using System;

namespace SqlBuilder.Attributes
{

	public class UpdateDefaultAttribute : Attribute
	{

		public string DefaultValue { get; set; }

		public UpdateDefaultAttribute(string defaultValue)
		{
			this.DefaultValue = defaultValue;
		}

	}

}