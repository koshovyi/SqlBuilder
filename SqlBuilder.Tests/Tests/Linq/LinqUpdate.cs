using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Linq;

namespace SqlBuilder.Tests.Tests.Linq
{

	[TestClass]
	public class LinqUpdate
	{

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqUpdateColumns1()
		{
			var q1 = new Update<DataBaseDemo.Author>();
			q1.SetsLinq(x=>x.AppendValue("name", "value")).WhereLinq(x => x.Equal("a").IsNULL("b"));
			string result = q1.GetSql();
			string sql = "UPDATE [tab_authors] SET [name]=value WHERE [a]=@a AND [b] IS NULL;";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqUpdateColumns2()
		{
			string result = Query<DataBaseDemo.Author>.CreateUpdate().SetsLinq(x=>x.AppendValue("count", "123")).WhereLinq(x=>x.Equal("a")).GetSql();
			string sql = "UPDATE [tab_authors] SET [count]=123 WHERE [a]=@a;";
			Assert.AreEqual(result, sql);
		}

	}

}