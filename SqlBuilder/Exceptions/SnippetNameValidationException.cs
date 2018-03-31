using System;

namespace SqlBuilder.Exceptions
{

	public class SnippetNameValidationException : Exception
	{

		public string NewName { get; set; }
		public string OldName { get; set; }
		public SnippetNameValidationException(string NewName, string OldName)
		{
			this.NewName = NewName;
			this.OldName = OldName;
		}

	}

}