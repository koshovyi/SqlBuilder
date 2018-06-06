using System.Text.RegularExpressions;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Templates
{

	public class Snippet : ITemplateSnippet
	{

		private string _Name;

		public string Code { get; set; }

		public string Prefix { get; set; }

		public string Postfix { get; set; }

		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if (!this.IsValid(value))
					throw new Exceptions.SnippetNameValidationException(value, this.Name);

				this._Name = value;
			}
		}

		public Snippet(string name, string code, string prefix = "", string postfix = "")
		{
			this.Name = name;
			this.Code = code;
			this.Prefix = prefix;
			this.Postfix = postfix;
		}

		private bool IsValid(string name)
		{
			return Regex.IsMatch(name, "^([A-Za-z0-9_]+)$", RegexOptions.IgnoreCase | RegexOptions.Singleline);
		}
		
	}

}