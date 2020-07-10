using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlBuilder.Linq;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class LinqInsert
	{

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqInsertSimple()
		{
			var q1 = new Insert(Format.MsSQL, "tab_authors");
			q1.Columns(x => x.Append("a", "b", "c")).Values("a", "b", "c");
			string result = q1.GetSql();
			string sql = "INSERT INTO [tab_authors]([a], [b], [c]) VALUES(a, b, c);";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqQueryInsertSimple()
		{
			string result = new Insert(Format.MsSQL, "tab_authors").Columns("a", "b", "c").Values("a", "b", "c").GetSql();
			string sql = "INSERT INTO [tab_authors]([a], [b], [c]) VALUES(a, b, c);";
			Assert.AreEqual(result, sql);
		}

	}

}