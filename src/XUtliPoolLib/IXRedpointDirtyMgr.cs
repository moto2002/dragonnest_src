using System;

namespace XUtliPoolLib
{
	internal interface IXRedpointDirtyMgr
	{
		void RecalculateRedPointState(int sys, bool bImmUpdateUI = true);
	}
}
