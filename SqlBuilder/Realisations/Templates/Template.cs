using System.Collections.Generic;
using System.Text.RegularExpressions;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Templates
{

	public class Template : ITemplate
	{

		private const string ESC_START = "{{";
		private const string ESC_END = "}}";

		private readonly List<ITemplateSnippet> _expressions;

		public IFormatter Parameters { get; set; }

		public string Pattern { get; set; }

		public IEnumerable<ITemplateSnippet> Snippets
		{
			get
			{
				return this._expressions;
			}
		}

		public Template(string pattern)
		{
			this.Pattern = pattern;
			this.Parameters = SqlBuilder.DefaultFormatter;
			this._expressions = new List<ITemplateSnippet>();
		}

		public ITemplate Append(params ITemplateSnippet[] snippets)
		{
			foreach(ITemplateSnippet snippet in snippets)
				this._expressions.Add(snippet);
			return this;
		}

		public ITemplate Append(string name, string code, string prefix = "", string postfix = "")
		{
			ITemplateSnippet snippet = new Snippet(name, code, prefix, postfix);
			this.Append(snippet);
			return this;
		}

		public string GetSql()
		{
			string pattern = this.Pattern;

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