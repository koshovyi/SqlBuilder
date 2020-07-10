using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class FormatTests
	{

		[TestMethod]
		[TestCategory("Format")]
		public void FormatColumns()
		{
			string column = "date";

			string result1 = SqlBuilder.FormatColumn(column, Format.MsSQL);
			Assert.AreEqual('[' + column + ']', result1);

			string result2 = SqlBuilder.FormatColumn(column, Format.MySQL);
			Assert.AreEqual('`' + column + '`', result2);

			Format c = Format.MySQL;
			c.EscapeEnabled = false;
			string result3 = SqlBuilder.FormatColumn(column, c);
			Assert.AreEqual(column, result3);

			string result4 = SqlBuilder.FormatColumn(column, Format.MsSQL, "t");
			Assert.AreEqual("[t].[" + column + ']', result4);
		}

		[TestMethod]
		[TestCategory("Format")]
		public void FormatTable()
		{
			string table = "tab_users";

			string result1 = SqlBuilder.FormatTable(table, Format.MsSQL);
			Assert.AreEqual('[' + table + ']', result1);

			string result2 = SqlBuilder.FormatTable(table, Format.MySQL);
			Assert.AreEqual('`' + table + '`', result2);

			Format c = Format.MySQL;
			c.EscapeEnabled = false;
			string result3 = SqlBuilder.FormatTable(table, c);
			Assert.AreEqual(table, result3);
		}

		[TestMethod]
		[TestCategory("Format")]
		public void FormatAliasColumn()
		{
			string alias = "text for alias";

			string result1 = SqlBuilder.FormatColumnAlias(alias, Format.MsSQL);
			Assert.AreEqual('\'' + alias + '\'', result1);

			string result2 = SqlBuilder.FormatColumnAlias(alias, Format.MySQL);
			Assert.AreEqual('\"' + alias + '\"', result2);
		}

		[TestMethod]
		[TestCategory("Format")]
		public void FormatAliasTable()
		{
			string alias = "tbl";

			string result1 = SqlBuilder.FormatTableAlias(alias, Format.MsSQL);
			Assert.AreEqual('[' + alias + ']', result1);

			string result2 = SqlBuilder.FormatTableAlias(alias, Format.MySQL);
			Assert.AreEqual('`' + alias + '`', result2);
		}

		[TestMethod]
		[TestCategory("Format")]
		public void FormatParameter()
		{
			string name = "login";

			string result1 = SqlBuilder.FormatParameter(name, Format.MsSQL);
			Assert.AreEqual('@' + name, result1);

			string result2 = SqlBuilder.FormatParameter(name, Format.MySQL);
			Assert.AreEqual('?' + name, result2);
		}

	}

}