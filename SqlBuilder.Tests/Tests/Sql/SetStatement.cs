using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Sql;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class SetStatement
	{

		[TestMethod]
		[TestCategory("SetList")]
		public void ValuesSimple1()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			SetList w = new SetList(SqlBuilder.Parameters);
			w.Append("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]=@a, [b]=@b, [c]=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("SetList")]
		public void ValuesSimple2()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			SetList w = new SetList(SqlBuilder.Parameters);
			w.Append("a", "NOW()").Append("b", "100").Append("c", "NULL");
			string result = w.GetSql();
			string sql = "[a]=NOW(), [b]=100, [c]=NULL";
			Assert.AreEqual(sql, result);
		}

	}

}
