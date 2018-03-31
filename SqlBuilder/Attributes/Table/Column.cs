using System;

namespace SqlBuilder.Attributes
{

	public class ColumnAttribute : Attribute
	{

		public string ColumnName { get; set; }

		public bool Escape { get; set; }

		public ColumnAttribute(string ColumnName, bool Escape = true)
		{
			this.ColumnName = ColumnName;
			this.Escape = Escape;
		}

		public override string ToString()
		{
			return this.ColumnName;
		}

	}

}