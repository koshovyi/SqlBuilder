using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{
	public class OrderBy : IOrderByList
	{
		private List<IOrderBy> _expressions;

		public IParameters Parameters { get; set; }

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

		public OrderBy()
		{
			this._expressions = new List<IOrderBy>();
			this.Parameters = SqlBuilder.Parameters;
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
				IOrderBy expression = OrderByExpression.Ascending(column);
				this.Append(expression);
			}
			return this;
		}

		public IOrderByList Descending(params string[] Columns)
		{
			foreach (string column in Columns)
			{
				IOrderBy expression = OrderByExpression.Descending(column);
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
					sb.Append(',');
				else
					sep = true;
				sb.Append(SqlBuilder.FormatColumn(expression.Column) + " " + expression.GetDirection());
			}

			return sb.ToString();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

	}

}