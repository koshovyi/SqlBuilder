using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlBuilder.Linq;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class Select
	{

		#region Select Simple

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleAllColumns()
		{
			string result = new Select<DataBaseDemo.Author>(Format.MsSQL).GetSql();
			string sql = "SELECT * FROM [tab_authors];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleAllColumnsAlias()
		{
			string result = new Select<DataBaseDemo.Author>(Format.MsSQL, "t").GetSql();
			string sql = "SELECT [t].* FROM [tab_authors] as [t];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleColumnsList()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL);
			s.Columns.Append("a", "b", "c");
			string result = s.GetSql();
			string sql = "SELECT [a], [b], [c] FROM [tab_authors];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleColumnsListStatic()
		{
			var s = new Query<DataBaseDemo.Author>(Format.MsSQL).Select();
			s.Columns.Append("a", "b", "c");
			string result = s.GetSql();
			string sql = "SELECT [a], [b], [c] FROM [tab_authors];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleColumnsListAlias()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL);
			s.Columns.Append("a", "b", "c");
			s.Columns.AppendAlias("d", "D");
			string result = s.GetSql();
			string sql = "SELECT [a], [b], [c], [d] as 'D' FROM [tab_authors];";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Select Where

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleWherePK()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL);
			s.Where.Equal(Reflection.GetPrimaryKey<DataBaseDemo.Author>());
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] WHERE [id]=@id;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleWherePKAlias()
		{
			var s = new Select<DataBaseDemo.Author>(Format.MsSQL, "t");
			s.Where.Equal(Reflection.GetPrimaryKey<DataBaseDemo.Author>());
			string result = s.GetSql();
			string sql = "SELECT [t].* FROM [tab_authors] as [t] WHERE [t].[id]=@id;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleWherePKStatic()
		{
			var s = new Query<DataBaseDemo.Author>(Format.MsSQL).SelectWherePK();
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] WHERE [id]=@id;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleWhereAnd()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL);
			s.Where.Equal("first_name", "last_name");
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] WHERE [first_name]=@first_name AND [last_name]=@last_name;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleWhereOr()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL);
			s.Where.Equal("position").Or().EqualGreater("age");
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] WHERE [position]=@position OR [age]>=@age;";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Select OrderBy

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleOrderByAsc()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL);
			s.OrderBy.Ascending("age");
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] ORDER BY [age] ASC;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleOrderByDesc()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL);
			s.OrderBy.Descending("age");
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] ORDER BY [age] DESC;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSimpleOrderByAscDesc()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL);
			s.OrderBy.Ascending("age").Descending("amount");
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] ORDER BY [age] ASC, [amount] DESC;";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Select GroupBy

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectGroupBySimple1()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL);
			s.GroupBy.Append(false, "country", "city");
			string result = s.GetSql();
			string sql = "SELECT * FROM [tab_authors] GROUP BY [country], [city];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectGroupBySimple2()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL);
			s.GroupBy.Append(true, "country", "city");
			string result = s.GetSql();
			string sql = "SELECT [country], [city] FROM [tab_authors] GROUP BY [country], [city];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectGroupBySimple3()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL);
			s.GroupBy.FuncMax("sm", "asm");
			string result = s.GetSql();
			string sql = "SELECT MAX([sm]) as 'asm' FROM [tab_authors] GROUP BY [sm];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectGroupBySimple4()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL, "t");
			s.GroupBy.FuncMax("sm", "asm");
			string result = s.GetSql();
			string sql = "SELECT MAX([sm]) as 'asm' FROM [tab_authors] as [t] GROUP BY [t].[sm];";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Select Join

		[TestMethod]
		[TestCategory("Query - Join")]
		public void QuerySelectJoinSimple1()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL);
			s.Columns.Append("a1", "a2", "a3");
			s.Join.InnerJoin("users", "u").Append("id_user", "id");
			string result = s.GetSql();
			string sql = "SELECT [a1], [a2], [a3] FROM [tab_authors] INNER JOIN [users] as [u] ON [tab_authors].[id_user]=[u].[id];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Join")]
		public void QuerySelectJoinSimple2()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL, "t");
			s.Columns.Append("a1");
			s.Join.InnerJoin("users", "u").Append("id_user", "id").Append("id_status", "id2");
			string result = s.GetSql();
			string sql = "SELECT [t].[a1] FROM [tab_authors] as [t] INNER JOIN [users] as [u] ON [t].[id_user]=[u].[id] AND [t].[id_status]=[u].[id2];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Join")]
		public void QuerySelectJoinSimple3()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL, "t");
			s.Columns.Append("a1");
			s.Join.InnerJoin("users", "u").Append("id_user", "id");
			s.Join.LeftJoin("statuses").Append("id_status", "id2");
			s.Join.RightJoin("profiles", "p").Append("id_profile", "id3");
			string result = s.GetSql();
			string sql = "SELECT [t].[a1] FROM [tab_authors] as [t] INNER JOIN [users] as [u] ON [t].[id_user]=[u].[id] LEFT JOIN [statuses] ON [t].[id_status]=[statuses].[id2] RIGHT JOIN [profiles] as [p] ON [t].[id_profile]=[p].[id3];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Join")]
		public void QuerySelectJoinSimple4()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL);
			s.Columns.Raw("[tab_authors].*", "[u].*", "[s].*");
			s.Join.LeftJoin("users", "id_user", "id", "u");
			s.Join.LeftJoin("statuses", "id_status", "id", "s");
			string result = s.GetSql();
			string sql = "SELECT [tab_authors].*, [u].*, [s].* FROM [tab_authors] LEFT JOIN [users] as [u] ON [tab_authors].[id_user]=[u].[id] LEFT JOIN [statuses] as [s] ON [tab_authors].[id_status]=[s].[id];";
			Assert.AreEqual(sql, result);
		}

		#endregion

		#region Select Hard

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectHard1()
		{
			Select<DataBaseDemo.Author> s = new Select<DataBaseDemo.Author>(Format.MsSQL);
			s.Columns.Append("s1", "s2", "s3").FuncMin("date");
			s.Where.Equal("s1", "s2").IsNotNULL("created_at").IsNULL("activated");
			s.GroupBy.Append(false, "country", "city").FuncCount("lll", "all");
			s.OrderBy.Ascending("age");
			string result = s.GetSql();
			string sql = "SELECT [s1], [s2], [s3], MIN([date]), COUNT([lll]) as 'all' FROM [tab_authors] WHERE [s1]=@s1 AND [s2]=@s2 AND [created_at] IS NOT NULL AND [activated] IS NULL GROUP BY [country], [city], [lll] ORDER BY [age] ASC;";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectHard2()
		{
			string sql1 = new Select<DataBaseDemo.Author>(Format.MsSQL)
				.Columns(c =>
				{
					c.Append("s1", "s2", "s3");
					c.FuncMin("date");
				})
				.Where(w =>
				{
					w.Equal("s1", "s2");
					w.IsNotNULL("created_at");
					w.IsNULL("activated");
				})
				.GroupBy(g =>
				{
					g.Append(false, "country", "city");
					g.FuncCount("lll", "all");
				})
				.OrderBy("age")
				.GetSql();
			
			string sql2 = "SELECT [s1], [s2], [s3], MIN([date]), COUNT([lll]) as 'all' FROM [tab_authors] WHERE [s1]=@s1 AND [s2]=@s2 AND [created_at] IS NOT NULL AND [activated] IS NULL GROUP BY [country], [city], [lll] ORDER BY [age] ASC;";
			Assert.AreEqual(sql1, sql2);
		}

		[TestMethod]
		[TestCategory("Query - Select")]
		public void QuerySelectSubQuery1()
		{
			Select<DataBaseDemo.Book> sub = new Select<DataBaseDemo.Book>(Format.MsSQL, "b");
			sub.Columns.FuncCount("id");
			sub.Where.EqualValue("id_author", "[a].[id]");

			Select<DataBaseDemo.Author> query = new Select<DataBaseDemo.Author>(Format.MsSQL, "a");
			query.Columns.Raw("[a].*");
			query.Columns.SubQuery(sub, "cnt");
			string result = query.GetSql();
			string sql = "SELECT [a].*, (SELECT COUNT([id]) FROM [tab_books] as [b] WHERE [b].[id_author]=[a].[id]) as 'cnt' FROM [tab_authors] as [a];";
			Assert.AreEqual(sql, result);
		}

		#endregion

	}

}