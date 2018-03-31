using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class WhereStatement
	{

		#region Equal, NotEqual

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndEqualSimple()
		{
			Where w = new Where();
			w.Equal("a", "b", "c");
			string result = w.GetSql();
			string sql = "a=@a AND b=@b AND c=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndEqualParamValue()
		{
			Where w = new Where();
			w.EqualParam("a", "1");
			w.EqualParam("b", "2");
			w.EqualParam("c", "3");
			string result = w.GetSql();
			string sql = "a=1 AND b=2 AND c=3";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndNotEqualSimple()
		{
			Where w = new Where();
			w.NotEqual("a", "b", "c");
			string result = w.GetSql();
			string sql = "a!=@a AND b!=@b AND c!=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndNotEqualParamValue()
		{
			Where w = new Where();
			w.NotEqualParam("a", "1");
			w.NotEqualParam("b", "2");
			w.NotEqualParam("c", "3");
			string result = w.GetSql();
			string sql = "a!=1 AND b!=2 AND c!=3";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Equal, NotEqual - Combinations

		[TestMethod]
		[TestCategory("Where - Combinations")]
		public void ComboAndEqualAndNotEqual()
		{
			Where w = new Where();
			w.EqualParam("a", "1");
			w.NotEqualParam("b", "2");
			string result = w.GetSql();
			string sql = "a=1 AND b!=2";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Greater, Less

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndEqualGreater()
		{
			Where w = new Where();
			w.EqualGreater("a", "b", "c");
			string result = w.GetSql();
			string sql = "a>=@a AND b>=@b AND c>=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndEqualLess()
		{
			Where w = new Where();
			w.EqualLess("a", "b", "c");
			string result = w.GetSql();
			string sql = "a<=@a AND b<=@b AND c<=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndGreater()
		{
			Where w = new Where();
			w.Greater("a", "b", "c");
			string result = w.GetSql();
			string sql = "a>@a AND b>@b AND c>@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndLess()
		{
			Where w = new Where();
			w.Less("a", "b", "c");
			string result = w.GetSql();
			string sql = "a<@a AND b<@b AND c<@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndEqualGreaterParam()
		{
			Where w = new Where();
			w.EqualGreaterParam("a", "1");
			w.EqualGreaterParam("b", "2");
			w.EqualGreaterParam("c", "3");
			string result = w.GetSql();
			string sql = "a>=1 AND b>=2 AND c>=3";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndEqualLessParam()
		{
			Where w = new Where();
			w.EqualLessParam("a", "1");
			w.EqualLessParam("b", "2");
			w.EqualLessParam("c", "3");
			string result = w.GetSql();
			string sql = "a<=1 AND b<=2 AND c<=3";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndGreaterParam()
		{
			Where w = new Where();
			w.GreaterParam("a", "1");
			w.GreaterParam("b", "2");
			w.GreaterParam("c", "3");
			string result = w.GetSql();
			string sql = "a>1 AND b>2 AND c>3";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndLessParam()
		{
			Where w = new Where();
			w.LessParam("a", "1");
			w.LessParam("b", "2");
			w.LessParam("c", "3");
			string result = w.GetSql();
			string sql = "a<1 AND b<2 AND c<3";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Greater, Less - Combinations

		[TestMethod]
		[TestCategory("Where - Combinations")]
		public void ComboAndGreaterAndLess()
		{
			Where w = new Where();
			w.Greater("a");
			w.Less("b");
			string result = w.GetSql();
			string sql = "a>@a AND b<@b";
			Assert.AreEqual(sql, result);
		}

		#endregion

	}

}
