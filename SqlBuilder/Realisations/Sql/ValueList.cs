using SqlBuilder.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Sql
{

	public class ValueList : IValueList
	{

		private readonly List<IValue> _expressions;

		public IParameters Parameters { get; set; }

		public int Count
		{
			get
			{
				return this._expressions.Count;
			}
		}

		public ValueList(IParameters parameters)
		{
			this._expressions = new List<IValue>();
			this.Parameters = parameters;
		}

		public IValueList Append(IValue expression)
		{
			this._expressions.Add(expression);
			return this;
		}

		public IValueList Append(params string[] values)
		{
			foreach(string value in values)
			{
				this.Append(new Value(value));
			}
			return this;
		}

		public IValueList AppendParameters(params string[] values)
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
			foreach(IValue value in this._expressions)
			{
				if (sb.Length > 0)
					sb.Append(", ");
				sb.Append(value.Expression);
			}
			return sb.ToString();
		}

	}

}