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
			this.Parameters = ParametersLibrary.MsSql;
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
			StringBuilder sb = new StringBuilder();
			foreach(IColumn column in this._expressions)
			{
				if (sb.Length > 0)
					sb.Append(',');
				if (string.IsNullOrEmpty(column.Alias))
					sb.Append(column.Name);
				else
					sb.Append(column.Name + " as " + column.Alias);
			}
			return sb.ToString();
		}

		public override string ToString()
		{
			return this.GetSql();
		}
	}

}