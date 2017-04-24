using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	public abstract class XRedpointRelationMgr : XRedpointDirtyMgr, IXRedpointRelationMgr
	{
		public const int BASE_ARRAY_LENGTH = 4;

		public const int NULL_ID = 0;

		protected Dictionary<int, int[]> mChildParentRelationDic = new Dictionary<int, int[]>();

		protected Dictionary<int, int[]> mParentChildRelationDic = new Dictionary<int, int[]>();

		public void AddRelation(int child, int parent, bool bImmUpdateUI = false)
		{
			if (child == 0)
			{
				return;
			}
			if (parent == 0)
			{
				return;
			}
			int[] array = null;
			if (this.mChildParentRelationDic.TryGetValue(child, out array))
			{
				if (this._InsertValue(ref array, parent))
				{
					this.mChildParentRelationDic[child] = array;
				}
			}
			else
			{
				array = new int[4];
				array[0] = parent;
				this.mChildParentRelationDic[child] = array;
			}
			int[] array2 = null;
			if (this.mParentChildRelationDic.TryGetValue(parent, out array2))
			{
				if (this._InsertValue(ref array2, child))
				{
					this.mParentChildRelationDic[parent] = array2;
				}
			}
			else
			{
				array2 = new int[4];
				array2[0] = child;
				this.mParentChildRelationDic[parent] = array2;
			}
			this.RecalculateRedPointSelfState(parent, bImmUpdateUI);
		}

		public void AddRelations(int child, int[] parents, bool bImmUpdateUI = false)
		{
			if (child == 0)
			{
				return;
			}
			if (parents == null || parents.Length == 0)
			{
				return;
			}
			int[] value = null;
			if (!this.mChildParentRelationDic.TryGetValue(child, out value))
			{
				value = new int[4];
				this.mChildParentRelationDic[child] = value;
			}
			for (int i = 0; i < parents.Length; i++)
			{
				if (parents[i] != 0)
				{
					if (this._InsertValue(ref value, parents[i]))
					{
						this.mChildParentRelationDic[child] = value;
					}
					int[] array = null;
					if (this.mParentChildRelationDic.TryGetValue(parents[i], out array))
					{
						if (this._InsertValue(ref array, child))
						{
							this.mParentChildRelationDic[parents[i]] = array;
						}
					}
					else
					{
						array = new int[4];
						array[0] = child;
						this.mParentChildRelationDic[parents[i]] = array;
					}
					this.RecalculateRedPointSelfState(parents[i], bImmUpdateUI);
				}
			}
		}

		public void RemoveRelation(int child, int parent, bool bImmUpdateUI = false)
		{
			if (child == 0)
			{
				return;
			}
			if (parent == 0)
			{
				return;
			}
			int[] array = null;
			if (this.mChildParentRelationDic.TryGetValue(child, out array))
			{
				this._DeleteValue(ref array, parent);
				if (array[0] == 0)
				{
					this.mChildParentRelationDic.Remove(child);
				}
			}
			int[] array2 = null;
			if (this.mParentChildRelationDic.TryGetValue(parent, out array2))
			{
				this._DeleteValue(ref array2, child);
				if (array2[0] == 0)
				{
					this.mParentChildRelationDic.Remove(parent);
				}
			}
			this.RecalculateRedPointSelfState(parent, bImmUpdateUI);
		}

		public void RemoveRelations(int child, int[] parents, bool bImmUpdateUI = false)
		{
			if (child == 0)
			{
				return;
			}
			if (parents == null || parents.Length == 0)
			{
				return;
			}
			int[] array = null;
			if (this.mChildParentRelationDic.TryGetValue(child, out array))
			{
				for (int i = 0; i < parents.Length; i++)
				{
					if (parents[i] != 0)
					{
						this._DeleteValue(ref array, parents[i]);
						if (array[0] == 0)
						{
							this.mChildParentRelationDic.Remove(child);
						}
						int[] array2 = null;
						if (this.mParentChildRelationDic.TryGetValue(parents[i], out array2))
						{
							this._DeleteValue(ref array2, child);
							if (array2[0] == 0)
							{
								this.mParentChildRelationDic.Remove(parents[i]);
							}
						}
						this.RecalculateRedPointSelfState(parents[i], bImmUpdateUI);
					}
				}
			}
		}

		public void RemoveAllRelations(int child, bool bImmUpdateUI = false)
		{
			if (child == 0)
			{
				return;
			}
			int[] array = null;
			if (this.mChildParentRelationDic.TryGetValue(child, out array))
			{
				for (int i = 0; i < array.Length; i++)
				{
					int[] array2 = null;
					if (this.mParentChildRelationDic.TryGetValue(array[i], out array2))
					{
						this._DeleteValue(ref array2, child);
						if (array2[0] == 0)
						{
							this.mParentChildRelationDic.Remove(array[i]);
						}
					}
					this.RecalculateRedPointSelfState(array[i], bImmUpdateUI);
				}
				this.mChildParentRelationDic.Remove(child);
			}
		}

		public void ClearAllRelations(bool bImmUpdateUI = false)
		{
			foreach (int current in this.mParentChildRelationDic.Keys)
			{
				this.mDirtySysList.Add(current);
			}
			foreach (int current2 in this.mParentChildRelationDic.Keys)
			{
				this.mSysRedpointStateDic[current2] = false;
			}
			this.mChildParentRelationDic.Clear();
			this.mParentChildRelationDic.Clear();
			if (bImmUpdateUI)
			{
				this.RefreshAllSysRedpoints();
			}
		}

		protected bool _InsertValue(ref int[] array, int value)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == 0 || value == array[i])
				{
					array[i] = value;
					return false;
				}
			}
			int[] array2 = new int[array.Length << 1];
			array.CopyTo(array2, 0);
			array2[array.Length] = value;
			array = array2;
			return true;
		}

		protected void _DeleteValue(ref int[] array, int parent)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == parent)
				{
					int num = 0;
					if (i + 1 < array.Length)
					{
						for (int j = array.Length - 1; j > i; j--)
						{
							if (array[j] != 0)
							{
								num = array[j];
								array[j] = 0;
								break;
							}
						}
					}
					array[i] = num;
					return;
				}
			}
		}
	}
}
