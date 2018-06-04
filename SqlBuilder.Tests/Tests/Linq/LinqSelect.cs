using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Linq;

namespace SqlBuilder.Tests.Tests.Linq
{

	[TestClass]
	public class LinqSelect
	{

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqSelectColumns()
		{
			var q1 = new Select<DataBaseDemo.Author>();
			q1.ColumnsLinq(x => x.Append("a", "b", "c"));
			string result = q1.GetSql();
			string sql = "SELECT [a], [b], [c] FROM [tab_authors];";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqSelectWhere()
		{
			var q1 = new Select<DataBaseDemo.Author>();
			q1.WhereLinq(x=>x.Equal("s1").IsNULL("s2"));
			string result = q1.GetSql();
			string sql = "SELECT * FROM [tab_authors] WHERE [s1]=@s1 AND [s2] IS NULL;";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqSelectOrderBy()
		{
			var q1 = new Select<DataBaseDemo.Author>();
			q1.OrderByLinq(x => x.Ascending("id").Descending("date"));
			string result = q1.GetSql();
			string sql = "SELECT * FROM [tab_authors] ORDER BY [id] ASC, [date] DESC;";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqSelectGroupBy()
		{
			var q1 = new Select<DataBaseDemo.Author>();
			q1.GroupByLinq(x => x.FuncMax("max", "mx").FuncMin("min", "mn").FuncCount("all"));
			string result = q1.GetSql();
			string sql = "SELECT MAX([max]) as 'mx', MIN([min]) as 'mn', COUNT([all]) FROM [tab_authors] GROUP BY [max], [min], [all];";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqSelect1()
		{
			var q1 = new Select<DataBaseDemo.Author>();
			q1.ColumnsLinq(x => x.Append("a", "b", "c").AppendAlias("d", "ddd").FuncMax("price")).WhereLinq(w=>w.Equal("a", "b", "c").IsNULL("active")).OrderByLinq(x=>x.Ascending("created_at"));
			string result = q1.GetSql();
			string sql = "SELECT [a], [b], [c], [d] as 'ddd', MAX([price]) FROM [tab_authors] WHERE [a]=@a AND [b]=@b AND [c]=@c AND [active] IS NULL ORDER BY [created_at] ASC;";
			Assert.AreEqual(result, sql);
		}

	}

}