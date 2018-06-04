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
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			ValueList w = new ValueList(SqlBuilder.Parameters);
			w.Append("a", "b", "c");
			string result = w.GetSql();
			string sql = "a, b, c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("ValueList")]
		public void ValuesSimple2()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			ValueList w = new ValueList(SqlBuilder.Parameters);
			w.AppendParameters("a", "b", "c");
			string result = w.GetSql();
			string sql = "@a, @b, @c";
			Assert.AreEqual(sql, result);
		}

	}

}
