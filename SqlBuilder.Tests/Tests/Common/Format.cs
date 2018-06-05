using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class Format
	{

		[TestMethod]
		[TestCategory("Format")]
		public void FormatColumns()
		{
			string column = "date";
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			string result1 = SqlBuilder.FormatColumn(column);
			Assert.AreEqual('[' + column + ']', result1);

			SqlBuilder.DefaultFormatter = FormatterLibrary.MySql;
			string result2 = SqlBuilder.FormatColumn(column);
			Assert.AreEqual('`' + column + '`', result2);

			SqlBuilder.DefaultFormatter.EscapeEnabled = false;
			string result3 = SqlBuilder.FormatColumn(column);
			Assert.AreEqual(column, result3);
		}

		[TestMethod]
		[TestCategory("Format")]
		public void FormatTable()
		{
			string table = "tab_users";
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			string result1 = SqlBuilder.FormatTable(table);
			Assert.AreEqual('[' + table + ']', result1);

			SqlBuilder.DefaultFormatter = FormatterLibrary.MySql;
			string result2 = SqlBuilder.FormatTable(table);
			Assert.AreEqual('`' + table + '`', result2);

			SqlBuilder.DefaultFormatter.EscapeEnabled = false;
			string result3 = SqlBuilder.FormatTable(table);
			Assert.AreEqual(table, result3);
		}

		[TestMethod]
		[TestCategory("Format")]
		public void FormatAlias()
		{
			string alias = "text for alias";
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			string result1 = SqlBuilder.FormatAlias(alias);
			Assert.AreEqual('\'' + alias + '\'', result1);

			SqlBuilder.DefaultFormatter = FormatterLibrary.MySql;
			string result2 = SqlBuilder.FormatAlias(alias);
			Assert.AreEqual('\"' + alias + '\"', result2);
		}

		[TestMethod]
		[TestCategory("Format")]
		public void FormatParameter()
		{
			string name = "login";
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			string result1 = SqlBuilder.FormatParameter(name);
			Assert.AreEqual('@' + name, result1);

			SqlBuilder.DefaultFormatter = FormatterLibrary.MySql;
			string result2 = SqlBuilder.FormatParameter(name);
			Assert.AreEqual('?' + name, result2);
		}

	}

}