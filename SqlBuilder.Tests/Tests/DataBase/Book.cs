using System;
using SqlBuilder.Attributes;

namespace SqlBuilder.Tests.DataBaseDemo
{

	[TableName("tab_books")]
	public class Book
	{

		[PrimaryKey, IgnoreInsert, IgnoreUpdate]
		public int ID { get; set; }

		[Column("created_at")]
		[InsertDefault("NOW()")]
		public DateTime CreatedAt {get;set;}

		public string Name { get; set; }

		public int Year { get; set; }

		[ForeignKey]
		public int ID_Author { get; set; }

		[ForeignKey]
		public int ID_Publisher { get; set; }

		[ForeignKey]
		public int ID_Shop { get; set; }

	}

}
