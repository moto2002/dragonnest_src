using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

namespace XUtliPoolLib
{
	public class XUIPool
	{
		public static int _far_far_away = 1000;

		public GameObject _tpl;

		protected List<GameObject> _pool = new List<GameObject>();

		protected List<bool> _used = new List<bool>();

		protected Stack<int> _ToBeRemoved = new Stack<int>();

		protected bool _bEffectiveMode = true;

		public IXUITool _uiTool;

		private int _ActiveCount;

		public int TplWidth
		{
			get;
			set;
		}

		public int TplHeight
		{
			get;
			set;
		}

		public Vector3 TplPos
		{
			get;
			set;
		}

		public bool IsValid
		{
			get
			{
				return this._tpl != null;
			}
		}

		public int ActiveCount
		{
			get
			{
				return this._ActiveCount;
			}
		}

		public XUIPool(IXUITool uiTool)
		{
			this._uiTool = uiTool;
		}

		public void SetupPool(GameObject parent, GameObject tpl, uint Count, bool bEffectiveMode = true)
		{
			this._pool.Clear();
			this._used.Clear();
			this._ToBeRemoved.Clear();
			this._tpl = tpl;
			this._bEffectiveMode = bEffectiveMode;
			this._ActiveCount = 0;
			IXUISprite iXUISprite = this._tpl.GetComponent("XUISprite") as IXUISprite;
			IXUILabel iXUILabel = this._tpl.GetComponent("XUILabel") as IXUILabel;
			if (iXUISprite != null)
			{
				this.TplWidth = iXUISprite.spriteWidth;
				this.TplHeight = iXUISprite.spriteHeight;
			}
			else if (iXUILabel != null)
			{
				this.TplWidth = iXUILabel.spriteWidth;
				this.TplHeight = iXUILabel.spriteHeight;
			}
			else
			{
				this.TplWidth = 0;
				this.TplHeight = 0;
			}
			if (!bEffectiveMode)
			{
				this.ReturnAllDisable();
			}
			this.TplPos = this._tpl.transform.localPosition;
			Transform parent2 = (parent == null) ? this._tpl.transform.parent : parent.transform;
			int num = 0;
			while ((long)num < (long)((ulong)Count))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(this._tpl) as GameObject;
				gameObject.transform.parent = parent2;
				gameObject.transform.localScale = Vector3.one;
				gameObject.name = "item" + num;
				if (this._bEffectiveMode)
				{
					gameObject.transform.localPosition = Vector3.one * (float)XUIPool._far_far_away;
				}
				else
				{
					gameObject.transform.localPosition = this._tpl.transform.localPosition;
					this.MakeGameObjectEnabled(gameObject, false);
				}
				this._pool.Add(gameObject);
				this._used.Add(false);
				num++;
			}
			if (this._bEffectiveMode)
			{
				this._tpl.transform.parent = parent2;
				this._tpl.transform.localPosition = Vector3.one * (float)XUIPool._far_far_away;
				return;
			}
			this._tpl.transform.parent = parent2;
			this.MakeGameObjectEnabled(this._tpl, false);
		}

		public GameObject FetchGameObject(bool fadeIn = false)
		{
			this._ActiveCount++;
			if (this._ToBeRemoved.Count > 0)
			{
				int index = this._ToBeRemoved.Pop();
				this.CheckFadeIn(fadeIn, this._pool[index]);
				return this._pool[index];
			}
			for (int i = 0; i < this._pool.Count; i++)
			{
				if (!this._used[i])
				{
					if (!this._bEffectiveMode)
					{
						this.MakeGameObjectEnabled(this._pool[i], true);
					}
					this._used[i] = true;
					this.CheckFadeIn(fadeIn, this._pool[i]);
					return this._pool[i];
				}
			}
			int count = this._pool.Count;
			if (!this._bEffectiveMode)
			{
				this.MakeGameObjectEnabled(this._tpl, true);
			}
			for (int j = 0; j < (count + 1) / 2; j++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(this._tpl) as GameObject;
				gameObject.transform.parent = this._tpl.transform.parent;
				gameObject.transform.localScale = Vector3.one;
				gameObject.name = "item" + this._pool.Count;
				if (this._bEffectiveMode)
				{
					gameObject.transform.localPosition = Vector3.one * (float)XUIPool._far_far_away;
				}
				else
				{
					gameObject.transform.localPosition = this._tpl.transform.localPosition;
					this.MakeGameObjectEnabled(gameObject, false);
				}
				this._pool.Add(gameObject);
				this._used.Add(false);
			}
			if (!this._bEffectiveMode)
			{
				this.MakeGameObjectEnabled(this._tpl, false);
			}
			this._used[count] = true;
			this.MakeGameObjectEnabled(this._pool[count], true);
			this.CheckFadeIn(fadeIn, this._pool[count]);
			return this._pool[count];
		}

