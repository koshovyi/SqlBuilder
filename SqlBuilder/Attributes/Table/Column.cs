using System;

namespace SqlBuilder.Attributes
{

	public class ColumnAttribute : Attribute
	{

		public string ColumnName { get; set; }

		public ColumnAttribute(string columnName)
		{
			this.ColumnName = columnName;
		}

		public override string ToString()
		{
			return this.ColumnName;
		}

	}

}