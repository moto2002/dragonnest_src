using LuaInterface;
using System;
using UnityEngine;

public class LuaDlg : MonoBehaviour
{
	private LuaScriptMgr mgr;

	private string m_name
	{
		get
		{
			return base.name.Substring(0, 1).ToUpper() + base.name.Substring(1);
		}
	}

	private void Awake()
	{
		this.mgr = HotfixManager.Instance.GetLuaScriptMgr();
		this.mgr.DoFile("Lua" + this.m_name + ".lua");
		LuaFunction luaFunction = this.mgr.GetLuaFunction("Lua" + this.m_name + ".Awake");
		if (luaFunction != null)
		{
			luaFunction.Call(new object[]
			{
				base.gameObject
			});
		}
	}

	private void Start()
	{
		if (this.mgr != null)
		{
			LuaFunction luaFunction = this.mgr.GetLuaFunction("Lua" + this.m_name + ".Start");
			if (luaFunction != null)
			{
				luaFunction.Call();
			}
		}
	}

	private void OnEnable()
	{
		if (this.mgr != null)
		{
			LuaFunction luaFunction = this.mgr.GetLuaFunction("Lua" + this.m_name + ".OnEnable");
			if (luaFunction != null)
			{
				luaFunction.Call();
			}
		}
	}

	private void OnDisable()
	{
		if (this.mgr != null)
		{
			LuaFunction luaFunction = this.mgr.GetLuaFunction("Lua" + this.m_name + ".OnDisable");
			if (luaFunction != null)
			{
				luaFunction.Call();
			}
		}
	}

	public void OnHide()
	{
		if (this.mgr != null)
		{
			LuaFunction luaFunction = this.mgr.GetLuaFunction("Lua" + this.m_name + ".OnHide");
			if (luaFunction != null)
			{
				luaFunction.Call();
			}
		}
	}

	public void Destroy()
	{
		if (this.mgr != null)
		{
			LuaFunction luaFunction = this.mgr.GetLuaFunction("Lua" + this.m_name + ".OnDestroy");
			if (luaFunction != null)
			{
				luaFunction.Call();
			}
		}
	}

	public void OnDestroy()
	{
		if (this.mgr != null)
		{
			try
			{
				LuaFunction luaFunction = this.mgr.GetLuaFunction("Lua" + this.m_name + ".OnDestroy");
				if (luaFunction != null)
				{
					luaFunction.Call();
				}
			}
			catch
			{
			}
		}
	}

	public void OnShow()
	{
		if (this.mgr != null)
		{
			LuaFunction luaFunction = this.mgr.GetLuaFunction("Lua" + this.m_name + ".OnShow");
			if (luaFunction != null)
			{
				luaFunction.Call();
			}
		}
	}
}
