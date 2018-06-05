using System;
using System.Collections.Generic;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Sql
{

	public class ColumnsListSimple : ColumnsList, IColumnsListSimple
	{

		public ColumnsListSimple(IFormatter parameters) : base(parameters)
		{
			this.Parameters = parameters;
		}

		public IColumnsListSimple Append(IColumn expression)
		{
			if (expression == null)
				throw new ArgumentNullException(nameof(expression));

			this._expressions.Add(expression);
			return this;
		}

		public IColumnsListSimple Append(params string[] names)
		{
			if (names == null)
				throw new ArgumentNullException(nameof(names));

			foreach (string name in names)
				this.AppendAlias(name, string.Empty);
			return this;
		}

		public IColumnsListSimple AppendAlias(string name, string alias, string prefix = "", string postfix = "")
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