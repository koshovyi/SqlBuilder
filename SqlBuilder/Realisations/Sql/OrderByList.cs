using SqlBuilder.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Sql
{

	public class OrderByList
	{

		private readonly List<OrderBy> _expressions;

		public Format Parameters { get; private set; }

		public IEnumerable<OrderBy> Expressions
		{
			get
			{
				return this._expressions;
			}
		}

		public int Count
		{
			get
			{
				return this._expressions.Count;
			}
		}

		public OrderByList(Format parameters)
		{
			this._expressions = new List<OrderBy>();
			this.Parameters = parameters;
		}

		public void Append(OrderBy expression)
		{
			this._expressions.Add(expression);
		}

		public void Clear()
		{
			this._expressions.Clear();
		}

		public OrderByList Ascending(params string[] columns)
		{
			foreach(string column in columns)
			{
				OrderBy expression = OrderBy.Ascending(column);
				this.Append(expression);
			}
			return this;
		}

		public OrderByList Descending(params string[] columns)
		{
			foreach (string column in columns)
			{
				OrderBy expression = OrderBy.Descending(column);
				this.Append(expression);
			}
			return this;
		}

		public string GetSql(string tableAlias = "")
		{
			StringBuilder sb = new StringBuilder();

			bool sep = false;
			foreach (OrderBy expression in this._expressions)
			{
				if (sep)
					sb.Append(", ");
				else
					sep = true;
				sb.Append(SqlBuilder.FormatColumn(expression.Column, this.Parameters, tableAlias) + " " + expression.GetDirection());
			}

			return sb.ToString();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

	}

}
