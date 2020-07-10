using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class QueryTests
	{

		[TestMethod]
		[TestCategory("Query - Methods")]
		public void QuerySelect()
		{
			var q1 = new Query<DataBaseDemo.Author>(global::SqlBuilder.Format.MsSQL).Select();
			q1.Where.Equal("id");

			var q2 = new Select<DataBaseDemo.Author>(global::SqlBuilder.Format.MsSQL);
			q2.Where.Equal("id");

			Assert.AreEqual(q1.GetSql(), q2.GetSql());
		}

		[TestMethod]
		[TestCategory("Query - Methods")]
		public void QueryDelete()
		{
			var q1 = new Query<DataBaseDemo.Author>(global::SqlBuilder.Format.MsSQL).Delete();
			q1.Where.Equal("id");

			var q2 = new Delete<DataBaseDemo.Author>(global::SqlBuilder.Format.MsSQL);
			q2.Where.Equal("id");

			Assert.AreEqual(q1.GetSql(), q2.GetSql());
		}

		[TestMethod]
		[TestCategory("Query - Methods")]
		public void QueryInsert()
		{
			var q1 = new Query<DataBaseDemo.Author>(global::SqlBuilder.Format.MsSQL).Insert();
			q1.AppendParameters("q1", "q2", "q3");

			var q2 = new Insert<DataBaseDemo.Author>(global::SqlBuilder.Format.MsSQL);
			q2.AppendParameters("q1", "q2", "q3");

			Assert.AreEqual(q1.GetSql(), q2.GetSql());
		}

		[TestMethod]
		[TestCategory("Query - Methods")]
		public void QueryUpdate()
		{
			var q1 = new Query<DataBaseDemo.Author>(global::SqlBuilder.Format.MsSQL).Update();
			q1.Sets.Append("q1", "q2", "q3");

			var q2 = new Update<DataBaseDemo.Author>(global::SqlBuilder.Format.MsSQL);
			q2.Sets.Append("q1", "q2", "q3");

			Assert.AreEqual(q1.GetSql(), q2.GetSql());
		}

	}

}