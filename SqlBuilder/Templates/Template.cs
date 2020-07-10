using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SqlBuilder.Templates
{

	public class Template
	{

		private const string ESC_START = "{{";
		private const string ESC_END = "}}";

		private readonly List<Snippet> _expressions;

		public string Pattern { get; set; }

		public IEnumerable<Snippet> Snippets
		{
			get
			{
				return this._expressions;
			}
		}

		public Template(string pattern)
		{
			this.Pattern = pattern;
			this._expressions = new List<Snippet>();
		}

		public Template Append(params Snippet[] snippets)
		{
			foreach(Snippet snippet in snippets)
				this._expressions.Add(snippet);
			return this;
		}

		public Template Append(string name, string code, string prefix = "", string postfix = "")
		{
			Snippet snippet = new Snippet(name, code, prefix, postfix);
			this.Append(snippet);
			return this;
		}

		public string GetSql(Format formatter)
		{
			string pattern = this.Pattern;

			this.Append(SnippetLibrary.End(formatter.EndOfStatement.ToString()));

			foreach(Snippet snippet in this._expressions)
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
