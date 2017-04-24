using System;

[Serializable]
public class UniWebViewEdgeInsets
{
	public int top;

	public int left;

	public int bottom;

	public int right;

	public UniWebViewEdgeInsets(int aTop, int aLeft, int aBottom, int aRight)
	{
		this.top = aTop;
		this.left = aLeft;
		this.bottom = aBottom;
		this.right = aRight;
	}

	public override int GetHashCode()
	{
		return (this.top + this.left + this.bottom + this.right).GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj == null || base.GetType() != obj.GetType())
		{
			return false;
		}
		UniWebViewEdgeInsets uniWebViewEdgeInsets = (UniWebViewEdgeInsets)obj;
		return this.top == uniWebViewEdgeInsets.top && this.left == uniWebViewEdgeInsets.left && this.bottom == uniWebViewEdgeInsets.bottom && this.right == uniWebViewEdgeInsets.right;
	}

	public static bool operator ==(UniWebViewEdgeInsets inset1, UniWebViewEdgeInsets inset2)
	{
		return inset1.Equals(inset2);
	}

	public static bool operator !=(UniWebViewEdgeInsets inset1, UniWebViewEdgeInsets inset2)
	{
		return !inset1.Equals(inset2);
	}
}
