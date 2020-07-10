using System;

namespace SqlBuilder.Attributes
{

	[AttributeUsage(AttributeTargets.Class)]
	public class TableNameAttribute : Attribute
	{

		public string Name { get; set; }

		public string Alias { get; set; }

		public TableNameAttribute(string tableName) : this(tableName, string.Empty)
		{
		}

		public TableNameAttribute(string tableName, string aliasName)
		{
			this.Name = tableName;
			this.Alias = aliasName;
		}

		public override string ToString()
		{
			return this.Name;
		}

	}

}
