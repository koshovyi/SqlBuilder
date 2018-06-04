namespace SqlBuilder.Enums
{

	public enum WhereType : uint
	{
		Unknown = 0,
		Equal,
		NotEqual,
		EqualGreater,
		EqualLess,
		Greater,
		Less,
		IsNULL,
		IsNotNULL,
		Between,
		NotBetween,
		Like,
		NotLike,
	}

}