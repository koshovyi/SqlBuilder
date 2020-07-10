using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlBuilder.Sql;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class ValuesStatement
	{

		[TestMethod]
		[TestCategory("ValueList")]
		public void ValuesSimple1()
		{
			ValueList w = new ValueList(global::SqlBuilder.Format.MsSQL);
			w.Append("a", "b", "c");
			string result = w.GetSql();
			string sql = "a, b, c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("ValueList")]
		public void ValuesSimple2()
		{
			ValueList w = new ValueList(global::SqlBuilder.Format.MsSQL);
			w.AppendParameters("a", "b", "c");
			string result = w.GetSql();
			string sql = "@a, @b, @c";
			Assert.AreEqual(sql, result);
		}

	}

}
