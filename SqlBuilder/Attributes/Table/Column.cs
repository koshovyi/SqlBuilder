using System;

namespace SqlBuilder.Attributes
{

	[AttributeUsage(AttributeTargets.Property)]
	public class ColumnNameAttribute : Attribute
	{

		public string Name { get; set; }

		public ColumnNameAttribute(string columnName)
		{
			this.Name = columnName;
		}

		public override string ToString()
		{
			return this.Name;
		}

	}

}
