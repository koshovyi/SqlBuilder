using SqlBuilder.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SqlBuilder
{

	public static class Reflection
	{

		public static IEnumerable<A> GetAttributes<T, A>()
		{
			Type type = typeof(T);
			foreach (A attr in type.GetCustomAttributes(typeof(A), false))
			{
				yield return attr;
			}
		}

		public static string GetTableName<T>()
		{
			string result = typeof(T).Name.ToLower();
			foreach (TableNameAttribute a in typeof(T).GetCustomAttributes(typeof(TableNameAttribute), false))
			{
				result = a.TableName;
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
				foreach (ForeignKeyAttribute pk in property.GetCustomAttributes(typeof(ForeignKeyAttribute), false))
				{
					result.Add(property.Name);
					break;
				}
			}

			return result.ToArray();
		}

	}

}