using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class Select
	{

		#region Select Simple

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleAllColumns()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			string result = new Select<DataBaseDemo.Author>().GetSql();
			string sql = "SELECT * FROM [tab_authors];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleAllColumnsAlias()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			string result = new Select<DataBaseDemo.Author>("t").GetSql();
			string sql = "SELECT 't'.* FROM [tab_authors] as 't';";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleColumnsList()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.Columns.Append("a", "b", "c");
			string result = s.GetSql();
			string sql = "SELECT [a], [b], [c] FROM [tab_authors];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleColumnsListStatic()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = Select<DataBaseDemo.Author>.SelectAll("a", "b", "c");
			string result = s.GetSql();
			string sql = "SELECT [a], [b], [c] FROM [tab_authors];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleColumnsListAlias()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.Columns.Append("a", "b", "c");
			s.Columns.AppendAlias("d", "D");
			string result = s.GetSql();
			string sql = "SELECT [a], [b], [c], [d] as 'D' FROM [tab_authors];";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Select Where

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleWherePK()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.Where.Equal(global::SqlBuilder.Reflection.GetPrimaryKey<DataBaseDemo.Author>());
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] WHERE [ID]=@ID;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleWherePKAlias()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>("t");
			s.Where.Equal(global::SqlBuilder.Reflection.GetPrimaryKey<DataBaseDemo.Author>());
			string result = s.GetSql();
			string sql = "SELECT 't'.* FROM [tab_authors] as 't' WHERE [ID]=@ID;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleWherePKStatic()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = Select<DataBaseDemo.Author>.SelectWhere();
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] WHERE [ID]=@ID;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleWhereAnd()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.Where.Equal("first_name", "last_name");
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] WHERE [first_name]=@first_name AND [last_name]=@last_name;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleWhereOr()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.Where.Equal("position").Or().EqualGreater("age");
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] WHERE [position]=@position OR [age]>=@age;";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Select OrderBy

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleOrderByAsc()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.OrderBy.Ascending("age");
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] ORDER BY [age] ASC;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleOrderByDesc()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.OrderBy.Descending("age");
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] ORDER BY [age] DESC;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleOrderByAscDesc()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.OrderBy.Ascending("age").Descending("amount");
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] ORDER BY [age] ASC, [amount] DESC;";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Select GroupBy

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectGroupBySimple1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.GroupBy.Append(false, "country", "city");
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] GROUP BY [country], [city];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectGroupBySimple2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.GroupBy.Append(true, "country", "city");
			string result = s.GetSql();
			string sql = "SELECT [country], [city] FROM [tab_authors] GROUP BY [country], [city];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectGroupBySimple3()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.GroupBy.FuncMax("sm", "asm");
			string result = s.GetSql();
			string sql = "SELECT MAX([sm]) as 'asm' FROM [tab_authors] GROUP BY [sm];";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Select Hard

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectHard1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>();
			s.Columns.Append("s1", "s2", "s3").FuncMin("date");
			s.Where.Equal("s1", "s2").IsNotNULL("created_at").IsNULL("activated");
			s.GroupBy.Append(false, "country", "city").FuncCount("lll", "all");
			s.OrderBy.Ascending("age");
			string result = s.GetSql();
			string sql = "SELECT [s1], [s2], [s3], MIN([date]), COUNT([lll]) as 'all' FROM [tab_authors] WHERE [s1]=@s1 AND [s2]=@s2 AND [created_at] IS NOT NULL AND [activated] IS NULL GROUP BY [country], [city], [lll] ORDER BY [age] ASC;";
			Assert.AreEqual(sql, result);
		}

		#endregion

	}

}