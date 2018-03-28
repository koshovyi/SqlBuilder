namespace SqlBuilder.Enums
{

	public enum WhereExpressionType : uint
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