using System;
using System.Collections.Generic;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class ColumnsListAggregation : ColumnsList, IColumnsListAggregation
	{

		public ColumnsListAggregation(IParameters parameters) : base(parameters)
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

		public void FuncMax(string Name, string Alias = "")
		{
			this.AppendAlias(Name, Alias, "MAX(", ")");
		}

		public void FuncMin(string Name, string Alias = "")
		{
			this.AppendAlias(Name, Alias, "MIN(", ")");
		}

		public void FuncCount(string Name, string Alias = "")
		{
			this.AppendAlias(Name, Alias, "COUNT(", ")");
		}

		public void FuncSum(string Name, string Alias = "")
		{
			this.AppendAlias("*", Alias, "SUM(", ")");
		}

	}

}