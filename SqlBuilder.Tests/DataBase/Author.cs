using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests.DataBaseDemo
{

	[TableName("tab_authors")]
	public class Author
	{

		[PrimaryKey]
		[StatementIgnore]
		public int ID { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

	}

}
