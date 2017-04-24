using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	public class XRedpointExMgr : XRedpointMgr, IXRedpointExMgr, IXRedpointMgr, IXRedpointRelationMgr, IXRedpointForbidMgr
	{
		protected uint mCurrentLevel;

		protected Dictionary<int, HashSet<uint>> mSysForbidLevelsDic = new Dictionary<int, HashSet<uint>>();

		public void AddSysForbidLevels(int sys, uint level)
		{
			HashSet<uint> hashSet = null;
			if (!this.mSysForbidLevelsDic.TryGetValue(sys, out hashSet))
			{
				hashSet = new HashSet<uint>();
				this.mSysForbidLevelsDic[sys] = hashSet;
			}
			if (hashSet.Add(level) && this.mCurrentLevel == level)
			{
				this._RefreshSysRedpointUI(sys, base._GetSysRedpointState(sys));
			}
		}

		public void RemoveSysForbidLevels(int sys, uint level)
		{
			HashSet<uint> hashSet = null;
			if (this.mSysForbidLevelsDic.TryGetValue(sys, out hashSet) && hashSet.Remove(level))
			{
				if (hashSet.Count <= 0)
				{
					this.mSysForbidLevelsDic.Remove(sys);
				}
				if (this.mCurrentLevel == level)
				{
					this._RefreshSysRedpointUI(sys, base._GetSysRedpointState(sys));
				}
			}
		}

		public void InitCurrentLevel(uint level)
		{
			this.mCurrentLevel = level;
		}

		public void SetCurrentLevel(uint level)
		{
			if (level != this.mCurrentLevel)
			{
				this.mCurrentLevel = level;
				foreach (KeyValuePair<int, HashSet<uint>> current in this.mSysForbidLevelsDic)
				{
					if (current.Value.Contains(level) && base._GetSysRedpointState(current.Key))
					{
						this._RefreshSysRedpointUI(current.Key, false);
					}
				}
			}
		}

		protected override void _RefreshSysRedpointUI(int sys, bool redpoint)
		{
			if (redpoint)
			{
				HashSet<uint> hashSet = null;
				if (this.mSysForbidLevelsDic.TryGetValue(sys, out hashSet) && hashSet.Contains(this.mCurrentLevel))
				{
					redpoint = false;
				}
			}
			base._RefreshSysRedpointUI(sys, redpoint);
		}
	}
}
