using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class Insert
	{

		[TestMethod]
		[TestCategory("Query - Insert")]
		public void QueryInsertSimple1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Insert<DataBaseDemo.Author> a = new Insert<DataBaseDemo.Author>(true);
			
			string result = a.GetSql();
			string sql = "INSERT INTO [tab_authors]([firstname], [lastname]) VALUES(@firstname, @lastname);";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Insert")]
		public void QueryInsertSimple2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Insert<DataBaseDemo.Author> a = new Insert<DataBaseDemo.Author>(true);
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
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Insert<DataBaseDemo.Author> a = new Insert<DataBaseDemo.Author>(true);
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
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Insert<DataBaseDemo.Author> a = new Insert<DataBaseDemo.Author>(true);
			a.AppendParameters("p1", "p2", "p3");

			string result = a.GetSql();
			string sql = "INSERT INTO [tab_authors]([firstname], [lastname], [p1], [p2], [p3]) VALUES(@firstname, @lastname, @p1, @p2, @p3);";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Insert")]
		public void QueryInsertSimple5()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Insert<DataBaseDemo.Author> a = new Insert<DataBaseDemo.Author>(false);
			a.AppendParameters("p1", "p2", "p3");

			string result = a.GetSql();
			string sql = "INSERT INTO [tab_authors]([p1], [p2], [p3]) VALUES(@p1, @p2, @p3);";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Insert")]
		public void QueryInsertStatic1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			string result = Insert<DataBaseDemo.Author>.Mapping("p1", "p2", "p3").GetSql();
			string sql = "INSERT INTO [tab_authors]([firstname], [lastname], [p1], [p2], [p3]) VALUES(@firstname, @lastname, @p1, @p2, @p3);";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Insert")]
		public void QueryInsertStatic2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			string result = Insert<DataBaseDemo.Author>.WithoutMapping("p1", "p2", "p3").GetSql();
			string sql = "INSERT INTO [tab_authors]([p1], [p2], [p3]) VALUES(@p1, @p2, @p3);";
			Assert.AreEqual(sql, result);
		}

	}

}