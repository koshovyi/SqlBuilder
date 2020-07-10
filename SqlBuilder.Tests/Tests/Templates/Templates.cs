using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlBuilder.Templates;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class Templates
	{

		[TestMethod]
		[TestCategory("Templates")]
		public void TemplateSelect()
		{
			Template t = TemplateLibrary.Select;
			t.Append(SnippetLibrary.Table("users", global::SqlBuilder.Format.MsSQL),
				SnippetLibrary.Columns("*"),
				SnippetLibrary.Where("age>=18"),
				SnippetLibrary.OrderBy("age ASC"));
			string sql = t.GetSql(global::SqlBuilder.Format.MsSQL);
			Assert.AreEqual(sql, "SELECT * FROM [users] WHERE age>=18 ORDER BY age ASC;");
		}

		[TestMethod]
		[TestCategory("Templates")]
		public void TemplateUpdate()
		{
			Template t = TemplateLibrary.Update;
			t.Append(SnippetLibrary.Table("users", global::SqlBuilder.Format.MsSQL),
				SnippetLibrary.Sets("[a]=@a,[b]=@b,[c]=@c"),
				SnippetLibrary.Where("age>=18"));
			string sql = t.GetSql(global::SqlBuilder.Format.MsSQL);
			Assert.AreEqual(sql, "UPDATE [users] SET [a]=@a,[b]=@b,[c]=@c WHERE age>=18;");
		}

		[TestMethod]
		[TestCategory("Templates")]
		public void TemplateInsert()
		{
			Template t = TemplateLibrary.Insert;
			t.Append(SnippetLibrary.Table("users", global::SqlBuilder.Format.MsSQL),
				SnippetLibrary.Columns("[a],[b],[c]"),
				SnippetLibrary.Values("@a,@b,@c"));
			string sql = t.GetSql(global::SqlBuilder.Format.MsSQL);
			Assert.AreEqual(sql, "INSERT INTO [users]([a],[b],[c]) VALUES(@a,@b,@c);");
		}

	}

}
