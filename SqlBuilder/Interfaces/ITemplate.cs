using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface ITemplate
	{

		string Pattern { get; set; }

		IParameters Parameters { get; set; }

		IEnumerable<ITemplateSnippet> Snippets { get; }

		ITemplate Append(params ITemplateSnippet[] Snippets);

		ITemplate Append(string Name, string Code, string Prefix = "", string Postfix = "");

		string GetSql(bool EndOfStatement = true);

	}

	public interface ITemplateSnippet
	{

		string Name { get; set; }
		string Code { get; set; }
		string Prefix { get; set; }
		string Postfix { get; set; }

	}

}