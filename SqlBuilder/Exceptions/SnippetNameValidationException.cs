using System;

namespace SqlBuilder.Exceptions
{

	public class SnippetNameValidationException : Exception
	{

		public string NewName { get; set; }

		public string OldName { get; set; }

		public SnippetNameValidationException(string newName, string oldName)
		{
			this.NewName = newName;
			this.OldName = oldName;
		}

	}

}