		private void CheckFadeIn(bool fadeIn, GameObject go)
		{
			if (!fadeIn)
			{
				return;
			}
			IXTweenFadeIn iXTweenFadeIn = go.GetComponent("TweenFadeIn") as IXTweenFadeIn;
			if (iXTweenFadeIn == null)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Tpl haven't FadeIn Component but Fetch try to get it.", null, null, null, null, null);
				return;
			}
			iXTweenFadeIn.PlayFadeIn();
		}

		public void FakeReturnAll()
		{
			this._ToBeRemoved.Clear();
			for (int i = this._used.Count - 1; i >= 0; i--)
			{
				if (this._used[i])
				{
					this._ToBeRemoved.Push(i);
				}
			}
			this._ActiveCount = 0;
		}

		public void ActualReturnAll(bool bChangeParent = false)
		{
			while (this._ToBeRemoved.Count > 0)
			{
				int index = this._ToBeRemoved.Pop();
				this._DisableGameObject(this._pool[index], bChangeParent);
				this._used[index] = false;
			}
		}

		public void ReturnAll(bool bChangeParent = false)
		{
			for (int i = 0; i < this._pool.Count; i++)
			{
				GameObject go = this._pool[i];
				this._DisableGameObject(go, bChangeParent);
			}
			for (int j = 0; j < this._used.Count; j++)
			{
				this._used[j] = false;
			}
			this._ActiveCount = 0;
		}

		public void ReturnAllDisable()
		{
			for (int i = 0; i < this._pool.Count; i++)
			{
				if (!this._pool[i].activeSelf)
				{
					if (i < this._used.Count)
					{
						this._used[i] = false;
					}
					this._ActiveCount--;
				}
			}
		}

		public void ReturnInstance(GameObject go, bool bChangeParent = false)
		{
			this._DisableGameObject(go, bChangeParent);
			int num = -1;
			for (int i = 0; i < this._pool.Count; i++)
			{
				if (this._pool[i] == go)
				{
					num = i;
					break;
				}
			}
			if (num > -1 && num < this._used.Count)
			{
				this._used[num] = false;
			}
			this._ActiveCount--;
		}

		public void ReturnAny(int count, bool bChangeParent = false)
		{
			int num = 0;
			while (num < this._pool.Count && count > 0)
			{
				if (this._used[num])
				{
					this._used[num] = false;
					this._DisableGameObject(this._pool[num], bChangeParent);
					this._ActiveCount--;
					count--;
				}
				num++;
			}
		}

		private void _DisableGameObject(GameObject go, bool bChangeParent)
		{
			if (bChangeParent)
			{
				go.transform.parent = this._tpl.transform.parent;
			}
			if (this._bEffectiveMode)
			{
				go.transform.localPosition = Vector3.one * (float)XUIPool._far_far_away;
				return;
			}
			this.MakeGameObjectEnabled(go, false);
		}

		public void GetActiveList(List<GameObject> ret)
		{
			int i = 0;
			int count = this._pool.Count;
			while (i < count)
			{
				GameObject gameObject = this._pool[i];
				if (this._bEffectiveMode)
				{
					if (gameObject.transform.localPosition.x < (float)XUIPool._far_far_away)
					{
						ret.Add(gameObject);
					}
				}
				else if (gameObject.activeInHierarchy)
				{
					ret.Add(gameObject);
				}
				i++;
			}
		}

		protected void MakeGameObjectEnabled(GameObject go, bool enabled)
		{
			go.SetActive(enabled);
		}

		public void PlayFadeInWithActiveList()
		{
			List<GameObject> list = ListPool<GameObject>.Get();
			this.GetActiveList(list);
			if (list.Count != 0)
			{
				IXTweenFadeIn iXTweenFadeIn = list[0].GetComponent("TweenFadeIn") as IXTweenFadeIn;
				if (iXTweenFadeIn == null)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Tpl ActiveList haven't FadeIn Component but Fetch try to get it.", null, null, null, null, null);
				}
				else
				{
					iXTweenFadeIn.ResetGroupDelay();
					for (int i = 0; i < list.Count; i++)
					{
						this.CheckFadeIn(true, list[i]);
					}
				}
			}
			ListPool<GameObject>.Release(list);
		}
	}
}
