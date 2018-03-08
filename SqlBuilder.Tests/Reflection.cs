using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SqlBuilder.Tests
{
	[TestClass]
	public class SqlBuilderTableName
	{

		[TestMethod]
		public void GetTableName()
		{
			SqlBuilder.Parameters = ParametersLibrary.MySQL;
			string tab_books = SqlBuilder.GetTableName<DataBaseDemo.Book>();
			string tab_authors = SqlBuilder.GetTableName<DataBaseDemo.Author>();
			string config = SqlBuilder.GetTableName<DataBaseDemo.Config>();
			Assert.AreEqual("tab_books", tab_books);
			Assert.AreEqual("tab_authors", tab_authors);
			Assert.AreEqual("config", config);
		}

		[TestMethod]
		public void GetPrimaryKey()
		{
			SqlBuilder.Parameters = ParametersLibrary.MySQL;
			string pk_books = SqlBuilder.GetPrimaryKey<DataBaseDemo.Book>();
			Assert.AreEqual("id", pk_books);
		}

	}
}
