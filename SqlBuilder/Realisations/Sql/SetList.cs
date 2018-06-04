using SqlBuilder.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Sql
{

	public class SetList : ISetList
	{

		private readonly List<ISet> _expressions;

		public IParameters Parameters { get; set; }

		public int Count
		{
			get
			{
				return this._expressions.Count;
			}
		}

		public SetList(IParameters parameters)
		{
			this._expressions = new List<ISet>();
			this.Parameters = parameters;
		}

		public ISetList Append(ISet expression)
		{
			this._expressions.Add(expression);
			return this;
		}

		public ISetList Append(params string[] values)
		{
			foreach(string value in values)
			{
				this.Append(new Set(value, this.Parameters.Parameter + value));
			}
			return this;
		}

		public ISetList Append(string name, string value)
		{
			ISet set = new Set(name, value);
			this.Append(set);
			return this;
		}

		public void Clear()
		{
			this._expressions.Clear();
		}

		public string GetSql()
		{
			StringBuilder sb = new StringBuilder();
			foreach(ISet value in this._expressions)
			{
				if (sb.Length > 0)
					sb.Append(", ");
				sb.Append(SqlBuilder.FormatColumn(value.Name, this.Parameters));
				sb.Append('=');
				sb.Append(value.Value);
			}
			return sb.ToString();
		}

	}

}