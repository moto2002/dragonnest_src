using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_UnityEngine_GameObject : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				string name;
				LuaObject.checkType(l, 2, out name);
				GameObject o = new GameObject(name);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 1)
			{
				GameObject o = new GameObject();
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 3)
			{
				string name2;
				LuaObject.checkType(l, 2, out name2);
				Type[] components;
				LuaObject.checkParams<Type>(l, 3, out components);
				GameObject o = new GameObject(name2, components);
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
	public static int SampleAnimation(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			AnimationClip animation;
			LuaObject.checkType<AnimationClip>(l, 2, out animation);
			float time;
			LuaObject.checkType(l, 3, out time);
			gameObject.SampleAnimation(animation, time);
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
	public static int GetComponent(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(string)))
			{
				GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
				string type;
				LuaObject.checkType(l, 2, out type);
				Component component = gameObject.GetComponent(type);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, component);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(Type)))
			{
				GameObject gameObject2 = (GameObject)LuaObject.checkSelf(l);
				Type type2;
				LuaObject.checkType(l, 2, out type2);
				Component component2 = gameObject2.GetComponent(type2);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, component2);
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
	public static int GetComponentInChildren(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			Type type;
			LuaObject.checkType(l, 2, out type);
			Component componentInChildren = gameObject.GetComponentInChildren(type);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, componentInChildren);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetComponentInParent(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			Type type;
			LuaObject.checkType(l, 2, out type);
			Component componentInParent = gameObject.GetComponentInParent(type);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, componentInParent);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetComponents(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
				Type type;
				LuaObject.checkType(l, 2, out type);
				Component[] components = gameObject.GetComponents(type);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, components);
				result = 2;
			}
			else if (num == 3)
			{
				GameObject gameObject2 = (GameObject)LuaObject.checkSelf(l);
				Type type2;
				LuaObject.checkType(l, 2, out type2);
				List<Component> results;
				LuaObject.checkType<List<Component>>(l, 3, out results);
				gameObject2.GetComponents(type2, results);
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
	public static int GetComponentsInChildren(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
				Type type;
				LuaObject.checkType(l, 2, out type);
				Component[] componentsInChildren = gameObject.GetComponentsInChildren(type);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, componentsInChildren);
				result = 2;
			}
			else if (num == 3)
			{
				GameObject gameObject2 = (GameObject)LuaObject.checkSelf(l);
				Type type2;
				LuaObject.checkType(l, 2, out type2);
				bool includeInactive;
				LuaObject.checkType(l, 3, out includeInactive);
				Component[] componentsInChildren2 = gameObject2.GetComponentsInChildren(type2, includeInactive);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, componentsInChildren2);
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
	public static int GetComponentsInParent(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
				Type type;
				LuaObject.checkType(l, 2, out type);
				Component[] componentsInParent = gameObject.GetComponentsInParent(type);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, componentsInParent);
				result = 2;
			}
			else if (num == 3)
			{
				GameObject gameObject2 = (GameObject)LuaObject.checkSelf(l);
				Type type2;
				LuaObject.checkType(l, 2, out type2);
				bool includeInactive;
				LuaObject.checkType(l, 3, out includeInactive);
				Component[] componentsInParent2 = gameObject2.GetComponentsInParent(type2, includeInactive);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, componentsInParent2);
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
	public static int SetActive(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			bool active;
			LuaObject.checkType(l, 2, out active);
			gameObject.SetActive(active);
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
	public static int CompareTag(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			string tag;
			LuaObject.checkType(l, 2, out tag);
			bool b = gameObject.CompareTag(tag);
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
	public static int SendMessageUpwards(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
				string methodName;
				LuaObject.checkType(l, 2, out methodName);
				gameObject.SendMessageUpwards(methodName);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(string), typeof(SendMessageOptions)))
			{
				GameObject gameObject2 = (GameObject)LuaObject.checkSelf(l);
				string methodName2;
				LuaObject.checkType(l, 2, out methodName2);
				SendMessageOptions options;
				LuaObject.checkEnum<SendMessageOptions>(l, 3, out options);
				gameObject2.SendMessageUpwards(methodName2, options);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(string), typeof(object)))
			{
				GameObject gameObject3 = (GameObject)LuaObject.checkSelf(l);
				string methodName3;
				LuaObject.checkType(l, 2, out methodName3);
				object value;
				LuaObject.checkType<object>(l, 3, out value);
				gameObject3.SendMessageUpwards(methodName3, value);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 4)
			{
				GameObject gameObject4 = (GameObject)LuaObject.checkSelf(l);
				string methodName4;
				LuaObject.checkType(l, 2, out methodName4);
				object value2;
				LuaObject.checkType<object>(l, 3, out value2);
				SendMessageOptions options2;
				LuaObject.checkEnum<SendMessageOptions>(l, 4, out options2);
				gameObject4.SendMessageUpwards(methodName4, value2, options2);
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
	public static int SendMessage(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
				string methodName;
				LuaObject.checkType(l, 2, out methodName);
				gameObject.SendMessage(methodName);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(string), typeof(SendMessageOptions)))
			{
				GameObject gameObject2 = (GameObject)LuaObject.checkSelf(l);
				string methodName2;
				LuaObject.checkType(l, 2, out methodName2);
				SendMessageOptions options;
				LuaObject.checkEnum<SendMessageOptions>(l, 3, out options);
				gameObject2.SendMessage(methodName2, options);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(string), typeof(object)))
			{
				GameObject gameObject3 = (GameObject)LuaObject.checkSelf(l);
				string methodName3;
				LuaObject.checkType(l, 2, out methodName3);
				object value;
				LuaObject.checkType<object>(l, 3, out value);
				gameObject3.SendMessage(methodName3, value);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 4)
			{
				GameObject gameObject4 = (GameObject)LuaObject.checkSelf(l);
				string methodName4;
				LuaObject.checkType(l, 2, out methodName4);
				object value2;
				LuaObject.checkType<object>(l, 3, out value2);
				SendMessageOptions options2;
				LuaObject.checkEnum<SendMessageOptions>(l, 4, out options2);
				gameObject4.SendMessage(methodName4, value2, options2);
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
	public static int BroadcastMessage(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
				string methodName;
				LuaObject.checkType(l, 2, out methodName);
				gameObject.BroadcastMessage(methodName);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(string), typeof(SendMessageOptions)))
			{
				GameObject gameObject2 = (GameObject)LuaObject.checkSelf(l);
				string methodName2;
				LuaObject.checkType(l, 2, out methodName2);
				SendMessageOptions options;
				LuaObject.checkEnum<SendMessageOptions>(l, 3, out options);
				gameObject2.BroadcastMessage(methodName2, options);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(string), typeof(object)))
			{
				GameObject gameObject3 = (GameObject)LuaObject.checkSelf(l);
				string methodName3;
				LuaObject.checkType(l, 2, out methodName3);
				object parameter;
				LuaObject.checkType<object>(l, 3, out parameter);
				gameObject3.BroadcastMessage(methodName3, parameter);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 4)
			{
				GameObject gameObject4 = (GameObject)LuaObject.checkSelf(l);
				string methodName4;
				LuaObject.checkType(l, 2, out methodName4);
				object parameter2;
				LuaObject.checkType<object>(l, 3, out parameter2);
				SendMessageOptions options2;
				LuaObject.checkEnum<SendMessageOptions>(l, 4, out options2);
				gameObject4.BroadcastMessage(methodName4, parameter2, options2);
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
	public static int AddComponent(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(Type)))
			{
				GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
				Type componentType;
				LuaObject.checkType(l, 2, out componentType);
				Component o = gameObject.AddComponent(componentType);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string)))
			{
				GameObject gameObject2 = (GameObject)LuaObject.checkSelf(l);
				string className;
				LuaObject.checkType(l, 2, out className);
				Component o2 = gameObject2.AddComponent(className);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o2);
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
	public static int CreatePrimitive_s(IntPtr l)
	{
		int result;
		try
		{
			PrimitiveType type;
			LuaObject.checkEnum<PrimitiveType>(l, 1, out type);
			GameObject o = GameObject.CreatePrimitive(type);
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
	public static int FindGameObjectWithTag_s(IntPtr l)
	{
		int result;
		try
		{
			string tag;
			LuaObject.checkType(l, 1, out tag);
			GameObject o = GameObject.FindGameObjectWithTag(tag);
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
	public static int FindWithTag_s(IntPtr l)
	{
		int result;
		try
		{
			string tag;
			LuaObject.checkType(l, 1, out tag);
			GameObject o = GameObject.FindWithTag(tag);
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
	public static int FindGameObjectsWithTag_s(IntPtr l)
	{
		int result;
		try
		{
			string tag;
			LuaObject.checkType(l, 1, out tag);
			GameObject[] a = GameObject.FindGameObjectsWithTag(tag);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, a);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Find_s(IntPtr l)
	{
		int result;
		try
		{
			string name;
			LuaObject.checkType(l, 1, out name);
			GameObject o = GameObject.Find(name);
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
	public static int get_isStatic(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.isStatic);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_isStatic(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			bool isStatic;
			LuaObject.checkType(l, 2, out isStatic);
			gameObject.isStatic = isStatic;
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
	public static int get_transform(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.transform);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_rigidbody(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.rigidbody);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_rigidbody2D(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.rigidbody2D);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_camera(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.camera);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_light(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.light);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_animation(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.animation);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_constantForce(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.constantForce);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_renderer(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.renderer);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_audio(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.audio);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_guiText(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.guiText);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_guiTexture(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.guiTexture);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_collider(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.collider);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_collider2D(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.collider2D);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_hingeJoint(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.hingeJoint);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_particleEmitter(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.particleEmitter);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_particleSystem(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.particleSystem);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_layer(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.layer);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_layer(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			int layer;
			LuaObject.checkType(l, 2, out layer);
			gameObject.layer = layer;
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
	public static int get_activeSelf(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.activeSelf);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_activeInHierarchy(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.activeInHierarchy);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_tag(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.tag);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_tag(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			string tag;
			LuaObject.checkType(l, 2, out tag);
			gameObject.tag = tag;
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
	public static int get_gameObject(IntPtr l)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, gameObject.gameObject);
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
		LuaObject.getTypeTable(l, "UnityEngine.GameObject");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.SampleAnimation));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.GetComponent));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.GetComponentInChildren));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.GetComponentInParent));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.GetComponents));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.GetComponentsInChildren));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.GetComponentsInParent));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.SetActive));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.CompareTag));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.SendMessageUpwards));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.SendMessage));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.BroadcastMessage));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.AddComponent));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.CreatePrimitive_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.FindGameObjectWithTag_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.FindWithTag_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.FindGameObjectsWithTag_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_GameObject.Find_s));
		LuaObject.addMember(l, "isStatic", new LuaCSFunction(Lua_UnityEngine_GameObject.get_isStatic), new LuaCSFunction(Lua_UnityEngine_GameObject.set_isStatic), true);
		LuaObject.addMember(l, "transform", new LuaCSFunction(Lua_UnityEngine_GameObject.get_transform), null, true);
		LuaObject.addMember(l, "rigidbody", new LuaCSFunction(Lua_UnityEngine_GameObject.get_rigidbody), null, true);
		LuaObject.addMember(l, "rigidbody2D", new LuaCSFunction(Lua_UnityEngine_GameObject.get_rigidbody2D), null, true);
		LuaObject.addMember(l, "camera", new LuaCSFunction(Lua_UnityEngine_GameObject.get_camera), null, true);
		LuaObject.addMember(l, "light", new LuaCSFunction(Lua_UnityEngine_GameObject.get_light), null, true);
		LuaObject.addMember(l, "animation", new LuaCSFunction(Lua_UnityEngine_GameObject.get_animation), null, true);
		LuaObject.addMember(l, "constantForce", new LuaCSFunction(Lua_UnityEngine_GameObject.get_constantForce), null, true);
		LuaObject.addMember(l, "renderer", new LuaCSFunction(Lua_UnityEngine_GameObject.get_renderer), null, true);
		LuaObject.addMember(l, "audio", new LuaCSFunction(Lua_UnityEngine_GameObject.get_audio), null, true);
		LuaObject.addMember(l, "guiText", new LuaCSFunction(Lua_UnityEngine_GameObject.get_guiText), null, true);
		LuaObject.addMember(l, "guiTexture", new LuaCSFunction(Lua_UnityEngine_GameObject.get_guiTexture), null, true);
		LuaObject.addMember(l, "collider", new LuaCSFunction(Lua_UnityEngine_GameObject.get_collider), null, true);
		LuaObject.addMember(l, "collider2D", new LuaCSFunction(Lua_UnityEngine_GameObject.get_collider2D), null, true);
		LuaObject.addMember(l, "hingeJoint", new LuaCSFunction(Lua_UnityEngine_GameObject.get_hingeJoint), null, true);
		LuaObject.addMember(l, "particleEmitter", new LuaCSFunction(Lua_UnityEngine_GameObject.get_particleEmitter), null, true);
		LuaObject.addMember(l, "particleSystem", new LuaCSFunction(Lua_UnityEngine_GameObject.get_particleSystem), null, true);
		LuaObject.addMember(l, "layer", new LuaCSFunction(Lua_UnityEngine_GameObject.get_layer), new LuaCSFunction(Lua_UnityEngine_GameObject.set_layer), true);
		LuaObject.addMember(l, "activeSelf", new LuaCSFunction(Lua_UnityEngine_GameObject.get_activeSelf), null, true);
		LuaObject.addMember(l, "activeInHierarchy", new LuaCSFunction(Lua_UnityEngine_GameObject.get_activeInHierarchy), null, true);
		LuaObject.addMember(l, "tag", new LuaCSFunction(Lua_UnityEngine_GameObject.get_tag), new LuaCSFunction(Lua_UnityEngine_GameObject.set_tag), true);
		LuaObject.addMember(l, "gameObject", new LuaCSFunction(Lua_UnityEngine_GameObject.get_gameObject), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_GameObject.constructor), typeof(GameObject), typeof(UnityEngine.Object));
	}
}
