using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlBuilder.Sql;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class OrderByStatement
	{

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByASCSimple1()
		{
			OrderByList o = new OrderByList(global::SqlBuilder.Format.MsSQL);
			o.Ascending("a");
			string result = o.GetSql();
			string sql = "[a] ASC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByASCSimple2()
		{
			OrderByList o = new OrderByList(global::SqlBuilder.Format.MsSQL);
			o.Ascending("a", "b", "c");
			string result = o.GetSql();
			string sql = "[a] ASC, [b] ASC, [c] ASC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByDESCSimple1()
		{
			OrderByList o = new OrderByList(global::SqlBuilder.Format.MsSQL);
			o.Descending("a");
			string result = o.GetSql();
			string sql = "[a] DESC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByDESCSimple2()
		{
			OrderByList o = new OrderByList(global::SqlBuilder.Format.MsSQL);
			o.Descending("a", "b", "c");
			string result = o.GetSql();
			string sql = "[a] DESC, [b] DESC, [c] DESC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByASCAndDESC1()
		{
			OrderByList o = new OrderByList(global::SqlBuilder.Format.MsSQL);
			o.Ascending("a");
			o.Descending("b");
			o.Ascending("c");
			o.Descending("d");
			string result = o.GetSql();
			string sql = "[a] ASC, [b] DESC, [c] ASC, [d] DESC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByASCAndDESC2()
		{
			OrderByList o = new OrderByList(global::SqlBuilder.Format.MsSQL);
			o.Ascending("a", "b", "c");
			o.Descending("d", "e", "f");
			string result = o.GetSql();
			string sql = "[a] ASC, [b] ASC, [c] ASC, [d] DESC, [e] DESC, [f] DESC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByASCAndDESCAlias()
		{
			OrderByList o = new OrderByList(global::SqlBuilder.Format.MsSQL);
			o.Ascending("a");
			o.Descending("b");
			o.Ascending("c");
			o.Descending("d");
			string result = o.GetSql("t");
			string sql = "[t].[a] ASC, [t].[b] DESC, [t].[c] ASC, [t].[d] DESC";
			Assert.AreEqual(sql, result);
		}

	}

}