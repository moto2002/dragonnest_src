using System;
using UnityEngine;

public class LuaEnum : MonoBehaviour
{
	private const string source = "\r\n        local type = LuaEnumType.IntToEnum(1);\r\n        print(type == LuaEnumType.AAA);\r\n    ";

	private void Start()
	{
		LuaScriptMgr luaScriptMgr = new LuaScriptMgr();
		luaScriptMgr.Start();
		luaScriptMgr.lua.DoString("\r\n        local type = LuaEnumType.IntToEnum(1);\r\n        print(type == LuaEnumType.AAA);\r\n    ");
	}
}
