using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_UISprite : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UISprite o = new UISprite();
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
	public static int GetAtlasSprite(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			UISpriteData atlasSprite = uISprite.GetAtlasSprite();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, atlasSprite);
			result = 2;
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
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			uISprite.MakePixelPerfect();
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
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			BetterList<Vector3> verts;
			LuaObject.checkType<BetterList<Vector3>>(l, 2, out verts);
			BetterList<Vector2> uvs;
			LuaObject.checkType<BetterList<Vector2>>(l, 3, out uvs);
			BetterList<Color32> cols;
			LuaObject.checkType<BetterList<Color32>>(l, 4, out cols);
			uISprite.OnFill(verts, uvs, cols);
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
	public static int get_current(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UISprite.current);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_current(IntPtr l)
	{
		int result;
		try
		{
			UISprite current;
			LuaObject.checkType<UISprite>(l, 2, out current);
			UISprite.current = current;
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
	public static int get_centerType(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uISprite.centerType);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_centerType(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			UISprite.AdvancedType centerType;
			LuaObject.checkEnum<UISprite.AdvancedType>(l, 2, out centerType);
			uISprite.centerType = centerType;
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
	public static int get_leftType(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uISprite.leftType);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_leftType(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			UISprite.AdvancedType leftType;
			LuaObject.checkEnum<UISprite.AdvancedType>(l, 2, out leftType);
			uISprite.leftType = leftType;
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
	public static int get_rightType(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uISprite.rightType);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_rightType(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			UISprite.AdvancedType rightType;
			LuaObject.checkEnum<UISprite.AdvancedType>(l, 2, out rightType);
			uISprite.rightType = rightType;
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
	public static int get_bottomType(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uISprite.bottomType);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_bottomType(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			UISprite.AdvancedType bottomType;
			LuaObject.checkEnum<UISprite.AdvancedType>(l, 2, out bottomType);
			uISprite.bottomType = bottomType;
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
	public static int get_topType(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uISprite.topType);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_topType(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			UISprite.AdvancedType topType;
			LuaObject.checkEnum<UISprite.AdvancedType>(l, 2, out topType);
			uISprite.topType = topType;
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
	public static int get_onClick(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISprite.onClick);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onClick(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			List<EventDelegate> onClick;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onClick);
			uISprite.onClick = onClick;
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
	public static int get_isEnabled(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISprite.isEnabled);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_type(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uISprite.type);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_type(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			UISprite.Type type;
			LuaObject.checkEnum<UISprite.Type>(l, 2, out type);
			uISprite.type = type;
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
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uISprite.flip);
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
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			UISprite.Flip flip;
			LuaObject.checkEnum<UISprite.Flip>(l, 2, out flip);
			uISprite.flip = flip;
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
	public static int get_FillScale(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISprite.FillScale);
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
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISprite.material);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_atlas(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISprite.atlas);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_atlas(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			UIAtlas atlas;
			LuaObject.checkType<UIAtlas>(l, 2, out atlas);
			uISprite.atlas = atlas;
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
	public static int get_spriteName(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISprite.spriteName);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_spriteName(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			string spriteName;
			LuaObject.checkType(l, 2, out spriteName);
			uISprite.spriteName = spriteName;
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
	public static int get_isValid(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISprite.isValid);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_fillDirection(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uISprite.fillDirection);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_fillDirection(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			UISprite.FillDirection fillDirection;
			LuaObject.checkEnum<UISprite.FillDirection>(l, 2, out fillDirection);
			uISprite.fillDirection = fillDirection;
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
	public static int get_fillAmount(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISprite.fillAmount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_fillAmount(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			float fillAmount;
			LuaObject.checkType(l, 2, out fillAmount);
			uISprite.fillAmount = fillAmount;
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
	public static int get_invert(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISprite.invert);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_invert(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			bool invert;
			LuaObject.checkType(l, 2, out invert);
			uISprite.invert = invert;
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
	public static int get_border(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISprite.border);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_minWidth(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISprite.minWidth);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_minHeight(IntPtr l)
	{
		int result;
		try
		{
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISprite.minHeight);
			result = 2;
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
			UISprite uISprite = (UISprite)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISprite.drawingDimensions);
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
		LuaObject.getTypeTable(l, "UISprite");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UISprite.GetAtlasSprite));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UISprite.MakePixelPerfect));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UISprite.OnFill));
		LuaObject.addMember(l, "current", new LuaCSFunction(Lua_UISprite.get_current), new LuaCSFunction(Lua_UISprite.set_current), false);
		LuaObject.addMember(l, "centerType", new LuaCSFunction(Lua_UISprite.get_centerType), new LuaCSFunction(Lua_UISprite.set_centerType), true);
		LuaObject.addMember(l, "leftType", new LuaCSFunction(Lua_UISprite.get_leftType), new LuaCSFunction(Lua_UISprite.set_leftType), true);
		LuaObject.addMember(l, "rightType", new LuaCSFunction(Lua_UISprite.get_rightType), new LuaCSFunction(Lua_UISprite.set_rightType), true);
		LuaObject.addMember(l, "bottomType", new LuaCSFunction(Lua_UISprite.get_bottomType), new LuaCSFunction(Lua_UISprite.set_bottomType), true);
		LuaObject.addMember(l, "topType", new LuaCSFunction(Lua_UISprite.get_topType), new LuaCSFunction(Lua_UISprite.set_topType), true);
		LuaObject.addMember(l, "onClick", new LuaCSFunction(Lua_UISprite.get_onClick), new LuaCSFunction(Lua_UISprite.set_onClick), true);
		LuaObject.addMember(l, "isEnabled", new LuaCSFunction(Lua_UISprite.get_isEnabled), null, true);
		LuaObject.addMember(l, "type", new LuaCSFunction(Lua_UISprite.get_type), new LuaCSFunction(Lua_UISprite.set_type), true);
		LuaObject.addMember(l, "flip", new LuaCSFunction(Lua_UISprite.get_flip), new LuaCSFunction(Lua_UISprite.set_flip), true);
		LuaObject.addMember(l, "FillScale", new LuaCSFunction(Lua_UISprite.get_FillScale), null, true);
		LuaObject.addMember(l, "material", new LuaCSFunction(Lua_UISprite.get_material), null, true);
		LuaObject.addMember(l, "atlas", new LuaCSFunction(Lua_UISprite.get_atlas), new LuaCSFunction(Lua_UISprite.set_atlas), true);
		LuaObject.addMember(l, "spriteName", new LuaCSFunction(Lua_UISprite.get_spriteName), new LuaCSFunction(Lua_UISprite.set_spriteName), true);
		LuaObject.addMember(l, "isValid", new LuaCSFunction(Lua_UISprite.get_isValid), null, true);
		LuaObject.addMember(l, "fillDirection", new LuaCSFunction(Lua_UISprite.get_fillDirection), new LuaCSFunction(Lua_UISprite.set_fillDirection), true);
		LuaObject.addMember(l, "fillAmount", new LuaCSFunction(Lua_UISprite.get_fillAmount), new LuaCSFunction(Lua_UISprite.set_fillAmount), true);
		LuaObject.addMember(l, "invert", new LuaCSFunction(Lua_UISprite.get_invert), new LuaCSFunction(Lua_UISprite.set_invert), true);
		LuaObject.addMember(l, "border", new LuaCSFunction(Lua_UISprite.get_border), null, true);
		LuaObject.addMember(l, "minWidth", new LuaCSFunction(Lua_UISprite.get_minWidth), null, true);
		LuaObject.addMember(l, "minHeight", new LuaCSFunction(Lua_UISprite.get_minHeight), null, true);
		LuaObject.addMember(l, "drawingDimensions", new LuaCSFunction(Lua_UISprite.get_drawingDimensions), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UISprite.constructor), typeof(UISprite), typeof(UIWidget));
	}
}
