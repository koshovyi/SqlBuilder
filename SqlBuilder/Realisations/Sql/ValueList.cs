using SqlBuilder.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Sql
{

	public class ValueList
	{

		private readonly List<Value> _expressions;

		public Format Parameters { get; set; }

		public int Count
		{
			get
			{
				return this._expressions.Count;
			}
		}

		public ValueList(Format parameters)
		{
			this._expressions = new List<Value>();
			this.Parameters = parameters;
		}

		public ValueList Append(Value expression)
		{
			this._expressions.Add(expression);
			return this;
		}

		public ValueList Append(params string[] values)
		{
			foreach(string value in values)
			{
				this.Append(new Value(value));
			}
			return this;
		}

		public ValueList AppendParameters(params string[] values)
		{
			foreach (string value in values)
			{
				this.Append(new Value(this.Parameters.Parameter + value));
			}
			return this;
		}

		public void Clear()
		{
			this._expressions.Clear();
		}

		public string GetSql()
		{
			StringBuilder sb = new StringBuilder();
			foreach(Value value in this._expressions)
			{
				if (sb.Length > 0)
					sb.Append(", ");
				sb.Append(value.Expression);
			}
			return sb.ToString();
		}

	}

}
