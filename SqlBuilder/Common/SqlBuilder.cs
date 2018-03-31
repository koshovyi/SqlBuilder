using System;
using System.Collections.Generic;
using System.Reflection;

namespace SqlBuilder
{

	public partial class SqlBuilder<T>
	{

		public string TableName { get; private set; }
		public string TableAlias { get; private set; }
		public Interfaces.IWhereList Where { get; set; }
		public Interfaces.IOrderByList OrderBy { get; set; }
		public Parameters Parameters { get; set; }

		public SqlBuilder()
		{
			this.Where = new Where();
			this.OrderBy = new OrderBy();
			this.Parameters = SqlBuilder.Parameters;
			this.TableName = Reflection.GetTableName<T>();
		}

	}

}