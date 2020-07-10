using SqlBuilder.Interfaces;
using System;

namespace SqlBuilder.Sql
{

	public class ColumnsListSimple : ColumnsList, IColumnsListSimple
	{

		internal ColumnsListSimple(Format parameters) : base(parameters)
		{
			this.Parameters = parameters;
		}

		public IColumnsListSimple Append(Column expression)
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
				Value = name,
				Alias = alias,
				Postfix = postfix,
				Prefix = prefix,
				IsRaw = false,
			};
			this.Append(column);
			return this;
		}

		public IColumnsListSimple Raw(string rawSql, string alias = "")
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

		public IColumnsListSimple Raw(params string[] rawSql)
		{
			foreach(string sql in rawSql)
			{
				this.Raw(sql);
			}
			return this;
		}

		public IColumnsListSimple SubQuery(IStatementSelect select, string alias = "")
		{
			if (!string.IsNullOrEmpty(alias))
				alias = this.Parameters.AliasOperator + SqlBuilder.FormatColumnAlias(alias, this.Parameters);
			this.Raw('(' + select.GetSql() + ')' + alias);
			return this;
		}

	}

}
