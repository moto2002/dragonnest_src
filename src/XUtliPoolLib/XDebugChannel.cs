using System;

namespace XUtliPoolLib
{
	public enum XDebugChannel
	{
		XDebug_Invalid,
		XDebug_Default,
		XDebug_Move,
		XDebug_Skill = 4,
		XDebug_Buff = 8,
		XDebug_Death = 16,
		XDebug_AI = 32,
		XDebug_UI = 64,
		XDebug_Component = 128,
		XDebug_Network = 256
	}
}
