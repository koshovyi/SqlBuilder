using System.Collections.Generic;
using System.Text.RegularExpressions;
using SqlBuilder.Interfaces;

namespace SqlBuilder
{

	public class Template : ITemplate
	{

		private const string ESC_START = "{{";
		private const string ESC_END = "}}";

		private List<ITemplateSnippet> _expressions;

		public IParameters Parameters { get; set; }

		public string Pattern { get; set; }

		public IEnumerable<ITemplateSnippet> Snippets
		{
			get
			{
				return this._expressions;
			}
		}

		public Template(string Pattern)
		{
			this.Pattern = Pattern;
			this.Parameters = SqlBuilder.Parameters;
			this._expressions = new List<ITemplateSnippet>();
		}

		public ITemplate Append(params ITemplateSnippet[] Snippets)
		{
			foreach(ITemplateSnippet snippet in Snippets)
				this._expressions.Add(snippet);
			return this;
		}

		public ITemplate Append(string Name, string Code, string Prefix = "", string Postfix = "")
		{
			ITemplateSnippet snippet = new Snippet(Name, Code, Prefix, Postfix);
			this.Append(snippet);
			return this;
		}

		public string GetSql(bool EndOfStatement = true)
		{
			string pattern = this.Pattern;

			if (EndOfStatement)
				this.Append(SnippetLibrary.End(Parameters.EndOfStatement.ToString()));

			foreach(ITemplateSnippet snippet in this._expressions)
			{
				string text = ESC_START + snippet.Name + ESC_END;
				if (pattern.Contains(text))
				{
					pattern = pattern.Replace(text, snippet.Prefix + snippet.Code + snippet.Postfix);
				}
			}

			pattern = Regex.Replace(pattern, ESC_START + "([A-Za-z0-9_]+)" + ESC_END, string.Empty, RegexOptions.IgnoreCase | RegexOptions.Singleline);

			return pattern;
		}

	}

}