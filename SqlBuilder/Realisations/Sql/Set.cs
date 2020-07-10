namespace SqlBuilder.Sql
{

	public class Set
	{

		public string Name { get; set; }

		public string Value { get; set; }

		public Set(string name, string value)
		{
			this.Name = name;
			this.Value = value;
		}

	}

}
