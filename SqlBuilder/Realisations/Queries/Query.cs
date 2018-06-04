using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SqlBuilder.Attributes;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class Query<T> : IQuery<T>
	{

		public IParameters Parameters { get; set; }

		public Query() : this(SqlBuilder.Parameters)
		{
		}

		public Query(IParameters parameters)
		{
			this.Parameters = SqlBuilder.Parameters;
		}

		#region Methods

		public Delete<T> Delete()
		{
			return new Delete<T>(this.Parameters);
		}

		public Insert<T> Insert()
		{
			return new Insert<T>(this.Parameters);
		}

		public Select<T> Select()
		{
			return new Select<T>(this.Parameters);
		}

		#endregion

		#region Static methods

		public static class Factory
		{

			public static Delete<T> Delete()
			{
				return new Delete<T>(SqlBuilder.Parameters);
			}

			public static Insert<T> Insert(bool AutoMapping = true)
			{
				return new Insert<T>(SqlBuilder.Parameters, AutoMapping);
			}

			public static Select<T> Select()
			{
				return new Select<T>(SqlBuilder.Parameters);
			}

		}

		#endregion

	}

}