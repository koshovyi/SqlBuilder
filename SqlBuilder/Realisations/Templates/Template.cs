using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class Template : Interfaces.ITemplate
	{
		public string Pattern { get; set; }
		public IEnumerable<ITemplateSnippet> Snippets { get; }

		public ITemplate Append(ITemplateSnippet Snippet)
		{
			throw new NotImplementedException();
		}

		public bool ContainsPart(string Name)
		{
			throw new NotImplementedException();
		}

		public string GetSql()
		{
			throw new NotImplementedException();
		}
	}

}
