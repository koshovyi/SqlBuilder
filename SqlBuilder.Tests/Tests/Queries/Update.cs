using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class Update
	{

		#region Update Simple

		[TestMethod]
		[TestCategory("Query - Update")]
		public void QueryUpdateSimple1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Update<DataBaseDemo.Author> u = new Update<DataBaseDemo.Author>();
			u.Sets.Append("a", "b", "c");
			u.Sets.AppendValue("d", "1").AppendValue("e", "NOW()");

			string result = u.GetSql();
			string sql = "UPDATE [tab_authors] SET [a]=@a, [b]=@b, [c]=@c, [d]=1, [e]=NOW();";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Update")]
		public void QueryUpdateSimple2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Update<DataBaseDemo.Author> u = new Update<DataBaseDemo.Author>();
			u.Sets.Append("a", "b", "c");
			u.Where.Equal("d", "e", "f");

			string result = u.GetSql();
			string sql = "UPDATE [tab_authors] SET [a]=@a, [b]=@b, [c]=@c WHERE [d]=@d AND [e]=@e AND [f]=@f;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Update")]
		public void QueryUpdateAlias()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Update<DataBaseDemo.Author> u = new Update<DataBaseDemo.Author>(false, "t");
			u.Sets.Append("a");
			u.Sets.AppendValue("d", "1").AppendValue("e", "NOW()");
			u.Where.Equal("id");

			string result = u.GetSql();
			string sql = "UPDATE [tab_authors] as 't' SET 't'.[a]=@a, 't'.[d]=1, 't'.[e]=NOW() WHERE 't'.[id]=@id;";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Update mapping

		[TestMethod]
		public void UpdateMapping1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Update<DataBaseDemo.Author> u = new Update<DataBaseDemo.Author>(true);

			string result = u.GetSql();
			string sql = "UPDATE [tab_authors] SET [firstname]=@firstname, [lastname]=@lastname;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		public void UpdateMapping2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Update<DataBaseDemo.Book> u = new Update<DataBaseDemo.Book>(true);

			string result = u.GetSql();
			string sql = "UPDATE [tab_books] SET [created_at]=@created_at, [name]=@name, [year]=@year, [id_author]=@id_author, [id_publisher]=@id_publisher, [id_shop]=@id_shop;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		public void UpdateMapping3()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Update<DataBaseDemo.Author> u = new Update<DataBaseDemo.Author>(true);
			u.Where.Equal("id").IsNULL("is_activated");

			string result = u.GetSql();
			string sql = "UPDATE [tab_authors] SET [firstname]=@firstname, [lastname]=@lastname WHERE [id]=@id AND [is_activated] IS NULL;";
			Assert.AreEqual(sql, result);
		}

		#endregion

	}

}