using LuaInterface;
using System;
using UnityEngine;

public class LuaTestDel : MonoBehaviour
{
	public delegate void VoidDelegate(GameObject go);

	public Action onClick;

	public LuaTestDel.VoidDelegate onEvClick;

	private void OnClick()
	{
		LuaScriptMgr luaScriptMgr = HotfixManager.Instance.GetLuaScriptMgr();
		luaScriptMgr.DoFile("LuaDel.lua");
		LuaFunction luaFunction = luaScriptMgr.GetLuaFunction("decoder");
		luaFunction.Call(new object[]
		{
			base.gameObject
		});
		base.gameObject.GetComponent("LuaTestDel");
		if (this.onClick != null)
		{
			this.onClick();
		}
		else
		{
			Debug.Log("onClick is null");
		}
		if (this.onEvClick != null)
		{
			this.onEvClick(base.gameObject);
		}
		else
		{
			Debug.Log("oneveclick is null");
		}
	}
}
