namespace SqlBuilder.Sql
{

	public class Column
	{

		public string Value { get; set; }

		public string Alias { get; set; }

		public string Prefix { get; set; }

		public string Postfix { get; set; }

		public bool IsRaw { get; set; }

		internal Column()
		{
		}

	}

}
