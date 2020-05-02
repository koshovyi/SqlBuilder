using SqlBuilder.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Sql
{

	public class JoinList : IJoinList
	{

		private readonly List<IJoin> _expressions;

		#region Properties

		public IFormatter Parameters { get; set; }

		public IEnumerable<IJoin> Expressions
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

		public JoinList(IFormatter parameters)
		{
			this._expressions = new List<IJoin>();
			this.Parameters = parameters;
		}

		#endregion

		#region Methods

		public IJoinList Append(IJoin expression)
		{
			this._expressions.Add(expression);
			return this;
		}

		public IJoin InnerJoin(string table, string tableAlias = "")
		{
			IJoin join = new Join(table, tableAlias, Enums.JoinType.INNER);
			this.Append(join);
			return join;
		}

		public IJoin InnerJoin(string table, string sourceColumn, string destColumn, string tableAlias = "")
		{
			IJoin join = this.InnerJoin(table, tableAlias);
			join.Append(sourceColumn, destColumn);
			return join;
		}

		public IJoin LeftJoin(string table, string tableAlias = "")
		{
			IJoin join = new Join(table, tableAlias, Enums.JoinType.LEFT);
			this.Append(join);
			return join;
		}

		public IJoin LeftJoin(string table, string sourceColumn, string destColumn, string tableAlias = "")
		{
			IJoin join = this.LeftJoin(table, tableAlias);
			join.Append(sourceColumn, destColumn);
			return join;
		}

		public IJoin RightJoin(string table, string tableAlias = "")
		{
			IJoin join = new Join(table, tableAlias, Enums.JoinType.RIGHT);
			this.Append(join);
			return join;
		}

		public IJoin RightJoin(string table, string sourceColumn, string destColumn, string tableAlias = "")
		{
			IJoin join = this.RightJoin(table, tableAlias);
			join.Append(sourceColumn, destColumn);
			return join;
		}

		public IJoin FullJoin(string table, string tableAlias = "")
		{
			IJoin join = new Join(table, tableAlias, Enums.JoinType.FULL);
			this.Append(join);
			return join;
		}

		public IJoin FullJoin(string table, string sourceColumn, string destColumn, string tableAlias = "")
		{
			IJoin join = this.FullJoin(table, tableAlias);
			join.Append(sourceColumn, destColumn);
			return join;
		}

		#endregion

		public void Clear()
		{
			this._expressions.Clear();
		}

		public string GetSql(string sourceTable)
		{
			StringBuilder sb = new StringBuilder();
			foreach(IJoin join in this._expressions)
			{
				if (sb.Length > 0)
					sb.Append(' ');
				sb.Append(join.GetSql(sourceTable));
			}
			return sb.ToString();
		}

	}

}