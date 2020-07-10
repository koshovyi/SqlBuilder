using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class Raw : IStatement
	{

		public Format Format { get; set; }

		public Enums.SqlQuery Query { get; private set; }

		public string Value { get; set; }

		public Raw(Format parameters, string raw)
		{
			this.Query = Enums.SqlQuery.Raw;
			this.Format = parameters;
			this.Value = raw;
		}

		public string GetSql()
		{
			return this.Value;
		}

		public override string ToString()
		{
			return this.GetSql();
		}

	}

}
