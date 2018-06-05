using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface ITemplate
	{

		string Pattern { get; set; }

		IFormatter Parameters { get; set; }

		IEnumerable<ITemplateSnippet> Snippets { get; }

		ITemplate Append(params ITemplateSnippet[] Snippets);

		ITemplate Append(string Name, string Code, string Prefix = "", string Postfix = "");

		string GetSql(bool EndOfStatement = true);

	}

}