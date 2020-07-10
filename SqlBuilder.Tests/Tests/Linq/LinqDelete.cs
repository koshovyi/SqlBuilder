using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlBuilder.Linq;
using SqlBuilder.Tests.DataBaseDemo;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class LinqDelete
	{

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqDeleteSimple()
		{
			var q1 = new Delete<Author>(Format.MsSQL);
			string result = q1.GetSql();
			string sql = "DELETE FROM [tab_authors];";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqDeleteSimpleWhere()
		{
			var q1 = new Delete<Author>(Format.MsSQL);
			q1.Where(x => x.Equal("a").IsNULL("b"));
			string result = q1.GetSql();
			string sql = "DELETE FROM [tab_authors] WHERE [a]=@a AND [b] IS NULL;";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqQueryDeleteSimpleWhere()
		{
			string result = new Query<Author>(Format.MsSQL).Delete().Where("a").GetSql();
			string sql = "DELETE FROM [tab_authors] WHERE [a]=@a;";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqDeleteTableAlias()
		{
			string result = new Query<Author>(Format.MsSQL).Delete("t").Where("a").GetSql();
			string sql = "DELETE FROM [tab_authors] as [t] WHERE [t].[a]=@a;";
			Assert.AreEqual(result, sql);
		}

	}

}