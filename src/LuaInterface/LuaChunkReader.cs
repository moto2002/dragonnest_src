using System;

namespace LuaInterface
{
	public delegate string LuaChunkReader(IntPtr luaState, ref ReaderInfo data, ref uint size);
}
