using SqlBuilder.Attributes;

namespace SqlBuilder.Tests.DataBaseDemo
{

	[TableName("tab_pages", "tp")]
	public class Page
	{

		[PrimaryKey(true)]
		public int ID { get; set; }

		[ForeignKey("ident_1")]
		public int ID1 { get; set; }

		[ForeignKey("ident_2")]
		public int ID2 { get; set; }

		public string Name { get; set; }

		public string Value { get; set; }

	}

}