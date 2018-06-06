using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Sql;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class ColumnsStatement
	{

		[TestMethod]
		[TestCategory("Columns - List")]
		public void ColumnsSimpleEmpty()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListSimple c = new ColumnsListSimple(SqlBuilder.DefaultFormatter);
			c.Append();
			string result = c.GetSql();
			string sql = "*";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Columns - List")]
		public void ColumnsSimple1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListSimple c = new ColumnsListSimple(SqlBuilder.DefaultFormatter);
			c.Append("a", "b", "c");
			string result = c.GetSql();
			string sql = "[a], [b], [c]";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Columns - List")]
		public void ColumnsSimple2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListSimple c = new ColumnsListSimple(SqlBuilder.DefaultFormatter);
			c.Append("column");
			string result = c.GetSql();
			string sql = "[column]";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Columns - List")]
		public void ColumnsSimple3()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListSimple c = new ColumnsListSimple(SqlBuilder.DefaultFormatter);
			c.Append("column1").Append("column2");
			string result = c.GetSql();
			string sql = "[column1], [column2]";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Columns - List")]
		public void ColumnsSimpleAlias1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListSimple c = new ColumnsListSimple(SqlBuilder.DefaultFormatter);
			c.AppendAlias("last_name", "l");
			c.AppendAlias("first_name", "f");
			string result = c.GetSql();
			string sql = "[last_name] as 'l', [first_name] as 'f'";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Columns - List")]
		public void ColumnsSimpleAlias2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListSimple c = new ColumnsListSimple(SqlBuilder.DefaultFormatter);
			c.AppendAlias("last_name", "l");
			c.AppendAlias("first_name", "f");
			string result = c.GetSql("tbl");
			string sql = "'tbl'.[last_name] as 'l', 'tbl'.[first_name] as 'f'";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Columns - Aggregations")]
		public void ColumnsAggregations1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListAggregation c = new ColumnsListAggregation(SqlBuilder.DefaultFormatter);
			c.FuncCount("all");
			c.FuncMax("cnt", "max_cnt");
			string result = c.GetSql();
			string sql = "COUNT([all]), MAX([cnt]) as 'max_cnt'";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Columns - List")]
		public void ColumnsListSimpleRaw()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ColumnsListSimple c = new ColumnsListSimple(SqlBuilder.DefaultFormatter);
			c.Append("a", "b", "c");
			c.AppendAlias("last_name", "l");
			c.Raw("SELECT NOW()");
			c.Raw("SELECT 'abc'", "lll");
			c.Append("d");
			string result = c.GetSql("tbl");
			string sql = "'tbl'.[a], 'tbl'.[b], 'tbl'.[c], 'tbl'.[last_name] as 'l', (SELECT NOW()), (SELECT 'abc') as 'lll', 'tbl'.[d]";
			Assert.AreEqual(sql, result);
		}

	}

}
