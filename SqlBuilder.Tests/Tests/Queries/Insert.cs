using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlBuilder.Linq;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class InsertTests
	{

		[TestMethod]
		[TestCategory("Query - Insert")]
		public void QueryInsertSimple1()
		{
			Insert<DataBaseDemo.Author> a = new Insert<DataBaseDemo.Author>(Format.MsSQL);

			string result = a.GetSql();
			string sql = "INSERT INTO [tab_authors]([firstname], [lastname]) VALUES(@firstname, @lastname);";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Insert")]
		public void QueryInsertSimple2()
		{
			Insert<DataBaseDemo.Author> a = new Insert<DataBaseDemo.Author>(Format.MsSQL);
			a.Columns.Append("created_at", "updated_at");
			a.Values.Append("NOW()", "'2020-01-01 23:45:22'");

			string result = a.GetSql();
			string sql = "INSERT INTO [tab_authors]([firstname], [lastname], [created_at], [updated_at]) VALUES(@firstname, @lastname, NOW(), '2020-01-01 23:45:22');";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Insert")]
		public void QueryInsertSimple3()
		{
			Insert<DataBaseDemo.Author> a = new Insert<DataBaseDemo.Author>(Format.MsSQL);
			a.Columns.Append("p1", "p2", "p3");
			a.Values.AppendParameters("p1", "p2", "p3");

			string result = a.GetSql();
			string sql = "INSERT INTO [tab_authors]([firstname], [lastname], [p1], [p2], [p3]) VALUES(@firstname, @lastname, @p1, @p2, @p3);";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Insert")]
		public void QueryInsertSimple4()
		{
			Insert<DataBaseDemo.Author> a = new Insert<DataBaseDemo.Author>(Format.MsSQL);
			a.AppendParameters("p1", "p2", "p3");

			string result = a.GetSql();
			string sql = "INSERT INTO [tab_authors]([firstname], [lastname], [p1], [p2], [p3]) VALUES(@firstname, @lastname, @p1, @p2, @p3);";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Insert")]
		public void QueryInsertSimple5()
		{
			Insert a = new Insert(Format.MsSQL, "table");
			a.AppendParameters("a", "b", "c");

			string result = a.GetSql();
			string sql = "INSERT INTO [table]([a], [b], [c]) VALUES(@a, @b, @c);";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Insert")]
		public void QueryInsertSimple6()
		{
			string sql1 = new Insert(Format.MsSQL, "table").AppendParameters("a", "b", "c").GetSql();
			string sql2 = "INSERT INTO [table]([a], [b], [c]) VALUES(@a, @b, @c);";
			Assert.AreEqual(sql1, sql2);
		}

		[TestMethod]
		[TestCategory("Query - Insert")]
		public void QueryInsertSimple7()
		{
			string sql1 = new Insert(Format.MsSQL, "table").AppendParameters("firstName", "lastName").Columns("createdAt").Values("'NOW()'").GetSql();
			string sql2 = "INSERT INTO [table]([firstName], [lastName], [createdAt]) VALUES(@firstName, @lastName, 'NOW()');";
			Assert.AreEqual(sql1, sql2);
		}

	}

}