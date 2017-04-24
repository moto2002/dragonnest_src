using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

public class HotfixManager : IHotfixManager
{
	public const string CLICK_LUA_FILE = "HotfixClick.lua";

	public const string NET_LUA_FILE = "HotfixNet.lua";

	public const string DOC_LUA_FILE = "HotfixDocument.lua";

	public const string MSG_LUE_FILE = "HotfixMsglist.lua";

	private LuaScriptMgr hotfixLua;

	private LuaFunction func_refresh;

	private LuaFunction func_click_b;

	private LuaFunction func_click_a;

	private LuaFunction func_net_b;

	private LuaFunction func_net_a;

	private LuaFunction func_pandora;

	private LuaFunction func_enterscene;

	private LuaFunction func_enterfinally;

	private LuaFunction func_attach;

	private LuaFunction func_detach;

	private LuaFunction func_reconnect;

	private LuaFunction func_pause;

	private LuaFunction func_fade;

	public bool useHotfix = true;

	private bool init;

	private List<string> doluafiles = new List<string>();

	public Dictionary<string, string> hotmsglist = new Dictionary<string, string>();

	private static HotfixManager _single;

	public static HotfixManager Instance
	{
		get
		{
			if (HotfixManager._single == null)
			{
				HotfixManager._single = new HotfixManager();
			}
			return HotfixManager._single;
		}
	}

	public void LoadHotfix(Action finish)
	{
		this.init = true;
		this.hotfixLua = new LuaScriptMgr();
		this.hotfixLua.Start();
		Hotfix.Init(delegate
		{
			this.TryFixMsglist();
			this.InitNet();
			this.InitClick();
			this.InitDocument();
			this.OnAttachToHost();
			if (finish != null)
			{
				finish();
			}
		});
	}

	public void Dispose()
	{
		this.doluafiles.Clear();
		this.DisposeFunc(this.func_click_a);
		this.DisposeFunc(this.func_click_b);
		this.DisposeFunc(this.func_net_a);
		this.DisposeFunc(this.func_net_b);
		this.DisposeFunc(this.func_attach);
		this.DisposeFunc(this.func_detach);
		this.DisposeFunc(this.func_enterfinally);
		this.DisposeFunc(this.func_enterscene);
		this.DisposeFunc(this.func_reconnect);
		this.DisposeFunc(this.func_pause);
		this.DisposeFunc(this.func_fade);
		this.DisposeFunc(this.func_pandora);
		if (this.init)
		{
			this.hotfixLua.Destroy();
			this.hotfixLua = null;
			this.init = false;
		}
	}

	private void DisposeFunc(LuaFunction func)
	{
		if (func != null)
		{
			func.Dispose();
			func = null;
		}
	}

	public bool DoLuaFile(string name)
	{
		if (this.doluafiles.Contains(name) || !this.init)
		{
			return true;
		}
		if (this.hotfixLua == null)
		{
			return false;
		}
		if (LuaStatic.Load(name) == null)
		{
			return false;
		}
		this.hotfixLua.lua.DoFile(name);
		this.doluafiles.Add(name);
		return true;
	}

	public void TryFixMsglist()
	{
		if (!this.useHotfix || !this.init)
		{
			return;
		}
		string name = "HotfixMsglist.lua";
		byte[] array = LuaStatic.Load(name);
		if (array != null)
		{
			ByteReader byteReader = new ByteReader(array);
			this.hotmsglist = byteReader.ReadDictionary();
		}
	}

	private void InitClick()
	{
		if (!this.useHotfix || !this.init)
		{
			return;
		}
		bool flag = this.DoLuaFile("HotfixClick.lua");
		if (flag)
		{
			if (this.func_click_b == null)
			{
				this.func_click_b = this.hotfixLua.lua.GetFunction("HotfixClick.BeforeClick");
			}
			if (this.func_click_a == null)
			{
				this.func_click_a = this.hotfixLua.lua.GetFunction("HotfixClick.AfterClick");
			}
		}
	}

	public bool TryFixClick(HotfixMode _mode, string _path)
	{
		if (!this.useHotfix || !this.init)
		{
			return false;
		}
		if (_mode == HotfixMode.BEFORE)
		{
			if (this.func_click_b != null)
			{
				object[] array = this.func_click_b.Call(new object[]
				{
					_path
				});
				return array != null && (bool)array[0];
			}
		}
		else
		{
			if (this.func_click_a != null)
			{
				object[] array2 = this.func_click_a.Call(new object[]
				{
					_path
				});
				return array2 != null && (bool)array2[0];
			}
			XSingleton<XDebug>.singleton.AddErrorLog("func _a is nul", null, null, null, null, null);
		}
		return false;
	}

	private void InitNet()
	{
		if (!this.useHotfix || !this.init)
		{
			return;
		}
		bool flag = this.DoLuaFile("HotfixNet.lua");
		if (flag)
		{
			if (this.func_net_b == null)
			{
				this.func_net_b = this.hotfixLua.lua.GetFunction("HotfixNet.BeforeNet");
			}
			if (this.func_net_a == null)
			{
				this.func_net_a = this.hotfixLua.lua.GetFunction("HotfixNet.AfterNet");
			}
		}
	}

	public bool TryFixNet(HotfixMode _mode, uint _udid, object body)
	{
		if (!this.useHotfix || !this.init)
		{
			return false;
		}
		if (_mode == HotfixMode.BEFORE)
		{
			if (this.func_net_b != null)
			{
				object[] array = this.func_net_b.Call(new object[]
				{
					_udid,
					body
				});
				return (bool)array[0];
			}
		}
		else if (this.func_net_a != null)
		{
			object[] array2 = this.func_net_a.Call(new object[]
			{
				_udid,
				body
			});
			return (bool)array2[0];
		}
		return false;
	}

