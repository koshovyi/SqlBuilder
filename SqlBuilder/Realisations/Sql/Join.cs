using SqlBuilder.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Sql
{

	public class Join : IJoin
	{

		protected readonly List<IJoinItem> _expressions;

		#region Properties

		public IFormatter Parameters { get; set; }

		public Enums.JoinType Type { get; set; }

		public string Table { get; set; }

		public string TableAlias { get; set; }

		public IEnumerable<IJoinItem> Expressions
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

		#region Constructors

		public Join(string table, string tableAlias = "", Enums.JoinType type = Enums.JoinType.INNER) : this(SqlBuilder.DefaultFormatter, table, tableAlias, type)
		{
		}

		public Join(IFormatter parameters, string table, string tableAlias, Enums.JoinType type)
		{
			this._expressions = new List<IJoinItem>();
			this.Parameters = parameters;
			this.Type = type;
			this.Table = table;
			this.TableAlias = tableAlias;
		}

		#endregion

		public IJoin Append(IJoinItem item)
		{
			this._expressions.Add(item);
			return this;
		}

		public IJoin Append(string sourceColumn, string destColumn)
		{
			IJoinItem item = new JoinItem(sourceColumn, destColumn);
			this._expressions.Add(item);
			return this;
		}

		public IJoin AppendRaw(string rawSql)
		{
			IJoinItem item = new JoinItem(rawSql);
			this._expressions.Add(item);
			return this;
		}

		public void Clear()
		{
			this._expressions.Clear();
		}

		public string GetSql(string sourceTable)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(this.GetJoinType());
			sb.Append(' ');
			sb.Append(SqlBuilder.FormatTable(this.Table, this.Parameters));
			if (!string.IsNullOrEmpty(this.TableAlias))
			{
				sb.Append(" as ");
				sb.Append(SqlBuilder.FormatTableAlias(this.TableAlias, this.Parameters));
			}
			sb.Append(" ON ");

			StringBuilder ex = new StringBuilder();
			foreach (IJoinItem item in this._expressions)
			{
				if (ex.Length > 0)
					ex.Append(" AND ");
				if (item.IsRaw)
					ex.Append(item.Value);
				else
				{
					ex.Append(SqlBuilder.FormatTableAlias(sourceTable, this.Parameters));
					ex.Append('.');
					ex.Append(SqlBuilder.FormatColumn(item.Column, this.Parameters));
					ex.Append('=');
					if(string.IsNullOrEmpty(this.TableAlias))
						ex.Append(SqlBuilder.FormatTable(this.Table, this.Parameters));
					else
						ex.Append(SqlBuilder.FormatTableAlias(this.TableAlias, this.Parameters));
					ex.Append('.');
					ex.Append(SqlBuilder.FormatColumn(item.Value, this.Parameters));
				}
			}
			sb.Append(ex);
			return sb.ToString();
		}

		private string GetJoinType()
		{
			switch (this.Type)
			{
				case Enums.JoinType.RIGHT:
					return "RIGHT JOIN";
				case Enums.JoinType.LEFT:
					return "LEFT JOIN";
				case Enums.JoinType.FULL:
					return "FULL JOIN";
				case Enums.JoinType.INNER:
				case Enums.JoinType.None:
				default:
					return "INNER JOIN";
			}
		}

	}

}