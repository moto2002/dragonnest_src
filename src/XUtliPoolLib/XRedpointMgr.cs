using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	public class XRedpointMgr : XRedpointForbidMgr, IXRedpointMgr, IXRedpointRelationMgr, IXRedpointForbidMgr
	{
		protected struct stRedpointGameObject
		{
			public static readonly XRedpointMgr.stRedpointGameObject Empty;

			public GameObject go;

			public SetRedpointUIHandler callback;
		}

		protected Dictionary<int, XRedpointMgr.stRedpointGameObject[]> mSysGameObjectListDic = new Dictionary<int, XRedpointMgr.stRedpointGameObject[]>();

		public void AddSysRedpointUI(int sys, GameObject go, SetRedpointUIHandler callback = null)
		{
			if (null == go)
			{
				return;
			}
			XRedpointMgr.stRedpointGameObject[] array = null;
			if (this.mSysGameObjectListDic.TryGetValue(sys, out array))
			{
				if (this._InsertObject(ref array, go, callback))
				{
					this.mSysGameObjectListDic[sys] = array;
				}
			}
			else
			{
				array = new XRedpointMgr.stRedpointGameObject[4];
				array[0].go = go;
				array[0].callback = callback;
				this.mSysGameObjectListDic[sys] = array;
			}
			go.SetActive(base._GetSysRedpointState(sys));
		}

		public void RemoveSysRedpointUI(int sys, GameObject go)
		{
			if (null == go)
			{
				return;
			}
			XRedpointMgr.stRedpointGameObject[] array = null;
			if (this.mSysGameObjectListDic.TryGetValue(sys, out array))
			{
				this._DeleteObject(ref array, go);
			}
		}

		public void RemoveAllSysRedpointsUI(int sys)
		{
			this.mSysGameObjectListDic.Remove(sys);
		}

		public void ClearAllSysRedpointsUI()
		{
			this.mSysGameObjectListDic.Clear();
		}

		public void SetSysRedpointState(int sys, bool redpoint, bool immediately = false)
		{
			bool flag = true;
			bool flag2;
			if (this.mSysRedpointStateDic.TryGetValue(sys, out flag2))
			{
				flag = (flag2 != redpoint);
			}
			this.mSysRedpointStateDic[sys] = redpoint;
			if (flag)
			{
				if (immediately)
				{
					this._RefreshSysRedpointUI(sys, redpoint);
					this._RecalculateRedPointParentStates(sys, immediately);
					return;
				}
				this.mDirtySysList.Add(sys);
			}
		}

		public override void RefreshAllSysRedpoints()
		{
			foreach (int current in this.mDirtySysList)
			{
				this._RefreshSysRedpointUI(current, base._GetSysRedpointState(current));
			}
			this.mDirtySysList.Clear();
		}

		public override void RecalculateRedPointSelfState(int sys, bool bImmUpdateUI = true)
		{
			bool flag = false;
			int[] array = null;
			if (this.mParentChildRelationDic.TryGetValue(sys, out array))
			{
				int num = 0;
				while (num < array.Length && array[num] == 0 && !flag)
				{
					flag = (flag || base._GetSysRedpointState(array[num]));
					num++;
				}
			}
			if (flag != base._GetSysRedpointState(sys))
			{
				this.mSysRedpointStateDic[sys] = flag;
				if (bImmUpdateUI)
				{
					this._RefreshSysRedpointUI(sys, flag);
					return;
				}
				this.mDirtySysList.Add(sys);
			}
		}

		protected void _RecalculateRedPointParentStates(int child, bool bImmUpdateUI = true)
		{
			bool flag = base._GetSysRedpointState(child);
			if (flag)
			{
				int[] array = null;
				if (this.mChildParentRelationDic.TryGetValue(child, out array))
				{
					int num = 0;
					while (num < array.Length && array[num] != 0)
					{
						this.SetSysRedpointState(array[num], true, bImmUpdateUI);
						num++;
					}
				}
			}
		}

		protected override void _RefreshSysRedpointUI(int sys, bool redpoint)
		{
			if (redpoint && this.mForbidHashSet.Contains(sys))
			{
				redpoint = false;
			}
			XRedpointMgr.stRedpointGameObject[] array = null;
			if (this.mSysGameObjectListDic.TryGetValue(sys, out array))
			{
				int num = 0;
				while (num < array.Length && null != array[num].go)
				{
					if (array[num].callback == null)
					{
						array[num].go.SetActive(redpoint);
					}
					else
					{
						array[num].callback(array[num].go);
					}
					num++;
				}
			}
			this.mDirtySysList.Remove(sys);
		}

		protected bool _InsertObject(ref XRedpointMgr.stRedpointGameObject[] array, GameObject go, SetRedpointUIHandler callback)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (null == array[i].go || array[i].go == go)
				{
					array[i].go = go;
					array[i].callback = callback;
					return false;
				}
			}
			XRedpointMgr.stRedpointGameObject[] array2 = new XRedpointMgr.stRedpointGameObject[array.Length << 1];
			array.CopyTo(array2, 0);
			array2[array.Length].go = go;
			array2[array.Length].callback = callback;
			array = array2;
			return true;
		}

		protected void _DeleteObject(ref XRedpointMgr.stRedpointGameObject[] array, GameObject parent)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].go == parent)
				{
					XRedpointMgr.stRedpointGameObject stRedpointGameObject = default(XRedpointMgr.stRedpointGameObject);
					if (i + 1 < array.Length)
					{
						for (int j = array.Length - 1; j > i; j--)
						{
							if (null != array[j].go)
							{
								stRedpointGameObject = array[j];
								array[j] = default(XRedpointMgr.stRedpointGameObject);
								break;
							}
						}
					}
					array[i] = stRedpointGameObject;
				}
			}
		}
	}
}
