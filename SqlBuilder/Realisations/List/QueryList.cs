using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class QueryList : Interfaces.IQueryList
	{

		private List<IStatement> _list;

		public IEnumerable<IStatement> Queries
		{
			get
			{
				return this._list;
			}
		}

		public int Count
		{
			get
			{
				return this._list.Count;
			}
		}

		public QueryList()
		{
			this._list = new List<IStatement>();
		}

		public IQueryList Append(params IStatement[] queries)
		{
			foreach(IStatement statement in queries)
			{
				this._list.Add(statement);
			}
			return this;
		}

		public void Clear()
		{
			this._list.Clear();
		}

		public string GetSql()
		{
			StringBuilder sb = new StringBuilder();
			foreach(IStatement statement in this._list)
			{
				sb.AppendLine(statement.GetSql());
			}
			return sb.ToString();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

	}

}