using SqlBuilder.Interfaces;

namespace SqlBuilder.Sql
{

	public class Column : IColumn
	{

		public string Value { get; set; }

		public string Alias { get; set; }

		public string Prefix { get; set; }

		public string Postfix { get; set; }

		public bool IsRaw { get; set; }

	}

}