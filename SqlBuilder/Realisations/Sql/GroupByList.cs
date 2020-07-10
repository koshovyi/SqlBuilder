using SqlBuilder.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Sql
{

	public class GroupByList
	{

		private readonly List<GroupBy> _expressions;

		public Format Parameters { get; private set; }

		public IColumnsListAggregation Columns { get; private set; }

		public IEnumerable<GroupBy> Expressions { get; }

		public int Count
		{
			get
			{
				return this._expressions.Count;
			}
		}

		internal GroupByList(Format parameters, IColumnsListAggregation columns)
		{
			this._expressions = new List<GroupBy>();
			this.Parameters = parameters;
			this.Columns = columns;
		}

		public GroupByList Append(GroupBy expression, bool copyToColumns = false)
		{
			this._expressions.Add(expression);
			if (copyToColumns)
				this.Columns.Append(expression.Column);
			return this;
		}

		public GroupByList AppendWithColumn(GroupBy expression, string column, string columnAlias, string prefix = "", string postfix = "")
		{
			this._expressions.Add(expression);
			this.Columns.AppendAlias(column, columnAlias, prefix, postfix);
			return this;
		}

		public GroupByList Append(bool copyToColumns, params string[] columns)
		{
			foreach (string column in columns)
			{
				GroupBy expression = new GroupBy(column);
				this.Append(expression, copyToColumns);
			}
			return this;
		}

		public void Clear()
		{
			this._expressions.Clear();
		}

		#region Aggregation

		public GroupByList FuncMax(string name, string aliasName = "")
		{
			GroupBy expression = new GroupBy(name);
			this.AppendWithColumn(expression, name, aliasName, "MAX(", ")");
			return this;
		}

		public GroupByList FuncMin(string name, string aliasName = "")
		{
			GroupBy expression = new GroupBy(name);
			this.AppendWithColumn(expression, name, aliasName, "MIN(", ")");
			return this;
		}

		public GroupByList FuncCount(string name, string aliasName = "")
		{
			GroupBy expression = new GroupBy(name);
			this.AppendWithColumn(expression, name, aliasName, "COUNT(", ")");
			return this;
		}

		public GroupByList FuncSum(string name, string aliasName = "")
		{
			GroupBy expression = new GroupBy(name);
			this.AppendWithColumn(expression, name, aliasName, "SUM(", ")");
			return this;
		}

		#endregion

		public string GetSql(string tableAlias = "")
		{
			StringBuilder sb = new StringBuilder();

			bool sep = false;
			foreach (GroupBy expression in this._expressions)
			{
				if (sep)
					sb.Append(", ");
				else
					sep = true;
				sb.Append(SqlBuilder.FormatColumn(expression.Column, this.Parameters, tableAlias));
			}

			return sb.ToString();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

	}

}
