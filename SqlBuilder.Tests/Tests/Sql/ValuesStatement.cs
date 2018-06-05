using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Sql;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class ValuesStatement
	{

		[TestMethod]
		[TestCategory("ValueList")]
		public void ValuesSimple1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ValueList w = new ValueList(SqlBuilder.DefaultFormatter);
			w.Append("a", "b", "c");
			string result = w.GetSql();
			string sql = "a, b, c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("ValueList")]
		public void ValuesSimple2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			ValueList w = new ValueList(SqlBuilder.DefaultFormatter);
			w.AppendParameters("a", "b", "c");
			string result = w.GetSql();
			string sql = "@a, @b, @c";
			Assert.AreEqual(sql, result);
		}

	}

}
