using LuaInterface;
using System;

public struct LuaField
{
	public string name;

	public LuaCSFunction getter;

	public LuaCSFunction setter;

	public LuaField(string str, LuaCSFunction g, LuaCSFunction s)
	{
		this.name = str;
		this.getter = g;
		this.setter = s;
	}
}
