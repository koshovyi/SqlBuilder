namespace SqlBuilder.Enums
{

	public enum WhereType : uint
	{
		None = 0,
		Raw = 1,
		In = 2,
		Equal = 3,
		NotEqual = 4,
		EqualGreater = 5,
		EqualLess = 6,
		Greater = 7,
		Less = 8,
		IsNULL = 9,
		IsNotNULL = 10,
		Between = 11,
		NotBetween = 12,
		Like = 13,
		NotLike = 14,
	}

}