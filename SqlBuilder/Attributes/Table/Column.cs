using System;

namespace SqlBuilder.Attributes
{

	public class ColumnAttribute : Attribute
	{

		public string ColumnName { get; set; }

		public ColumnAttribute(string ColumnName)
		{
			this.ColumnName = ColumnName;
		}

		public override string ToString()
		{
			return this.ColumnName;
		}

	}

}