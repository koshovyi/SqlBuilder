using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlBuilder;

namespace SqlBuilder.Tests
{
	[TestClass]
	public class Reflections
	{

		[TestMethod]
		[TestCategory("Reflection")]
		public void GetTableName()
		{
			SqlBuilder.Parameters = ParametersLibrary.MySql;

			string tab_books = Reflection.GetTableName<DataBaseDemo.Book>();
			Assert.AreEqual("tab_books", tab_books);

			string tab_authors = Reflection.GetTableName<DataBaseDemo.Author>();
			Assert.AreEqual("tab_authors", tab_authors);

			string config = Reflection.GetTableName<DataBaseDemo.Config>();
			Assert.AreEqual("config", config);
		}

		[TestMethod]
		[TestCategory("Reflection")]
		public void GetTableNameEscape()
		{
			string tab_books = Reflection.GetTableName<DataBaseDemo.Book>();
			Assert.AreEqual("tab_books", tab_books);

			string tab_authors = Reflection.GetTableName<DataBaseDemo.Author>();
			Assert.AreEqual("tab_authors", tab_authors);
		}

		[TestMethod]
		[TestCategory("Reflection")]
		public void GetPrimaryKey()
		{
			string pk_books = Reflection.GetPrimaryKey<DataBaseDemo.Book>().ToLower();
			Assert.AreEqual("id", pk_books);

			string pk_authors = Reflection.GetPrimaryKey<DataBaseDemo.Author>().ToLower();
			Assert.AreEqual("id", pk_authors);
		}

	}
}
