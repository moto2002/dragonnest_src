using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	public abstract class XRedpointForbidMgr : XRedpointRelationMgr, IXRedpointForbidMgr
	{
		protected HashSet<int> mForbidHashSet = new HashSet<int>();

		public void AddForbid(int sys, bool bImmUpdateUI = true)
		{
			if (this.mForbidHashSet.Add(sys))
			{
				if (bImmUpdateUI)
				{
					this._RefreshSysRedpointUI(sys, base._GetSysRedpointState(sys));
					return;
				}
				this.mDirtySysList.Add(sys);
			}
		}

		public void AddForbids(int[] systems, bool bImmUpdateUI = true)
		{
			if (systems == null || systems.Length == 0)
			{
				return;
			}
			for (int i = 0; i < systems.Length; i++)
			{
				if (this.mForbidHashSet.Add(systems[i]))
				{
					if (bImmUpdateUI)
					{
						this._RefreshSysRedpointUI(systems[i], base._GetSysRedpointState(systems[i]));
					}
					else
					{
						this.mDirtySysList.Add(systems[i]);
					}
				}
			}
		}

		public void RemoveForbid(int sys, bool bImmUpdateUI = true)
		{
			if (this.mForbidHashSet.Remove(sys))
			{
				if (bImmUpdateUI)
				{
					this._RefreshSysRedpointUI(sys, base._GetSysRedpointState(sys));
					return;
				}
				this.mDirtySysList.Add(sys);
			}
		}

		public void RemoveForbids(int[] systems, bool bImmUpdateUI = true)
		{
			if (systems == null || systems.Length == 0)
			{
				return;
			}
			for (int i = 0; i < systems.Length; i++)
			{
				if (this.mForbidHashSet.Remove(systems[i]))
				{
					if (bImmUpdateUI)
					{
						this._RefreshSysRedpointUI(systems[i], base._GetSysRedpointState(systems[i]));
					}
					else
					{
						this.mDirtySysList.Add(systems[i]);
					}
				}
			}
		}

		public void ClearForbids(bool bImmUpdateUI = true)
		{
			foreach (int current in this.mForbidHashSet)
			{
				if (bImmUpdateUI)
				{
					this._RefreshSysRedpointUI(current, base._GetSysRedpointState(current));
				}
				else
				{
					this.mDirtySysList.Add(current);
				}
			}
			this.mForbidHashSet.Clear();
		}
	}
}
