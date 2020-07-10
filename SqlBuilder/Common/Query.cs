using SqlBuilder.Interfaces;
using SqlBuilder.Linq;

namespace SqlBuilder
{

	public class Query
	{

		public static Format DefaultFormat { get; set; }

		public Format Format { get; set; }

		public Query() : this(DefaultFormat)
		{
		}

		public Query(Format formatter)
		{
			this.Format = formatter;
		}

		//Raw
		public IStatement Raw(string raw) => new Raw(this.Format, raw);

		//Delete
		public IStatementDelete Delete(string tableName) => new Delete(this.Format, tableName, string.Empty);
		public IStatementDelete Delete(string tableName, string tableAlias) => new Delete(this.Format, tableName, tableAlias);

		//Insert
		public IStatementInsert Insert(string tableName) => new Insert(this.Format, tableName);

		//Update
		public IStatementUpdate Update(string tableName, string tableAlias = "") => new Update(this.Format, tableName, tableAlias);
		
		//Select
		public IStatementSelect Select(string tableName, string tableAlias = "") => new Select(this.Format, tableName, tableAlias);
		public IStatementSelect SelectWherePK(string tableName, string tableAlias = "") => SelectWherePK(tableName, Constants.PK_KEY_DEFAULT, tableAlias);
		public IStatementSelect SelectWherePK(string tableName, string pkName, string tableAlias = "") => new Select(this.Format, tableName, tableAlias).Where(pkName);

	}

	public class Query<T> : Query
	{

		public Query(Format format) : base(format)
		{
		}

		//Delete
		public IStatementDelete Delete() => new Delete<T>(this.Format, string.Empty);
		public new IStatementDelete Delete(string tableAlias) => new Delete<T>(this.Format, tableAlias);

		//Insert
		public IStatementInsert Insert() => new Insert<T>(this.Format);

		//Update
		public IStatementUpdate Update(string tableAlias = "") => new Update<T>(this.Format, tableAlias);

		//Select
		public IStatementSelect Select(string tableAlias = "") => new Select<T>(this.Format, tableAlias);
		public IStatementSelect SelectWherePK(string tableAlias = "") => SelectWherePK(Reflection.GetPrimaryKey<T>(), tableAlias);
		public new IStatementSelect SelectWherePK(string pkName, string tableAlias = "") => new Select<T>(this.Format, tableAlias).Where(pkName);

	}

}
