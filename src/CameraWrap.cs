using LuaInterface;
using System;
using UnityEngine;

public class CameraWrap
{
	private static Type classType = typeof(Camera);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SetTargetBuffers", new LuaCSFunction(CameraWrap.SetTargetBuffers)),
			new LuaMethod("ResetWorldToCameraMatrix", new LuaCSFunction(CameraWrap.ResetWorldToCameraMatrix)),
			new LuaMethod("ResetProjectionMatrix", new LuaCSFunction(CameraWrap.ResetProjectionMatrix)),
			new LuaMethod("ResetAspect", new LuaCSFunction(CameraWrap.ResetAspect)),
			new LuaMethod("WorldToScreenPoint", new LuaCSFunction(CameraWrap.WorldToScreenPoint)),
			new LuaMethod("WorldToViewportPoint", new LuaCSFunction(CameraWrap.WorldToViewportPoint)),
			new LuaMethod("ViewportToWorldPoint", new LuaCSFunction(CameraWrap.ViewportToWorldPoint)),
			new LuaMethod("ScreenToWorldPoint", new LuaCSFunction(CameraWrap.ScreenToWorldPoint)),
			new LuaMethod("ScreenToViewportPoint", new LuaCSFunction(CameraWrap.ScreenToViewportPoint)),
			new LuaMethod("ViewportToScreenPoint", new LuaCSFunction(CameraWrap.ViewportToScreenPoint)),
			new LuaMethod("ViewportPointToRay", new LuaCSFunction(CameraWrap.ViewportPointToRay)),
			new LuaMethod("ScreenPointToRay", new LuaCSFunction(CameraWrap.ScreenPointToRay)),
			new LuaMethod("GetAllCameras", new LuaCSFunction(CameraWrap.GetAllCameras)),
			new LuaMethod("Render", new LuaCSFunction(CameraWrap.Render)),
			new LuaMethod("RenderWithShader", new LuaCSFunction(CameraWrap.RenderWithShader)),
			new LuaMethod("SetReplacementShader", new LuaCSFunction(CameraWrap.SetReplacementShader)),
			new LuaMethod("ResetReplacementShader", new LuaCSFunction(CameraWrap.ResetReplacementShader)),
			new LuaMethod("RenderDontRestore", new LuaCSFunction(CameraWrap.RenderDontRestore)),
			new LuaMethod("SetupCurrent", new LuaCSFunction(CameraWrap.SetupCurrent)),
			new LuaMethod("RenderToCubemap", new LuaCSFunction(CameraWrap.RenderToCubemap)),
			new LuaMethod("CopyFrom", new LuaCSFunction(CameraWrap.CopyFrom)),
			new LuaMethod("CalculateObliqueMatrix", new LuaCSFunction(CameraWrap.CalculateObliqueMatrix)),
			new LuaMethod("New", new LuaCSFunction(CameraWrap._CreateCamera)),
			new LuaMethod("GetClassType", new LuaCSFunction(CameraWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(CameraWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("fieldOfView", new LuaCSFunction(CameraWrap.get_fieldOfView), new LuaCSFunction(CameraWrap.set_fieldOfView)),
			new LuaField("nearClipPlane", new LuaCSFunction(CameraWrap.get_nearClipPlane), new LuaCSFunction(CameraWrap.set_nearClipPlane)),
			new LuaField("farClipPlane", new LuaCSFunction(CameraWrap.get_farClipPlane), new LuaCSFunction(CameraWrap.set_farClipPlane)),
			new LuaField("renderingPath", new LuaCSFunction(CameraWrap.get_renderingPath), new LuaCSFunction(CameraWrap.set_renderingPath)),
			new LuaField("actualRenderingPath", new LuaCSFunction(CameraWrap.get_actualRenderingPath), null),
			new LuaField("hdr", new LuaCSFunction(CameraWrap.get_hdr), new LuaCSFunction(CameraWrap.set_hdr)),
			new LuaField("orthographicSize", new LuaCSFunction(CameraWrap.get_orthographicSize), new LuaCSFunction(CameraWrap.set_orthographicSize)),
			new LuaField("orthographic", new LuaCSFunction(CameraWrap.get_orthographic), new LuaCSFunction(CameraWrap.set_orthographic)),
			new LuaField("transparencySortMode", new LuaCSFunction(CameraWrap.get_transparencySortMode), new LuaCSFunction(CameraWrap.set_transparencySortMode)),
			new LuaField("isOrthoGraphic", new LuaCSFunction(CameraWrap.get_isOrthoGraphic), new LuaCSFunction(CameraWrap.set_isOrthoGraphic)),
			new LuaField("depth", new LuaCSFunction(CameraWrap.get_depth), new LuaCSFunction(CameraWrap.set_depth)),
			new LuaField("aspect", new LuaCSFunction(CameraWrap.get_aspect), new LuaCSFunction(CameraWrap.set_aspect)),
			new LuaField("cullingMask", new LuaCSFunction(CameraWrap.get_cullingMask), new LuaCSFunction(CameraWrap.set_cullingMask)),
			new LuaField("eventMask", new LuaCSFunction(CameraWrap.get_eventMask), new LuaCSFunction(CameraWrap.set_eventMask)),
			new LuaField("backgroundColor", new LuaCSFunction(CameraWrap.get_backgroundColor), new LuaCSFunction(CameraWrap.set_backgroundColor)),
			new LuaField("rect", new LuaCSFunction(CameraWrap.get_rect), new LuaCSFunction(CameraWrap.set_rect)),
			new LuaField("pixelRect", new LuaCSFunction(CameraWrap.get_pixelRect), new LuaCSFunction(CameraWrap.set_pixelRect)),
			new LuaField("targetTexture", new LuaCSFunction(CameraWrap.get_targetTexture), new LuaCSFunction(CameraWrap.set_targetTexture)),
			new LuaField("pixelWidth", new LuaCSFunction(CameraWrap.get_pixelWidth), null),
			new LuaField("pixelHeight", new LuaCSFunction(CameraWrap.get_pixelHeight), null),
			new LuaField("cameraToWorldMatrix", new LuaCSFunction(CameraWrap.get_cameraToWorldMatrix), null),
			new LuaField("worldToCameraMatrix", new LuaCSFunction(CameraWrap.get_worldToCameraMatrix), new LuaCSFunction(CameraWrap.set_worldToCameraMatrix)),
			new LuaField("projectionMatrix", new LuaCSFunction(CameraWrap.get_projectionMatrix), new LuaCSFunction(CameraWrap.set_projectionMatrix)),
			new LuaField("velocity", new LuaCSFunction(CameraWrap.get_velocity), null),
			new LuaField("clearFlags", new LuaCSFunction(CameraWrap.get_clearFlags), new LuaCSFunction(CameraWrap.set_clearFlags)),
			new LuaField("stereoEnabled", new LuaCSFunction(CameraWrap.get_stereoEnabled), null),
			new LuaField("stereoSeparation", new LuaCSFunction(CameraWrap.get_stereoSeparation), new LuaCSFunction(CameraWrap.set_stereoSeparation)),
			new LuaField("stereoConvergence", new LuaCSFunction(CameraWrap.get_stereoConvergence), new LuaCSFunction(CameraWrap.set_stereoConvergence)),
			new LuaField("main", new LuaCSFunction(CameraWrap.get_main), null),
			new LuaField("current", new LuaCSFunction(CameraWrap.get_current), null),
			new LuaField("allCameras", new LuaCSFunction(CameraWrap.get_allCameras), null),
			new LuaField("allCamerasCount", new LuaCSFunction(CameraWrap.get_allCamerasCount), null),
			new LuaField("useOcclusionCulling", new LuaCSFunction(CameraWrap.get_useOcclusionCulling), new LuaCSFunction(CameraWrap.set_useOcclusionCulling)),
			new LuaField("layerCullDistances", new LuaCSFunction(CameraWrap.get_layerCullDistances), new LuaCSFunction(CameraWrap.set_layerCullDistances)),
			new LuaField("layerCullSpherical", new LuaCSFunction(CameraWrap.get_layerCullSpherical), new LuaCSFunction(CameraWrap.set_layerCullSpherical)),
			new LuaField("depthTextureMode", new LuaCSFunction(CameraWrap.get_depthTextureMode), new LuaCSFunction(CameraWrap.set_depthTextureMode)),
			new LuaField("clearStencilAfterLightingPass", new LuaCSFunction(CameraWrap.get_clearStencilAfterLightingPass), new LuaCSFunction(CameraWrap.set_clearStencilAfterLightingPass))
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Camera", typeof(Camera), regs, fields, typeof(Behaviour));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateCamera(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			Camera obj = new Camera();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Camera.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, CameraWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fieldOfView(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fieldOfView");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fieldOfView on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.fieldOfView);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_nearClipPlane(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nearClipPlane");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nearClipPlane on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.nearClipPlane);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_farClipPlane(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name farClipPlane");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index farClipPlane on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.farClipPlane);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_renderingPath(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderingPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderingPath on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.renderingPath);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_actualRenderingPath(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name actualRenderingPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index actualRenderingPath on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.actualRenderingPath);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hdr(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hdr");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hdr on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.hdr);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_orthographicSize(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name orthographicSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index orthographicSize on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.orthographicSize);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_orthographic(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name orthographic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index orthographic on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.orthographic);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_transparencySortMode(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name transparencySortMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index transparencySortMode on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.transparencySortMode);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isOrthoGraphic(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isOrthoGraphic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isOrthoGraphic on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.isOrthoGraphic);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_depth(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.depth);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_aspect(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aspect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aspect on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.aspect);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cullingMask(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cullingMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cullingMask on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.cullingMask);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_eventMask(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name eventMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index eventMask on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.eventMask);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_backgroundColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name backgroundColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index backgroundColor on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.backgroundColor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rect(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rect on a nil value");
			}
		}
		LuaScriptMgr.PushValue(L, camera.rect);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pixelRect(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelRect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelRect on a nil value");
			}
		}
		LuaScriptMgr.PushValue(L, camera.pixelRect);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetTexture(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetTexture on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.targetTexture);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pixelWidth(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelWidth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelWidth on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.pixelWidth);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pixelHeight(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelHeight on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.pixelHeight);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cameraToWorldMatrix(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cameraToWorldMatrix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cameraToWorldMatrix on a nil value");
			}
		}
		LuaScriptMgr.PushValue(L, camera.cameraToWorldMatrix);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldToCameraMatrix(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldToCameraMatrix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldToCameraMatrix on a nil value");
			}
		}
		LuaScriptMgr.PushValue(L, camera.worldToCameraMatrix);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_projectionMatrix(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name projectionMatrix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index projectionMatrix on a nil value");
			}
		}
		LuaScriptMgr.PushValue(L, camera.projectionMatrix);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_velocity(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name velocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index velocity on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.velocity);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clearFlags(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clearFlags");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clearFlags on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.clearFlags);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_stereoEnabled(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stereoEnabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stereoEnabled on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.stereoEnabled);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_stereoSeparation(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stereoSeparation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stereoSeparation on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.stereoSeparation);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_stereoConvergence(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stereoConvergence");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stereoConvergence on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.stereoConvergence);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_main(IntPtr L)
	{
		LuaScriptMgr.Push(L, Camera.main);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_current(IntPtr L)
	{
		LuaScriptMgr.Push(L, Camera.current);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_allCameras(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, Camera.allCameras);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_allCamerasCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, Camera.allCamerasCount);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useOcclusionCulling(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useOcclusionCulling");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useOcclusionCulling on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.useOcclusionCulling);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_layerCullDistances(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name layerCullDistances");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index layerCullDistances on a nil value");
			}
		}
		LuaScriptMgr.PushArray(L, camera.layerCullDistances);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_layerCullSpherical(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name layerCullSpherical");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index layerCullSpherical on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.layerCullSpherical);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_depthTextureMode(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depthTextureMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depthTextureMode on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.depthTextureMode);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clearStencilAfterLightingPass(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clearStencilAfterLightingPass");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clearStencilAfterLightingPass on a nil value");
			}
		}
		LuaScriptMgr.Push(L, camera.clearStencilAfterLightingPass);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fieldOfView(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fieldOfView");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fieldOfView on a nil value");
			}
		}
		camera.fieldOfView = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_nearClipPlane(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nearClipPlane");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nearClipPlane on a nil value");
			}
		}
		camera.nearClipPlane = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_farClipPlane(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name farClipPlane");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index farClipPlane on a nil value");
			}
		}
		camera.farClipPlane = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_renderingPath(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderingPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderingPath on a nil value");
			}
		}
		camera.renderingPath = (RenderingPath)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(RenderingPath)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hdr(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hdr");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hdr on a nil value");
			}
		}
		camera.hdr = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_orthographicSize(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name orthographicSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index orthographicSize on a nil value");
			}
		}
		camera.orthographicSize = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_orthographic(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name orthographic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index orthographic on a nil value");
			}
		}
		camera.orthographic = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_transparencySortMode(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name transparencySortMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index transparencySortMode on a nil value");
			}
		}
		camera.transparencySortMode = (TransparencySortMode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(TransparencySortMode)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isOrthoGraphic(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isOrthoGraphic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isOrthoGraphic on a nil value");
			}
		}
		camera.isOrthoGraphic = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_depth(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
			}
		}
		camera.depth = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_aspect(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aspect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aspect on a nil value");
			}
		}
		camera.aspect = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cullingMask(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cullingMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cullingMask on a nil value");
			}
		}
		camera.cullingMask = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_eventMask(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name eventMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index eventMask on a nil value");
			}
		}
		camera.eventMask = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_backgroundColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name backgroundColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index backgroundColor on a nil value");
			}
		}
		camera.backgroundColor = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rect(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rect on a nil value");
			}
		}
		camera.rect = (Rect)LuaScriptMgr.GetNetObject(L, 3, typeof(Rect));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pixelRect(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelRect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelRect on a nil value");
			}
		}
		camera.pixelRect = (Rect)LuaScriptMgr.GetNetObject(L, 3, typeof(Rect));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_targetTexture(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetTexture on a nil value");
			}
		}
		camera.targetTexture = (RenderTexture)LuaScriptMgr.GetUnityObject(L, 3, typeof(RenderTexture));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_worldToCameraMatrix(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldToCameraMatrix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldToCameraMatrix on a nil value");
			}
		}
		camera.worldToCameraMatrix = (Matrix4x4)LuaScriptMgr.GetNetObject(L, 3, typeof(Matrix4x4));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_projectionMatrix(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name projectionMatrix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index projectionMatrix on a nil value");
			}
		}
		camera.projectionMatrix = (Matrix4x4)LuaScriptMgr.GetNetObject(L, 3, typeof(Matrix4x4));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clearFlags(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clearFlags");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clearFlags on a nil value");
			}
		}
		camera.clearFlags = (CameraClearFlags)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(CameraClearFlags)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_stereoSeparation(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stereoSeparation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stereoSeparation on a nil value");
			}
		}
		camera.stereoSeparation = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_stereoConvergence(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stereoConvergence");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stereoConvergence on a nil value");
			}
		}
		camera.stereoConvergence = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useOcclusionCulling(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useOcclusionCulling");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useOcclusionCulling on a nil value");
			}
		}
		camera.useOcclusionCulling = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_layerCullDistances(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name layerCullDistances");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index layerCullDistances on a nil value");
			}
		}
		camera.layerCullDistances = LuaScriptMgr.GetArrayNumber<float>(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_layerCullSpherical(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name layerCullSpherical");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index layerCullSpherical on a nil value");
			}
		}
		camera.layerCullSpherical = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_depthTextureMode(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depthTextureMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depthTextureMode on a nil value");
			}
		}
		camera.depthTextureMode = (DepthTextureMode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(DepthTextureMode)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clearStencilAfterLightingPass(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Camera camera = (Camera)luaObject;
		if (camera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clearStencilAfterLightingPass");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clearStencilAfterLightingPass on a nil value");
			}
		}
		camera.clearStencilAfterLightingPass = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTargetBuffers(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Camera), typeof(RenderBuffer[]), typeof(RenderBuffer)))
		{
			Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
			RenderBuffer[] arrayObject = LuaScriptMgr.GetArrayObject<RenderBuffer>(L, 2);
			RenderBuffer depthBuffer = (RenderBuffer)LuaScriptMgr.GetLuaObject(L, 3);
			camera.SetTargetBuffers(arrayObject, depthBuffer);
			return 0;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Camera), typeof(RenderBuffer), typeof(RenderBuffer)))
		{
			Camera camera2 = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
			RenderBuffer colorBuffer = (RenderBuffer)LuaScriptMgr.GetLuaObject(L, 2);
			RenderBuffer depthBuffer2 = (RenderBuffer)LuaScriptMgr.GetLuaObject(L, 3);
			camera2.SetTargetBuffers(colorBuffer, depthBuffer2);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Camera.SetTargetBuffers");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetWorldToCameraMatrix(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		camera.ResetWorldToCameraMatrix();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetProjectionMatrix(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		camera.ResetProjectionMatrix();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetAspect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		camera.ResetAspect();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WorldToScreenPoint(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		Vector3 vector = LuaScriptMgr.GetVector3(L, 2);
		Vector3 v = camera.WorldToScreenPoint(vector);
		LuaScriptMgr.Push(L, v);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WorldToViewportPoint(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		Vector3 vector = LuaScriptMgr.GetVector3(L, 2);
		Vector3 v = camera.WorldToViewportPoint(vector);
		LuaScriptMgr.Push(L, v);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ViewportToWorldPoint(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		Vector3 vector = LuaScriptMgr.GetVector3(L, 2);
		Vector3 v = camera.ViewportToWorldPoint(vector);
		LuaScriptMgr.Push(L, v);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ScreenToWorldPoint(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		Vector3 vector = LuaScriptMgr.GetVector3(L, 2);
		Vector3 v = camera.ScreenToWorldPoint(vector);
		LuaScriptMgr.Push(L, v);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ScreenToViewportPoint(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		Vector3 vector = LuaScriptMgr.GetVector3(L, 2);
		Vector3 v = camera.ScreenToViewportPoint(vector);
		LuaScriptMgr.Push(L, v);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ViewportToScreenPoint(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		Vector3 vector = LuaScriptMgr.GetVector3(L, 2);
		Vector3 v = camera.ViewportToScreenPoint(vector);
		LuaScriptMgr.Push(L, v);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ViewportPointToRay(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		Vector3 vector = LuaScriptMgr.GetVector3(L, 2);
		Ray ray = camera.ViewportPointToRay(vector);
		LuaScriptMgr.Push(L, ray);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ScreenPointToRay(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		Vector3 vector = LuaScriptMgr.GetVector3(L, 2);
		Ray ray = camera.ScreenPointToRay(vector);
		LuaScriptMgr.Push(L, ray);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAllCameras(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera[] arrayObject = LuaScriptMgr.GetArrayObject<Camera>(L, 1);
		int allCameras = Camera.GetAllCameras(arrayObject);
		LuaScriptMgr.Push(L, allCameras);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Render(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		camera.Render();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RenderWithShader(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		Shader shader = (Shader)LuaScriptMgr.GetUnityObject(L, 2, typeof(Shader));
		string luaString = LuaScriptMgr.GetLuaString(L, 3);
		camera.RenderWithShader(shader, luaString);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetReplacementShader(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		Shader shader = (Shader)LuaScriptMgr.GetUnityObject(L, 2, typeof(Shader));
		string luaString = LuaScriptMgr.GetLuaString(L, 3);
		camera.SetReplacementShader(shader, luaString);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetReplacementShader(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		camera.ResetReplacementShader();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RenderDontRestore(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		camera.RenderDontRestore();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetupCurrent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera cur = (Camera)LuaScriptMgr.GetUnityObject(L, 1, typeof(Camera));
		Camera.SetupCurrent(cur);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RenderToCubemap(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Camera), typeof(RenderTexture)))
		{
			Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
			RenderTexture cubemap = (RenderTexture)LuaScriptMgr.GetLuaObject(L, 2);
			bool b = camera.RenderToCubemap(cubemap);
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Camera), typeof(Cubemap)))
		{
			Camera camera2 = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
			Cubemap cubemap2 = (Cubemap)LuaScriptMgr.GetLuaObject(L, 2);
			bool b2 = camera2.RenderToCubemap(cubemap2);
			LuaScriptMgr.Push(L, b2);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Camera), typeof(RenderTexture), typeof(int)))
		{
			Camera camera3 = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
			RenderTexture cubemap3 = (RenderTexture)LuaScriptMgr.GetLuaObject(L, 2);
			int faceMask = (int)LuaDLL.lua_tonumber(L, 3);
			bool b3 = camera3.RenderToCubemap(cubemap3, faceMask);
			LuaScriptMgr.Push(L, b3);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Camera), typeof(Cubemap), typeof(int)))
		{
			Camera camera4 = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
			Cubemap cubemap4 = (Cubemap)LuaScriptMgr.GetLuaObject(L, 2);
			int faceMask2 = (int)LuaDLL.lua_tonumber(L, 3);
			bool b4 = camera4.RenderToCubemap(cubemap4, faceMask2);
			LuaScriptMgr.Push(L, b4);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Camera.RenderToCubemap");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CopyFrom(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		Camera other = (Camera)LuaScriptMgr.GetUnityObject(L, 2, typeof(Camera));
		camera.CopyFrom(other);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateObliqueMatrix(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera camera = (Camera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera");
		Vector4 vector = LuaScriptMgr.GetVector4(L, 2);
		Matrix4x4 matrix4x = camera.CalculateObliqueMatrix(vector);
		LuaScriptMgr.PushValue(L, matrix4x);
		return 1;
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
