using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class Update
	{

		#region Update Simple

		[TestMethod]
		[TestCategory("Query - Update")]
		public void QueryUpdateSimple1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Update<DataBaseDemo.Author> u = new Update<DataBaseDemo.Author>();
			u.Sets.Append("a", "b", "c");
			u.Sets.Append("d", "1").Append("e", "NOW()");
			
			string result = u.GetSql();
			string sql = "UPDATE [tab_authors] SET [a]=@a, [b]=@b, [c]=@c, [d]=1, [e]=NOW();";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Update")]
		public void QueryUpdateSimple2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Update<DataBaseDemo.Author> u = new Update<DataBaseDemo.Author>();
			u.Sets.Append("a", "b", "c");
			u.Where.Equal("d", "e", "f");

			string result = u.GetSql();
			string sql = "UPDATE [tab_authors] SET [a]=@a, [b]=@b, [c]=@c WHERE [d]=@d AND [e]=@e AND [f]=@f;";
			Assert.AreEqual(sql, result);
		}

		#endregion

	}

}