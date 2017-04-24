using LuaInterface;
using System;
using UnityEngine;

public class LuaDelegate01 : MonoBehaviour
{
	private const string script = "\r\n        local func1 = function() print('测试委托1'); end\r\n        local func2 = function(gameObj) print('测试委托2:>'..gameObj.name); end        \r\n        \r\n        function testDelegate(go) \r\n            local ev = go:AddComponent(TestDelegateListener.GetClassType());\r\n        \r\n            ---直接赋值模式---\r\n            ev.onClick = func1;\r\n\r\n            ---C#的加减模式---\r\n            local delegate = DelegateFactory.TestLuaDelegate_VoidDelegate(func2);\r\n            ev.onEvClick = ev.onEvClick + delegate;\r\n            --ev.onEvClick = ev.onEvClick - delegate;\r\n        end\r\n    ";

	private void Start()
	{
		LuaScriptMgr luaScriptMgr = new LuaScriptMgr();
		luaScriptMgr.Start();
		luaScriptMgr.DoString("\r\n        local func1 = function() print('测试委托1'); end\r\n        local func2 = function(gameObj) print('测试委托2:>'..gameObj.name); end        \r\n        \r\n        function testDelegate(go) \r\n            local ev = go:AddComponent(TestDelegateListener.GetClassType());\r\n        \r\n            ---直接赋值模式---\r\n            ev.onClick = func1;\r\n\r\n            ---C#的加减模式---\r\n            local delegate = DelegateFactory.TestLuaDelegate_VoidDelegate(func2);\r\n            ev.onEvClick = ev.onEvClick + delegate;\r\n            --ev.onEvClick = ev.onEvClick - delegate;\r\n        end\r\n    ");
		LuaFunction luaFunction = luaScriptMgr.GetLuaFunction("testDelegate");
		luaFunction.Call(new object[]
		{
			base.gameObject
		});
	}
}
