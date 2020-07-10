namespace SqlBuilder.Templates
{

	public static class TemplateLibrary
	{

		public static Template Select
		{
			get
			{
				string sql = "{{START}}SELECT {{LIMIT_START}}{{OFFSET_START}}{{PRECOLUMNS}}{{COLUMNS}}{{POSTCOLUMNS}} FROM {{TABLE}}{{JOINS}}{{WHERE}}{{GROUPBY}}{{ORDERBY}}{{LIMIT_END}}{{OFFSET_END}}{{END}}";
				return new Template(sql);
			}
		}

		public static Template Insert
		{
			get
			{
				string sql = "{{START}}INSERT INTO {{TABLE}}({{COLUMNS}}) VALUES({{VALUES}}){{END}}";
				return new Template(sql);
			}
		}

		public static Template Delete
		{
			get
			{
				string sql = "{{START}}DELETE FROM {{TABLE}}{{WHERE}}{{END}}";
				return new Template(sql);
			}
		}

		public static Template Update
		{
			get
			{
				string sql = "{{START}}UPDATE {{TABLE}} SET {{SETS}}{{WHERE}}{{END}}";
				return new Template(sql);
			}
		}

		public static Template Truncate
		{
			get
			{
				string sql = "{{START}}TRUNCATE TABLE {{TABLE}}{{END}}";
				return new Template(sql);
			}
		}

		public static Template DropDatabase
		{
			get
			{
				string sql = "{{START}}DROP DATABASE {{DATABASE}}{{END}}";
				return new Template(sql);
			}
		}

		public static Template DropTable
		{
			get
			{
				string sql = "{{START}}DROP TABLE {{DATABASE}}{{END}}";
				return new Template(sql);
			}
		}

	}

}
