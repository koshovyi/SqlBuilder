using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Linq;

namespace SqlBuilder.Tests.Tests.Linq
{

	[TestClass]
	public class LinqInsert
	{

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqInsertColumns1()
		{
			var q1 = new Insert<DataBaseDemo.Author>(false);
			q1.ColumnsLinq(x => x.Append("a", "b", "c")).ValuesLinq(x=>x.Append("a", "b", "c"));
			string result = q1.GetSql();
			string sql = "INSERT INTO [tab_authors]([a], [b], [c]) VALUES(a, b, c);";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqInsertColumns2()
		{
			string result = Query<DataBaseDemo.Author>.CreateInsert(false).ColumnsLinq(x => x.Append("a", "b", "c")).ValuesLinq(x => x.Append("a", "b", "c")).GetSql();
			string sql = "INSERT INTO [tab_authors]([a], [b], [c]) VALUES(a, b, c);";
			Assert.AreEqual(result, sql);
		}

	}

}