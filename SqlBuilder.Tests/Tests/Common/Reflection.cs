using SqlBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using reflection = global::SqlBuilder.Reflection;

namespace SqlBuilder.Tests
{
	[TestClass]
	public class Reflection
	{

		[TestMethod]
		[TestCategory("Reflection")]
		public void GetTableName()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MySql;

			string tab_books = reflection.GetTableName<DataBaseDemo.Book>();
			Assert.AreEqual("tab_books", tab_books);

			string tab_authors = reflection.GetTableName<DataBaseDemo.Author>();
			Assert.AreEqual("tab_authors", tab_authors);

			string config = reflection.GetTableName<DataBaseDemo.Config>();
			Assert.AreEqual("config", config);
		}

		[TestMethod]
		[TestCategory("Reflection")]
		public void GetTableNameEscape()
		{
			string tab_books = reflection.GetTableName<DataBaseDemo.Book>();
			Assert.AreEqual("tab_books", tab_books);

			string tab_authors = reflection.GetTableName<DataBaseDemo.Author>();
			Assert.AreEqual("tab_authors", tab_authors);
		}

		[TestMethod]
		[TestCategory("Reflection")]
		public void GetPrimaryKey()
		{
			string pk_books = reflection.GetPrimaryKey<DataBaseDemo.Book>().ToLower();
			Assert.AreEqual("id", pk_books);

			string pk_authors = reflection.GetPrimaryKey<DataBaseDemo.Author>().ToLower();
			Assert.AreEqual("id", pk_authors);

			Assert.ThrowsException<Exceptions.PrimaryKeyNotFoundException>(() => { reflection.GetPrimaryKey<DataBaseDemo.Config>(); });
		}

		[TestMethod]
		[TestCategory("Reflection")]
		public void GetForeignKeys()
		{
			string[] fk1 = reflection.GetForeignKeys<DataBaseDemo.Book>();
			string[] fk2 = reflection.GetForeignKeys<DataBaseDemo.Config>();
			Assert.AreEqual(3, fk1.Length);
			Assert.AreEqual(0, fk2.Length);
			Assert.AreEqual("ID_Author,ID_Publisher,ID_Shop", string.Join(',', fk1));
		}

	}
}
