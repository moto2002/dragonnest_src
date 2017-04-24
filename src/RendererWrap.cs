using LuaInterface;
using System;
using UnityEngine;

public class RendererWrap
{
	private static Type classType = typeof(Renderer);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SetPropertyBlock", new LuaCSFunction(RendererWrap.SetPropertyBlock)),
			new LuaMethod("GetPropertyBlock", new LuaCSFunction(RendererWrap.GetPropertyBlock)),
			new LuaMethod("Render", new LuaCSFunction(RendererWrap.Render)),
			new LuaMethod("New", new LuaCSFunction(RendererWrap._CreateRenderer)),
			new LuaMethod("GetClassType", new LuaCSFunction(RendererWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(RendererWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("isPartOfStaticBatch", new LuaCSFunction(RendererWrap.get_isPartOfStaticBatch), null),
			new LuaField("worldToLocalMatrix", new LuaCSFunction(RendererWrap.get_worldToLocalMatrix), null),
			new LuaField("localToWorldMatrix", new LuaCSFunction(RendererWrap.get_localToWorldMatrix), null),
			new LuaField("enabled", new LuaCSFunction(RendererWrap.get_enabled), new LuaCSFunction(RendererWrap.set_enabled)),
			new LuaField("castShadows", new LuaCSFunction(RendererWrap.get_castShadows), new LuaCSFunction(RendererWrap.set_castShadows)),
			new LuaField("receiveShadows", new LuaCSFunction(RendererWrap.get_receiveShadows), new LuaCSFunction(RendererWrap.set_receiveShadows)),
			new LuaField("material", new LuaCSFunction(RendererWrap.get_material), new LuaCSFunction(RendererWrap.set_material)),
			new LuaField("sharedMaterial", new LuaCSFunction(RendererWrap.get_sharedMaterial), new LuaCSFunction(RendererWrap.set_sharedMaterial)),
			new LuaField("sharedMaterials", new LuaCSFunction(RendererWrap.get_sharedMaterials), new LuaCSFunction(RendererWrap.set_sharedMaterials)),
			new LuaField("materials", new LuaCSFunction(RendererWrap.get_materials), new LuaCSFunction(RendererWrap.set_materials)),
			new LuaField("bounds", new LuaCSFunction(RendererWrap.get_bounds), null),
			new LuaField("lightmapIndex", new LuaCSFunction(RendererWrap.get_lightmapIndex), new LuaCSFunction(RendererWrap.set_lightmapIndex)),
			new LuaField("lightmapTilingOffset", new LuaCSFunction(RendererWrap.get_lightmapTilingOffset), new LuaCSFunction(RendererWrap.set_lightmapTilingOffset)),
			new LuaField("isVisible", new LuaCSFunction(RendererWrap.get_isVisible), null),
			new LuaField("useLightProbes", new LuaCSFunction(RendererWrap.get_useLightProbes), new LuaCSFunction(RendererWrap.set_useLightProbes)),
			new LuaField("lightProbeAnchor", new LuaCSFunction(RendererWrap.get_lightProbeAnchor), new LuaCSFunction(RendererWrap.set_lightProbeAnchor)),
			new LuaField("sortingLayerName", new LuaCSFunction(RendererWrap.get_sortingLayerName), new LuaCSFunction(RendererWrap.set_sortingLayerName)),
			new LuaField("sortingLayerID", new LuaCSFunction(RendererWrap.get_sortingLayerID), new LuaCSFunction(RendererWrap.set_sortingLayerID)),
			new LuaField("sortingOrder", new LuaCSFunction(RendererWrap.get_sortingOrder), new LuaCSFunction(RendererWrap.set_sortingOrder))
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Renderer", typeof(Renderer), regs, fields, typeof(Component));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateRenderer(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			Renderer obj = new Renderer();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Renderer.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, RendererWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isPartOfStaticBatch(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPartOfStaticBatch");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPartOfStaticBatch on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.isPartOfStaticBatch);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldToLocalMatrix(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldToLocalMatrix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldToLocalMatrix on a nil value");
			}
		}
		LuaScriptMgr.PushValue(L, renderer.worldToLocalMatrix);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localToWorldMatrix(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localToWorldMatrix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localToWorldMatrix on a nil value");
			}
		}
		LuaScriptMgr.PushValue(L, renderer.localToWorldMatrix);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_enabled(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.enabled);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_castShadows(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name castShadows");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index castShadows on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.castShadows);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_receiveShadows(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name receiveShadows");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index receiveShadows on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.receiveShadows);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_material(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.material);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sharedMaterial(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sharedMaterial");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sharedMaterial on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.sharedMaterial);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sharedMaterials(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sharedMaterials");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sharedMaterials on a nil value");
			}
		}
		LuaScriptMgr.PushArray(L, renderer.sharedMaterials);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_materials(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name materials");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index materials on a nil value");
			}
		}
		LuaScriptMgr.PushArray(L, renderer.materials);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bounds(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bounds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bounds on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.bounds);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lightmapIndex(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lightmapIndex");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lightmapIndex on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.lightmapIndex);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lightmapTilingOffset(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lightmapTilingOffset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lightmapTilingOffset on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.lightmapTilingOffset);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isVisible(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isVisible");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isVisible on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.isVisible);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useLightProbes(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useLightProbes");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useLightProbes on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.useLightProbes);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lightProbeAnchor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lightProbeAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lightProbeAnchor on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.lightProbeAnchor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sortingLayerName(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sortingLayerName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sortingLayerName on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.sortingLayerName);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sortingLayerID(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sortingLayerID");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sortingLayerID on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.sortingLayerID);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sortingOrder(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sortingOrder");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sortingOrder on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderer.sortingOrder);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_enabled(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
			}
		}
		renderer.enabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_castShadows(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name castShadows");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index castShadows on a nil value");
			}
		}
		renderer.castShadows = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_receiveShadows(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name receiveShadows");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index receiveShadows on a nil value");
			}
		}
		renderer.receiveShadows = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_material(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}
		renderer.material = (Material)LuaScriptMgr.GetUnityObject(L, 3, typeof(Material));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sharedMaterial(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sharedMaterial");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sharedMaterial on a nil value");
			}
		}
		renderer.sharedMaterial = (Material)LuaScriptMgr.GetUnityObject(L, 3, typeof(Material));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sharedMaterials(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sharedMaterials");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sharedMaterials on a nil value");
			}
		}
		renderer.sharedMaterials = LuaScriptMgr.GetArrayObject<Material>(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_materials(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name materials");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index materials on a nil value");
			}
		}
		renderer.materials = LuaScriptMgr.GetArrayObject<Material>(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lightmapIndex(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lightmapIndex");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lightmapIndex on a nil value");
			}
		}
		renderer.lightmapIndex = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lightmapTilingOffset(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lightmapTilingOffset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lightmapTilingOffset on a nil value");
			}
		}
		renderer.lightmapTilingOffset = LuaScriptMgr.GetVector4(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useLightProbes(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useLightProbes");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useLightProbes on a nil value");
			}
		}
		renderer.useLightProbes = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lightProbeAnchor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lightProbeAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lightProbeAnchor on a nil value");
			}
		}
		renderer.lightProbeAnchor = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sortingLayerName(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sortingLayerName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sortingLayerName on a nil value");
			}
		}
		renderer.sortingLayerName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sortingLayerID(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sortingLayerID");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sortingLayerID on a nil value");
			}
		}
		renderer.sortingLayerID = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sortingOrder(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Renderer renderer = (Renderer)luaObject;
		if (renderer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sortingOrder");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sortingOrder on a nil value");
			}
		}
		renderer.sortingOrder = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPropertyBlock(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Renderer renderer = (Renderer)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Renderer");
		MaterialPropertyBlock propertyBlock = (MaterialPropertyBlock)LuaScriptMgr.GetNetObject(L, 2, typeof(MaterialPropertyBlock));
		renderer.SetPropertyBlock(propertyBlock);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPropertyBlock(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Renderer renderer = (Renderer)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Renderer");
		MaterialPropertyBlock dest = (MaterialPropertyBlock)LuaScriptMgr.GetNetObject(L, 2, typeof(MaterialPropertyBlock));
		renderer.GetPropertyBlock(dest);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Render(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Renderer renderer = (Renderer)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Renderer");
		int material = (int)LuaScriptMgr.GetNumber(L, 2);
		renderer.Render(material);
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
