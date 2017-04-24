using System;
using System.IO;
using UnityEngine;

namespace LuaInterface
{
	public static class LuaStatic
	{
		public static ReadLuaFile Load;

		public static string init_luanet;

		static LuaStatic()
		{
			LuaStatic.init_luanet = "local metatable = {}\r\n            local rawget = rawget\r\n            local debug = debug\r\n            local import_type = luanet.import_type\r\n            local load_assembly = luanet.load_assembly\r\n            luanet.error, luanet.type = error, type\r\n            -- Lookup a .NET identifier component.\r\n            function metatable:__index(key) -- key is e.g. 'Form'\r\n            -- Get the fully-qualified name, e.g. 'System.Windows.Forms.Form'\r\n            local fqn = rawget(self,'.fqn')\r\n            fqn = ((fqn and fqn .. '.') or '') .. key\r\n\r\n            -- Try to find either a luanet function or a CLR type\r\n            local obj = rawget(luanet,key) or import_type(fqn)\r\n\r\n            -- If key is neither a luanet function or a CLR type, then it is simply\r\n            -- an identifier component.\r\n            if obj == nil then\r\n                -- It might be an assembly, so we load it too.\r\n                    pcall(load_assembly,fqn)\r\n                    obj = { ['.fqn'] = fqn }\r\n            setmetatable(obj, metatable)\r\n            end\r\n\r\n            -- Cache this lookup\r\n            rawset(self, key, obj)\r\n            return obj\r\n            end\r\n\r\n            -- A non-type has been called; e.g. foo = System.Foo()\r\n            function metatable:__call(...)\r\n            error('No such type: ' .. rawget(self,'.fqn'), 2)\r\n            end\r\n\r\n            -- This is the root of the .NET namespace\r\n            luanet['.fqn'] = false\r\n            setmetatable(luanet, metatable)\r\n\r\n            -- Preload the mscorlib assembly\r\n            luanet.load_assembly('mscorlib')\r\n\r\n            function traceback(msg)                \r\n                return debug.traceback(msg, 1)                \r\n            end";
			LuaStatic.Load = new ReadLuaFile(LuaStatic.DefaultLoader);
		}

		private static byte[] DefaultLoader(string path)
		{
			byte[] result = null;
			if (File.Exists(path))
			{
				result = File.ReadAllBytes(path);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int panic(IntPtr L)
		{
			string message = string.Format("unprotected error in call to Lua API ({0})", LuaDLL.lua_tostring(L, -1));
			LuaDLL.lua_pop(L, 1);
			throw new LuaException(message);
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int traceback(IntPtr L)
		{
			LuaDLL.lua_getglobal(L, "debug");
			LuaDLL.lua_getfield(L, -1, "traceback");
			LuaDLL.lua_pushvalue(L, 1);
			LuaDLL.lua_pushnumber(L, 2.0);
			LuaDLL.lua_call(L, 2, 1);
			return 1;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int print(IntPtr L)
		{
			int num = LuaDLL.lua_gettop(L);
			string text = string.Empty;
			LuaDLL.lua_getglobal(L, "tostring");
			for (int i = 1; i <= num; i++)
			{
				LuaDLL.lua_pushvalue(L, -1);
				LuaDLL.lua_pushvalue(L, i);
				LuaDLL.lua_call(L, 1, 1);
				if (i > 1)
				{
					text += "\t";
				}
				text += LuaDLL.lua_tostring(L, -1);
				LuaDLL.lua_pop(L, 1);
			}
			Debug.Log("LUA: " + text);
			return 0;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int loader(IntPtr L)
		{
			string text = string.Empty;
			text = LuaDLL.lua_tostring(L, 1);
			string text2 = text.ToLower();
			if (text2.EndsWith(".lua"))
			{
				int length = text.LastIndexOf('.');
				text = text.Substring(0, length);
			}
			text = text.Replace('.', '/') + ".lua";
			LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
			if (mgrFromLuaState == null)
			{
				return 0;
			}
			LuaDLL.lua_pushstdcallcfunction(L, mgrFromLuaState.lua.tracebackFunction, 0);
			int oldTop = LuaDLL.lua_gettop(L);
			byte[] array = LuaStatic.Load(text);
			if (array == null)
			{
				if (!text.Contains("mobdebug"))
				{
					Debugger.LogError("Loader lua file failed: {0}", new object[]
					{
						text
					});
				}
				LuaDLL.lua_pop(L, 1);
				return 0;
			}
			if (LuaDLL.luaL_loadbuffer(L, array, array.Length, text) != 0)
			{
				mgrFromLuaState.lua.ThrowExceptionFromError(oldTop);
				LuaDLL.lua_pop(L, 1);
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int dofile(IntPtr L)
		{
			string text = string.Empty;
			text = LuaDLL.lua_tostring(L, 1);
			string text2 = text.ToLower();
			if (text2.EndsWith(".lua"))
			{
				int length = text.LastIndexOf('.');
				text = text.Substring(0, length);
			}
			text = text.Replace('.', '/') + ".lua";
			int num = LuaDLL.lua_gettop(L);
			byte[] array = LuaStatic.Load(text);
			if (array == null)
			{
				return LuaDLL.lua_gettop(L) - num;
			}
			if (LuaDLL.luaL_loadbuffer(L, array, array.Length, text) == 0)
			{
				LuaDLL.lua_call(L, 0, LuaDLL.LUA_MULTRET);
			}
			return LuaDLL.lua_gettop(L) - num;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int loadfile(IntPtr L)
		{
			return LuaStatic.loader(L);
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int importWrap(IntPtr L)
		{
			string text = string.Empty;
			text = LuaDLL.lua_tostring(L, 1);
			text = text.Replace('.', '_');
			if (!string.IsNullOrEmpty(text))
			{
				LuaBinder.Bind(L, text);
			}
			return 0;
		}
	}
}
