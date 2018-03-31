using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class Columns : Interfaces.IColumnsList
	{
		private List<IColumn> _expressions;

		public IParameters Parameters { get; set; }

		public IEnumerable<IColumn> Expressions
		{
			get
			{
				return this._expressions;
			}
		}

		public Columns()
		{
			this._expressions = new List<IColumn>();
			this.Parameters = SqlBuilder.Parameters;
		}

		public IColumnsList Append(IColumn Expression)
		{
			this._expressions.Add(Expression);
			return this;
		}

		public IColumnsList Append(params string[] Names)
		{
			foreach(string name in Names)
				this.AppendAlias(name, string.Empty);
			return this;
		}

		public IColumnsList Append(string Name)
		{
			this.AppendAlias(Name, string.Empty);
			return this;
		}

		public IColumnsList AppendAlias(string Name, string Alias)
		{
			Column column = new Column()
			{
				Name = Name,
				Alias = Alias,
			};
			this.Append(column);
			return this;
		}

		public int Count
		{
			get
			{
				return this._expressions.Count;
			}
		}

		public void Clear()
		{
			this._expressions.Clear();
		}

		public string GetSql()
		{
			return SqlBuilder.GetColumnsList(this);
		}

		public override string ToString()
		{
			return this.GetSql();
		}
	}

}