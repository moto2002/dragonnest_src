using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

public class LuaUIManager : ILuaUIManager
{
	private Dictionary<uint, LuaNode> m_stask = new Dictionary<uint, LuaNode>();

	private static LuaUIManager _single;

	public static LuaUIManager Instance
	{
		get
		{
			if (LuaUIManager._single == null)
			{
				LuaUIManager._single = new LuaUIManager();
			}
			return LuaUIManager._single;
		}
	}

	public bool IsUIShowed()
	{
		bool result = false;
		foreach (KeyValuePair<uint, LuaNode> current in this.m_stask)
		{
			if (current.Value.go != null && current.Value.go.activeInHierarchy)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public bool Load(string name)
	{
		uint num = XSingleton<XCommon>.singleton.XHash(name);
		if (!this.Find(num))
		{
			GameObject gameObject = UICamera.mainCamera.gameObject;
			GameObject gameObject2 = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(name, true, false) as GameObject;
			gameObject2.transform.parent = UICamera.mainCamera.transform;
			gameObject2.transform.localPosition = Vector3.zero;
			gameObject2.transform.localRotation = Quaternion.identity;
			gameObject2.transform.localScale = Vector3.one;
			gameObject2.layer = gameObject.layer;
			gameObject2.name = name.Substring(name.LastIndexOf('/') + 1);
			LuaNode value = default(LuaNode);
			LuaDlg dlg = gameObject2.AddComponent<LuaDlg>();
			value.dlg = dlg;
			value.go = gameObject2;
			value.name = name;
			value.id = num;
			value.dlg.OnShow();
			if (!this.m_stask.ContainsKey(num))
			{
				this.m_stask.Add(num, value);
			}
			return true;
		}
		if (this.Find(num))
		{
			this.m_stask[num].go.SetActive(true);
			this.m_stask[num].dlg.OnShow();
		}
		return false;
	}

	public bool Hide(string name)
	{
		uint id = XSingleton<XCommon>.singleton.XHash(name);
		return this.IDHide(id);
	}

	public GameObject GetDlgObj(string name)
	{
		uint key = XSingleton<XCommon>.singleton.XHash(name);
		if (this.m_stask.ContainsKey(key))
		{
			return this.m_stask[key].go;
		}
		return null;
	}

	public bool IDHide(uint id)
	{
		if (this.m_stask.Count > 0 && this.Find(id))
		{
			LuaNode luaNode = this.m_stask[id];
			if (luaNode.go != null)
			{
				luaNode.go.SetActive(false);
			}
			luaNode.dlg.OnHide();
			return true;
		}
		return true;
	}

	public bool Destroy(string name)
	{
		uint id = XSingleton<XCommon>.singleton.XHash(name);
		return this.IDDestroy(id);
	}

	public bool IDDestroy(uint id)
	{
		if (this.m_stask.Count > 0 && this.Find(id))
		{
			UnityEngine.Object.Destroy(this.m_stask[id].go);
			if (this.m_stask.ContainsKey(id))
			{
				this.m_stask.Remove(id);
			}
			return true;
		}
		return false;
	}

	public void Clear()
	{
		List<uint> list = new List<uint>(this.m_stask.Keys);
		for (int i = 0; i < list.Count; i++)
		{
			this.IDDestroy(list[i]);
		}
		this.m_stask.Clear();
	}

	private bool Find(uint id)
	{
		if (!this.m_stask.ContainsKey(id))
		{
			return false;
		}
		if (this.m_stask[id].go != null)
		{
			return true;
		}
		this.m_stask.Remove(id);
		return false;
	}
}
