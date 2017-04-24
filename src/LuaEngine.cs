using LuaCore;
using System;
using UnityEngine;
using XUtliPoolLib;

public class LuaEngine : MonoBehaviour, ILuaEngine
{
	public static LuaEngine Instance;

	private bool gui;

	private string cname = "LuaEngine";

	private string origin_text = "des";

	private string des_text = "code";

	private int y = 200;

	private bool init;

	public IHotfixManager hotfixMgr
	{
		get
		{
			return HotfixManager.Instance;
		}
	}

	public ILuaUIManager luaUIManager
	{
		get
		{
			return LuaUIManager.Instance;
		}
	}

	public ILuaGameInfo luaGameInfo
	{
		get
		{
			return LuaGameInfo.single;
		}
	}

	private void Awake()
	{
		LuaEngine.Instance = this;
	}

	private void OnDestroy()
	{
		HotfixManager.Instance.Dispose();
		LuaEngine.Instance = null;
	}

	public void InitLua()
	{
		this.init = true;
		Single<TimerManager>.Instance.Init();
		HotfixManager.Instance.LoadHotfix(new Action(this.OnInitFinish));
	}

	private void Update()
	{
		if (this.init)
		{
			Single<TimerManager>.Instance.Update();
		}
	}

	private void OnApplicationPause(bool pause)
	{
		HotfixManager.Instance.OnPause(pause);
	}

	private void OnInitFinish()
	{
		Debug.Log("Hotfix init finish!");
	}
}
