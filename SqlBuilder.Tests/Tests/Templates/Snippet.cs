using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class Snippets
	{

		[TestMethod]
		[TestCategory("Snippets")]
		public void SnippetNameValidation()
		{
			Snippet s1 = new Snippet("CODE", "S1");
			Snippet s2 = new Snippet("WHERE", "S2");
			Snippet s3 = new Snippet("ORDERBY", "S3");
			Snippet s4 = new Snippet("LIMIT", "S4");
			Snippet s5 = new Snippet("TEST_THIS", "S5");
		}

		[TestMethod]
		[TestCategory("Snippets")]
		public void SnippetNameValidationException()
		{
			Assert.ThrowsException<Exceptions.SnippetNameValidationException>(() => { new Snippet("@WHERE", ""); });
			Assert.ThrowsException<Exceptions.SnippetNameValidationException>(() => { new Snippet(" ", ""); });
			Assert.ThrowsException<Exceptions.SnippetNameValidationException>(() => { new Snippet("123sass=", ""); });
			Assert.ThrowsException<Exceptions.SnippetNameValidationException>(() => { new Snippet("BLA!BLA", ""); });
			Assert.ThrowsException<Exceptions.SnippetNameValidationException>(() => { new Snippet("Foo Bar", ""); });
		}

	}

}