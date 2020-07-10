using SqlBuilder.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Sql
{

	public class JoinList
	{

		private readonly List<Join> _expressions;

		#region Properties

		public Format Parameters { get; set; }

		public IEnumerable<Join> Expressions
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

		public JoinList(Format parameters)
		{
			this._expressions = new List<Join>();
			this.Parameters = parameters;
		}

		#endregion

		#region Methods

		public JoinList Append(Join expression)
		{
			this._expressions.Add(expression);
			return this;
		}

		public Join InnerJoin(string table, string tableAlias = "")
		{
			Join join = new Join(this.Parameters, table, tableAlias, Enums.JoinType.INNER);
			this.Append(join);
			return join;
		}

		public Join InnerJoin(string table, string sourceColumn, string destColumn, string tableAlias = "")
		{
			Join join = this.InnerJoin(table, tableAlias);
			join.Append(sourceColumn, destColumn);
			return join;
		}

		public Join LeftJoin(string table, string tableAlias = "")
		{
			Join join = new Join(this.Parameters, table, tableAlias, Enums.JoinType.LEFT);
			this.Append(join);
			return join;
		}

		public Join LeftJoin(string table, string sourceColumn, string destColumn, string tableAlias = "")
		{
			Join join = this.LeftJoin(table, tableAlias);
			join.Append(sourceColumn, destColumn);
			return join;
		}

		public Join RightJoin(string table, string tableAlias = "")
		{
			Join join = new Join(this.Parameters, table, tableAlias, Enums.JoinType.RIGHT);
			this.Append(join);
			return join;
		}

		public Join RightJoin(string table, string sourceColumn, string destColumn, string tableAlias = "")
		{
			Join join = this.RightJoin(table, tableAlias);
			join.Append(sourceColumn, destColumn);
			return join;
		}

		public Join FullJoin(string table, string tableAlias = "")
		{
			Join join = new Join(this.Parameters, table, tableAlias, Enums.JoinType.FULL);
			this.Append(join);
			return join;
		}

		public Join FullJoin(string table, string sourceColumn, string destColumn, string tableAlias = "")
		{
			Join join = this.FullJoin(table, tableAlias);
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
			foreach(Join join in this._expressions)
			{
				if (sb.Length > 0)
					sb.Append(' ');
				sb.Append(join.GetSql(sourceTable));
			}
			return sb.ToString();
		}

	}

}
