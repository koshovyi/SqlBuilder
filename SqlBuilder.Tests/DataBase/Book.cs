using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests.DataBaseDemo
{

	[TableName("tab_books")]
	public class Book
	{

		[PrimaryKey]
		[IgnoreAttribute]
		public int ID { get; set; }

		public string Name { get; set; }

		[Column("created_at")]
		[InsertDefault("NOW()")]
		public DateTime CreatedAt {get;set;}

		public int Year { get; set; }


		public int ID_Author { get; set; }

	}

}
