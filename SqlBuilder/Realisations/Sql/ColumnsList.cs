using SqlBuilder.Interfaces;
using System.Collections.Generic;
using System.Text;

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
					: SqlBuilder.FormatTableAlias(tableAlias, this.Parameters) + ".*";
			}

			StringBuilder sb = new StringBuilder();
			foreach (IColumn column in this.Expressions)
			{
				if (sb.Length > 0)
					sb.Append(", ");
				if (!string.IsNullOrEmpty(tableAlias) && !column.IsRaw)
					sb.Append(SqlBuilder.FormatTableAlias(tableAlias, this.Parameters) + '.');
				if (column.IsRaw)
				{
					//sb.Append('(');
					sb.Append(column.Value);
					//sb.Append(')');
				}
				else
				{
					sb.Append(column.Prefix);
					sb.Append(SqlBuilder.FormatColumn(column.Value, this.Parameters));
					sb.Append(column.Postfix);
				}
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