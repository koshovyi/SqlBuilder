namespace SqlBuilder.Common
{

	public static class Compiler
	{

		public static string LastInsertID(Enums.SqlType query)
		{
			switch (query)
			{
				case Enums.SqlType.MySql:
					return "SELECT LAST_INSERT_ID()";
				case Enums.SqlType.PostgreSql:
					return "RETURNING 1";
				default:
				case Enums.SqlType.MsSql:
					return "SELECT @@IDENTITY";
			}
		}

	}

}