using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class UpdateTests
	{

		#region Update Simple

		[TestMethod]
		[TestCategory("Query - Update")]
		public void QueryUpdateSimple1()
		{
			Update u = new Update(Format.MsSQL, "tab_authors");
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
			Update u = new Update(Format.MsSQL, "tab_authors");
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
			Update u = new Update(Format.MsSQL, "tab_authors", "t");
			u.Sets.Append("a");
			u.Sets.AppendValue("d", "1").AppendValue("e", "NOW()");
			u.Where.Equal("id");

			string result = u.GetSql();
			string sql = "UPDATE [tab_authors] as [t] SET [t].[a]=@a, [t].[d]=1, [t].[e]=NOW() WHERE [t].[id]=@id;";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Update mapping

		[TestMethod]
		[TestCategory("Query - Update")]
		public void UpdateMapping1()
		{
			Update<DataBaseDemo.Author> u = new Update<DataBaseDemo.Author>(Format.MsSQL);

			string result = u.GetSql();
			string sql = "UPDATE [tab_authors] SET [firstname]=@firstname, [lastname]=@lastname;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Update")]
		public void UpdateMapping2()
		{
			Update<DataBaseDemo.Book> u = new Update<DataBaseDemo.Book>(Format.MsSQL);

			string result = u.GetSql();
			string sql = "UPDATE [tab_books] SET [created_at]=@created_at, [updated_at]=NOW(), [name]=@name, [year]=@year, [id_author]=@id_author, [id_publisher]=@id_publisher, [id_custom1]=@id_custom1, [id_custom2]=@id_custom2, [id_shop]=@id_shop;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Update")]
		public void UpdateMapping3()
		{
			Update<DataBaseDemo.Author> u = new Update<DataBaseDemo.Author>(Format.MsSQL);
			u.Where.Equal("id").IsNULL("is_activated");

			string result = u.GetSql();
			string sql = "UPDATE [tab_authors] SET [firstname]=@firstname, [lastname]=@lastname WHERE [id]=@id AND [is_activated] IS NULL;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Update")]
		public void UpdateMappingIgnore()
		{
			Update<DataBaseDemo.Author> u = new Update<DataBaseDemo.Author>(Format.MsSQL);
			u.Where.Equal("id").IsNULL("is_activated");

			string result = u.GetSql();
			string sql = "UPDATE [tab_authors] SET [firstname]=@firstname, [lastname]=@lastname WHERE [id]=@id AND [is_activated] IS NULL;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Update")]
		public void UpdateMapping4()
		{
			Update<DataBaseDemo.Author> u = new Update<DataBaseDemo.Author>(Format.MsSQL);
			u.Where.Equal("id");

			string result = u.GetSql();
			string sql = "UPDATE [tab_authors] SET [firstname]=@firstname, [lastname]=@lastname WHERE [id]=@id;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Update")]
		public void UpdateMapping5()
		{
			Update<DataBaseDemo.Author> u = new Update<DataBaseDemo.Author>(Format.MsSQL);
			u.Where.EqualValue("id", "123");

			string result = u.GetSql();
			string sql = "UPDATE [tab_authors] SET [firstname]=@firstname, [lastname]=@lastname WHERE [id]=123;";
			Assert.AreEqual(sql, result);
		}

		#endregion

	}

}