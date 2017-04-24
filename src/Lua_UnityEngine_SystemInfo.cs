using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_SystemInfo : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			SystemInfo o = new SystemInfo();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, o);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SupportsRenderTextureFormat_s(IntPtr l)
	{
		int result;
		try
		{
			RenderTextureFormat format;
			LuaObject.checkEnum<RenderTextureFormat>(l, 1, out format);
			bool b = SystemInfo.SupportsRenderTextureFormat(format);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, b);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_operatingSystem(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.operatingSystem);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_processorType(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.processorType);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_processorCount(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.processorCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_systemMemorySize(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.systemMemorySize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_graphicsMemorySize(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.graphicsMemorySize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_graphicsDeviceName(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.graphicsDeviceName);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_graphicsDeviceVendor(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.graphicsDeviceVendor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_graphicsDeviceID(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.graphicsDeviceID);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_graphicsDeviceVendorID(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.graphicsDeviceVendorID);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_graphicsDeviceVersion(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.graphicsDeviceVersion);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_graphicsShaderLevel(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.graphicsShaderLevel);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_graphicsPixelFillrate(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.graphicsPixelFillrate);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supportsShadows(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supportsShadows);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supportsRenderTextures(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supportsRenderTextures);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supportsRenderToCubemap(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supportsRenderToCubemap);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supportsImageEffects(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supportsImageEffects);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supports3DTextures(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supports3DTextures);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supportsComputeShaders(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supportsComputeShaders);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supportsInstancing(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supportsInstancing);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supportsSparseTextures(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supportsSparseTextures);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supportedRenderTargetCount(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supportedRenderTargetCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supportsStencil(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supportsStencil);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supportsVertexPrograms(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supportsVertexPrograms);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_npotSupport(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)SystemInfo.npotSupport);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_deviceUniqueIdentifier(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.deviceUniqueIdentifier);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_deviceName(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.deviceName);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_deviceModel(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.deviceModel);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supportsAccelerometer(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supportsAccelerometer);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supportsGyroscope(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supportsGyroscope);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supportsLocationService(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supportsLocationService);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_supportsVibration(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.supportsVibration);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_deviceType(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)SystemInfo.deviceType);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_maxTextureSize(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, SystemInfo.maxTextureSize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	public static void reg(IntPtr l)
	{
		LuaObject.getTypeTable(l, "UnityEngine.SystemInfo");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_SystemInfo.SupportsRenderTextureFormat_s));
		LuaObject.addMember(l, "operatingSystem", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_operatingSystem), null, false);
		LuaObject.addMember(l, "processorType", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_processorType), null, false);
		LuaObject.addMember(l, "processorCount", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_processorCount), null, false);
		LuaObject.addMember(l, "systemMemorySize", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_systemMemorySize), null, false);
		LuaObject.addMember(l, "graphicsMemorySize", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_graphicsMemorySize), null, false);
		LuaObject.addMember(l, "graphicsDeviceName", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_graphicsDeviceName), null, false);
		LuaObject.addMember(l, "graphicsDeviceVendor", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_graphicsDeviceVendor), null, false);
		LuaObject.addMember(l, "graphicsDeviceID", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_graphicsDeviceID), null, false);
		LuaObject.addMember(l, "graphicsDeviceVendorID", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_graphicsDeviceVendorID), null, false);
		LuaObject.addMember(l, "graphicsDeviceVersion", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_graphicsDeviceVersion), null, false);
		LuaObject.addMember(l, "graphicsShaderLevel", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_graphicsShaderLevel), null, false);
		LuaObject.addMember(l, "graphicsPixelFillrate", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_graphicsPixelFillrate), null, false);
		LuaObject.addMember(l, "supportsShadows", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supportsShadows), null, false);
		LuaObject.addMember(l, "supportsRenderTextures", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supportsRenderTextures), null, false);
		LuaObject.addMember(l, "supportsRenderToCubemap", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supportsRenderToCubemap), null, false);
		LuaObject.addMember(l, "supportsImageEffects", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supportsImageEffects), null, false);
		LuaObject.addMember(l, "supports3DTextures", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supports3DTextures), null, false);
		LuaObject.addMember(l, "supportsComputeShaders", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supportsComputeShaders), null, false);
		LuaObject.addMember(l, "supportsInstancing", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supportsInstancing), null, false);
		LuaObject.addMember(l, "supportsSparseTextures", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supportsSparseTextures), null, false);
		LuaObject.addMember(l, "supportedRenderTargetCount", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supportedRenderTargetCount), null, false);
		LuaObject.addMember(l, "supportsStencil", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supportsStencil), null, false);
		LuaObject.addMember(l, "supportsVertexPrograms", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supportsVertexPrograms), null, false);
		LuaObject.addMember(l, "npotSupport", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_npotSupport), null, false);
		LuaObject.addMember(l, "deviceUniqueIdentifier", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_deviceUniqueIdentifier), null, false);
		LuaObject.addMember(l, "deviceName", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_deviceName), null, false);
		LuaObject.addMember(l, "deviceModel", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_deviceModel), null, false);
		LuaObject.addMember(l, "supportsAccelerometer", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supportsAccelerometer), null, false);
		LuaObject.addMember(l, "supportsGyroscope", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supportsGyroscope), null, false);
		LuaObject.addMember(l, "supportsLocationService", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supportsLocationService), null, false);
		LuaObject.addMember(l, "supportsVibration", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_supportsVibration), null, false);
		LuaObject.addMember(l, "deviceType", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_deviceType), null, false);
		LuaObject.addMember(l, "maxTextureSize", new LuaCSFunction(Lua_UnityEngine_SystemInfo.get_maxTextureSize), null, false);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_SystemInfo.constructor), typeof(SystemInfo));
	}
}
