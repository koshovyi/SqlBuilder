using Microsoft.VisualStudio.TestTools.UnitTesting;
using reflection = global::SqlBuilder.Reflection;

namespace SqlBuilder.Tests
{
	[TestClass]
	public class ReflectionTests
	{

		[TestMethod]
		[TestCategory("Reflection")]
		public void GetTableNamesAndAliases()
		{
			string tab_books = reflection.GetTableName<DataBaseDemo.Book>();
			string tab_books_alias = reflection.GetTableAlias<DataBaseDemo.Book>();
			Assert.AreEqual("tab_books", tab_books);
			Assert.AreEqual(string.Empty, tab_books_alias);

			string tab_authors = reflection.GetTableName<DataBaseDemo.Author>();
			string tab_authors_alias = reflection.GetTableAlias<DataBaseDemo.Author>();
			Assert.AreEqual("tab_authors", tab_authors);
			Assert.AreEqual(string.Empty, tab_authors_alias);

			string config = reflection.GetTableName<DataBaseDemo.Config>();
			string config_alias = reflection.GetTableAlias<DataBaseDemo.Config>();
			Assert.AreEqual("Config", config);
			Assert.AreEqual(string.Empty, config_alias);

			string tab_page = reflection.GetTableName<DataBaseDemo.Page>();
			string tab_page_alias = reflection.GetTableAlias<DataBaseDemo.Page>();
			Assert.AreEqual("tab_pages", tab_page);
			Assert.AreEqual("tp", tab_page_alias);
		}

		[TestMethod]
		[TestCategory("Reflection")]
		public void GetPrimaryKeys()
		{
			string pk_books = reflection.GetPrimaryKey<DataBaseDemo.Book>();
			Assert.AreEqual("ID", pk_books);

			string pk_authors = reflection.GetPrimaryKey<DataBaseDemo.Author>();
			Assert.AreEqual("id", pk_authors);

			string pk_page = reflection.GetPrimaryKey<DataBaseDemo.Page>();
			Assert.AreEqual("id", pk_page);
		}

		[TestMethod]
		[TestCategory("Reflection")]
		public void GetForeignKeys()
		{
			string[] fk1 = reflection.GetForeignKeys<DataBaseDemo.Book>();
			Assert.AreEqual(5, fk1.Length);
			Assert.AreEqual("ID_Author,ID_Publisher,id_custom1,customField,ID_Shop", string.Join(',', fk1));

			string[] fk2 = reflection.GetForeignKeys<DataBaseDemo.Page>();
			Assert.AreEqual(2, fk2.Length);
			Assert.AreEqual("ident_1,ident_2", string.Join(',', fk2));
		}

		[TestMethod]
		[TestCategory("Reflection")]
		public void PrimaryKeyNotFound()
		{
			Assert.ThrowsException<Exceptions.PrimaryKeyNotFoundException>(() => { reflection.GetPrimaryKey<DataBaseDemo.Config>(); });
		}

		[TestMethod]
		[TestCategory("Reflection")]
		public void ForeignKeyNotFound()
		{
			Assert.ThrowsException<Exceptions.ForeignKeyNotFoundException>(() => { reflection.GetForeignKeys<DataBaseDemo.Config>(); });
			Assert.ThrowsException<Exceptions.ForeignKeyNotFoundException>(() => { reflection.GetForeignKeys<DataBaseDemo.Author>(); });
		}

	}
}
