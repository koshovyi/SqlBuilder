using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class Query
	{

		[TestMethod]
		[TestCategory("Query - Methods")]
		public void QuerySelect()
		{
			var q1 = Query<DataBaseDemo.Author>.CreateSelect();
			q1.Where.Equal("id");

			var q2 = new Query<DataBaseDemo.Author>().Select();
			q2.Where.Equal("id");

			var q3 = new Select<DataBaseDemo.Author>();
			q3.Where.Equal("id");

			Assert.AreEqual(q3.GetSql(), q2.GetSql());
			Assert.AreEqual(q3.GetSql(), q1.GetSql());
		}

		[TestMethod]
		[TestCategory("Query - Methods")]
		public void QueryDelete()
		{
			var q1 = Query<DataBaseDemo.Author>.CreateDelete();
			q1.Where.Equal("id");

			var q2 = new Query<DataBaseDemo.Author>().Delete();
			q2.Where.Equal("id");

			var q3 = new Delete<DataBaseDemo.Author>();
			q3.Where.Equal("id");

			Assert.AreEqual(q3.GetSql(), q2.GetSql());
			Assert.AreEqual(q3.GetSql(), q1.GetSql());
		}

		[TestMethod]
		[TestCategory("Query - Methods")]
		public void QueryInsert()
		{
			var q1 = Query<DataBaseDemo.Author>.CreateInsert();
			q1.AppendParameters("q1", "q2", "q3");

			var q2 = new Query<DataBaseDemo.Author>().Insert();
			q2.AppendParameters("q1", "q2", "q3");

			var q3 = new Insert<DataBaseDemo.Author>();
			q3.AppendParameters("q1", "q2", "q3");

			Assert.AreEqual(q3.GetSql(), q2.GetSql());
			Assert.AreEqual(q3.GetSql(), q1.GetSql());
		}

		[TestMethod]
		[TestCategory("Query - Methods")]
		public void QueryUpdate()
		{
			var q1 = Query<DataBaseDemo.Author>.CreateUpdate();
			q1.Sets.Append("q1", "q2", "q3");

			var q2 = new Query<DataBaseDemo.Author>().Update();
			q2.Sets.Append("q1", "q2", "q3");

			var q3 = new Update<DataBaseDemo.Author>();
			q3.Sets.Append("q1", "q2", "q3");

			Assert.AreEqual(q3.GetSql(), q2.GetSql());
			Assert.AreEqual(q3.GetSql(), q1.GetSql());
		}

	}

}