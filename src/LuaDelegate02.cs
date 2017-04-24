using LuaInterface;
using System;
using UnityEngine;

public class LuaDelegate02 : MonoBehaviour
{
	private string script = "                  \r\n            function DoClick1(go)\r\n                print('click1 on ', go.name)\r\n            end\r\n\r\n            function DoClick2(go)\r\n                print('click2 on ', go.name)\r\n            end\r\n            \r\n            local click2 = nil\r\n\r\n            function AddDelegate(listener)                     \r\n                listener.OnClick = DoClick1\r\n                click2 = DelegateFactory.Action_GameObject(DoClick2)                \r\n                listener.OnClick = listener.OnClick + click2                                    \r\n            end\r\n\r\n            function RemoveDelegate(listener)                \r\n                listener.OnClick = listener.OnClick - click2       \r\n                return delegate         \r\n            end\r\n    ";

	private void Start()
	{
		LuaScriptMgr luaScriptMgr = new LuaScriptMgr();
		luaScriptMgr.Start();
		luaScriptMgr.DoString(this.script);
		TestEventListener testEventListener = base.gameObject.AddComponent<TestEventListener>();
		LuaFunction luaFunction = luaScriptMgr.GetLuaFunction("AddDelegate");
		luaFunction.Call(new object[]
		{
			testEventListener
		});
		testEventListener.OnClick(base.gameObject);
		luaFunction.Release();
		Debug.Log("---------------------------------------------------------------------");
		luaFunction = luaScriptMgr.GetLuaFunction("RemoveDelegate");
		luaFunction.Call(new object[]
		{
			testEventListener
		});
		testEventListener.OnClick(base.gameObject);
		luaFunction.Release();
	}
}
