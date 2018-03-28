using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface ITemplate
	{

		string Pattern { get; set; }
		bool ContainsPart(string Name);
		IEnumerable<ITemplateSnippet> Snippets { get; }
		ITemplate Append(ITemplateSnippet Snippet);
		string GetSql();

	}

	public interface ITemplateSnippet
	{

		string Name { get; set; }
		string Code { get; set; }
		string Prefix { get; set; }
		string Postfix { get; set; }
	}

}