using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class QueryList
	{

		[TestMethod]
		[TestCategory("Query - List")]
		public void QueryListSimple()
		{
			global::SqlBuilder.QueryList l = new global::SqlBuilder.QueryList();
			var a1 = Query<DataBaseDemo.Author>.CreateSelect();
			var a2 = Query<DataBaseDemo.Author>.CreateInsert();
			var a3 = Query<DataBaseDemo.Author>.CreateUpdate();
			var a4 = Query<DataBaseDemo.Author>.CreateDelete();
			l.Append(a1, a2, a3, a4);

			string sql = string.Format("{1}{0}{2}{0}{3}{0}{4}", Environment.NewLine, a1.GetSql(), a2.GetSql(), a3.GetSql(), a4.GetSql());

			Assert.AreEqual(4, l.Count);
			Assert.AreEqual(sql, l.GetSql());
		}

	}

}