using System;
using System.Collections.Generic;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class ColumnsList : IColumnsList
	{

		protected readonly List<IColumn> _expressions;

		#region Properties

		public IParameters Parameters { get; set; }

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

		public ColumnsList(IParameters parameters)
		{
			this._expressions = new List<IColumn>();
			this.Parameters = parameters;
		}

		#endregion

		public void Clear()
		{
			this._expressions.Clear();
		}

		public string GetSql(string aliasTable = "")
		{
			return SqlBuilder.GetColumnsList(this, this.Parameters, aliasTable);
		}

		public override string ToString()
		{
			return this.GetSql();
		}

	}

}