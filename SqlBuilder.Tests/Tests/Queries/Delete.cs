using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlBuilder.Linq;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class DeleteTests
	{

		#region Delete Simple

		[TestMethod]
		[TestCategory("Query - Delete")]
		public void QueryDeleteSimpleEmpty1()
		{
			Delete<DataBaseDemo.Author> d = new Delete<DataBaseDemo.Author>(Format.MsSQL);
			
			string result = d.GetSql();
			string sql = "DELETE FROM [tab_authors];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Delete")]
		public void QueryDeleteSimpleEmpty2()
		{
			Delete d = new Delete(Format.MsSQL, "table");

			string result = d.GetSql();
			string sql = "DELETE FROM [table];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Delete")]
		public void QueryDeleteSimpleEmpty3()
		{
			Delete d = new Delete(Format.MsSQL, "table", "t");

			string result = d.GetSql();
			string sql = "DELETE FROM [table] as [t];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Delete")]
		public void QueryDeleteSimpleWhere1()
		{
			string result = new Delete<DataBaseDemo.Author>(Format.MsSQL)
				.Where("id")
				.GetSql();

			string sql = "DELETE FROM [tab_authors] WHERE [id]=@id;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Delete")]
		public void QueryDeleteSimpleWhere2()
		{
			Delete<DataBaseDemo.Author> d = new Delete<DataBaseDemo.Author>(Format.MsSQL);
			d.Where.Equal("p1").Less("p2").IsNULL("p3");

			string result = d.GetSql();
			string sql = "DELETE FROM [tab_authors] WHERE [p1]=@p1 AND [p2]<@p2 AND [p3] IS NULL;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Delete")]
		public void QueryDeleteSimpleWhere3()
		{
			string result = new Delete<DataBaseDemo.Author>(Format.MsSQL)
			.Where(w => w.EqualValue("id", "123"))
			.GetSql();

			string sql = "DELETE FROM [tab_authors] WHERE [id]=123;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Delete")]
		public void QueryDeleteAliasWhere()
		{
			Delete<DataBaseDemo.Author> d = new Delete<DataBaseDemo.Author>(Format.MsSQL, "td");
			d.Where(w => w.Equal("p1").Less("p2").IsNULL("p3"));

			string result = d.GetSql();
			string sql = "DELETE FROM [tab_authors] as [td] WHERE [td].[p1]=@p1 AND [td].[p2]<@p2 AND [td].[p3] IS NULL;";
			Assert.AreEqual(sql, result);
		}

		#endregion

	}

}