	public bool TryFixNet(HotfixMode _mode, string _route)
	{
		if (!this.useHotfix || !this.init)
		{
			return false;
		}
		if (_mode == HotfixMode.BEFORE)
		{
			if (this.func_net_b != null)
			{
				object[] array = this.func_net_b.Call(new object[]
				{
					_route
				});
				return (bool)array[0];
			}
		}
		else if (this.func_net_a != null)
		{
			object[] array2 = this.func_net_a.Call(new object[]
			{
				_route
			});
			return (bool)array2[0];
		}
		return false;
	}

	public bool TryFixRefresh(HotfixMode _mode, string _pageName, GameObject go)
	{
		if (_pageName == "LoadingDlg" || _pageName == "LoginDlg" || _pageName == "LoginTip")
		{
			return false;
		}
		if (this.useHotfix && this.init)
		{
			string name = "Hotfix" + _pageName + ".lua";
			bool flag = this.DoLuaFile(name);
			if (flag)
			{
				this.func_refresh = null;
				if (_mode == HotfixMode.BEFORE)
				{
					this.func_refresh = this.hotfixLua.lua.GetFunction(_pageName + ".BeforeRefresh");
				}
				else if (_mode == HotfixMode.AFTER)
				{
					this.func_refresh = this.hotfixLua.lua.GetFunction(_pageName + ".AfterRefresh");
				}
				else if (_mode == HotfixMode.HIDE)
				{
					this.func_refresh = this.hotfixLua.lua.GetFunction(_pageName + ".Hide");
				}
				if (this.func_refresh != null)
				{
					object[] array = this.func_refresh.Call(new object[]
					{
						go
					});
					this.func_refresh.Release();
					return array != null && (bool)array[0];
				}
				XSingleton<XDebug>.singleton.AddLog(string.Concat(new object[]
				{
					"func is null!",
					_pageName,
					" mode: ",
					_mode
				}), null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}
		return false;
	}

	public bool TryFixHandler(HotfixMode _mode, string _handlerName, GameObject go)
	{
		if (this.useHotfix && this.init)
		{
			string name = "Hotfix" + _handlerName + ".lua";
			bool flag = this.DoLuaFile(name);
			if (flag)
			{
				this.func_refresh = this.hotfixLua.lua.GetFunction((_mode != HotfixMode.BEFORE) ? (_handlerName + ".AfterHandlerShow") : (_handlerName + ".BeforeHandlerShow"));
				if (this.func_refresh != null)
				{
					object[] array = this.func_refresh.Call(new object[]
					{
						go
					});
					this.func_refresh.Release();
					return array != null && (bool)array[0];
				}
				XSingleton<XDebug>.singleton.AddErrorLog("func is null! " + _handlerName, null, null, null, null, null);
			}
		}
		return false;
	}

	public void RegistedPtc(uint _type, byte[] body, int length)
	{
		XLua.NotifyRoute(_type, body, length);
	}

	public LuaScriptMgr GetLuaScriptMgr()
	{
		return this.hotfixLua;
	}

	private void InitDocument()
	{
		if (!this.useHotfix || !this.init)
		{
			return;
		}
		bool flag = this.DoLuaFile("HotfixDocument.lua");
		if (flag)
		{
			if (this.func_enterscene == null)
			{
				this.func_enterscene = this.hotfixLua.lua.GetFunction("HotfixDocument.EnterScene");
			}
			if (this.func_enterfinally == null)
			{
				this.func_enterfinally = this.hotfixLua.lua.GetFunction("HotfixDocument.EnterSceneFinally");
			}
			if (this.func_attach == null)
			{
				this.func_attach = this.hotfixLua.lua.GetFunction("HotfixDocument.Attach");
			}
			if (this.func_detach == null)
			{
				this.func_detach = this.hotfixLua.lua.GetFunction("HotfixDocument.Detach");
			}
			if (this.func_reconnect == null)
			{
				this.func_reconnect = this.hotfixLua.lua.GetFunction("HotfixDocument.Reconnect");
			}
			if (this.func_pause == null)
			{
				this.func_pause = this.hotfixLua.lua.GetFunction("HotfixDocument.Pause");
			}
			if (this.func_fade == null)
			{
				this.func_fade = this.hotfixLua.lua.GetFunction("HotfixDocument.FadeShow");
			}
			if (this.func_pandora == null)
			{
				this.func_pandora = this.hotfixLua.lua.GetFunction("HotfixDocument.PandoraCallback");
			}
		}
	}

	public void OnEnterScene()
	{
		if (this.func_enterscene != null)
		{
			this.func_enterscene.Call();
		}
	}

	public void OnEnterSceneFinally()
	{
		if (this.func_enterfinally != null)
		{
			this.func_enterfinally.Call();
		}
	}

	public void OnAttachToHost()
	{
		if (this.func_attach != null)
		{
			this.func_attach.Call();
		}
	}

	public void OnPandoraCallback(string json)
	{
		if (this.func_pandora != null)
		{
			Debug.Log("json=>" + json);
			this.func_pandora.Call(new object[]
			{
				json
			});
		}
	}

	public void OnReconnect()
	{
		if (this.func_reconnect != null)
		{
			this.func_reconnect.Call();
		}
	}

	public void OnDetachFromHost()
	{
		if (this.func_detach != null)
		{
			this.func_detach.Call();
		}
	}

	public void FadeShow(bool show)
	{
		if (this.func_fade != null)
		{
			this.func_fade.Call(new object[]
			{
				show
			});
		}
	}

	public void OnPause(bool pause)
	{
		if (this.func_pause != null)
		{
			this.func_pause.Call(new object[]
			{
				pause
			});
		}
	}
}
