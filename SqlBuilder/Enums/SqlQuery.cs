namespace SqlBuilder.Enums
{

	public enum SqlQuery : uint
	{
		None = 0,
		Raw = 1,
		Select = 2,
		Update = 3,
		Delete = 4,
		Insert = 5,
	}

}