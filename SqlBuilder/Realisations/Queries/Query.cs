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

		public Delete<T> Delete(string tableAlias = "")
		{
			return new Delete<T>(this.Parameters, tableAlias);
		}

		public Insert<T> Insert(bool autoMapping = false, string tableAlias = "")
		{
			return new Insert<T>(this.Parameters, autoMapping, tableAlias);
		}

		public Update<T> Update(bool autoMapping = false, string tableAlias = "")
		{
			return new Update<T>(this.Parameters, autoMapping, tableAlias);
		}

		public Select<T> Select(string tableAlias = "")
		{
			return new Select<T>(this.Parameters, tableAlias);
		}

		#endregion

		#region Static methods

		public static Delete<T> CreateDelete(string tableAlias = "")
		{
			return new Delete<T>(SqlBuilder.DefaultFormatter, tableAlias);
		}

		public static Insert<T> CreateInsert(bool autoMapping = false, string tableAlias = "")
		{
			return new Insert<T>(SqlBuilder.DefaultFormatter, autoMapping, tableAlias);
		}

		public static Select<T> CreateSelect(string tableAlias = "")
		{
			return new Select<T>(SqlBuilder.DefaultFormatter, tableAlias);
		}

		public static Update<T> CreateUpdate(bool autoMapping = false, string tableAlias = "")
		{
			return new Update<T>(SqlBuilder.DefaultFormatter, autoMapping, tableAlias);
		}

		#endregion

	}

}