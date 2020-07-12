# SqlBuilder [Beta]

**SqlBuilder** - simple and tiny SQL builder. Most easy way to create sql queries from code for **.NET Core** :)

[![Nuget](https://img.shields.io/nuget/v/Koshovyi.SqlBuilder)](https://www.nuget.org/packages/Koshovyi.SqlBuilder/)

### Install

`nuget install	Koshovyi.SqlBuilder`

### Features

* Supports special [database attributes](#db_attributes) and [reflection](#reflection);
* Supports RAW sql string (columns, subqueries, aggregation functions etc.);
* Supports all standard SQL DML queries: [SELECT](#sql_select), [DELETE](#sql_delete), [INSERT](#sql_insert) and [UPDATE](#sql_update);
* Supports only paramterized queries for safe value escaping;
* Supports query templates;
* Supports LINQ extensions (`using SqlBuilder.Linq;`);
* And many more features;

### Usage - Quick Guide

```csharp
string sql = new Select<Author>(Format.MsSQL)
	.Columns(c =>	
	{
		c.Append("s1", "s2", "s3");
		c.FuncMin("date");
	})
	.Where(w =>
	{
		w.Equal("s1", "s2");
		w.IsNotNULL("created_at");
		w.IsNULL("activated");
	})
	.GroupBy(g =>
	{
		g.Append(false, "country", "city");
		g.FuncCount("all", "countOfAll");
	})
	.OrderBy("age")
	.GetSql();

/* Result:

SELECT [s1], [s2], [s3], MIN([date]), COUNT([all]) as 'countOfAll' FROM [tab_authors] WHERE [s1]=@s1 AND [s2]=@s2 AND [created_at] IS NOT NULL AND [activated] IS NULL GROUP BY [country], [city], [all] ORDER BY [age] ASC;

*/
```

### Simple examples (DML)

**Select** <a id="sql_select"></a>

```csharp

```

**Insert** <a id="sql_insert"></a>

1. Insert columns:

```csharp
string sql = new Insert(Format.MsSQL, "table")
	.AppendParameters("a", "b", "c")
	.GetSql();

/* Result:

INSERT INTO [table]([a], [b], [c]) VALUES(@a, @b, @c);

*/
```

2. Insert custom columns and custom values:

```csharp
string sql = new Insert(Format.MsSQL, "table")
	.AppendParameters("firstName", "lastName")
	.Columns("createdAt")
	.Values("'NOW()'")
	.GetSql();

/* Result:

INSERT INTO [table]([firstName], [lastName], [createdAt]) VALUES(@firstName, @lastName, 'NOW()');

*/
```

3. Insert new row for &lt;T&gt; + default attributes:

```csharp
string sql = new Insert<Author>(Format.MsSQL)
	.GetSql();

/* Result:

INSERT INTO [author]([firstName], [lastName], [createdAt]) VALUES(@firstName, @lastName, 'NOW()');

*/
```

**Delete** <a id="sql_delete"></a>

1. Delete all rows:

```csharp
string sql = new Delete(Format.MsSQL, "table")
	.GetSql();

/* Result:

DELETE FROM [table];

*/

```

2. Delete all rows (table with alias):

```csharp
string sql = new Delete(Format.MsSQL, "table", "t")
	.GetSql();

/* Result:

DELETE FROM [table] as [t];

*/

```

3. Delete row where id=@id (Parameter):

```csharp
string sql = new Delete(Format.MsSQL, "table")
	.Where("id")
	.GetSql();

/* Result:

DELETE FROM [table] WHERE [id]=@id;

*/

```

4. Delete row where id=123 (Value):

```csharp
string sql = new Delete(Format.MsSQL, "table")
	.Where(w => w.EqualValue("id", "123"))
	.GetSql();

/* Result:

DELETE FROM [table] WHERE [id]=123;

*/

```

5. Delete row &lt;T&gt; + where:

```csharp
string sql = new Delete<Author>(Format.MsSQL, "td")
	.Where(w => w.Equal("p1").Less("p2").IsNULL("p3"));
	.GetSql();

/* Result:

DELETE FROM [tab_authors] as [td] WHERE [td].[p1]=@p1 AND [td].[p2]<@p2 AND [td].[p3] IS NULL;

*/

```

**Update** <a id="sql_update"></a>

1. Update all rows:

```csharp
string sql = new Update<Author>(Format.MsSQL)
	.GetSql();

/* Result:

UPDATE [authors] SET [firstname]=@firstname, [lastname]=@lastname;

*/

```

2. Update rows where id=@id (Parameter):

```csharp
string sql = new Update<Author>(Format.MsSQL)
	.Where("id")
	.GetSql();

/* Result:

UPDATE [authors] SET [firstname]=@firstname, [lastname]=@lastname WHERE [id]=@id;

*/

```

3. Update rows where id=123 (Value):

```csharp
string sql = new Update<Author>(Format.MsSQL)
	.Where(w => w.EqualValue("id", "123"))
	.GetSql();

/* Result:

UPDATE [authors] SET [firstname]=@firstname, [lastname]=@lastname WHERE [id]=123;

*/

```

3. Update rows where id=123 (Value):

```csharp
string sql = new Update<Author>(Format.MsSQL)
	.Where(w => w.EqualValue("id", "123"))
	.GetSql();

/* Result:

UPDATE [authors] SET [firstname]=@firstname, [lastname]=@lastname WHERE [id]=123;

*/

```

### Database attributes <a name="db_attributes"></a>

SqlBuilder attributes:

| Attribute | Description |
|--------|-------------|
|TableNameAttribute|Set custom table name (and optionaly alias) |
|ColumnAttribute|Set custom column name|
|PrimaryKeyAttribute|Attribute for PK|
|ForeignKeyAttribute|Attribute for FK|
|IgnoreInsertAttribute|Ignore property from INSERT statement|
|IgnoreUpdateAttribute|Ignore property from UPDATE statement|
|InsertDefaultAttribute|Default value for INSERT statement|
|UpdateDefaultAttribute|Default value for UPDATE statement|

### Reflection <a name="reflection"></a>

SqlBuilder reflection methods:

| Method | Description | Attribute |
|--------|-------------|-------------|
|GetTableName&lt;T&gt;|Get table name|`TableNameAttribute`|
|GetTableAlias&lt;T&gt;|Get table alias|`TableNameAttribute`|
|GetPrimaryKey&lt;T&gt;|Get PK from table|`PrimaryKeyAttribute`|
|GetForeignKeys&lt;T&gt;|Get FK[] array from table|`ForeignKeyAttribute`|
