using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_Material : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(string)))
			{
				string contents;
				LuaObject.checkType(l, 2, out contents);
				Material o = new Material(contents);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(Shader)))
			{
				Shader shader;
				LuaObject.checkType<Shader>(l, 2, out shader);
				Material o = new Material(shader);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(Material)))
			{
				Material source;
				LuaObject.checkType<Material>(l, 2, out source);
				Material o = new Material(source);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else
			{
				result = LuaObject.error(l, "New object failed.");
			}
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SetColor(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(int), typeof(Color)))
			{
				Material material = (Material)LuaObject.checkSelf(l);
				int nameID;
				LuaObject.checkType(l, 2, out nameID);
				Color color;
				LuaObject.checkType(l, 3, out color);
				material.SetColor(nameID, color);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string), typeof(Color)))
			{
				Material material2 = (Material)LuaObject.checkSelf(l);
				string propertyName;
				LuaObject.checkType(l, 2, out propertyName);
				Color color2;
				LuaObject.checkType(l, 3, out color2);
				material2.SetColor(propertyName, color2);
				LuaObject.pushValue(l, true);
				result = 1;
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
	public static int GetColor(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(int)))
			{
				Material material = (Material)LuaObject.checkSelf(l);
				int nameID;
				LuaObject.checkType(l, 2, out nameID);
				Color color = material.GetColor(nameID);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, color);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string)))
			{
				Material material2 = (Material)LuaObject.checkSelf(l);
				string propertyName;
				LuaObject.checkType(l, 2, out propertyName);
				Color color2 = material2.GetColor(propertyName);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, color2);
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
	public static int SetVector(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(int), typeof(Vector4)))
			{
				Material material = (Material)LuaObject.checkSelf(l);
				int nameID;
				LuaObject.checkType(l, 2, out nameID);
				Vector4 vector;
				LuaObject.checkType(l, 3, out vector);
				material.SetVector(nameID, vector);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string), typeof(Vector4)))
			{
				Material material2 = (Material)LuaObject.checkSelf(l);
				string propertyName;
				LuaObject.checkType(l, 2, out propertyName);
				Vector4 vector2;
				LuaObject.checkType(l, 3, out vector2);
				material2.SetVector(propertyName, vector2);
				LuaObject.pushValue(l, true);
				result = 1;
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
	public static int GetVector(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(int)))
			{
				Material material = (Material)LuaObject.checkSelf(l);
				int nameID;
				LuaObject.checkType(l, 2, out nameID);
				Vector4 vector = material.GetVector(nameID);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, vector);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string)))
			{
				Material material2 = (Material)LuaObject.checkSelf(l);
				string propertyName;
				LuaObject.checkType(l, 2, out propertyName);
				Vector4 vector2 = material2.GetVector(propertyName);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, vector2);
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
	public static int SetTexture(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(int), typeof(Texture)))
			{
				Material material = (Material)LuaObject.checkSelf(l);
				int nameID;
				LuaObject.checkType(l, 2, out nameID);
				Texture texture;
				LuaObject.checkType<Texture>(l, 3, out texture);
				material.SetTexture(nameID, texture);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string), typeof(Texture)))
			{
				Material material2 = (Material)LuaObject.checkSelf(l);
				string propertyName;
				LuaObject.checkType(l, 2, out propertyName);
				Texture texture2;
				LuaObject.checkType<Texture>(l, 3, out texture2);
				material2.SetTexture(propertyName, texture2);
				LuaObject.pushValue(l, true);
				result = 1;
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
	public static int GetTexture(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(int)))
			{
				Material material = (Material)LuaObject.checkSelf(l);
				int nameID;
				LuaObject.checkType(l, 2, out nameID);
				Texture texture = material.GetTexture(nameID);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, texture);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string)))
			{
				Material material2 = (Material)LuaObject.checkSelf(l);
				string propertyName;
				LuaObject.checkType(l, 2, out propertyName);
				Texture texture2 = material2.GetTexture(propertyName);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, texture2);
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
	public static int SetTextureOffset(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			string propertyName;
			LuaObject.checkType(l, 2, out propertyName);
			Vector2 offset;
			LuaObject.checkType(l, 3, out offset);
			material.SetTextureOffset(propertyName, offset);
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
	public static int GetTextureOffset(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			string propertyName;
			LuaObject.checkType(l, 2, out propertyName);
			Vector2 textureOffset = material.GetTextureOffset(propertyName);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, textureOffset);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SetTextureScale(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			string propertyName;
			LuaObject.checkType(l, 2, out propertyName);
			Vector2 scale;
			LuaObject.checkType(l, 3, out scale);
			material.SetTextureScale(propertyName, scale);
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
	public static int GetTextureScale(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			string propertyName;
			LuaObject.checkType(l, 2, out propertyName);
			Vector2 textureScale = material.GetTextureScale(propertyName);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, textureScale);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SetMatrix(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(int), typeof(Matrix4x4)))
			{
				Material material = (Material)LuaObject.checkSelf(l);
				int nameID;
				LuaObject.checkType(l, 2, out nameID);
				Matrix4x4 matrix;
				LuaObject.checkValueType<Matrix4x4>(l, 3, out matrix);
				material.SetMatrix(nameID, matrix);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string), typeof(Matrix4x4)))
			{
				Material material2 = (Material)LuaObject.checkSelf(l);
				string propertyName;
				LuaObject.checkType(l, 2, out propertyName);
				Matrix4x4 matrix2;
				LuaObject.checkValueType<Matrix4x4>(l, 3, out matrix2);
				material2.SetMatrix(propertyName, matrix2);
				LuaObject.pushValue(l, true);
				result = 1;
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
	public static int GetMatrix(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(int)))
			{
				Material material = (Material)LuaObject.checkSelf(l);
				int nameID;
				LuaObject.checkType(l, 2, out nameID);
				Matrix4x4 matrix = material.GetMatrix(nameID);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, matrix);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string)))
			{
				Material material2 = (Material)LuaObject.checkSelf(l);
				string propertyName;
				LuaObject.checkType(l, 2, out propertyName);
				Matrix4x4 matrix2 = material2.GetMatrix(propertyName);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, matrix2);
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
	public static int SetFloat(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(int), typeof(float)))
			{
				Material material = (Material)LuaObject.checkSelf(l);
				int nameID;
				LuaObject.checkType(l, 2, out nameID);
				float value;
				LuaObject.checkType(l, 3, out value);
				material.SetFloat(nameID, value);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string), typeof(float)))
			{
				Material material2 = (Material)LuaObject.checkSelf(l);
				string propertyName;
				LuaObject.checkType(l, 2, out propertyName);
				float value2;
				LuaObject.checkType(l, 3, out value2);
				material2.SetFloat(propertyName, value2);
				LuaObject.pushValue(l, true);
				result = 1;
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
	public static int GetFloat(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(int)))
			{
				Material material = (Material)LuaObject.checkSelf(l);
				int nameID;
				LuaObject.checkType(l, 2, out nameID);
				float @float = material.GetFloat(nameID);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, @float);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string)))
			{
				Material material2 = (Material)LuaObject.checkSelf(l);
				string propertyName;
				LuaObject.checkType(l, 2, out propertyName);
				float float2 = material2.GetFloat(propertyName);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, float2);
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
	public static int SetInt(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(int), typeof(int)))
			{
				Material material = (Material)LuaObject.checkSelf(l);
				int nameID;
				LuaObject.checkType(l, 2, out nameID);
				int value;
				LuaObject.checkType(l, 3, out value);
				material.SetInt(nameID, value);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string), typeof(int)))
			{
				Material material2 = (Material)LuaObject.checkSelf(l);
				string propertyName;
				LuaObject.checkType(l, 2, out propertyName);
				int value2;
				LuaObject.checkType(l, 3, out value2);
				material2.SetInt(propertyName, value2);
				LuaObject.pushValue(l, true);
				result = 1;
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
	public static int GetInt(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(int)))
			{
				Material material = (Material)LuaObject.checkSelf(l);
				int nameID;
				LuaObject.checkType(l, 2, out nameID);
				int @int = material.GetInt(nameID);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, @int);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string)))
			{
				Material material2 = (Material)LuaObject.checkSelf(l);
				string propertyName;
				LuaObject.checkType(l, 2, out propertyName);
				int int2 = material2.GetInt(propertyName);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, int2);
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
	public static int SetBuffer(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			string propertyName;
			LuaObject.checkType(l, 2, out propertyName);
			ComputeBuffer buffer;
			LuaObject.checkType<ComputeBuffer>(l, 3, out buffer);
			material.SetBuffer(propertyName, buffer);
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
	public static int HasProperty(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(int)))
			{
				Material material = (Material)LuaObject.checkSelf(l);
				int nameID;
				LuaObject.checkType(l, 2, out nameID);
				bool b = material.HasProperty(nameID);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string)))
			{
				Material material2 = (Material)LuaObject.checkSelf(l);
				string propertyName;
				LuaObject.checkType(l, 2, out propertyName);
				bool b2 = material2.HasProperty(propertyName);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b2);
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
	public static int GetTag(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 3)
			{
				Material material = (Material)LuaObject.checkSelf(l);
				string tag;
				LuaObject.checkType(l, 2, out tag);
				bool searchFallbacks;
				LuaObject.checkType(l, 3, out searchFallbacks);
				string tag2 = material.GetTag(tag, searchFallbacks);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, tag2);
				result = 2;
			}
			else if (num == 4)
			{
				Material material2 = (Material)LuaObject.checkSelf(l);
				string tag3;
				LuaObject.checkType(l, 2, out tag3);
				bool searchFallbacks2;
				LuaObject.checkType(l, 3, out searchFallbacks2);
				string defaultValue;
				LuaObject.checkType(l, 4, out defaultValue);
				string tag4 = material2.GetTag(tag3, searchFallbacks2, defaultValue);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, tag4);
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
	public static int Lerp(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			Material start;
			LuaObject.checkType<Material>(l, 2, out start);
			Material end;
			LuaObject.checkType<Material>(l, 3, out end);
			float t;
			LuaObject.checkType(l, 4, out t);
			material.Lerp(start, end, t);
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
	public static int SetPass(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			int pass;
			LuaObject.checkType(l, 2, out pass);
			bool b = material.SetPass(pass);
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
	public static int CopyPropertiesFromMaterial(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			Material mat;
			LuaObject.checkType<Material>(l, 2, out mat);
			material.CopyPropertiesFromMaterial(mat);
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
	public static int EnableKeyword(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			string keyword;
			LuaObject.checkType(l, 2, out keyword);
			material.EnableKeyword(keyword);
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
	public static int DisableKeyword(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			string keyword;
			LuaObject.checkType(l, 2, out keyword);
			material.DisableKeyword(keyword);
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
			Material material = (Material)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, material.shader);
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
			Material material = (Material)LuaObject.checkSelf(l);
			Shader shader;
			LuaObject.checkType<Shader>(l, 2, out shader);
			material.shader = shader;
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
	public static int get_color(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, material.color);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_color(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			Color color;
			LuaObject.checkType(l, 2, out color);
			material.color = color;
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
			Material material = (Material)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, material.mainTexture);
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
			Material material = (Material)LuaObject.checkSelf(l);
			Texture mainTexture;
			LuaObject.checkType<Texture>(l, 2, out mainTexture);
			material.mainTexture = mainTexture;
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
	public static int get_mainTextureOffset(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, material.mainTextureOffset);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_mainTextureOffset(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			Vector2 mainTextureOffset;
			LuaObject.checkType(l, 2, out mainTextureOffset);
			material.mainTextureOffset = mainTextureOffset;
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
	public static int get_mainTextureScale(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, material.mainTextureScale);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_mainTextureScale(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			Vector2 mainTextureScale;
			LuaObject.checkType(l, 2, out mainTextureScale);
			material.mainTextureScale = mainTextureScale;
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
	public static int get_passCount(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, material.passCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_renderQueue(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, material.renderQueue);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_renderQueue(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			int renderQueue;
			LuaObject.checkType(l, 2, out renderQueue);
			material.renderQueue = renderQueue;
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
	public static int get_shaderKeywords(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, material.shaderKeywords);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_shaderKeywords(IntPtr l)
	{
		int result;
		try
		{
			Material material = (Material)LuaObject.checkSelf(l);
			string[] shaderKeywords;
			LuaObject.checkArray<string>(l, 2, out shaderKeywords);
			material.shaderKeywords = shaderKeywords;
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
		LuaObject.getTypeTable(l, "UnityEngine.Material");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.SetColor));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.GetColor));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.SetVector));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.GetVector));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.SetTexture));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.GetTexture));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.SetTextureOffset));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.GetTextureOffset));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.SetTextureScale));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.GetTextureScale));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.SetMatrix));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.GetMatrix));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.SetFloat));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.GetFloat));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.SetInt));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.GetInt));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.SetBuffer));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.HasProperty));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.GetTag));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.Lerp));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.SetPass));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.CopyPropertiesFromMaterial));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.EnableKeyword));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Material.DisableKeyword));
		LuaObject.addMember(l, "shader", new LuaCSFunction(Lua_UnityEngine_Material.get_shader), new LuaCSFunction(Lua_UnityEngine_Material.set_shader), true);
		LuaObject.addMember(l, "color", new LuaCSFunction(Lua_UnityEngine_Material.get_color), new LuaCSFunction(Lua_UnityEngine_Material.set_color), true);
		LuaObject.addMember(l, "mainTexture", new LuaCSFunction(Lua_UnityEngine_Material.get_mainTexture), new LuaCSFunction(Lua_UnityEngine_Material.set_mainTexture), true);
		LuaObject.addMember(l, "mainTextureOffset", new LuaCSFunction(Lua_UnityEngine_Material.get_mainTextureOffset), new LuaCSFunction(Lua_UnityEngine_Material.set_mainTextureOffset), true);
		LuaObject.addMember(l, "mainTextureScale", new LuaCSFunction(Lua_UnityEngine_Material.get_mainTextureScale), new LuaCSFunction(Lua_UnityEngine_Material.set_mainTextureScale), true);
		LuaObject.addMember(l, "passCount", new LuaCSFunction(Lua_UnityEngine_Material.get_passCount), null, true);
		LuaObject.addMember(l, "renderQueue", new LuaCSFunction(Lua_UnityEngine_Material.get_renderQueue), new LuaCSFunction(Lua_UnityEngine_Material.set_renderQueue), true);
		LuaObject.addMember(l, "shaderKeywords", new LuaCSFunction(Lua_UnityEngine_Material.get_shaderKeywords), new LuaCSFunction(Lua_UnityEngine_Material.set_shaderKeywords), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Material.constructor), typeof(Material), typeof(UnityEngine.Object));
	}
}
