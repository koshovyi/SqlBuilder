using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlBuilder.Sql;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class WhereStatement
	{

		#region Raw

		[TestMethod]
		[TestCategory("Where - Raw, In")]
		public void RawSimple1()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.Raw("[a] IS NULL AND [b]=2 AND [c] NOT LIKE '%text%'");
			string result = w.GetSql();
			string sql = "[a] IS NULL AND [b]=2 AND [c] NOT LIKE '%text%'";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Raw, In")]
		public void RawSimple2()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.Raw("[a] NOT LIKE '%text%'");
			w.Equal("id");
			string result = w.GetSql();
			string sql = "[a] NOT LIKE '%text%' AND [id]=@id";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region In

		[TestMethod]
		[TestCategory("Where - Raw, In")]
		public void InSimple1()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.Equal("a");
			w.In("b", "1", "2", "3");
			w.Equal("c");
			string result = w.GetSql();
			string sql = "[a]=@a AND [b] IN (1, 2, 3) AND [c]=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Raw, In")]
		public void InSimple2()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.In("id_user", "SELECT id FROM tab_users");
			string result = w.GetSql();
			string sql = "[id_user] IN (SELECT id FROM tab_users)";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Raw, In")]
		public void InSimple3()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.In("id_user", "SELECT id FROM tab_users");
			string result = w.GetSql();
			string sql = "[id_user] IN (SELECT id FROM tab_users)";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Equal, NotEqual

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndEqualSimple1()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.Equal("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]=@a AND [b]=@b AND [c]=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndEqualSimple2()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.Equal("a", "b", "c");
			string result = w.GetSql(tableAlias: "t");
			string sql = "[t].[a]=@a AND [t].[b]=@b AND [t].[c]=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndEqualParamValue()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
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
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.NotEqual("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]!=@a AND [b]!=@b AND [c]!=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Equal, NotEqual")]
		public void AndNotEqualParamValue()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
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
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
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
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.EqualGreater("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]>=@a AND [b]>=@b AND [c]>=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndEqualLess()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.EqualLess("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]<=@a AND [b]<=@b AND [c]<=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndGreater()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.Greater("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]>@a AND [b]>@b AND [c]>@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndLess()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.Less("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]<@a AND [b]<@b AND [c]<@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Greater, Less")]
		public void AndEqualGreaterParam()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
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
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
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
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
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
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
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
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
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
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.IsNULL("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a] IS NULL AND [b] IS NULL AND [c] IS NULL";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Combinations")]
		public void IsNotNullSimple()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
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
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
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
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
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
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
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

		[TestMethod]
		[TestCategory("Where - Parenthesis")]
		public void WhereParenthesis4()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.RawParenthesis("[a] IS NULL OR [b] IS NULL");
			string result = w.GetSql();
			string sql = "([a] IS NULL OR [b] IS NULL)";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Where - Parenthesis")]
		public void WhereParenthesis5()
		{
			WhereList w = new WhereList(global::SqlBuilder.Format.MsSQL);
			w.RawParenthesis("[a] IS NULL OR [b] IS NULL");
			w.RawParenthesis("[c] IS NULL OR [d] IS NULL");
			string result = w.GetSql();
			string sql = "([a] IS NULL OR [b] IS NULL) AND ([c] IS NULL OR [d] IS NULL)";
			Assert.AreEqual(sql, result);
		}

		#endregion

	}

}
