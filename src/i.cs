using System;
using System.Runtime.CompilerServices;

internal class i
{
	[CompilerGenerated]
	private int a;

	[CompilerGenerated]
	private int b;

	[CompilerGenerated]
	public int b()
	{
		return this.a;
	}

	[CompilerGenerated]
	public void b(int A_0)
	{
		this.a = A_0;
	}

	[CompilerGenerated]
	public int a()
	{
		return this.b;
	}

	[CompilerGenerated]
	public void a(int A_0)
	{
		this.b = A_0;
	}

	public i()
	{
		this.b(0);
		this.a(0);
	}

	public i(int A_0, int A_1)
	{
		this.b(A_0);
		this.a(A_1);
	}
}
