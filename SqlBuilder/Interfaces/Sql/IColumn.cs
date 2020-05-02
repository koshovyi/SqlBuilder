namespace SqlBuilder.Interfaces
{

	public interface IColumn
	{

		string Value { get; set; }

		string Prefix { get; set; }

		string Postfix { get; set; }

		string Alias { get; set; }

		bool IsRaw { get; set; }

	}

}