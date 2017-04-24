using LuaInterface;
using System;
using UnityEngine;

public class LuaTest : Single<LuaTest>
{
	public void TestCSV()
	{
		LuaScriptMgr luaScriptMgr = HotfixManager.Instance.GetLuaScriptMgr();
		luaScriptMgr.DoFile("LuaParseTable.lua");
		TextAsset textAsset = Resources.Load<TextAsset>("Table/Chat");
		LuaFunction luaFunction = luaScriptMgr.GetLuaFunction("LuaParseTable.chat");
		luaFunction.Call(new object[]
		{
			textAsset.text
		});
		textAsset = Resources.Load<TextAsset>("Table/FashionRank");
		luaFunction = luaScriptMgr.GetLuaFunction("LuaParseTable.rank");
		luaFunction.Call(new object[]
		{
			textAsset.text
		});
		textAsset = Resources.Load<TextAsset>("Table/CampInfo");
		luaFunction = luaScriptMgr.GetLuaFunction("LuaParseTable.camp");
		luaFunction.Call(new object[]
		{
			textAsset.text
		});
		textAsset = Resources.Load<TextAsset>("Table/EquipList");
		luaFunction = luaScriptMgr.GetLuaFunction("LuaParseTable.equip");
		luaFunction.Call(new object[]
		{
			textAsset.text
		});
		luaFunction = luaScriptMgr.GetLuaFunction("LuaParseTable.read");
		luaFunction.Call();
		luaFunction.Release();
	}

	public void TestProto()
	{
	}

	public void TestMail()
	{
	}

	public void TestFetchMail()
	{
	}
}
