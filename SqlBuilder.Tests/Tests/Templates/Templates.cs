using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class Templates
	{

		[TestMethod]
		[TestCategory("Templates")]
		public void TemplateSelect()
		{
			ITemplate t = TemplateLibrary.Select;
			t.Append(SnippetLibrary.Table("users"),
				SnippetLibrary.Columns("*"),
				SnippetLibrary.Where("age>=18"),
				SnippetLibrary.OrderBy("age ASC"));
			string sql = t.GetSql();
			Assert.AreEqual(sql, "SELECT * FROM [users] WHERE age>=18 ORDER BY age ASC;");
		}

		[TestMethod]
		[TestCategory("Templates")]
		public void TemplateUpdate()
		{
			ITemplate t = TemplateLibrary.Update;
			t.Append(SnippetLibrary.Table("users"),
				SnippetLibrary.Sets("[a]=@a,[b]=@b,[c]=@c"),
				SnippetLibrary.Where("age>=18"));
			string sql = t.GetSql();
			Assert.AreEqual(sql, "UPDATE [users] SET [a]=@a,[b]=@b,[c]=@c WHERE age>=18;");
		}

		[TestMethod]
		[TestCategory("Templates")]
		public void TemplateInsert()
		{
			ITemplate t = TemplateLibrary.Insert;
			t.Append(SnippetLibrary.Table("users"),
				SnippetLibrary.Columns("[a],[b],[c]"),
				SnippetLibrary.Values("@a,@b,@c"));
			string sql = t.GetSql();
			Assert.AreEqual(sql, "INSERT INTO [users]([a],[b],[c]) VALUES(@a,@b,@c);");
		}

	}

}
