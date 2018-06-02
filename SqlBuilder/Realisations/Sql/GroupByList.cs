using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Sql
{

	public class GroupByList : IGroupByList
	{

		private readonly List<IGroupBy> _expressions;

		public IParameters Parameters { get; private set; }

		public IColumnsListAggregation Columns { get; private set; }

		public IEnumerable<IGroupBy> Expressions { get; }

		public int Count
		{
			get
			{
				return this._expressions.Count;
			}
		}

		public GroupByList(IParameters parameters, IColumnsListAggregation columns)
		{
			this._expressions = new List<IGroupBy>();
			this.Parameters = parameters;
			this.Columns = columns;
		}

		public IGroupByList Append(IGroupBy expression, bool copyToColumns = false)
		{
			this._expressions.Add(expression);
			if (copyToColumns)
				this.Columns.Append(expression.Column);
			return this;
		}

		public IGroupByList AppendWithColumn(IGroupBy expression, string Column, string ColumnAlias, string Prefix = "", string Postfix = "")
		{
			this._expressions.Add(expression);
			this.Columns.AppendAlias(Column, ColumnAlias, Prefix, Postfix);
			return this;
		}

		public IGroupByList Append(bool copyToColumns = false, params string[] columns)
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

		public void FuncMax(string Name, string Alias = "")
		{
			GroupBy expression = new GroupBy(Name);
			this.AppendWithColumn(expression, Name, Alias, "MAX(", ")");
		}

		public void FuncMin(string Name, string Alias = "")
		{
			GroupBy expression = new GroupBy(Name);
			this.AppendWithColumn(expression, Name, Alias, "MIN(", ")");
		}

		public void FuncCount(string Name, string Alias = "")
		{
			GroupBy expression = new GroupBy(Name);
			this.AppendWithColumn(expression, Name, Alias, "COUNT(", ")");
		}

		public void FuncSum(string Name, string Alias = "")
		{
			GroupBy expression = new GroupBy(Name);
			this.AppendWithColumn(expression, Name, Alias, "SUM(", ")");
		}

		#endregion

		public string GetSql(bool GroupBy = false, string aliasTable = "")
		{
			StringBuilder sb = new StringBuilder();
			if (GroupBy && this._expressions.Count > 0)
				sb.Append("GROUP BY ");

			bool sep = false;
			foreach (IGroupBy expression in this._expressions)
			{
				if (sep)
					sb.Append(", ");
				else
					sep = true;
				sb.Append(SqlBuilder.FormatColumn(expression.Column, this.Parameters));
			}

			return sb.ToString();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

	}

}