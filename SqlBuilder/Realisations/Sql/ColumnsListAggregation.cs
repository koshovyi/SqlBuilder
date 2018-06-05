using System;
using System.Collections.Generic;
using SqlBuilder.Interfaces;

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
				Name = name,
				Alias = alias,
				Postfix = postfix,
				Prefix = prefix,
			};
			this.Append(column);
			return this;
		}

		public IColumnsListAggregation FuncMax(string Name, string Alias = "")
		{
			this.AppendAlias(Name, Alias, "MAX(", ")");
			return this;
		}

		public IColumnsListAggregation FuncMin(string Name, string Alias = "")
		{
			this.AppendAlias(Name, Alias, "MIN(", ")");
			return this;
		}

		public IColumnsListAggregation FuncCount(string Name, string Alias = "")
		{
			this.AppendAlias(Name, Alias, "COUNT(", ")");
			return this;
		}

		public IColumnsListAggregation FuncSum(string Name, string Alias = "")
		{
			this.AppendAlias("*", Alias, "SUM(", ")");
			return this;
		}

	}

}