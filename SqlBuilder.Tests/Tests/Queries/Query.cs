using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class Query
	{

		#region Query

		[TestMethod]
		[TestCategory("Query - Methods")]
		public void QuerySelect()
		{
			var q1 = Query<DataBaseDemo.Author>.Factory.Select();
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
			var q1 = Query<DataBaseDemo.Author>.Factory.Delete();
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
			var q1 = Query<DataBaseDemo.Author>.Factory.Insert();
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
		}

		#endregion

	}

}