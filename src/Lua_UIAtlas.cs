using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_UIAtlas : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetSprite(IntPtr l)
	{
		int result;
		try
		{
			UIAtlas uIAtlas = (UIAtlas)LuaObject.checkSelf(l);
			string name;
			LuaObject.checkType(l, 2, out name);
			UISpriteData sprite = uIAtlas.GetSprite(name);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, sprite);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SortAlphabetically(IntPtr l)
	{
		int result;
		try
		{
			UIAtlas uIAtlas = (UIAtlas)LuaObject.checkSelf(l);
			uIAtlas.SortAlphabetically();
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
	public static int GetListOfSprites(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				UIAtlas uIAtlas = (UIAtlas)LuaObject.checkSelf(l);
				BetterList<string> listOfSprites = uIAtlas.GetListOfSprites();
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, listOfSprites);
				result = 2;
			}
			else if (num == 2)
			{
				UIAtlas uIAtlas2 = (UIAtlas)LuaObject.checkSelf(l);
				string match;
				LuaObject.checkType(l, 2, out match);
				BetterList<string> listOfSprites2 = uIAtlas2.GetListOfSprites(match);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, listOfSprites2);
				result = 2;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
				result = 2;
			}
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int MarkAsChanged(IntPtr l)
	{
		int result;
		try
		{
			UIAtlas uIAtlas = (UIAtlas)LuaObject.checkSelf(l);
			uIAtlas.MarkAsChanged();
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
	public static int CheckIfRelated_s(IntPtr l)
	{
		int result;
		try
		{
			UIAtlas a;
			LuaObject.checkType<UIAtlas>(l, 1, out a);
			UIAtlas b;
			LuaObject.checkType<UIAtlas>(l, 2, out b);
			bool b2 = UIAtlas.CheckIfRelated(a, b);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, b2);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_spriteMaterial(IntPtr l)
	{
		int result;
		try
		{
			UIAtlas uIAtlas = (UIAtlas)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIAtlas.spriteMaterial);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_spriteMaterial(IntPtr l)
	{
		int result;
		try
		{
			UIAtlas uIAtlas = (UIAtlas)LuaObject.checkSelf(l);
			Material spriteMaterial;
			LuaObject.checkType<Material>(l, 2, out spriteMaterial);
			uIAtlas.spriteMaterial = spriteMaterial;
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
			UIAtlas uIAtlas = (UIAtlas)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIAtlas.premultipliedAlpha);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_spriteList(IntPtr l)
	{
		int result;
		try
		{
			UIAtlas uIAtlas = (UIAtlas)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIAtlas.spriteList);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_spriteList(IntPtr l)
	{
		int result;
		try
		{
			UIAtlas uIAtlas = (UIAtlas)LuaObject.checkSelf(l);
			List<UISpriteData> spriteList;
			LuaObject.checkType<List<UISpriteData>>(l, 2, out spriteList);
			uIAtlas.spriteList = spriteList;
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
	public static int get_texture(IntPtr l)
	{
		int result;
		try
		{
			UIAtlas uIAtlas = (UIAtlas)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIAtlas.texture);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_pixelSize(IntPtr l)
	{
		int result;
		try
		{
			UIAtlas uIAtlas = (UIAtlas)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIAtlas.pixelSize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_pixelSize(IntPtr l)
	{
		int result;
		try
		{
			UIAtlas uIAtlas = (UIAtlas)LuaObject.checkSelf(l);
			float pixelSize;
			LuaObject.checkType(l, 2, out pixelSize);
			uIAtlas.pixelSize = pixelSize;
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
	public static int get_replacement(IntPtr l)
	{
		int result;
		try
		{
			UIAtlas uIAtlas = (UIAtlas)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIAtlas.replacement);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_replacement(IntPtr l)
	{
		int result;
		try
		{
			UIAtlas uIAtlas = (UIAtlas)LuaObject.checkSelf(l);
			UIAtlas replacement;
			LuaObject.checkType<UIAtlas>(l, 2, out replacement);
			uIAtlas.replacement = replacement;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	public static void reg(IntPtr l)
	{
		LuaObject.getTypeTable(l, "UIAtlas");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIAtlas.GetSprite));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIAtlas.SortAlphabetically));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIAtlas.GetListOfSprites));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIAtlas.MarkAsChanged));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIAtlas.CheckIfRelated_s));
		LuaObject.addMember(l, "spriteMaterial", new LuaCSFunction(Lua_UIAtlas.get_spriteMaterial), new LuaCSFunction(Lua_UIAtlas.set_spriteMaterial), true);
		LuaObject.addMember(l, "premultipliedAlpha", new LuaCSFunction(Lua_UIAtlas.get_premultipliedAlpha), null, true);
		LuaObject.addMember(l, "spriteList", new LuaCSFunction(Lua_UIAtlas.get_spriteList), new LuaCSFunction(Lua_UIAtlas.set_spriteList), true);
		LuaObject.addMember(l, "texture", new LuaCSFunction(Lua_UIAtlas.get_texture), null, true);
		LuaObject.addMember(l, "pixelSize", new LuaCSFunction(Lua_UIAtlas.get_pixelSize), new LuaCSFunction(Lua_UIAtlas.set_pixelSize), true);
		LuaObject.addMember(l, "replacement", new LuaCSFunction(Lua_UIAtlas.get_replacement), new LuaCSFunction(Lua_UIAtlas.set_replacement), true);
		LuaObject.createTypeMetatable(l, null, typeof(UIAtlas), typeof(MonoBehaviour));
	}
}
