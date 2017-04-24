using System;

namespace XUpdater
{
	internal enum eUPdatePhase
	{
		xUP_None,
		xUP_Prepare,
		xUP_FetchVersion,
		xUP_LoadVersion,
		xUP_CompareVersion,
		xUP_DownLoadConfirm,
		xUP_DownLoadBundle,
		xUP_ShowVersion,
		xUP_LaunchGame,
		xUP_Ending,
		xUP_Finish,
		xUP_Error
	}
}
