using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_UnityEngine_Component : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			Component o = new Component();
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
	public static int GetComponent(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(string)))
			{
				Component component = (Component)LuaObject.checkSelf(l);
				string type;
				LuaObject.checkType(l, 2, out type);
				Component component2 = component.GetComponent(type);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, component2);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(Type)))
			{
				Component component3 = (Component)LuaObject.checkSelf(l);
				Type type2;
				LuaObject.checkType(l, 2, out type2);
				Component component4 = component3.GetComponent(type2);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, component4);
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
			Component component = (Component)LuaObject.checkSelf(l);
			Type t;
			LuaObject.checkType(l, 2, out t);
			Component componentInChildren = component.GetComponentInChildren(t);
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
	public static int GetComponentsInChildren(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				Component component = (Component)LuaObject.checkSelf(l);
				Type t;
				LuaObject.checkType(l, 2, out t);
				Component[] componentsInChildren = component.GetComponentsInChildren(t);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, componentsInChildren);
				result = 2;
			}
			else if (num == 3)
			{
				Component component2 = (Component)LuaObject.checkSelf(l);
				Type t2;
				LuaObject.checkType(l, 2, out t2);
				bool includeInactive;
				LuaObject.checkType(l, 3, out includeInactive);
				Component[] componentsInChildren2 = component2.GetComponentsInChildren(t2, includeInactive);
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
	public static int GetComponentInParent(IntPtr l)
	{
		int result;
		try
		{
			Component component = (Component)LuaObject.checkSelf(l);
			Type t;
			LuaObject.checkType(l, 2, out t);
			Component componentInParent = component.GetComponentInParent(t);
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
	public static int GetComponentsInParent(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				Component component = (Component)LuaObject.checkSelf(l);
				Type t;
				LuaObject.checkType(l, 2, out t);
				Component[] componentsInParent = component.GetComponentsInParent(t);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, componentsInParent);
				result = 2;
			}
			else if (num == 3)
			{
				Component component2 = (Component)LuaObject.checkSelf(l);
				Type t2;
				LuaObject.checkType(l, 2, out t2);
				bool includeInactive;
				LuaObject.checkType(l, 3, out includeInactive);
				Component[] componentsInParent2 = component2.GetComponentsInParent(t2, includeInactive);
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
	public static int GetComponents(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				Component component = (Component)LuaObject.checkSelf(l);
				Type type;
				LuaObject.checkType(l, 2, out type);
				Component[] components = component.GetComponents(type);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, components);
				result = 2;
			}
			else if (num == 3)
			{
				Component component2 = (Component)LuaObject.checkSelf(l);
				Type type2;
				LuaObject.checkType(l, 2, out type2);
				List<Component> results;
				LuaObject.checkType<List<Component>>(l, 3, out results);
				component2.GetComponents(type2, results);
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
	public static int CompareTag(IntPtr l)
	{
		int result;
		try
		{
			Component component = (Component)LuaObject.checkSelf(l);
			string tag;
			LuaObject.checkType(l, 2, out tag);
			bool b = component.CompareTag(tag);
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
				Component component = (Component)LuaObject.checkSelf(l);
				string methodName;
				LuaObject.checkType(l, 2, out methodName);
				component.SendMessageUpwards(methodName);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(string), typeof(SendMessageOptions)))
			{
				Component component2 = (Component)LuaObject.checkSelf(l);
				string methodName2;
				LuaObject.checkType(l, 2, out methodName2);
				SendMessageOptions options;
				LuaObject.checkEnum<SendMessageOptions>(l, 3, out options);
				component2.SendMessageUpwards(methodName2, options);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(string), typeof(object)))
			{
				Component component3 = (Component)LuaObject.checkSelf(l);
				string methodName3;
				LuaObject.checkType(l, 2, out methodName3);
				object value;
				LuaObject.checkType<object>(l, 3, out value);
				component3.SendMessageUpwards(methodName3, value);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 4)
			{
				Component component4 = (Component)LuaObject.checkSelf(l);
				string methodName4;
				LuaObject.checkType(l, 2, out methodName4);
				object value2;
				LuaObject.checkType<object>(l, 3, out value2);
				SendMessageOptions options2;
				LuaObject.checkEnum<SendMessageOptions>(l, 4, out options2);
				component4.SendMessageUpwards(methodName4, value2, options2);
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
				Component component = (Component)LuaObject.checkSelf(l);
				string methodName;
				LuaObject.checkType(l, 2, out methodName);
				component.SendMessage(methodName);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(string), typeof(SendMessageOptions)))
			{
				Component component2 = (Component)LuaObject.checkSelf(l);
				string methodName2;
				LuaObject.checkType(l, 2, out methodName2);
				SendMessageOptions options;
				LuaObject.checkEnum<SendMessageOptions>(l, 3, out options);
				component2.SendMessage(methodName2, options);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(string), typeof(object)))
			{
				Component component3 = (Component)LuaObject.checkSelf(l);
				string methodName3;
				LuaObject.checkType(l, 2, out methodName3);
				object value;
				LuaObject.checkType<object>(l, 3, out value);
				component3.SendMessage(methodName3, value);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 4)
			{
				Component component4 = (Component)LuaObject.checkSelf(l);
				string methodName4;
				LuaObject.checkType(l, 2, out methodName4);
				object value2;
				LuaObject.checkType<object>(l, 3, out value2);
				SendMessageOptions options2;
				LuaObject.checkEnum<SendMessageOptions>(l, 4, out options2);
				component4.SendMessage(methodName4, value2, options2);
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
				Component component = (Component)LuaObject.checkSelf(l);
				string methodName;
				LuaObject.checkType(l, 2, out methodName);
				component.BroadcastMessage(methodName);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(string), typeof(SendMessageOptions)))
			{
				Component component2 = (Component)LuaObject.checkSelf(l);
				string methodName2;
				LuaObject.checkType(l, 2, out methodName2);
				SendMessageOptions options;
				LuaObject.checkEnum<SendMessageOptions>(l, 3, out options);
				component2.BroadcastMessage(methodName2, options);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(string), typeof(object)))
			{
				Component component3 = (Component)LuaObject.checkSelf(l);
				string methodName3;
				LuaObject.checkType(l, 2, out methodName3);
				object parameter;
				LuaObject.checkType<object>(l, 3, out parameter);
				component3.BroadcastMessage(methodName3, parameter);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 4)
			{
				Component component4 = (Component)LuaObject.checkSelf(l);
				string methodName4;
				LuaObject.checkType(l, 2, out methodName4);
				object parameter2;
				LuaObject.checkType<object>(l, 3, out parameter2);
				SendMessageOptions options2;
				LuaObject.checkEnum<SendMessageOptions>(l, 4, out options2);
				component4.BroadcastMessage(methodName4, parameter2, options2);
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
	public static int get_transform(IntPtr l)
	{
		int result;
		try
		{
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.transform);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.rigidbody);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.rigidbody2D);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.camera);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.light);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.animation);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.constantForce);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.renderer);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.audio);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.guiText);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.guiTexture);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.collider);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.collider2D);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.hingeJoint);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.particleEmitter);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.particleSystem);
			result = 2;
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.gameObject);
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
			Component component = (Component)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, component.tag);
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
			Component component = (Component)LuaObject.checkSelf(l);
			string tag;
			LuaObject.checkType(l, 2, out tag);
			component.tag = tag;
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
		LuaObject.getTypeTable(l, "UnityEngine.Component");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Component.GetComponent));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Component.GetComponentInChildren));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Component.GetComponentsInChildren));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Component.GetComponentInParent));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Component.GetComponentsInParent));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Component.GetComponents));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Component.CompareTag));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Component.SendMessageUpwards));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Component.SendMessage));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Component.BroadcastMessage));
		LuaObject.addMember(l, "transform", new LuaCSFunction(Lua_UnityEngine_Component.get_transform), null, true);
		LuaObject.addMember(l, "rigidbody", new LuaCSFunction(Lua_UnityEngine_Component.get_rigidbody), null, true);
		LuaObject.addMember(l, "rigidbody2D", new LuaCSFunction(Lua_UnityEngine_Component.get_rigidbody2D), null, true);
		LuaObject.addMember(l, "camera", new LuaCSFunction(Lua_UnityEngine_Component.get_camera), null, true);
		LuaObject.addMember(l, "light", new LuaCSFunction(Lua_UnityEngine_Component.get_light), null, true);
		LuaObject.addMember(l, "animation", new LuaCSFunction(Lua_UnityEngine_Component.get_animation), null, true);
		LuaObject.addMember(l, "constantForce", new LuaCSFunction(Lua_UnityEngine_Component.get_constantForce), null, true);
		LuaObject.addMember(l, "renderer", new LuaCSFunction(Lua_UnityEngine_Component.get_renderer), null, true);
		LuaObject.addMember(l, "audio", new LuaCSFunction(Lua_UnityEngine_Component.get_audio), null, true);
		LuaObject.addMember(l, "guiText", new LuaCSFunction(Lua_UnityEngine_Component.get_guiText), null, true);
		LuaObject.addMember(l, "guiTexture", new LuaCSFunction(Lua_UnityEngine_Component.get_guiTexture), null, true);
		LuaObject.addMember(l, "collider", new LuaCSFunction(Lua_UnityEngine_Component.get_collider), null, true);
		LuaObject.addMember(l, "collider2D", new LuaCSFunction(Lua_UnityEngine_Component.get_collider2D), null, true);
		LuaObject.addMember(l, "hingeJoint", new LuaCSFunction(Lua_UnityEngine_Component.get_hingeJoint), null, true);
		LuaObject.addMember(l, "particleEmitter", new LuaCSFunction(Lua_UnityEngine_Component.get_particleEmitter), null, true);
		LuaObject.addMember(l, "particleSystem", new LuaCSFunction(Lua_UnityEngine_Component.get_particleSystem), null, true);
		LuaObject.addMember(l, "gameObject", new LuaCSFunction(Lua_UnityEngine_Component.get_gameObject), null, true);
		LuaObject.addMember(l, "tag", new LuaCSFunction(Lua_UnityEngine_Component.get_tag), new LuaCSFunction(Lua_UnityEngine_Component.set_tag), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Component.constructor), typeof(Component), typeof(UnityEngine.Object));
	}
}
