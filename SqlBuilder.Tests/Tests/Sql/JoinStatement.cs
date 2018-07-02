using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlBuilder.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class JoinStatement
	{

		#region Join types

		[TestMethod]
		[TestCategory("Join")]
		public void JoinPrimitivesInner()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Join j = new Join("users");
			j.Append("id_user", "id");

			string result = j.GetSql("t");
			string sql = "INNER JOIN [users] ON [t].[id_user]=[users].[id]";

			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Join")]
		public void JoinPrimitivesLeft()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Join j = new Join("users", type: Enums.JoinType.LEFT);
			j.Append("id_user", "id");

			string result = j.GetSql("t");
			string sql = "LEFT JOIN [users] ON [t].[id_user]=[users].[id]";

			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Join")]
		public void JoinPrimitivesRight()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Join j = new Join("users", type: Enums.JoinType.RIGHT);
			j.Append("id_user", "id");

			string result = j.GetSql("t");
			string sql = "RIGHT JOIN [users] ON [t].[id_user]=[users].[id]";

			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Join")]
		public void JoinPrimitivesFull()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Join j = new Join("users", type: Enums.JoinType.FULL);
			j.Append("id_user", "id");

			string result = j.GetSql("t");
			string sql = "FULL JOIN [users] ON [t].[id_user]=[users].[id]";

			Assert.AreEqual(result, sql);
		}

		#endregion

		#region Join simple

		[TestMethod]
		[TestCategory("Join")]
		public void JoinPrimitives1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Join j = new Join("users");
			j.Append("id_user", "id").Append("id_admin", "id");

			string result = j.GetSql("t");
			string sql = "INNER JOIN [users] ON [t].[id_user]=[users].[id] AND [t].[id_admin]=[users].[id]";

			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Join")]
		public void JoinPrimitives2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Join j = new Join("users", "u");
			j.Append("id_user", "id").Append("id_admin", "id");

			string result = j.GetSql("t");
			string sql = "INNER JOIN [users] as [u] ON [t].[id_user]=[u].[id] AND [t].[id_admin]=[u].[id]";

			Assert.AreEqual(result, sql);
		}

		#endregion

		#region Join many tables

		[TestMethod]
		[TestCategory("Join")]
		public void JoinSimpleTwoTables()
		{
			JoinList list = new JoinList(SqlBuilder.DefaultFormatter);

			Join j1 = new Join("users");
			j1.Append("id_user", "id").Append("id_admin", "id");
			list.Append(j1);

			Join j2 = new Join("profiles", "p", Enums.JoinType.LEFT);
			j2.Append("id_profile", "id");
			list.Append(j2);

			string result = list.GetSql("t");
			string sql = "INNER JOIN [users] ON [t].[id_user]=[users].[id] AND [t].[id_admin]=[users].[id] LEFT JOIN [profiles] as [p] ON [t].[id_profile]=[p].[id]";

			Assert.AreEqual(result, sql);
		}

		#endregion

	}

}