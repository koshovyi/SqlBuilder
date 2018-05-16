using System;
using System.Collections.Generic;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class ColumnsList : IColumnsList
	{

		private readonly List<IColumn> _expressions;

		#region Properties

		public IParameters Parameters { get; set; }

		public IEnumerable<IColumn> Expressions
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

		#endregion

		#region Constructor

		public ColumnsList(IParameters parameters)
		{
			this._expressions = new List<IColumn>();
			this.Parameters = parameters;
		}

		#endregion

		public IColumnsList Append(IColumn expression)
		{
			if (expression == null)
				throw new ArgumentNullException(nameof(expression));

			this._expressions.Add(expression);
			return this;
		}

		public IColumnsList Append(params string[] names)
		{
			if (names == null)
				throw new ArgumentNullException(nameof(names));

			foreach (string name in names)
				this.AppendAlias(name, string.Empty);
			return this;
		}

		public IColumnsList AppendAlias(string name, string alias, string prefix = "", string postfix = "")
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

		public void Clear()
		{
			this._expressions.Clear();
		}

		public string GetSql(string aliasTable = "")
		{
			return SqlBuilder.GetColumnsList(this, this.Parameters, aliasTable);
		}

		public override string ToString()
		{
			return this.GetSql();
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