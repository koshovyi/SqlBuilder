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
		public void AndEqualSimple()
		{
			Where w = new Where();
			w.Equal("a", "b", "c");
			string result = w.GetSQL();
			string sql = "a=@a AND b=@b AND c=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		public void AndEqualParamValue()
		{
			Where w = new Where();
			w.Equal("a", "1");
			w.Equal("b", "2");
			w.Equal("c", "3");
			string result = w.GetSQL();
			string sql = "a=1 AND b=2 AND c=3";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		public void AndNotEqualSimple()
		{
			Where w = new Where();
			w.NotEqual("a", "b", "c");
			string result = w.GetSQL();
			string sql = "a!=@a AND b!=@b AND c!=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		public void AndNotEqualParamValue()
		{
			Where w = new Where();
			w.NotEqual("a", "1");
			w.NotEqual("b", "2");
			w.NotEqual("c", "3");
			string result = w.GetSQL();
			string sql = "a!=1 AND b!=2 AND c!=3";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		public void AndEqualAndNotEqual()
		{
			Where w = new Where();
			w.Equal("a", "1");
			w.NotEqual("b", "2");
			string result = w.GetSQL();
			string sql = "a=1 AND b!=2";
			Assert.AreEqual(sql, result);
		}

		#endregion

	}

}
