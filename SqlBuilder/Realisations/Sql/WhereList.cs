using SqlBuilder.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Sql
{
	public class WhereList
	{

		private readonly List<Where> _expressions;

		#region Properties

		public Format Parameters { get; private set; }

		public Enums.WhereLogic LogicOperator { get; private set; } = Enums.WhereLogic.And;

		public bool HasOpenedParenthesis { get; private set; }

		public int Level { get; private set; }

		public IEnumerable<Where> Expressions
		{
			get
			{
				return this._expressions;
			}
		}

		#endregion

		#region Construcor

		public WhereList(Format parameters)
		{
			this._expressions = new List<Where>();
			this.Parameters = parameters;
		}

		#endregion

		#region Logic operators

		public WhereList And()
		{
			this.LogicOperator = Enums.WhereLogic.And;
			return this;
		}

		public WhereList Or()
		{
			this.LogicOperator = Enums.WhereLogic.Or;
			return this;
		}

		public WhereList AndNot()
		{
			this.LogicOperator = Enums.WhereLogic.AndNot;
			return this;
		}

		#endregion

		#region Expressions List

		public int Count
		{
			get
			{
				return this._expressions.Count;
			}
		}

		public void Append(Where expression)
		{
			this._expressions.Add(expression);
		}

		public void Clear()
		{
			this._expressions.Clear();
		}

		private void CreateExpression(Enums.WhereType type, string column, string value, string prefix = "", string postfix = "")
		{
			Where exp = new Where(type, this.LogicOperator)
			{
				Column = column,
				IsColumn = true,
				Value = value,
				Prefix = prefix,
				Postfix = postfix,
			};
			this.Append(exp);
		}

		private void CreateParenthesis(Enums.Parenthesis parenthesis, string value = "")
		{
			Where exp = new Where(Enums.WhereType.None, this.LogicOperator, parenthesis)
			{
				Value = value,
			};
			this.Append(exp);
		}

		#endregion

		#region Expressions

		public WhereList Raw(string rawSql)
		{
			Where exp = new Where(Enums.WhereType.Raw, this.LogicOperator)
			{
				IsColumn = false,
				Value = rawSql,
			};
			this.Append(exp);
			return this;
		}

		public WhereList In(string column, IStatementSelect query)
		{
			CreateExpression(Enums.WhereType.In, column, " IN (" + query.GetSql(true).ToString() + ")");

			return this;
		}

		public WhereList In(string column, params string[] rawSql)
		{
			StringBuilder sb = new StringBuilder();
			foreach (string expression in rawSql)
			{
				if (sb.Length > 0)
					sb.Append(", ");
				sb.Append(expression);
			}

			CreateExpression(Enums.WhereType.In, column, " IN (" + sb.ToString() + ")");
			return this;
		}

		public WhereList EqualValue(string column, string value)
		{
			CreateExpression(Enums.WhereType.Equal, column, '=' + value);
			return this;
		}

		public WhereList Equal(params string[] columns)
		{
			foreach (string expression in columns)
				this.EqualValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public WhereList NotEqualValue(string column, string value)
		{
			CreateExpression(Enums.WhereType.NotEqual, column, "!=" + value);
			return this;
		}

		public WhereList NotEqual(params string[] columns)
		{
			foreach (string expression in columns)
				this.NotEqualValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public WhereList EqualLessValue(string column, string value)
		{
			CreateExpression(Enums.WhereType.EqualLess, column, "<=" + value);
			return this;
		}

		public WhereList EqualLess(params string[] columns)
		{
			foreach(string expression in columns)
				this.EqualLessValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public WhereList EqualGreaterValue(string column, string value)
		{
			CreateExpression(Enums.WhereType.EqualGreater, column, ">=" + value);
			return this;
		}

		public WhereList EqualGreater(params string[] columns)
		{
			foreach (string expression in columns)
				this.EqualGreaterValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public WhereList LessValue(string column, string value)
		{
			CreateExpression(Enums.WhereType.Less, column, "<" + value);
			return this;
		}

		public WhereList Less(params string[] columns)
		{
			foreach (string expression in columns)
				this.LessValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public WhereList GreaterValue(string column, string value)
		{
			CreateExpression(Enums.WhereType.Less, column, ">" + value);
			return this;
		}

		public WhereList Greater(params string[] columns)
		{
			foreach (string expression in columns)
				this.GreaterValue(expression, this.Parameters.Parameter + expression);
			return this;
		}

		public WhereList IsNULL(params string[] columns)
		{
			foreach (string expression in columns)
			{
				CreateExpression(Enums.WhereType.IsNULL, expression, " IS NULL");
			}
			return this;
		}

		public WhereList IsNotNULL(params string[] columns)
		{
			foreach (string expression in columns)
			{
				CreateExpression(Enums.WhereType.IsNotNULL, expression, " IS NOT NULL");
			}
			return this;
		}

		public WhereList Between(string name, string begin, string end)
		{
			string value = " BETWEEN " + this.Parameters.Parameter + begin + " AND " + this.Parameters.Parameter + end;
			CreateExpression(Enums.WhereType.Between, name, value);
			return this;
		}

		public WhereList NotBetween(string name, string begin, string end)
		{
			string value = " NOT BETWEEN " + this.Parameters.Parameter + begin + " AND " + this.Parameters.Parameter + end;
			CreateExpression(Enums.WhereType.NotBetween, name, value);
			return this;
		}

		public WhereList Like(string name, string pattern)
		{
			string value = this.Parameters.Parameter + name + " LIKE " + pattern;
			CreateExpression(Enums.WhereType.Like, "", value);
			return this;
		}

		public WhereList NotLike(string name, string pattern)
		{
			string value = this.Parameters.Parameter + name + " NOT LIKE " + pattern;
			CreateExpression(Enums.WhereType.NotLike, "", value);
			return this;
		}

		#endregion

		#region Parenthesis

		public WhereList OpenParenthesis(int count = 1)
		{
			for (int i = 0; i < count; i++)
			{
				this.CreateParenthesis(Enums.Parenthesis.OpenParenthesis);
				this.HasOpenedParenthesis = true;
				this.Level++;
			}
			return this;
		}

		public WhereList CloseParenthesis(int count = 1)
		{
			for (int i = 0; i < count; i++)
			{
				if (this.Level == 0)
					throw new Exceptions.ParenthesisExpectedException();

				this.CreateParenthesis(Enums.Parenthesis.CloseParenthesis);
				this.Level--;
				this.HasOpenedParenthesis = this.Level > 0;
			}
			return this;
		}

		public WhereList RawParenthesis(string rawSql)
		{
			this.OpenParenthesis();
			this.Raw(rawSql);
			this.CloseParenthesis();
			return this;
		}

		#endregion

		#region Render SQL

		public string GetSql(string tableAlias = "")
		{
			StringBuilder sb = new StringBuilder();

			bool logic = false, lastparenthesis = false;
			foreach(Where expression in this._expressions)
			{
				if (logic && !lastparenthesis && expression.Parenthesis != Enums.Parenthesis.CloseParenthesis)
				{
					sb.Append(' ');
					sb.Append(GetSqlCurrentLogic(expression.Logic));
					sb.Append(' ');
				}
				else
					logic = true;

				if (expression.Parenthesis == Enums.Parenthesis.OpenParenthesis)
				{
					sb.Append('(');
					lastparenthesis = true;
				}
				else if (expression.Parenthesis == Enums.Parenthesis.CloseParenthesis)
				{
					sb.Append(')');
					lastparenthesis = false;
				}
				else
				{
					if (expression.IsColumn)
						sb.Append(SqlBuilder.FormatColumn(expression.Column, this.Parameters, tableAlias));

					sb.Append(expression.Value);
					lastparenthesis = false;
				}
			}

			return sb.ToString();
		}

		private string GetSqlCurrentLogic(Enums.WhereLogic logic)
		{
			switch (logic)
			{
				case Enums.WhereLogic.AndNot:
					return "AND NOT";
				case Enums.WhereLogic.Or:
					return "OR";
				default:
				case Enums.WhereLogic.And:
					return "AND";
			}
		}

		#endregion

		public override string ToString()
		{
			return this.GetSql();
		}

	}

}
