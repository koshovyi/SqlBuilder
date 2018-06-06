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

		ITemplate Append(params ITemplateSnippet[] snippets);

		ITemplate Append(string name, string code, string prefix = "", string postfix = "");

		string GetSql();

	}

}