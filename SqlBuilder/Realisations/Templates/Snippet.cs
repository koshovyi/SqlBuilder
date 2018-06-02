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

		public Snippet(string Name, string Code, string Prefix = "", string Postfix = "")
		{
			this.Name = Name;
			this.Code = Code;
			this.Prefix = Prefix;
			this.Postfix = Postfix;
		}

		private bool IsValid(string Name)
		{
			return Regex.IsMatch(Name, "^([A-Za-z0-9_]+)$", RegexOptions.IgnoreCase | RegexOptions.Singleline);
		}
		
	}

}