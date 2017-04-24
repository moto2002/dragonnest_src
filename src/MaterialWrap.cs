using LuaInterface;
using System;
using UnityEngine;

public class MaterialWrap
{
	private static Type classType = typeof(Material);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SetColor", new LuaCSFunction(MaterialWrap.SetColor)),
			new LuaMethod("GetColor", new LuaCSFunction(MaterialWrap.GetColor)),
			new LuaMethod("SetVector", new LuaCSFunction(MaterialWrap.SetVector)),
			new LuaMethod("GetVector", new LuaCSFunction(MaterialWrap.GetVector)),
			new LuaMethod("SetTexture", new LuaCSFunction(MaterialWrap.SetTexture)),
			new LuaMethod("GetTexture", new LuaCSFunction(MaterialWrap.GetTexture)),
			new LuaMethod("SetTextureOffset", new LuaCSFunction(MaterialWrap.SetTextureOffset)),
			new LuaMethod("GetTextureOffset", new LuaCSFunction(MaterialWrap.GetTextureOffset)),
			new LuaMethod("SetTextureScale", new LuaCSFunction(MaterialWrap.SetTextureScale)),
			new LuaMethod("GetTextureScale", new LuaCSFunction(MaterialWrap.GetTextureScale)),
			new LuaMethod("SetMatrix", new LuaCSFunction(MaterialWrap.SetMatrix)),
			new LuaMethod("GetMatrix", new LuaCSFunction(MaterialWrap.GetMatrix)),
			new LuaMethod("SetFloat", new LuaCSFunction(MaterialWrap.SetFloat)),
			new LuaMethod("GetFloat", new LuaCSFunction(MaterialWrap.GetFloat)),
			new LuaMethod("SetInt", new LuaCSFunction(MaterialWrap.SetInt)),
			new LuaMethod("GetInt", new LuaCSFunction(MaterialWrap.GetInt)),
			new LuaMethod("SetBuffer", new LuaCSFunction(MaterialWrap.SetBuffer)),
			new LuaMethod("HasProperty", new LuaCSFunction(MaterialWrap.HasProperty)),
			new LuaMethod("GetTag", new LuaCSFunction(MaterialWrap.GetTag)),
			new LuaMethod("Lerp", new LuaCSFunction(MaterialWrap.Lerp)),
			new LuaMethod("SetPass", new LuaCSFunction(MaterialWrap.SetPass)),
			new LuaMethod("CopyPropertiesFromMaterial", new LuaCSFunction(MaterialWrap.CopyPropertiesFromMaterial)),
			new LuaMethod("EnableKeyword", new LuaCSFunction(MaterialWrap.EnableKeyword)),
			new LuaMethod("DisableKeyword", new LuaCSFunction(MaterialWrap.DisableKeyword)),
			new LuaMethod("New", new LuaCSFunction(MaterialWrap._CreateMaterial)),
			new LuaMethod("GetClassType", new LuaCSFunction(MaterialWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(MaterialWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("shader", new LuaCSFunction(MaterialWrap.get_shader), new LuaCSFunction(MaterialWrap.set_shader)),
			new LuaField("color", new LuaCSFunction(MaterialWrap.get_color), new LuaCSFunction(MaterialWrap.set_color)),
			new LuaField("mainTexture", new LuaCSFunction(MaterialWrap.get_mainTexture), new LuaCSFunction(MaterialWrap.set_mainTexture)),
			new LuaField("mainTextureOffset", new LuaCSFunction(MaterialWrap.get_mainTextureOffset), new LuaCSFunction(MaterialWrap.set_mainTextureOffset)),
			new LuaField("mainTextureScale", new LuaCSFunction(MaterialWrap.get_mainTextureScale), new LuaCSFunction(MaterialWrap.set_mainTextureScale)),
			new LuaField("passCount", new LuaCSFunction(MaterialWrap.get_passCount), null),
			new LuaField("renderQueue", new LuaCSFunction(MaterialWrap.get_renderQueue), new LuaCSFunction(MaterialWrap.set_renderQueue)),
			new LuaField("shaderKeywords", new LuaCSFunction(MaterialWrap.get_shaderKeywords), new LuaCSFunction(MaterialWrap.set_shaderKeywords))
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Material", typeof(Material), regs, fields, typeof(UnityEngine.Object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateMaterial(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material)))
		{
			Material source = (Material)LuaScriptMgr.GetUnityObject(L, 1, typeof(Material));
			Material obj = new Material(source);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(Shader)))
		{
			Shader shader = (Shader)LuaScriptMgr.GetUnityObject(L, 1, typeof(Shader));
			Material obj2 = new Material(shader);
			LuaScriptMgr.Push(L, obj2);
			return 1;
		}
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string @string = LuaScriptMgr.GetString(L, 1);
			Material obj3 = new Material(@string);
			LuaScriptMgr.Push(L, obj3);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, MaterialWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shader(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shader");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shader on a nil value");
			}
		}
		LuaScriptMgr.Push(L, material.shader);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_color(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name color");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index color on a nil value");
			}
		}
		LuaScriptMgr.Push(L, material.color);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mainTexture(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
			}
		}
		LuaScriptMgr.Push(L, material.mainTexture);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mainTextureOffset(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTextureOffset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTextureOffset on a nil value");
			}
		}
		LuaScriptMgr.Push(L, material.mainTextureOffset);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mainTextureScale(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTextureScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTextureScale on a nil value");
			}
		}
		LuaScriptMgr.Push(L, material.mainTextureScale);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_passCount(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name passCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index passCount on a nil value");
			}
		}
		LuaScriptMgr.Push(L, material.passCount);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_renderQueue(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderQueue on a nil value");
			}
		}
		LuaScriptMgr.Push(L, material.renderQueue);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shaderKeywords(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shaderKeywords");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shaderKeywords on a nil value");
			}
		}
		LuaScriptMgr.PushArray(L, material.shaderKeywords);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shader(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shader");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shader on a nil value");
			}
		}
		material.shader = (Shader)LuaScriptMgr.GetUnityObject(L, 3, typeof(Shader));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_color(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name color");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index color on a nil value");
			}
		}
		material.color = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mainTexture(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
			}
		}
		material.mainTexture = (Texture)LuaScriptMgr.GetUnityObject(L, 3, typeof(Texture));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mainTextureOffset(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTextureOffset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTextureOffset on a nil value");
			}
		}
		material.mainTextureOffset = LuaScriptMgr.GetVector2(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mainTextureScale(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTextureScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTextureScale on a nil value");
			}
		}
		material.mainTextureScale = LuaScriptMgr.GetVector2(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_renderQueue(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderQueue on a nil value");
			}
		}
		material.renderQueue = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shaderKeywords(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Material material = (Material)luaObject;
		if (material == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shaderKeywords");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shaderKeywords on a nil value");
			}
		}
		material.shaderKeywords = LuaScriptMgr.GetArrayString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetColor(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(LuaTable)))
		{
			Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int nameID = (int)LuaDLL.lua_tonumber(L, 2);
			Color color = LuaScriptMgr.GetColor(L, 3);
			material.SetColor(nameID, color);
			return 0;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(LuaTable)))
		{
			Material material2 = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string @string = LuaScriptMgr.GetString(L, 2);
			Color color2 = LuaScriptMgr.GetColor(L, 3);
			material2.SetColor(@string, color2);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetColor");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetColor(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int nameID = (int)LuaDLL.lua_tonumber(L, 2);
			Color color = material.GetColor(nameID);
			LuaScriptMgr.Push(L, color);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material material2 = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string @string = LuaScriptMgr.GetString(L, 2);
			Color color2 = material2.GetColor(@string);
			LuaScriptMgr.Push(L, color2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetColor");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetVector(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(LuaTable)))
		{
			Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int nameID = (int)LuaDLL.lua_tonumber(L, 2);
			Vector4 vector = LuaScriptMgr.GetVector4(L, 3);
			material.SetVector(nameID, vector);
			return 0;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(LuaTable)))
		{
			Material material2 = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string @string = LuaScriptMgr.GetString(L, 2);
			Vector4 vector2 = LuaScriptMgr.GetVector4(L, 3);
			material2.SetVector(@string, vector2);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetVector");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetVector(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int nameID = (int)LuaDLL.lua_tonumber(L, 2);
			Vector4 vector = material.GetVector(nameID);
			LuaScriptMgr.Push(L, vector);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material material2 = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string @string = LuaScriptMgr.GetString(L, 2);
			Vector4 vector2 = material2.GetVector(@string);
			LuaScriptMgr.Push(L, vector2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetVector");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTexture(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(Texture)))
		{
			Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int nameID = (int)LuaDLL.lua_tonumber(L, 2);
			Texture texture = (Texture)LuaScriptMgr.GetLuaObject(L, 3);
			material.SetTexture(nameID, texture);
			return 0;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(Texture)))
		{
			Material material2 = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string @string = LuaScriptMgr.GetString(L, 2);
			Texture texture2 = (Texture)LuaScriptMgr.GetLuaObject(L, 3);
			material2.SetTexture(@string, texture2);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetTexture");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTexture(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int nameID = (int)LuaDLL.lua_tonumber(L, 2);
			Texture texture = material.GetTexture(nameID);
			LuaScriptMgr.Push(L, texture);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material material2 = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string @string = LuaScriptMgr.GetString(L, 2);
			Texture texture2 = material2.GetTexture(@string);
			LuaScriptMgr.Push(L, texture2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetTexture");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTextureOffset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		Vector2 vector = LuaScriptMgr.GetVector2(L, 3);
		material.SetTextureOffset(luaString, vector);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTextureOffset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		Vector2 textureOffset = material.GetTextureOffset(luaString);
		LuaScriptMgr.Push(L, textureOffset);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTextureScale(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		Vector2 vector = LuaScriptMgr.GetVector2(L, 3);
		material.SetTextureScale(luaString, vector);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTextureScale(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		Vector2 textureScale = material.GetTextureScale(luaString);
		LuaScriptMgr.Push(L, textureScale);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetMatrix(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(Matrix4x4)))
		{
			Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int nameID = (int)LuaDLL.lua_tonumber(L, 2);
			Matrix4x4 matrix = (Matrix4x4)LuaScriptMgr.GetLuaObject(L, 3);
			material.SetMatrix(nameID, matrix);
			return 0;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(Matrix4x4)))
		{
			Material material2 = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string @string = LuaScriptMgr.GetString(L, 2);
			Matrix4x4 matrix2 = (Matrix4x4)LuaScriptMgr.GetLuaObject(L, 3);
			material2.SetMatrix(@string, matrix2);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetMatrix");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMatrix(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int nameID = (int)LuaDLL.lua_tonumber(L, 2);
			Matrix4x4 matrix = material.GetMatrix(nameID);
			LuaScriptMgr.PushValue(L, matrix);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material material2 = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string @string = LuaScriptMgr.GetString(L, 2);
			Matrix4x4 matrix2 = material2.GetMatrix(@string);
			LuaScriptMgr.PushValue(L, matrix2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetMatrix");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetFloat(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(float)))
		{
			Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int nameID = (int)LuaDLL.lua_tonumber(L, 2);
			float value = (float)LuaDLL.lua_tonumber(L, 3);
			material.SetFloat(nameID, value);
			return 0;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(float)))
		{
			Material material2 = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string @string = LuaScriptMgr.GetString(L, 2);
			float value2 = (float)LuaDLL.lua_tonumber(L, 3);
			material2.SetFloat(@string, value2);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetFloat");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetFloat(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int nameID = (int)LuaDLL.lua_tonumber(L, 2);
			float @float = material.GetFloat(nameID);
			LuaScriptMgr.Push(L, @float);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material material2 = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string @string = LuaScriptMgr.GetString(L, 2);
			float float2 = material2.GetFloat(@string);
			LuaScriptMgr.Push(L, float2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetFloat");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetInt(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(int)))
		{
			Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int nameID = (int)LuaDLL.lua_tonumber(L, 2);
			int value = (int)LuaDLL.lua_tonumber(L, 3);
			material.SetInt(nameID, value);
			return 0;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(int)))
		{
			Material material2 = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string @string = LuaScriptMgr.GetString(L, 2);
			int value2 = (int)LuaDLL.lua_tonumber(L, 3);
			material2.SetInt(@string, value2);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetInt");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInt(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int nameID = (int)LuaDLL.lua_tonumber(L, 2);
			int @int = material.GetInt(nameID);
			LuaScriptMgr.Push(L, @int);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material material2 = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string @string = LuaScriptMgr.GetString(L, 2);
			int int2 = material2.GetInt(@string);
			LuaScriptMgr.Push(L, int2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetInt");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetBuffer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		ComputeBuffer buffer = (ComputeBuffer)LuaScriptMgr.GetNetObject(L, 3, typeof(ComputeBuffer));
		material.SetBuffer(luaString, buffer);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HasProperty(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int nameID = (int)LuaDLL.lua_tonumber(L, 2);
			bool b = material.HasProperty(nameID);
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material material2 = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string @string = LuaScriptMgr.GetString(L, 2);
			bool b2 = material2.HasProperty(@string);
			LuaScriptMgr.Push(L, b2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.HasProperty");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTag(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 3)
		{
			Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string luaString = LuaScriptMgr.GetLuaString(L, 2);
			bool boolean = LuaScriptMgr.GetBoolean(L, 3);
			string tag = material.GetTag(luaString, boolean);
			LuaScriptMgr.Push(L, tag);
			return 1;
		}
		if (num == 4)
		{
			Material material2 = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
			bool boolean2 = LuaScriptMgr.GetBoolean(L, 3);
			string luaString3 = LuaScriptMgr.GetLuaString(L, 4);
			string tag2 = material2.GetTag(luaString2, boolean2, luaString3);
			LuaScriptMgr.Push(L, tag2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetTag");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lerp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		Material start = (Material)LuaScriptMgr.GetUnityObject(L, 2, typeof(Material));
		Material end = (Material)LuaScriptMgr.GetUnityObject(L, 3, typeof(Material));
		float t = (float)LuaScriptMgr.GetNumber(L, 4);
		material.Lerp(start, end, t);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPass(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		int pass = (int)LuaScriptMgr.GetNumber(L, 2);
		bool b = material.SetPass(pass);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CopyPropertiesFromMaterial(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		Material mat = (Material)LuaScriptMgr.GetUnityObject(L, 2, typeof(Material));
		material.CopyPropertiesFromMaterial(mat);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EnableKeyword(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		material.EnableKeyword(luaString);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DisableKeyword(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material material = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		material.DisableKeyword(luaString);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UnityEngine.Object x = LuaScriptMgr.GetLuaObject(L, 1) as UnityEngine.Object;
		UnityEngine.Object y = LuaScriptMgr.GetLuaObject(L, 2) as UnityEngine.Object;
		bool b = x == y;
		LuaScriptMgr.Push(L, b);
		return 1;
	}
}
