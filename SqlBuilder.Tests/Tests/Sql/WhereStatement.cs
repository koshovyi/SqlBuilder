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
		public void AndEqualSimple1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.Equal("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]=@a AND [b]=@b AND [c]=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndEqualSimple2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.Equal("a", "b", "c");
			string result = w.GetSql(tableAlias: "t");
			string sql = "'t'.[a]=@a AND 't'.[b]=@b AND 't'.[c]=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndEqualParamValue()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.EqualValue("a", "1");
			w.EqualValue("b", "2");
			w.EqualValue("c", "3");
			string result = w.GetSql();
			string sql = "[a]=1 AND [b]=2 AND [c]=3";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndNotEqualSimple()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.NotEqual("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]!=@a AND [b]!=@b AND [c]!=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndNotEqualParamValue()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.NotEqualValue("a", "1");
			w.NotEqualValue("b", "2");
			w.NotEqualValue("c", "3");
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
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.EqualValue("a", "1");
			w.NotEqualValue("b", "2");
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
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.EqualGreater("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]>=@a AND [b]>=@b AND [c]>=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndEqualLess()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.EqualLess("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]<=@a AND [b]<=@b AND [c]<=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndGreater()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.Greater("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]>@a AND [b]>@b AND [c]>@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndLess()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.Less("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]<@a AND [b]<@b AND [c]<@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndEqualGreaterParam()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.EqualGreaterValue("a", "1");
			w.EqualGreaterValue("b", "2");
			w.EqualGreaterValue("c", "3");
			string result = w.GetSql();
			string sql = "[a]>=1 AND [b]>=2 AND [c]>=3";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndEqualLessParam()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.EqualLessValue("a", "1");
			w.EqualLessValue("b", "2");
			w.EqualLessValue("c", "3");
			string result = w.GetSql();
			string sql = "[a]<=1 AND [b]<=2 AND [c]<=3";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndGreaterParam()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.GreaterValue("a", "1");
			w.GreaterValue("b", "2");
			w.GreaterValue("c", "3");
			string result = w.GetSql();
			string sql = "[a]>1 AND [b]>2 AND [c]>3";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndLessParam()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.LessValue("a", "1");
			w.LessValue("b", "2");
			w.LessValue("c", "3");
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
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
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
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.IsNULL("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a] IS NULL AND [b] IS NULL AND [c] IS NULL";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Combinations")]
		public void IsNotNullSimple()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.IsNotNULL("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a] IS NOT NULL AND [b] IS NOT NULL AND [c] IS NOT NULL";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Parenthesis

		[TestMethod]
		[TestCategory("Where - Parenthesis")]
		public void WhereParenthesis1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.OpenParenthesis();
			w.Or();
			w.IsNULL("a", "b", "c");
			w.CloseParenthesis();
			string result = w.GetSql();
			string sql = "([a] IS NULL OR [b] IS NULL OR [c] IS NULL)";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Parenthesis")]
		public void WhereParenthesis2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.Equal("id");
			w.OpenParenthesis(2);
			w.IsNULL("a", "b", "c");
			w.CloseParenthesis();
			w.Or();
			w.OpenParenthesis();
			w.And();
			w.IsNULL("d", "e", "f");
			w.CloseParenthesis(2);
			string result = w.GetSql();
			string sql = "[id]=@id AND (([a] IS NULL AND [b] IS NULL AND [c] IS NULL) OR ([d] IS NULL AND [e] IS NULL AND [f] IS NULL))";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Parenthesis")]
		public void WhereParenthesis3()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			WhereList w = new WhereList(SqlBuilder.DefaultFormatter);
			w.OpenParenthesis(3);
			w.Or();
			w.IsNULL("a", "b");
			w.CloseParenthesis();
			w.And();
			w.OpenParenthesis();
			w.Or();
			w.IsNULL("c", "d");
			w.CloseParenthesis(2);
			w.And();
			w.Less("ls");
			w.CloseParenthesis();
			w.Greater("gr");
			string result = w.GetSql();
			string sql = "((([a] IS NULL OR [b] IS NULL) AND ([c] IS NULL OR [d] IS NULL)) AND [ls]<@ls) AND [gr]>@gr";
			Assert.AreEqual(sql, result);
		}

		#endregion

	}

}
