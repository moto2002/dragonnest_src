using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UITexture : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UITexture o = new UITexture();
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
	public static int RestAlpha(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			uITexture.RestAlpha();
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int MakePixelPerfect(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			uITexture.MakePixelPerfect();
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int OnFill(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			BetterList<Vector3> verts;
			LuaObject.checkType<BetterList<Vector3>>(l, 2, out verts);
			BetterList<Vector2> uvs;
			LuaObject.checkType<BetterList<Vector2>>(l, 3, out uvs);
			BetterList<Color32> cols;
			LuaObject.checkType<BetterList<Color32>>(l, 4, out cols);
			uITexture.OnFill(verts, uvs, cols);
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_mainTexture(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITexture.mainTexture);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_mainTexture(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			Texture mainTexture;
			LuaObject.checkType<Texture>(l, 2, out mainTexture);
			uITexture.mainTexture = mainTexture;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_alphaTexture(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITexture.alphaTexture);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_material(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITexture.material);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_material(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			Material material;
			LuaObject.checkType<Material>(l, 2, out material);
			uITexture.material = material;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_shader(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITexture.shader);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_shader(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			Shader shader;
			LuaObject.checkType<Shader>(l, 2, out shader);
			uITexture.shader = shader;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_flip(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uITexture.flip);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_flip(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			UITexture.Flip flip;
			LuaObject.checkEnum<UITexture.Flip>(l, 2, out flip);
			uITexture.flip = flip;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_premultipliedAlpha(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITexture.premultipliedAlpha);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_uvRect(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITexture.uvRect);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_uvRect(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			Rect uvRect;
			LuaObject.checkValueType<Rect>(l, 2, out uvRect);
			uITexture.uvRect = uvRect;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_drawingDimensions(IntPtr l)
	{
		int result;
		try
		{
			UITexture uITexture = (UITexture)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITexture.drawingDimensions);
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
		LuaObject.getTypeTable(l, "UITexture");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UITexture.RestAlpha));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UITexture.MakePixelPerfect));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UITexture.OnFill));
		LuaObject.addMember(l, "mainTexture", new LuaCSFunction(Lua_UITexture.get_mainTexture), new LuaCSFunction(Lua_UITexture.set_mainTexture), true);
		LuaObject.addMember(l, "alphaTexture", new LuaCSFunction(Lua_UITexture.get_alphaTexture), null, true);
		LuaObject.addMember(l, "material", new LuaCSFunction(Lua_UITexture.get_material), new LuaCSFunction(Lua_UITexture.set_material), true);
		LuaObject.addMember(l, "shader", new LuaCSFunction(Lua_UITexture.get_shader), new LuaCSFunction(Lua_UITexture.set_shader), true);
		LuaObject.addMember(l, "flip", new LuaCSFunction(Lua_UITexture.get_flip), new LuaCSFunction(Lua_UITexture.set_flip), true);
		LuaObject.addMember(l, "premultipliedAlpha", new LuaCSFunction(Lua_UITexture.get_premultipliedAlpha), null, true);
		LuaObject.addMember(l, "uvRect", new LuaCSFunction(Lua_UITexture.get_uvRect), new LuaCSFunction(Lua_UITexture.set_uvRect), true);
		LuaObject.addMember(l, "drawingDimensions", new LuaCSFunction(Lua_UITexture.get_drawingDimensions), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UITexture.constructor), typeof(UITexture), typeof(UIWidget));
	}
}
