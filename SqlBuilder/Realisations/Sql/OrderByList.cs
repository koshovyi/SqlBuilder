using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Sql
{

	public class OrderByList : IOrderByList
	{

		private readonly List<IOrderBy> _expressions;

		public IParameters Parameters { get; private set; }

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

		public OrderByList(IParameters parameters)
		{
			this._expressions = new List<IOrderBy>();
			this.Parameters = parameters;
		}

		public void Append(IOrderBy Expression)
		{
			this._expressions.Add(Expression);
		}

		public void Clear()
		{
			this._expressions.Clear();
		}

		public IOrderByList Ascending(params string[] Columns)
		{
			foreach(string column in Columns)
			{
				IOrderBy expression = OrderBy.Ascending(column);
				this.Append(expression);
			}
			return this;
		}

		public IOrderByList Descending(params string[] Columns)
		{
			foreach (string column in Columns)
			{
				IOrderBy expression = OrderBy.Descending(column);
				this.Append(expression);
			}
			return this;
		}

		public string GetSql(bool OrderBy = false)
		{
			StringBuilder sb = new StringBuilder();
			if (OrderBy && this._expressions.Count > 0)
				sb.Append("ORDER BY ");

			bool sep = false;
			foreach (IOrderBy expression in this._expressions)
			{
				if (sep)
					sb.Append(", ");
				else
					sep = true;
				sb.Append(SqlBuilder.FormatColumn(expression.Column, this.Parameters) + " " + expression.GetDirection());
			}

			return sb.ToString();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

	}

}