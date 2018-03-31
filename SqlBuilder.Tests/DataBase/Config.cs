using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Attributes;

namespace SqlBuilder.Tests.DataBaseDemo
{

	public class Config
	{

		[PrimaryKey]
		public string Name { get; set; }

		public string Value { get; set; }

	}

}