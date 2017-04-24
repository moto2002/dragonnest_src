using System;

namespace LuaInterface
{
	internal delegate object ExtractValue(IntPtr luaState, int stackPos);
}
