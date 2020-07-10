using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Sql
{

	public class SetList
	{

		private readonly List<Set> _expressions;

		public Format Parameters { get; set; }

		public int Count
		{
			get
			{
				return this._expressions.Count;
			}
		}

		public SetList(Format parameters)
		{
			this._expressions = new List<Set>();
			this.Parameters = parameters;
		}

		public SetList Append(Set expression)
		{
			this._expressions.Add(expression);
			return this;
		}

		public SetList Append(params string[] values)
		{
			foreach(string value in values)
			{
				this.Append(new Set(value, this.Parameters.Parameter + value));
			}
			return this;
		}

		public SetList AppendValue(string name, string value)
		{
			Set set = new Set(name, value);
			this.Append(set);
			return this;
		}

		public void Clear()
		{
			this._expressions.Clear();
		}

		public string GetSql(string tableAlias = "")
		{
			StringBuilder sb = new StringBuilder();
			foreach(Set value in this._expressions)
			{
				if (sb.Length > 0)
					sb.Append(", ");
				sb.Append(SqlBuilder.FormatColumn(value.Name, this.Parameters, tableAlias));
				sb.Append('=');
				sb.Append(value.Value);
			}
			return sb.ToString();
		}

	}

}
