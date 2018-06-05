using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Sql
{

	public class ColumnsList : IColumnsList
	{

		protected readonly List<IColumn> _expressions;

		#region Properties

		public IFormatter Parameters { get; set; }

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

		public ColumnsList(IFormatter parameters)
		{
			this._expressions = new List<IColumn>();
			this.Parameters = parameters;
		}

		#endregion

		public void Clear()
		{
			this._expressions.Clear();
		}

		public string GetSql(string tableAlias = "")
		{
			if (this.Count == 0)
			{
				return string.IsNullOrEmpty(tableAlias)
					? "*"
					: SqlBuilder.FormatAlias(tableAlias, this.Parameters) + ".*";
			}

			StringBuilder sb = new StringBuilder();
			foreach (IColumn column in this.Expressions)
			{
				if (sb.Length > 0)
					sb.Append(", ");
				if (!string.IsNullOrEmpty(tableAlias))
					sb.Append(SqlBuilder.FormatAlias(tableAlias, this.Parameters));
				sb.Append(column.Prefix);
				sb.Append(SqlBuilder.FormatColumn(column.Name, this.Parameters));
				sb.Append(column.Postfix);
				if (!string.IsNullOrEmpty(column.Alias))
				{
					sb.Append(" as ");
					sb.Append(this.Parameters.AliasEscape);
					sb.Append(column.Alias);
					sb.Append(this.Parameters.AliasEscape);
				}
			}
			return sb.ToString();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

	}

}