using LuaInterface;
using System;

public struct LuaMethod
{
	public string name;

	public LuaCSFunction func;

	public LuaMethod(string str, LuaCSFunction f)
	{
		this.name = str;
		this.func = f;
	}
}
