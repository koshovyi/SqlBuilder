using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IQuery<T>
	{

		Delete<T> Delete();

		Insert<T> Insert();

		Select<T> Select();

		Update<T> Update();

	}

}