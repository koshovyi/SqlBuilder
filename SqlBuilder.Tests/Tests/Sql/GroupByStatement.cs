using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Sql;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class GroupByStatement
	{

		[TestMethod]
		[TestCategory("GroupBy")]
		public void GroupBySimpleList1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListAggregation c = new ColumnsListAggregation(SqlBuilder.DefaultFormatter);
			GroupByList g = new GroupByList(SqlBuilder.DefaultFormatter, c);

			g.Append(false, "a", "b", "c");
			string result = g.GetSql();
			string sql = "[a], [b], [c]";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("GroupBy")]
		public void GroupBySimpleList2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListAggregation c = new ColumnsListAggregation(SqlBuilder.DefaultFormatter);
			GroupByList g = new GroupByList(SqlBuilder.DefaultFormatter, c);
			g.Append(false, "a", "b", "c");

			string result = g.GetSql();
			string sql = "[a], [b], [c]";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("GroupBy")]
		public void GroupBySimpleList3()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListAggregation c = new ColumnsListAggregation(SqlBuilder.DefaultFormatter);
			GroupByList g = new GroupByList(SqlBuilder.DefaultFormatter, c);
			g.Append(true, "a", "b", "c");

			string result = g.GetSql();
			string sql = "[a], [b], [c]";
			Assert.AreEqual(sql, result);
			Assert.AreEqual(c.Count, g.Count);
		}

		[TestMethod]
		[TestCategory("GroupBy")]
		public void GroupBySimpleListAlias()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListAggregation c = new ColumnsListAggregation(SqlBuilder.DefaultFormatter);
			GroupByList g = new GroupByList(SqlBuilder.DefaultFormatter, c);

			g.Append(false, "a", "b", "c");
			string result = g.GetSql("t");
			string sql = "'t'.[a], 't'.[b], 't'.[c]";
			Assert.AreEqual(sql, result);
		}


		[TestMethod]
		[TestCategory("GroupBy")]
		public void GroupByAggregation1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListAggregation c = new ColumnsListAggregation(SqlBuilder.DefaultFormatter);
			GroupByList g = new GroupByList(SqlBuilder.DefaultFormatter, c);
			g.FuncMax("sm");

			string result1 = g.GetSql();
			string sql1 = "[sm]";
			string result2 = c.GetSql();
			string sql2 = "MAX([sm])";

			Assert.AreEqual(sql1, result1);
			Assert.AreEqual(sql2, result2);
			Assert.AreEqual(c.Count, g.Count);
		}

		[TestMethod]
		[TestCategory("GroupBy")]
		public void GroupByAggregation2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListAggregation c = new ColumnsListAggregation(SqlBuilder.DefaultFormatter);
			GroupByList g = new GroupByList(SqlBuilder.DefaultFormatter, c);
			g.FuncMin("sm");

			string result1 = g.GetSql();
			string sql1 = "[sm]";
			string result2 = c.GetSql();
			string sql2 = "MIN([sm])";

			Assert.AreEqual(sql1, result1);
			Assert.AreEqual(sql2, result2);
			Assert.AreEqual(c.Count, g.Count);
		}

		[TestMethod]
		[TestCategory("GroupBy")]
		public void GroupByAggregation3()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListAggregation c = new ColumnsListAggregation(SqlBuilder.DefaultFormatter);
			GroupByList g = new GroupByList(SqlBuilder.DefaultFormatter, c);
			g.FuncCount("sm");

			string result1 = g.GetSql();
			string sql1 = "[sm]";
			string result2 = c.GetSql();
			string sql2 = "COUNT([sm])";

			Assert.AreEqual(sql1, result1);
			Assert.AreEqual(sql2, result2);
			Assert.AreEqual(c.Count, g.Count);
		}

		[TestMethod]
		[TestCategory("GroupBy")]
		public void GroupByAggregation4()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListAggregation c = new ColumnsListAggregation(SqlBuilder.DefaultFormatter);
			GroupByList g = new GroupByList(SqlBuilder.DefaultFormatter, c);
			g.FuncSum("sm");

			string result1 = g.GetSql();
			string sql1 = "[sm]";
			string result2 = c.GetSql();
			string sql2 = "SUM([sm])";

			Assert.AreEqual(sql1, result1);
			Assert.AreEqual(sql2, result2);
			Assert.AreEqual(c.Count, g.Count);
		}

		[TestMethod]
		[TestCategory("GroupBy")]
		public void GroupByAggregationMany()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListAggregation c = new ColumnsListAggregation(SqlBuilder.DefaultFormatter);
			GroupByList g = new GroupByList(SqlBuilder.DefaultFormatter, c);
			g.FuncSum("sm", "asm");
			g.FuncMax("mx", "amx");
			g.FuncMin("mn", "amn");

			string result1 = g.GetSql();
			string sql1 = "[sm], [mx], [mn]";
			string result2 = c.GetSql();
			string sql2 = "SUM([sm]) as 'asm', MAX([mx]) as 'amx', MIN([mn]) as 'amn'";

			Assert.AreEqual(sql1, result1);
			Assert.AreEqual(sql2, result2);
			Assert.AreEqual(c.Count, g.Count);
		}

	}

}