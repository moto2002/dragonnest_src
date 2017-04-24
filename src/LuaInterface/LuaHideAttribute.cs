using System;

namespace LuaInterface
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class LuaHideAttribute : Attribute
	{
	}
}
