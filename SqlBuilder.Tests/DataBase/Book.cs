using System;
using SqlBuilder.Attributes;

namespace SqlBuilder.Tests.DataBaseDemo
{

	[TableName("tab_books")]
	public class Book
	{

		[Ignore]
		[PrimaryKey]
		public int ID { get; set; }

		[Column("created_at")]
		[InsertDefault("NOW()")]
		public DateTime CreatedAt {get;set;}

		public string Name { get; set; }

		public int Year { get; set; }

		public int ID_Author { get; set; }

	}

}
