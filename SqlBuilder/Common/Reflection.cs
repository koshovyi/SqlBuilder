using SqlBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SqlBuilder
{

	public static class Reflection
	{

		public static string GetTableName<T>()
		{
			string result = typeof(T).Name;
			foreach (TableNameAttribute a in typeof(T).GetCustomAttributes(typeof(TableNameAttribute), false))
			{
				result = a.Name;
				break;
			}
			return result;
		}

		public static string GetTableAlias<T>()
		{
			string result = string.Empty;
			foreach (TableNameAttribute a in typeof(T).GetCustomAttributes(typeof(TableNameAttribute), false))
			{
				result = a.Alias;
				break;
			}
			return result;
		}

		public static string GetPrimaryKey<T>()
		{
			Type type = typeof(T);
			foreach (PropertyInfo property in type.GetProperties())
			{
				foreach (PrimaryKeyAttribute pk in property.GetCustomAttributes(typeof(PrimaryKeyAttribute), false))
				{
					if(pk.ToLowerCase)
						return property.Name.ToLower();
					return property.Name;
				}
			}

			throw new Exceptions.PrimaryKeyNotFoundException();
		}

		public static string[] GetForeignKeys<T>()
		{
			Type type = typeof(T);
			List<string> result = new List<string>();
			foreach (PropertyInfo property in type.GetProperties())
			{
				string name = string.Empty;
				foreach (ForeignKeyAttribute pk in property.GetCustomAttributes(typeof(ForeignKeyAttribute), false))
				{
					name = pk.Name;
					if (string.IsNullOrEmpty(name))
						name = property.Name;
					if (pk.ToLowerCase)
						name = name.ToLower();
					break;
				}
				if(!string.IsNullOrEmpty(name))
					result.Add(name);
			}

			if (result.Count == 0)
				throw new Exceptions.ForeignKeyNotFoundException();
			return result.ToArray();
		}

	}

}
