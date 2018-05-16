using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder
{

	public static class TemplateLibrary
	{

		public static Interfaces.ITemplate Select
		{
			get
			{
				string sql = "{{START}}SELECT {{PRECOLUMNS}}{{COLUMNS}}{{POSTCOLUMNS}} FROM {{TABLE}}{{JOINS}}{{WHERE}}{{GROUPBY}}{{ORDERBY}}{{END}}";
				return new Template(sql);
			}
		}

		public static Interfaces.ITemplate Insert
		{
			get
			{
				string sql = "{{START}}INSERT INTO {{TABLE}}({{COLUMNS}}) VALUES({{VALUES}}){{END}}";
				return new Template(sql);
			}
		}

		public static Interfaces.ITemplate Delete
		{
			get
			{
				string sql = "{{START}}DELETE FROM {{TABLE}}{{WHERE}}{{END}}";
				return new Template(sql);
			}
		}

		public static Interfaces.ITemplate Update
		{
			get
			{
				string sql = "{{START}}UPDATE {{TABLE}} SET {{SETS}}{{WHERE}}{{END}}";
				return new Template(sql);
			}
		}

		public static Interfaces.ITemplate Truncate
		{
			get
			{
				string sql = "{{START}}TRUNCATE TABLE {{TABLE}}{{END}}";
				return new Template(sql);
			}
		}

		public static Interfaces.ITemplate DropDatabase
		{
			get
			{
				string sql = "{{START}}DROP DATABASE {{DATABASE}}{{END}}";
				return new Template(sql);
			}
		}

		public static Interfaces.ITemplate DropTable
		{
			get
			{
				string sql = "{{START}}DROP TABLE {{DATABASE}}{{END}}";
				return new Template(sql);
			}
		}

	}

}