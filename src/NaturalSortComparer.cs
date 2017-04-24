using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class NaturalSortComparer<T> : IDisposable, IComparer<string>
{
	private readonly bool isAscending;

	private Dictionary<string, string[]> table = new Dictionary<string, string[]>();

	public NaturalSortComparer(bool inAscendingOrder = true)
	{
		this.isAscending = inAscendingOrder;
	}

	int IComparer<string>.Compare(string x, string y)
	{
		if (x == y)
		{
			return 0;
		}
		string[] array;
		if (!this.table.TryGetValue(x, out array))
		{
			array = Regex.Split(x.Replace(" ", string.Empty), "([0-9]+)");
			this.table.Add(x, array);
		}
		string[] array2;
		if (!this.table.TryGetValue(y, out array2))
		{
			array2 = Regex.Split(y.Replace(" ", string.Empty), "([0-9]+)");
			this.table.Add(y, array2);
		}
		int num = 0;
		int num2;
		while (num < array.Length && num < array2.Length)
		{
			if (array[num] != array2[num])
			{
				num2 = NaturalSortComparer<T>.PartCompare(array[num], array2[num]);
				return (!this.isAscending) ? (-num2) : num2;
			}
			num++;
		}
		if (array2.Length > array.Length)
		{
			num2 = 1;
		}
		else if (array.Length > array2.Length)
		{
			num2 = -1;
		}
		else
		{
			num2 = 0;
		}
		return (!this.isAscending) ? (-num2) : num2;
	}

	public int Compare(string x, string y)
	{
		throw new NotImplementedException();
	}

	private static int PartCompare(string left, string right)
	{
		int num;
		if (!int.TryParse(left, out num))
		{
			return left.CompareTo(right);
		}
		int value;
		if (!int.TryParse(right, out value))
		{
			return left.CompareTo(right);
		}
		return num.CompareTo(value);
	}

	public void Dispose()
	{
		this.table.Clear();
		this.table = null;
	}
}
