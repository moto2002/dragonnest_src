using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	public abstract class XRedpointDirtyMgr
	{
		protected HashSet<int> mDirtySysList = new HashSet<int>();

		protected Dictionary<int, bool> mSysRedpointStateDic = new Dictionary<int, bool>();

		public abstract void RecalculateRedPointSelfState(int sys, bool bImmUpdateUI = true);

		public abstract void RefreshAllSysRedpoints();

		protected abstract void _RefreshSysRedpointUI(int sys, bool redpoint);

		protected bool _GetSysRedpointState(int sys)
		{
			bool result = false;
			this.mSysRedpointStateDic.TryGetValue(sys, out result);
			return result;
		}
	}
}
