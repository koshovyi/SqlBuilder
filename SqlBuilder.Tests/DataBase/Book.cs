using System;
using SqlBuilder.Attributes;

namespace SqlBuilder.Tests.DataBaseDemo
{

	[TableName("tab_books")]
	public class Book
	{

		[PrimaryKey, IgnoreInsert, IgnoreUpdate]
		public int ID { get; set; }

		[ColumnName("created_at")]
		[InsertDefault("NOW()")]
		public DateTime CreatedAt {get;set;}

		[ColumnName("updated_at")]
		[UpdateDefault("NOW()")]
		public DateTime UpdatedAt { get; set; }

		public string Name { get; set; }

		public int Year { get; set; }

		[ForeignKey]
		public int ID_Author { get; set; }

		[ForeignKey]
		public int ID_Publisher { get; set; }

		[ForeignKey(true)]
		public int ID_Custom1 { get; set; }

		[ForeignKey("customField")]
		public int ID_Custom2 { get; set; }

		[ForeignKey]
		public int ID_Shop { get; set; }

	}

}
