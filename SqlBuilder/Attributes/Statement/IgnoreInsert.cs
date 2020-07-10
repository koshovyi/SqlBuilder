using System;

namespace SqlBuilder.Attributes
{

	[AttributeUsage(AttributeTargets.Property)]
	public class IgnoreInsertAttribute : Attribute
	{

		public IgnoreInsertAttribute()
		{
		}

	}

}
