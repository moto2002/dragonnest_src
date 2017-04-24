using System;

namespace XUtliPoolLib
{
	public interface ILuaEngine
	{
		IHotfixManager hotfixMgr
		{
			get;
		}

		ILuaUIManager luaUIManager
		{
			get;
		}

		ILuaGameInfo luaGameInfo
		{
			get;
		}

		void InitLua();
	}
}
