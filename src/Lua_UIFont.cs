using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIFont : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int MarkAsChanged(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			uIFont.MarkAsChanged();
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
	public static int UpdateUVRect(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			uIFont.UpdateUVRect();
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
	public static int MatchSymbol(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			string text;
			LuaObject.checkType(l, 2, out text);
			int offset;
			LuaObject.checkType(l, 3, out offset);
			int textLength;
			LuaObject.checkType(l, 4, out textLength);
			BMSymbol o = uIFont.MatchSymbol(text, offset, textLength);
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
	public static int AddSymbol(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			string sequence;
			LuaObject.checkType(l, 2, out sequence);
			string spriteName;
			LuaObject.checkType(l, 3, out spriteName);
			uIFont.AddSymbol(sequence, spriteName);
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
	public static int RemoveSymbol(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			string sequence;
			LuaObject.checkType(l, 2, out sequence);
			uIFont.RemoveSymbol(sequence);
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
	public static int RenameSymbol(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			string before;
			LuaObject.checkType(l, 2, out before);
			string after;
			LuaObject.checkType(l, 3, out after);
			uIFont.RenameSymbol(before, after);
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
	public static int UsesSprite(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			string s;
			LuaObject.checkType(l, 2, out s);
			bool b = uIFont.UsesSprite(s);
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
	public static int CheckIfRelated_s(IntPtr l)
	{
		int result;
		try
		{
			UIFont a;
			LuaObject.checkType<UIFont>(l, 1, out a);
			UIFont b;
			LuaObject.checkType<UIFont>(l, 2, out b);
			bool b2 = UIFont.CheckIfRelated(a, b);
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
	public static int get_bmFont(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.bmFont);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_bmFont(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			BMFont bmFont;
			LuaObject.checkType<BMFont>(l, 2, out bmFont);
			uIFont.bmFont = bmFont;
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
	public static int get_texWidth(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.texWidth);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_texWidth(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			int texWidth;
			LuaObject.checkType(l, 2, out texWidth);
			uIFont.texWidth = texWidth;
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
	public static int get_texHeight(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.texHeight);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_texHeight(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			int texHeight;
			LuaObject.checkType(l, 2, out texHeight);
			uIFont.texHeight = texHeight;
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
	public static int get_hasSymbols(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.hasSymbols);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_symbols(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.symbols);
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
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.atlas);
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
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			UIAtlas atlas;
			LuaObject.checkType<UIAtlas>(l, 2, out atlas);
			uIFont.atlas = atlas;
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
	public static int get_material(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.material);
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
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			Material material;
			LuaObject.checkType<Material>(l, 2, out material);
			uIFont.material = material;
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
	public static int get_premultipliedAlphaShader(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.premultipliedAlphaShader);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_packedFontShader(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.packedFontShader);
			result = 2;
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
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.texture);
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
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.uvRect);
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
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			Rect uvRect;
			LuaObject.checkValueType<Rect>(l, 2, out uvRect);
			uIFont.uvRect = uvRect;
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
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.spriteName);
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
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			string spriteName;
			LuaObject.checkType(l, 2, out spriteName);
			uIFont.spriteName = spriteName;
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
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.isValid);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_defaultSize(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.defaultSize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_defaultSize(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			int defaultSize;
			LuaObject.checkType(l, 2, out defaultSize);
			uIFont.defaultSize = defaultSize;
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
	public static int get_sprite(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.sprite);
			result = 2;
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
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.replacement);
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
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			UIFont replacement;
			LuaObject.checkType<UIFont>(l, 2, out replacement);
			uIFont.replacement = replacement;
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
	public static int get_isDynamic(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.isDynamic);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_dynamicFont(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIFont.dynamicFont);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_dynamicFont(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			Font dynamicFont;
			LuaObject.checkType<Font>(l, 2, out dynamicFont);
			uIFont.dynamicFont = dynamicFont;
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
	public static int get_dynamicFontStyle(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIFont.dynamicFontStyle);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_dynamicFontStyle(IntPtr l)
	{
		int result;
		try
		{
			UIFont uIFont = (UIFont)LuaObject.checkSelf(l);
			FontStyle dynamicFontStyle;
			LuaObject.checkEnum<FontStyle>(l, 2, out dynamicFontStyle);
			uIFont.dynamicFontStyle = dynamicFontStyle;
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
		LuaObject.getTypeTable(l, "UIFont");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIFont.MarkAsChanged));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIFont.UpdateUVRect));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIFont.MatchSymbol));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIFont.AddSymbol));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIFont.RemoveSymbol));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIFont.RenameSymbol));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIFont.UsesSprite));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIFont.CheckIfRelated_s));
		LuaObject.addMember(l, "bmFont", new LuaCSFunction(Lua_UIFont.get_bmFont), new LuaCSFunction(Lua_UIFont.set_bmFont), true);
		LuaObject.addMember(l, "texWidth", new LuaCSFunction(Lua_UIFont.get_texWidth), new LuaCSFunction(Lua_UIFont.set_texWidth), true);
		LuaObject.addMember(l, "texHeight", new LuaCSFunction(Lua_UIFont.get_texHeight), new LuaCSFunction(Lua_UIFont.set_texHeight), true);
		LuaObject.addMember(l, "hasSymbols", new LuaCSFunction(Lua_UIFont.get_hasSymbols), null, true);
		LuaObject.addMember(l, "symbols", new LuaCSFunction(Lua_UIFont.get_symbols), null, true);
		LuaObject.addMember(l, "atlas", new LuaCSFunction(Lua_UIFont.get_atlas), new LuaCSFunction(Lua_UIFont.set_atlas), true);
		LuaObject.addMember(l, "material", new LuaCSFunction(Lua_UIFont.get_material), new LuaCSFunction(Lua_UIFont.set_material), true);
		LuaObject.addMember(l, "premultipliedAlphaShader", new LuaCSFunction(Lua_UIFont.get_premultipliedAlphaShader), null, true);
		LuaObject.addMember(l, "packedFontShader", new LuaCSFunction(Lua_UIFont.get_packedFontShader), null, true);
		LuaObject.addMember(l, "texture", new LuaCSFunction(Lua_UIFont.get_texture), null, true);
		LuaObject.addMember(l, "uvRect", new LuaCSFunction(Lua_UIFont.get_uvRect), new LuaCSFunction(Lua_UIFont.set_uvRect), true);
		LuaObject.addMember(l, "spriteName", new LuaCSFunction(Lua_UIFont.get_spriteName), new LuaCSFunction(Lua_UIFont.set_spriteName), true);
		LuaObject.addMember(l, "isValid", new LuaCSFunction(Lua_UIFont.get_isValid), null, true);
		LuaObject.addMember(l, "defaultSize", new LuaCSFunction(Lua_UIFont.get_defaultSize), new LuaCSFunction(Lua_UIFont.set_defaultSize), true);
		LuaObject.addMember(l, "sprite", new LuaCSFunction(Lua_UIFont.get_sprite), null, true);
		LuaObject.addMember(l, "replacement", new LuaCSFunction(Lua_UIFont.get_replacement), new LuaCSFunction(Lua_UIFont.set_replacement), true);
		LuaObject.addMember(l, "isDynamic", new LuaCSFunction(Lua_UIFont.get_isDynamic), null, true);
		LuaObject.addMember(l, "dynamicFont", new LuaCSFunction(Lua_UIFont.get_dynamicFont), new LuaCSFunction(Lua_UIFont.set_dynamicFont), true);
		LuaObject.addMember(l, "dynamicFontStyle", new LuaCSFunction(Lua_UIFont.get_dynamicFontStyle), new LuaCSFunction(Lua_UIFont.set_dynamicFontStyle), true);
		LuaObject.createTypeMetatable(l, null, typeof(UIFont), typeof(MonoBehaviour));
	}
}
