using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Attributes;

namespace SqlBuilder.Tests.DataBaseDemo
{

	[TableName("tab_authors")]
	public class Author
	{

		[IgnoreInsert]
		[PrimaryKey]
		public int ID { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

	}

}
