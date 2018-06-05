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

		public IFormatter Parameters { get; set; }

		public Query() : this(SqlBuilder.DefaultFormatter)
		{
		}

		public Query(IFormatter parameters)
		{
			this.Parameters = SqlBuilder.DefaultFormatter;
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

		public Update<T> Update()
		{
			return new Update<T>(this.Parameters);
		}

		public Select<T> Select()
		{
			return new Select<T>(this.Parameters);
		}

		#endregion

		#region Static methods

		public static Delete<T> CreateDelete()
		{
			return new Delete<T>(SqlBuilder.DefaultFormatter);
		}

		public static Insert<T> CreateInsert(bool AutoMapping = true)
		{
			return new Insert<T>(SqlBuilder.DefaultFormatter, AutoMapping);
		}

		public static Select<T> CreateSelect()
		{
			return new Select<T>(SqlBuilder.DefaultFormatter);
		}

		public static Update<T> CreateUpdate()
		{
			return new Update<T>(SqlBuilder.DefaultFormatter);
		}

		#endregion

	}

}