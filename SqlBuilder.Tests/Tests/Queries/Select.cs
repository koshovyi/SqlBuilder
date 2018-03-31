using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class Select
	{

		#region Select simple

		[TestMethod]
		[TestCategory("Query.Select")]
		public void QuerySelectSimpleAllColumns()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			string result = new Select<DataBaseDemo.Author>().GetSql();
			string sql = "SELECT * FROM tab_authors;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query.Select")]
		public void QuerySelectSimpleAllColumnsStatic()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			string result = Select<DataBaseDemo.Author>.SelectAll().GetSql();
			string sql = "SELECT * FROM tab_authors;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query.Select")]
		public void QuerySelectSimpleColumnsList()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.Columns.Append("a", "b", "c");
			string result = s.GetSql();
			string sql = "SELECT a,b,c FROM tab_authors;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query.Select")]
		public void QuerySelectSimpleColumnsListStatic()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			Select<DataBaseDemo.Author> s = Select<DataBaseDemo.Author>.SelectAll("a", "b", "c");
			string result = s.GetSql();
			string sql = "SELECT a,b,c FROM tab_authors;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query.Select")]
		public void QuerySelectSimpleColumnsListAlias()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.Columns.Append("a", "b", "c");
			s.Columns.AppendAlias("d", "D");
			string result = s.GetSql();
			string sql = "SELECT a,b,c,d as D FROM tab_authors;";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Select Where

		[TestMethod]
		[TestCategory("Query.Select")]
		public void QuerySelectSimpleWherePK()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.Where.Equal(Reflection.GetPrimaryKey<DataBaseDemo.Author>());
			string result = s.GetSql();
			string sql = "SELECT * FROM tab_authors WHERE ID=@ID;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query.Select")]
		public void QuerySelectSimpleWherePKStatic()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			Select<DataBaseDemo.Author> s = Select<DataBaseDemo.Author>.SelectWherePK();
			string result = s.GetSql();
			string sql = "SELECT * FROM tab_authors WHERE ID=@ID;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query.Select")]
		public void QuerySelectSimpleWhereAnd()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.Where.Equal("first_name", "last_name");
			string result = s.GetSql();
			string sql = "SELECT * FROM tab_authors WHERE first_name=@first_name AND last_name=@last_name;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query.Select")]
		public void QuerySelectSimpleWhereOr()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.Where.Equal("position").Or().EqualGreater("age");
			string result = s.GetSql();
			string sql = "SELECT * FROM tab_authors WHERE position=@position OR age>=@age;";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region OrderBy

		[TestMethod]
		[TestCategory("Query.Select")]
		public void QuerySelectSimpleOrderByAsc()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.OrderBy.Ascending("age");
			string result = s.GetSql();
			string sql = "SELECT * FROM tab_authors ORDER BY age ASC;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query.Select")]
		public void QuerySelectSimpleOrderByDesc()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.OrderBy.Descending("age");
			string result = s.GetSql();
			string sql = "SELECT * FROM tab_authors ORDER BY age DESC;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query.Select")]
		public void QuerySelectSimpleOrderByAscDesc()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.OrderBy.Ascending("age").Descending("amount");
			string result = s.GetSql();
			string sql = "SELECT * FROM tab_authors ORDER BY age ASC,amount DESC;";
			Assert.AreEqual(sql, result);
		}

		#endregion

	}

}