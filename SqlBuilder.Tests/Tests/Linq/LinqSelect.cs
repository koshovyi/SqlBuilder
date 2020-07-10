using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlBuilder.Linq;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class LinqSelect
	{

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqSelectColumns()
		{
			var q1 = new Select<DataBaseDemo.Author>(Format.MsSQL);
			q1.Columns(x => x.Append("a", "b", "c"));
			string result = q1.GetSql();
			string sql = "SELECT [a], [b], [c] FROM [tab_authors];";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqSelectWhere()
		{
			var q1 = new Select<DataBaseDemo.Author>(Format.MsSQL);
			q1.Where(x=>x.Equal("s1").IsNULL("s2"));
			string result = q1.GetSql();
			string sql = "SELECT * FROM [tab_authors] WHERE [s1]=@s1 AND [s2] IS NULL;";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqSelectOrderBy()
		{
			var q1 = new Select<DataBaseDemo.Author>(Format.MsSQL);
			q1.OrderBy(x => x.Ascending("id").Descending("date"));
			string result = q1.GetSql();
			string sql = "SELECT * FROM [tab_authors] ORDER BY [id] ASC, [date] DESC;";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqSelectGroupBy()
		{
			var q1 = new Select<DataBaseDemo.Author>(Format.MsSQL);
			q1.GroupBy(x => x.FuncMax("max", "mx").FuncMin("min", "mn").FuncCount("all"));
			string result = q1.GetSql();
			string sql = "SELECT MAX([max]) as 'mx', MIN([min]) as 'mn', COUNT([all]) FROM [tab_authors] GROUP BY [max], [min], [all];";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqSelectJoin()
		{
			var q1 = new Select<DataBaseDemo.Author>(Format.MsSQL);
			q1.Join(j => j.LeftJoin("users", "id_user", "id", "u").Append("id_status", "ids")).Join(j => j.FullJoin("cities", "id_city", "idc", "c"));
			string result = q1.GetSql();
			string sql = "SELECT * FROM [tab_authors] LEFT JOIN [users] as [u] ON [tab_authors].[id_user]=[u].[id] AND [tab_authors].[id_status]=[u].[ids] FULL JOIN [cities] as [c] ON [tab_authors].[id_city]=[c].[idc];";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqSelectComplexQuery()
		{
			var q1 = new Select<DataBaseDemo.Author>(Format.MsSQL);
			q1.Columns(x => x.Append("a", "b", "c").AppendAlias("d", "ddd").FuncMax("price")).Where(w=>w.Equal("a", "b", "c").IsNULL("active")).GroupBy(x=>x.FuncCount("cnt", "ccc")).OrderBy(x=>x.Ascending("created_at"));
			string result = q1.GetSql();
			string sql = "SELECT [a], [b], [c], [d] as 'ddd', MAX([price]), COUNT([cnt]) as 'ccc' FROM [tab_authors] WHERE [a]=@a AND [b]=@b AND [c]=@c AND [active] IS NULL GROUP BY [cnt] ORDER BY [created_at] ASC;";
			Assert.AreEqual(result, sql);
		}

	}

}