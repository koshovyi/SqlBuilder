using System;

namespace SqlBuilder.Attributes
{

	[AttributeUsage(AttributeTargets.Property)]
	public class IgnoreUpdateAttribute : Attribute
	{

		public IgnoreUpdateAttribute()
		{
		}

	}

}
