using SqlBuilder.Interfaces;
using System;

namespace SqlBuilder.Sql
{

	public class ColumnsListAggregation : ColumnsList, IColumnsListAggregation
	{

		public ColumnsListAggregation(IFormatter parameters) : base(parameters)
		{
			this.Parameters = parameters;
		}

		public IColumnsListAggregation Append(IColumn expression)
		{
			if (expression == null)
				throw new ArgumentNullException(nameof(expression));

			this._expressions.Add(expression);
			return this;
		}

		public IColumnsListAggregation Append(params string[] names)
		{
			if (names == null)
				throw new ArgumentNullException(nameof(names));

			foreach (string name in names)
				this.AppendAlias(name, string.Empty);
			return this;
		}

		public IColumnsListAggregation AppendAlias(string name, string alias, string prefix = "", string postfix = "")
		{
			Column column = new Column()
			{
				Value = name,
				Alias = alias,
				Postfix = postfix,
				Prefix = prefix,
				IsRaw = false,
			};
			this.Append(column);
			return this;
		}

		public IColumnsListAggregation Raw(string rawSql, string alias = "")
		{
			Column column = new Column()
			{
				Value = rawSql,
				Alias = alias,
				Postfix = string.Empty,
				Prefix = string.Empty,
				IsRaw = true,
			};
			this.Append(column);
			return this;
		}

		public IColumnsListAggregation Raw(params string[] rawSql)
		{
			foreach(string sql in rawSql)
			{
				this.Raw(sql);
			}
			return this;
		}

		public IColumnsListAggregation FuncMax(string name, string aliasName = "")
		{
			this.AppendAlias(name, aliasName, "MAX(", ")");
			return this;
		}

		public IColumnsListAggregation FuncMin(string name, string aliasName = "")
		{
			this.AppendAlias(name, aliasName, "MIN(", ")");
			return this;
		}

		public IColumnsListAggregation FuncCount(string name, string aliasName = "")
		{
			this.AppendAlias(name, aliasName, "COUNT(", ")");
			return this;
		}

		public IColumnsListAggregation FuncSum(string name, string aliasName = "")
		{
			this.AppendAlias("*", aliasName, "SUM(", ")");
			return this;
		}

	}

}