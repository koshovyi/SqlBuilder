using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class QueryListTests
	{

		[TestMethod]
		[TestCategory("Query - List")]
		public void QueryListSimple()
		{
			QueryList l = new QueryList();
			var a1 = new Query<DataBaseDemo.Author>(Format.MsSQL).Select();
			var a2 = new Query<DataBaseDemo.Author>(Format.MsSQL).Insert();
			var a3 = new Query<DataBaseDemo.Author>(Format.MsSQL).Update();
			var a4 = new Query<DataBaseDemo.Author>(Format.MsSQL).Delete();
			l.Append(a1, a2, a3, a4);

			string sql = string.Format("{1}{0}{2}{0}{3}{0}{4}", Environment.NewLine, a1.GetSql(), a2.GetSql(), a3.GetSql(), a4.GetSql());

			Assert.AreEqual(4, l.Count);
			Assert.AreEqual(sql, l.GetSql());
		}

	}

}