using System;

namespace SqlBuilder.Attributes
{

	public class TableNameAttribute : Attribute
	{

		public string TableName { get; set; }

		public TableNameAttribute(string tableName)
		{
			this.TableName = tableName;
		}

		public override string ToString()
		{
			return this.TableName;
		}

	}

}