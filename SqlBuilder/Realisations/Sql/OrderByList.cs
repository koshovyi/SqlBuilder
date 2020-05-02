using SqlBuilder.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Sql
{

	public class OrderByList : IOrderByList
	{

		private readonly List<IOrderBy> _expressions;

		public IFormatter Parameters { get; private set; }

		public IEnumerable<IOrderBy> Expressions
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

		public OrderByList(IFormatter parameters)
		{
			this._expressions = new List<IOrderBy>();
			this.Parameters = parameters;
		}

		public void Append(IOrderBy expression)
		{
			this._expressions.Add(expression);
		}

		public void Clear()
		{
			this._expressions.Clear();
		}

		public IOrderByList Ascending(params string[] columns)
		{
			foreach(string column in columns)
			{
				IOrderBy expression = OrderBy.Ascending(column);
				this.Append(expression);
			}
			return this;
		}

		public IOrderByList Descending(params string[] columns)
		{
			foreach (string column in columns)
			{
				IOrderBy expression = OrderBy.Descending(column);
				this.Append(expression);
			}
			return this;
		}

		public string GetSql(string tableAlias = "")
		{
			StringBuilder sb = new StringBuilder();

			bool sep = false;
			foreach (IOrderBy expression in this._expressions)
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