using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UILabel : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UILabel o = new UILabel();
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
	public static int GetSides(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			Transform relativeTo;
			LuaObject.checkType<Transform>(l, 2, out relativeTo);
			Vector3[] sides = uILabel.GetSides(relativeTo);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, sides);
			result = 2;
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
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			uILabel.MarkAsChanged();
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
	public static int ProcessText(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			uILabel.ProcessText();
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
	public static int UpdateDefaultPrintedSize(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			uILabel.UpdateDefaultPrintedSize();
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
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			uILabel.MakePixelPerfect();
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
	public static int AssumeNaturalSize(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			uILabel.AssumeNaturalSize();
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
	public static int GetCharacterIndexAtPosition(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(Vector2)))
			{
				UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
				Vector2 localPos;
				LuaObject.checkType(l, 2, out localPos);
				int characterIndexAtPosition = uILabel.GetCharacterIndexAtPosition(localPos);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, characterIndexAtPosition);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(Vector3)))
			{
				UILabel uILabel2 = (UILabel)LuaObject.checkSelf(l);
				Vector3 worldPos;
				LuaObject.checkType(l, 2, out worldPos);
				int characterIndexAtPosition2 = uILabel2.GetCharacterIndexAtPosition(worldPos);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, characterIndexAtPosition2);
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
	public static int GetWordAtPosition(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(Vector2)))
			{
				UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
				Vector2 localPos;
				LuaObject.checkType(l, 2, out localPos);
				string wordAtPosition = uILabel.GetWordAtPosition(localPos);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, wordAtPosition);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(Vector3)))
			{
				UILabel uILabel2 = (UILabel)LuaObject.checkSelf(l);
				Vector3 worldPos;
				LuaObject.checkType(l, 2, out worldPos);
				string wordAtPosition2 = uILabel2.GetWordAtPosition(worldPos);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, wordAtPosition2);
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
	public static int GetWordAtCharacterIndex(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			int characterIndex;
			LuaObject.checkType(l, 2, out characterIndex);
			string wordAtCharacterIndex = uILabel.GetWordAtCharacterIndex(characterIndex);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, wordAtCharacterIndex);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetUrlAtPosition(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(Vector2)))
			{
				UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
				Vector2 localPos;
				LuaObject.checkType(l, 2, out localPos);
				string urlAtPosition = uILabel.GetUrlAtPosition(localPos);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, urlAtPosition);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(Vector3)))
			{
				UILabel uILabel2 = (UILabel)LuaObject.checkSelf(l);
				Vector3 worldPos;
				LuaObject.checkType(l, 2, out worldPos);
				string urlAtPosition2 = uILabel2.GetUrlAtPosition(worldPos);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, urlAtPosition2);
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
	public static int GetUrlAtCharacterIndex(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			int characterIndex;
			LuaObject.checkType(l, 2, out characterIndex);
			string urlAtCharacterIndex = uILabel.GetUrlAtCharacterIndex(characterIndex);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, urlAtCharacterIndex);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetCharacterIndex(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			int currentIndex;
			LuaObject.checkType(l, 2, out currentIndex);
			KeyCode key;
			LuaObject.checkEnum<KeyCode>(l, 3, out key);
			int characterIndex = uILabel.GetCharacterIndex(currentIndex, key);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, characterIndex);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int PrintOverlay(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			int start;
			LuaObject.checkType(l, 2, out start);
			int end;
			LuaObject.checkType(l, 3, out end);
			UIGeometry caret;
			LuaObject.checkType<UIGeometry>(l, 4, out caret);
			UIGeometry highlight;
			LuaObject.checkType<UIGeometry>(l, 5, out highlight);
			Color caretColor;
			LuaObject.checkType(l, 6, out caretColor);
			Color highlightColor;
			LuaObject.checkType(l, 7, out highlightColor);
			uILabel.PrintOverlay(start, end, caret, highlight, caretColor, highlightColor);
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
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			BetterList<Vector3> verts;
			LuaObject.checkType<BetterList<Vector3>>(l, 2, out verts);
			BetterList<Vector2> uvs;
			LuaObject.checkType<BetterList<Vector2>>(l, 3, out uvs);
			BetterList<Color32> cols;
			LuaObject.checkType<BetterList<Color32>>(l, 4, out cols);
			uILabel.OnFill(verts, uvs, cols);
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
	public static int ApplyOffset(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			BetterList<Vector3> verts;
			LuaObject.checkType<BetterList<Vector3>>(l, 2, out verts);
			int start;
			LuaObject.checkType(l, 3, out start);
			Vector2 o = uILabel.ApplyOffset(verts, start);
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
	public static int CalculateOffsetToFit(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			string text;
			LuaObject.checkType(l, 2, out text);
			int i = uILabel.CalculateOffsetToFit(text);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, i);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SetCurrentProgress(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			uILabel.SetCurrentProgress();
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
	public static int SetCurrentPercent(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			uILabel.SetCurrentPercent();
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
	public static int SetCurrentSelection(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			uILabel.SetCurrentSelection();
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
	public static int Wrap(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 3)
			{
				UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
				string text;
				LuaObject.checkType(l, 2, out text);
				string s;
				bool b = uILabel.Wrap(text, out s);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b);
				LuaObject.pushValue(l, s);
				result = 3;
			}
			else if (num == 4)
			{
				UILabel uILabel2 = (UILabel)LuaObject.checkSelf(l);
				string text2;
				LuaObject.checkType(l, 2, out text2);
				int height;
				LuaObject.checkType(l, 4, out height);
				string s2;
				bool b2 = uILabel2.Wrap(text2, out s2, height);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b2);
				LuaObject.pushValue(l, s2);
				result = 3;
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
	public static int UpdateNGUIText(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			uILabel.UpdateNGUIText();
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
	public static int get_keepCrispWhenShrunk(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uILabel.keepCrispWhenShrunk);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_keepCrispWhenShrunk(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			UILabel.Crispness keepCrispWhenShrunk;
			LuaObject.checkEnum<UILabel.Crispness>(l, 2, out keepCrispWhenShrunk);
			uILabel.keepCrispWhenShrunk = keepCrispWhenShrunk;
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
	public static int get_isAnchoredHorizontally(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.isAnchoredHorizontally);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isAnchoredVertically(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.isAnchoredVertically);
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
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.material);
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
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			Material material;
			LuaObject.checkType<Material>(l, 2, out material);
			uILabel.material = material;
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
	public static int get_bitmapFont(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.bitmapFont);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_bitmapFont(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			UIFont bitmapFont;
			LuaObject.checkType<UIFont>(l, 2, out bitmapFont);
			uILabel.bitmapFont = bitmapFont;
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
	public static int get_trueTypeFont(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.trueTypeFont);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_trueTypeFont(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			Font trueTypeFont;
			LuaObject.checkType<Font>(l, 2, out trueTypeFont);
			uILabel.trueTypeFont = trueTypeFont;
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
	public static int get_ambigiousFont(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.ambigiousFont);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_ambigiousFont(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			UnityEngine.Object ambigiousFont;
			LuaObject.checkType<UnityEngine.Object>(l, 2, out ambigiousFont);
			uILabel.ambigiousFont = ambigiousFont;
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
	public static int get_text(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.text);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_text(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			string text;
			LuaObject.checkType(l, 2, out text);
			uILabel.text = text;
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
	public static int get_defaultFontSize(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.defaultFontSize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_fontSize(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.fontSize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_fontSize(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			int fontSize;
			LuaObject.checkType(l, 2, out fontSize);
			uILabel.fontSize = fontSize;
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
	public static int get_fontStyle(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uILabel.fontStyle);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_fontStyle(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			FontStyle fontStyle;
			LuaObject.checkEnum<FontStyle>(l, 2, out fontStyle);
			uILabel.fontStyle = fontStyle;
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
	public static int get_alignment(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uILabel.alignment);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_alignment(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			NGUIText.Alignment alignment;
			LuaObject.checkEnum<NGUIText.Alignment>(l, 2, out alignment);
			uILabel.alignment = alignment;
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
	public static int get_applyGradient(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.applyGradient);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_applyGradient(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			bool applyGradient;
			LuaObject.checkType(l, 2, out applyGradient);
			uILabel.applyGradient = applyGradient;
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
	public static int get_gradientTop(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.gradientTop);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_gradientTop(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			Color gradientTop;
			LuaObject.checkType(l, 2, out gradientTop);
			uILabel.gradientTop = gradientTop;
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
	public static int get_gradientBottom(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.gradientBottom);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_gradientBottom(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			Color gradientBottom;
			LuaObject.checkType(l, 2, out gradientBottom);
			uILabel.gradientBottom = gradientBottom;
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
	public static int get_spacingX(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.spacingX);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_spacingX(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			int spacingX;
			LuaObject.checkType(l, 2, out spacingX);
			uILabel.spacingX = spacingX;
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
	public static int get_spacingY(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.spacingY);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_spacingY(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			int spacingY;
			LuaObject.checkType(l, 2, out spacingY);
			uILabel.spacingY = spacingY;
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
	public static int get_supportEncoding(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.supportEncoding);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_supportEncoding(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			bool supportEncoding;
			LuaObject.checkType(l, 2, out supportEncoding);
			uILabel.supportEncoding = supportEncoding;
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
	public static int get_symbolStyle(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uILabel.symbolStyle);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_symbolStyle(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			NGUIText.SymbolStyle symbolStyle;
			LuaObject.checkEnum<NGUIText.SymbolStyle>(l, 2, out symbolStyle);
			uILabel.symbolStyle = symbolStyle;
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
	public static int get_overflowMethod(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uILabel.overflowMethod);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_overflowMethod(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			UILabel.Overflow overflowMethod;
			LuaObject.checkEnum<UILabel.Overflow>(l, 2, out overflowMethod);
			uILabel.overflowMethod = overflowMethod;
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
	public static int get_multiLine(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.multiLine);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_multiLine(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			bool multiLine;
			LuaObject.checkType(l, 2, out multiLine);
			uILabel.multiLine = multiLine;
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
	public static int get_localCorners(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.localCorners);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_worldCorners(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.worldCorners);
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
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.drawingDimensions);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_maxLineCount(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.maxLineCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_maxLineCount(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			int maxLineCount;
			LuaObject.checkType(l, 2, out maxLineCount);
			uILabel.maxLineCount = maxLineCount;
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
	public static int get_effectStyle(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uILabel.effectStyle);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_effectStyle(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			UILabel.Effect effectStyle;
			LuaObject.checkEnum<UILabel.Effect>(l, 2, out effectStyle);
			uILabel.effectStyle = effectStyle;
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
	public static int get_effectColor(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.effectColor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_effectColor(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			Color effectColor;
			LuaObject.checkType(l, 2, out effectColor);
			uILabel.effectColor = effectColor;
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
	public static int get_effectDistance(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.effectDistance);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_effectDistance(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			Vector2 effectDistance;
			LuaObject.checkType(l, 2, out effectDistance);
			uILabel.effectDistance = effectDistance;
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
	public static int get_processedText(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.processedText);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_printedSize(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.printedSize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_localSize(IntPtr l)
	{
		int result;
		try
		{
			UILabel uILabel = (UILabel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uILabel.localSize);
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
		LuaObject.getTypeTable(l, "UILabel");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.GetSides));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.MarkAsChanged));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.ProcessText));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.UpdateDefaultPrintedSize));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.MakePixelPerfect));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.AssumeNaturalSize));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.GetCharacterIndexAtPosition));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.GetWordAtPosition));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.GetWordAtCharacterIndex));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.GetUrlAtPosition));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.GetUrlAtCharacterIndex));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.GetCharacterIndex));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.PrintOverlay));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.OnFill));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.ApplyOffset));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.CalculateOffsetToFit));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.SetCurrentProgress));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.SetCurrentPercent));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.SetCurrentSelection));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.Wrap));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UILabel.UpdateNGUIText));
		LuaObject.addMember(l, "keepCrispWhenShrunk", new LuaCSFunction(Lua_UILabel.get_keepCrispWhenShrunk), new LuaCSFunction(Lua_UILabel.set_keepCrispWhenShrunk), true);
		LuaObject.addMember(l, "isAnchoredHorizontally", new LuaCSFunction(Lua_UILabel.get_isAnchoredHorizontally), null, true);
		LuaObject.addMember(l, "isAnchoredVertically", new LuaCSFunction(Lua_UILabel.get_isAnchoredVertically), null, true);
		LuaObject.addMember(l, "material", new LuaCSFunction(Lua_UILabel.get_material), new LuaCSFunction(Lua_UILabel.set_material), true);
		LuaObject.addMember(l, "bitmapFont", new LuaCSFunction(Lua_UILabel.get_bitmapFont), new LuaCSFunction(Lua_UILabel.set_bitmapFont), true);
		LuaObject.addMember(l, "trueTypeFont", new LuaCSFunction(Lua_UILabel.get_trueTypeFont), new LuaCSFunction(Lua_UILabel.set_trueTypeFont), true);
		LuaObject.addMember(l, "ambigiousFont", new LuaCSFunction(Lua_UILabel.get_ambigiousFont), new LuaCSFunction(Lua_UILabel.set_ambigiousFont), true);
		LuaObject.addMember(l, "text", new LuaCSFunction(Lua_UILabel.get_text), new LuaCSFunction(Lua_UILabel.set_text), true);
		LuaObject.addMember(l, "defaultFontSize", new LuaCSFunction(Lua_UILabel.get_defaultFontSize), null, true);
		LuaObject.addMember(l, "fontSize", new LuaCSFunction(Lua_UILabel.get_fontSize), new LuaCSFunction(Lua_UILabel.set_fontSize), true);
		LuaObject.addMember(l, "fontStyle", new LuaCSFunction(Lua_UILabel.get_fontStyle), new LuaCSFunction(Lua_UILabel.set_fontStyle), true);
		LuaObject.addMember(l, "alignment", new LuaCSFunction(Lua_UILabel.get_alignment), new LuaCSFunction(Lua_UILabel.set_alignment), true);
		LuaObject.addMember(l, "applyGradient", new LuaCSFunction(Lua_UILabel.get_applyGradient), new LuaCSFunction(Lua_UILabel.set_applyGradient), true);
		LuaObject.addMember(l, "gradientTop", new LuaCSFunction(Lua_UILabel.get_gradientTop), new LuaCSFunction(Lua_UILabel.set_gradientTop), true);
		LuaObject.addMember(l, "gradientBottom", new LuaCSFunction(Lua_UILabel.get_gradientBottom), new LuaCSFunction(Lua_UILabel.set_gradientBottom), true);
		LuaObject.addMember(l, "spacingX", new LuaCSFunction(Lua_UILabel.get_spacingX), new LuaCSFunction(Lua_UILabel.set_spacingX), true);
		LuaObject.addMember(l, "spacingY", new LuaCSFunction(Lua_UILabel.get_spacingY), new LuaCSFunction(Lua_UILabel.set_spacingY), true);
		LuaObject.addMember(l, "supportEncoding", new LuaCSFunction(Lua_UILabel.get_supportEncoding), new LuaCSFunction(Lua_UILabel.set_supportEncoding), true);
		LuaObject.addMember(l, "symbolStyle", new LuaCSFunction(Lua_UILabel.get_symbolStyle), new LuaCSFunction(Lua_UILabel.set_symbolStyle), true);
		LuaObject.addMember(l, "overflowMethod", new LuaCSFunction(Lua_UILabel.get_overflowMethod), new LuaCSFunction(Lua_UILabel.set_overflowMethod), true);
		LuaObject.addMember(l, "multiLine", new LuaCSFunction(Lua_UILabel.get_multiLine), new LuaCSFunction(Lua_UILabel.set_multiLine), true);
		LuaObject.addMember(l, "localCorners", new LuaCSFunction(Lua_UILabel.get_localCorners), null, true);
		LuaObject.addMember(l, "worldCorners", new LuaCSFunction(Lua_UILabel.get_worldCorners), null, true);
		LuaObject.addMember(l, "drawingDimensions", new LuaCSFunction(Lua_UILabel.get_drawingDimensions), null, true);
		LuaObject.addMember(l, "maxLineCount", new LuaCSFunction(Lua_UILabel.get_maxLineCount), new LuaCSFunction(Lua_UILabel.set_maxLineCount), true);
		LuaObject.addMember(l, "effectStyle", new LuaCSFunction(Lua_UILabel.get_effectStyle), new LuaCSFunction(Lua_UILabel.set_effectStyle), true);
		LuaObject.addMember(l, "effectColor", new LuaCSFunction(Lua_UILabel.get_effectColor), new LuaCSFunction(Lua_UILabel.set_effectColor), true);
		LuaObject.addMember(l, "effectDistance", new LuaCSFunction(Lua_UILabel.get_effectDistance), new LuaCSFunction(Lua_UILabel.set_effectDistance), true);
		LuaObject.addMember(l, "processedText", new LuaCSFunction(Lua_UILabel.get_processedText), null, true);
		LuaObject.addMember(l, "printedSize", new LuaCSFunction(Lua_UILabel.get_printedSize), null, true);
		LuaObject.addMember(l, "localSize", new LuaCSFunction(Lua_UILabel.get_localSize), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UILabel.constructor), typeof(UILabel), typeof(UIWidget));
	}
}
