using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Sql;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class WhereStatement
	{

		#region Equal, NotEqual

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndEqualSimple()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.Equal("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]=@a AND [b]=@b AND [c]=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndEqualParamValue()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.EqualParam("a", "1");
			w.EqualParam("b", "2");
			w.EqualParam("c", "3");
			string result = w.GetSql();
			string sql = "[a]=1 AND [b]=2 AND [c]=3";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndNotEqualSimple()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.NotEqual("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]!=@a AND [b]!=@b AND [c]!=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndNotEqualParamValue()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.NotEqualParam("a", "1");
			w.NotEqualParam("b", "2");
			w.NotEqualParam("c", "3");
			string result = w.GetSql();
			string sql = "[a]!=1 AND [b]!=2 AND [c]!=3";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Equal, NotEqual - Combinations

		[TestMethod]
		[TestCategory("Where - Combinations")]
		public void ComboAndEqualAndNotEqual()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.EqualParam("a", "1");
			w.NotEqualParam("b", "2");
			string result = w.GetSql();
			string sql = "[a]=1 AND [b]!=2";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Greater, Less

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndEqualGreater()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.EqualGreater("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]>=@a AND [b]>=@b AND [c]>=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndEqualLess()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.EqualLess("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]<=@a AND [b]<=@b AND [c]<=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndGreater()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.Greater("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]>@a AND [b]>@b AND [c]>@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndLess()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.Less("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]<@a AND [b]<@b AND [c]<@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndEqualGreaterParam()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.EqualGreaterParam("a", "1");
			w.EqualGreaterParam("b", "2");
			w.EqualGreaterParam("c", "3");
			string result = w.GetSql();
			string sql = "[a]>=1 AND [b]>=2 AND [c]>=3";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndEqualLessParam()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.EqualLessParam("a", "1");
			w.EqualLessParam("b", "2");
			w.EqualLessParam("c", "3");
			string result = w.GetSql();
			string sql = "[a]<=1 AND [b]<=2 AND [c]<=3";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndGreaterParam()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.GreaterParam("a", "1");
			w.GreaterParam("b", "2");
			w.GreaterParam("c", "3");
			string result = w.GetSql();
			string sql = "[a]>1 AND [b]>2 AND [c]>3";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndLessParam()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.LessParam("a", "1");
			w.LessParam("b", "2");
			w.LessParam("c", "3");
			string result = w.GetSql();
			string sql = "[a]<1 AND [b]<2 AND [c]<3";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Greater, Less - Combinations

		[TestMethod]
		[TestCategory("Where - Combinations")]
		public void ComboAndGreaterAndLess()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.Greater("a");
			w.Less("b");
			string result = w.GetSql();
			string sql = "[a]>@a AND [b]<@b";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Null, NotNull, Beetween, Like

		[TestMethod]
		[TestCategory("Where - Combinations")]
		public void IsNullSimple()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.IsNULL("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a] IS NULL AND [b] IS NULL AND [c] IS NULL";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Combinations")]
		public void IsNotNullSimple()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.Parameters);
			w.IsNotNULL("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a] IS NOT NULL AND [b] IS NOT NULL AND [c] IS NOT NULL";
			Assert.AreEqual(sql, result);
		}

		#endregion

	}

}
