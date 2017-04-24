using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace com.tencent.pandora
{
	public class LuaCoroutine : LuaObject
	{
		private static MonoBehaviour mb;

		public static void reg(IntPtr l, MonoBehaviour m)
		{
			LuaCoroutine.mb = m;
			LuaObject.reg(l, new LuaCSFunction(LuaCoroutine.Yieldk), "UnityEngine");
			string str = "\r\nlocal Yield = UnityEngine.Yieldk\r\n\r\nuCoroutine = uCoroutine or {}\r\n\r\nuCoroutine.create = function(x)\r\n\r\n\tlocal co = coroutine.create(x)\r\n\tcoroutine.resume(co)\r\n\treturn co\r\n\r\nend\r\n\r\nuCoroutine.yield = function(x)\r\n\r\n\tlocal co, ismain = coroutine.running()\r\n\tif ismain then error('Can not yield in main thread') end\r\n\r\n\tif type(x) == 'thread' and coroutine.status(x) ~= 'dead' then\r\n\t\trepeat\r\n\t\t\tYield(nil, function() coroutine.resume(co) end)\r\n\t\t\tcoroutine.yield()\r\n\t\tuntil coroutine.status(x) == 'dead'\r\n\telse\r\n\t\tYield(x, function() coroutine.resume(co) end)\r\n\t\tcoroutine.yield()\r\n\tend\r\n\r\nend\r\n\r\n-- backward compatibility of older versions\r\nUnityEngine.Yield = uCoroutine.yield\r\n";
			LuaState.get(l).doString(str);
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int Yieldk(IntPtr l)
		{
			int result;
			try
			{
				if (LuaDLL.pua_pushthread(l) == 1)
				{
					result = LuaObject.error(l, "should put Yield call into lua coroutine.");
				}
				else
				{
					object y = LuaObject.checkObj(l, 1);
					LuaFunction f;
					LuaObject.checkType(l, 2, out f);
					LuaCoroutine.mb.StartCoroutine(LuaCoroutine.yieldReturn(y, f));
					LuaObject.pushValue(l, true);
					result = 1;
				}
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[DebuggerHidden]
		public static IEnumerator yieldReturn(object y, LuaFunction f)
		{
			LuaCoroutine.<yieldReturn>c__Iterator0 <yieldReturn>c__Iterator = new LuaCoroutine.<yieldReturn>c__Iterator0();
			<yieldReturn>c__Iterator.y = y;
			<yieldReturn>c__Iterator.f = f;
			<yieldReturn>c__Iterator.<$>y = y;
			<yieldReturn>c__Iterator.<$>f = f;
			return <yieldReturn>c__Iterator;
		}
	}
}
