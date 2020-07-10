using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlBuilder;
using SqlBuilder.Linq;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class LinqUpdate
	{

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqUpdateSimpleWhere1()
		{
			var q1 = new Query(Format.MsSQL).Update("tab_authors");
			q1.Sets(x=>x.AppendValue("name", "value")).Where(x => x.Equal("a").IsNULL("b"));
			string result = q1.GetSql();
			string sql = "UPDATE [tab_authors] SET [name]=value WHERE [a]=@a AND [b] IS NULL;";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqUpdateSimpleWhere2()
		{
			var q1 = new Query(Format.MsSQL).Update("tab_authors");
			q1.Sets("name", "value").Where("a", "b");
			string result = q1.GetSql();
			string sql = "UPDATE [tab_authors] SET [name]=@name, [value]=@value WHERE [a]=@a AND [b]=@b;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqUpdateSimpleWhere3()
		{
			var q1 = new Query(Format.MsSQL).Update("tab_authors");
			q1.Sets("name", "value").Where("a").Where("b").Where("c").Where(x => x.Equal("d"));
			string result = q1.GetSql();
			string sql = "UPDATE [tab_authors] SET [name]=@name, [value]=@value WHERE [a]=@a AND [b]=@b AND [c]=@c AND [d]=@d;";
			Assert.AreEqual(sql, result);
		}

	}

}