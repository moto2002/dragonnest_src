using LuaInterface;
using System;
using UnityEngine;

public class PhysicsWrap
{
	private static Type classType = typeof(Physics);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Raycast", new LuaCSFunction(PhysicsWrap.Raycast)),
			new LuaMethod("RaycastAll", new LuaCSFunction(PhysicsWrap.RaycastAll)),
			new LuaMethod("Linecast", new LuaCSFunction(PhysicsWrap.Linecast)),
			new LuaMethod("OverlapSphere", new LuaCSFunction(PhysicsWrap.OverlapSphere)),
			new LuaMethod("CapsuleCast", new LuaCSFunction(PhysicsWrap.CapsuleCast)),
			new LuaMethod("SphereCast", new LuaCSFunction(PhysicsWrap.SphereCast)),
			new LuaMethod("CapsuleCastAll", new LuaCSFunction(PhysicsWrap.CapsuleCastAll)),
			new LuaMethod("SphereCastAll", new LuaCSFunction(PhysicsWrap.SphereCastAll)),
			new LuaMethod("CheckSphere", new LuaCSFunction(PhysicsWrap.CheckSphere)),
			new LuaMethod("CheckCapsule", new LuaCSFunction(PhysicsWrap.CheckCapsule)),
			new LuaMethod("IgnoreCollision", new LuaCSFunction(PhysicsWrap.IgnoreCollision)),
			new LuaMethod("IgnoreLayerCollision", new LuaCSFunction(PhysicsWrap.IgnoreLayerCollision)),
			new LuaMethod("GetIgnoreLayerCollision", new LuaCSFunction(PhysicsWrap.GetIgnoreLayerCollision)),
			new LuaMethod("New", new LuaCSFunction(PhysicsWrap._CreatePhysics)),
			new LuaMethod("GetClassType", new LuaCSFunction(PhysicsWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("kIgnoreRaycastLayer", new LuaCSFunction(PhysicsWrap.get_kIgnoreRaycastLayer), null),
			new LuaField("kDefaultRaycastLayers", new LuaCSFunction(PhysicsWrap.get_kDefaultRaycastLayers), null),
			new LuaField("kAllLayers", new LuaCSFunction(PhysicsWrap.get_kAllLayers), null),
			new LuaField("IgnoreRaycastLayer", new LuaCSFunction(PhysicsWrap.get_IgnoreRaycastLayer), null),
			new LuaField("DefaultRaycastLayers", new LuaCSFunction(PhysicsWrap.get_DefaultRaycastLayers), null),
			new LuaField("AllLayers", new LuaCSFunction(PhysicsWrap.get_AllLayers), null),
			new LuaField("gravity", new LuaCSFunction(PhysicsWrap.get_gravity), new LuaCSFunction(PhysicsWrap.set_gravity)),
			new LuaField("minPenetrationForPenalty", new LuaCSFunction(PhysicsWrap.get_minPenetrationForPenalty), new LuaCSFunction(PhysicsWrap.set_minPenetrationForPenalty)),
			new LuaField("bounceThreshold", new LuaCSFunction(PhysicsWrap.get_bounceThreshold), new LuaCSFunction(PhysicsWrap.set_bounceThreshold)),
			new LuaField("sleepVelocity", new LuaCSFunction(PhysicsWrap.get_sleepVelocity), new LuaCSFunction(PhysicsWrap.set_sleepVelocity)),
			new LuaField("sleepAngularVelocity", new LuaCSFunction(PhysicsWrap.get_sleepAngularVelocity), new LuaCSFunction(PhysicsWrap.set_sleepAngularVelocity)),
			new LuaField("maxAngularVelocity", new LuaCSFunction(PhysicsWrap.get_maxAngularVelocity), new LuaCSFunction(PhysicsWrap.set_maxAngularVelocity)),
			new LuaField("solverIterationCount", new LuaCSFunction(PhysicsWrap.get_solverIterationCount), new LuaCSFunction(PhysicsWrap.set_solverIterationCount))
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Physics", typeof(Physics), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreatePhysics(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			Physics o = new Physics();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Physics.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, PhysicsWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_kIgnoreRaycastLayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, 4);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_kDefaultRaycastLayers(IntPtr L)
	{
		LuaScriptMgr.Push(L, -5);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_kAllLayers(IntPtr L)
	{
		LuaScriptMgr.Push(L, -1);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IgnoreRaycastLayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, 4);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DefaultRaycastLayers(IntPtr L)
	{
		LuaScriptMgr.Push(L, -5);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_AllLayers(IntPtr L)
	{
		LuaScriptMgr.Push(L, -1);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gravity(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.gravity);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minPenetrationForPenalty(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.minPenetrationForPenalty);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bounceThreshold(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.bounceThreshold);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sleepVelocity(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.sleepVelocity);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sleepAngularVelocity(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.sleepAngularVelocity);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxAngularVelocity(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.maxAngularVelocity);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_solverIterationCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.solverIterationCount);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_gravity(IntPtr L)
	{
		Physics.gravity = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_minPenetrationForPenalty(IntPtr L)
	{
		Physics.minPenetrationForPenalty = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bounceThreshold(IntPtr L)
	{
		Physics.bounceThreshold = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sleepVelocity(IntPtr L)
	{
		Physics.sleepVelocity = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sleepAngularVelocity(IntPtr L)
	{
		Physics.sleepAngularVelocity = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxAngularVelocity(IntPtr L)
	{
		Physics.maxAngularVelocity = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_solverIterationCount(IntPtr L)
	{
		Physics.solverIterationCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Raycast(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			Ray ray = LuaScriptMgr.GetRay(L, 1);
			bool b = Physics.Raycast(ray);
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float)))
		{
			Ray ray2 = LuaScriptMgr.GetRay(L, 1);
			float distance = (float)LuaDLL.lua_tonumber(L, 2);
			bool b2 = Physics.Raycast(ray2, distance);
			LuaScriptMgr.Push(L, b2);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), null))
		{
			Ray ray3 = LuaScriptMgr.GetRay(L, 1);
			RaycastHit hit;
			bool b3 = Physics.Raycast(ray3, out hit);
			LuaScriptMgr.Push(L, b3);
			LuaScriptMgr.Push(L, hit);
			return 2;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable)))
		{
			Vector3 vector = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector2 = LuaScriptMgr.GetVector3(L, 2);
			bool b4 = Physics.Raycast(vector, vector2);
			LuaScriptMgr.Push(L, b4);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float), typeof(int)))
		{
			Ray ray4 = LuaScriptMgr.GetRay(L, 1);
			float distance2 = (float)LuaDLL.lua_tonumber(L, 2);
			int layerMask = (int)LuaDLL.lua_tonumber(L, 3);
			bool b5 = Physics.Raycast(ray4, distance2, layerMask);
			LuaScriptMgr.Push(L, b5);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable), typeof(float)))
		{
			Vector3 vector3 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector4 = LuaScriptMgr.GetVector3(L, 2);
			float distance3 = (float)LuaDLL.lua_tonumber(L, 3);
			bool b6 = Physics.Raycast(vector3, vector4, distance3);
			LuaScriptMgr.Push(L, b6);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), null, typeof(float)))
		{
			Ray ray5 = LuaScriptMgr.GetRay(L, 1);
			float distance4 = (float)LuaDLL.lua_tonumber(L, 3);
			RaycastHit hit2;
			bool b7 = Physics.Raycast(ray5, out hit2, distance4);
			LuaScriptMgr.Push(L, b7);
			LuaScriptMgr.Push(L, hit2);
			return 2;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable), null))
		{
			Vector3 vector5 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector6 = LuaScriptMgr.GetVector3(L, 2);
			RaycastHit hit3;
			bool b8 = Physics.Raycast(vector5, vector6, out hit3);
			LuaScriptMgr.Push(L, b8);
			LuaScriptMgr.Push(L, hit3);
			return 2;
		}
		if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable), typeof(float), typeof(int)))
		{
			Vector3 vector7 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector8 = LuaScriptMgr.GetVector3(L, 2);
			float distance5 = (float)LuaDLL.lua_tonumber(L, 3);
			int layerMask2 = (int)LuaDLL.lua_tonumber(L, 4);
			bool b9 = Physics.Raycast(vector7, vector8, distance5, layerMask2);
			LuaScriptMgr.Push(L, b9);
			return 1;
		}
		if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable), null, typeof(float)))
		{
			Vector3 vector9 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector10 = LuaScriptMgr.GetVector3(L, 2);
			float distance6 = (float)LuaDLL.lua_tonumber(L, 4);
			RaycastHit hit4;
			bool b10 = Physics.Raycast(vector9, vector10, out hit4, distance6);
			LuaScriptMgr.Push(L, b10);
			LuaScriptMgr.Push(L, hit4);
			return 2;
		}
		if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), null, typeof(float), typeof(int)))
		{
			Ray ray6 = LuaScriptMgr.GetRay(L, 1);
			float distance7 = (float)LuaDLL.lua_tonumber(L, 3);
			int layerMask3 = (int)LuaDLL.lua_tonumber(L, 4);
			RaycastHit hit5;
			bool b11 = Physics.Raycast(ray6, out hit5, distance7, layerMask3);
			LuaScriptMgr.Push(L, b11);
			LuaScriptMgr.Push(L, hit5);
			return 2;
		}
		if (num == 5)
		{
			Vector3 vector11 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector12 = LuaScriptMgr.GetVector3(L, 2);
			float distance8 = (float)LuaScriptMgr.GetNumber(L, 4);
			int layerMask4 = (int)LuaScriptMgr.GetNumber(L, 5);
			RaycastHit hit6;
			bool b12 = Physics.Raycast(vector11, vector12, out hit6, distance8, layerMask4);
			LuaScriptMgr.Push(L, b12);
			LuaScriptMgr.Push(L, hit6);
			return 2;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Physics.Raycast");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RaycastAll(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			Ray ray = LuaScriptMgr.GetRay(L, 1);
			RaycastHit[] o = Physics.RaycastAll(ray);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable)))
		{
			Vector3 vector = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector2 = LuaScriptMgr.GetVector3(L, 2);
			RaycastHit[] o2 = Physics.RaycastAll(vector, vector2);
			LuaScriptMgr.PushArray(L, o2);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float)))
		{
			Ray ray2 = LuaScriptMgr.GetRay(L, 1);
			float distance = (float)LuaDLL.lua_tonumber(L, 2);
			RaycastHit[] o3 = Physics.RaycastAll(ray2, distance);
			LuaScriptMgr.PushArray(L, o3);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable), typeof(float)))
		{
			Vector3 vector3 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector4 = LuaScriptMgr.GetVector3(L, 2);
			float distance2 = (float)LuaDLL.lua_tonumber(L, 3);
			RaycastHit[] o4 = Physics.RaycastAll(vector3, vector4, distance2);
			LuaScriptMgr.PushArray(L, o4);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float), typeof(int)))
		{
			Ray ray3 = LuaScriptMgr.GetRay(L, 1);
			float distance3 = (float)LuaDLL.lua_tonumber(L, 2);
			int layerMask = (int)LuaDLL.lua_tonumber(L, 3);
			RaycastHit[] o5 = Physics.RaycastAll(ray3, distance3, layerMask);
			LuaScriptMgr.PushArray(L, o5);
			return 1;
		}
		if (num == 4)
		{
			Vector3 vector5 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector6 = LuaScriptMgr.GetVector3(L, 2);
			float distance4 = (float)LuaScriptMgr.GetNumber(L, 3);
			int layermask = (int)LuaScriptMgr.GetNumber(L, 4);
			RaycastHit[] o6 = Physics.RaycastAll(vector5, vector6, distance4, layermask);
			LuaScriptMgr.PushArray(L, o6);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Physics.RaycastAll");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Linecast(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			Vector3 vector = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector2 = LuaScriptMgr.GetVector3(L, 2);
			bool b = Physics.Linecast(vector, vector2);
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable), null))
		{
			Vector3 vector3 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector4 = LuaScriptMgr.GetVector3(L, 2);
			RaycastHit hit;
			bool b2 = Physics.Linecast(vector3, vector4, out hit);
			LuaScriptMgr.Push(L, b2);
			LuaScriptMgr.Push(L, hit);
			return 2;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable), typeof(int)))
		{
			Vector3 vector5 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector6 = LuaScriptMgr.GetVector3(L, 2);
			int layerMask = (int)LuaDLL.lua_tonumber(L, 3);
			bool b3 = Physics.Linecast(vector5, vector6, layerMask);
			LuaScriptMgr.Push(L, b3);
			return 1;
		}
		if (num == 4)
		{
			Vector3 vector7 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector8 = LuaScriptMgr.GetVector3(L, 2);
			int layerMask2 = (int)LuaScriptMgr.GetNumber(L, 4);
			RaycastHit hit2;
			bool b4 = Physics.Linecast(vector7, vector8, out hit2, layerMask2);
			LuaScriptMgr.Push(L, b4);
			LuaScriptMgr.Push(L, hit2);
			return 2;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Physics.Linecast");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OverlapSphere(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			Vector3 vector = LuaScriptMgr.GetVector3(L, 1);
			float radius = (float)LuaScriptMgr.GetNumber(L, 2);
			Collider[] o = Physics.OverlapSphere(vector, radius);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		if (num == 3)
		{
			Vector3 vector2 = LuaScriptMgr.GetVector3(L, 1);
			float radius2 = (float)LuaScriptMgr.GetNumber(L, 2);
			int layerMask = (int)LuaScriptMgr.GetNumber(L, 3);
			Collider[] o2 = Physics.OverlapSphere(vector2, radius2, layerMask);
			LuaScriptMgr.PushArray(L, o2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Physics.OverlapSphere");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CapsuleCast(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 4)
		{
			Vector3 vector = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector2 = LuaScriptMgr.GetVector3(L, 2);
			float radius = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector3 vector3 = LuaScriptMgr.GetVector3(L, 4);
			bool b = Physics.CapsuleCast(vector, vector2, radius, vector3);
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable), typeof(float), typeof(LuaTable), null))
		{
			Vector3 vector4 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector5 = LuaScriptMgr.GetVector3(L, 2);
			float radius2 = (float)LuaDLL.lua_tonumber(L, 3);
			Vector3 vector6 = LuaScriptMgr.GetVector3(L, 4);
			RaycastHit hit;
			bool b2 = Physics.CapsuleCast(vector4, vector5, radius2, vector6, out hit);
			LuaScriptMgr.Push(L, b2);
			LuaScriptMgr.Push(L, hit);
			return 2;
		}
		if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable), typeof(float), typeof(LuaTable), typeof(float)))
		{
			Vector3 vector7 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector8 = LuaScriptMgr.GetVector3(L, 2);
			float radius3 = (float)LuaDLL.lua_tonumber(L, 3);
			Vector3 vector9 = LuaScriptMgr.GetVector3(L, 4);
			float distance = (float)LuaDLL.lua_tonumber(L, 5);
			bool b3 = Physics.CapsuleCast(vector7, vector8, radius3, vector9, distance);
			LuaScriptMgr.Push(L, b3);
			return 1;
		}
		if (num == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable), typeof(float), typeof(LuaTable), null, typeof(float)))
		{
			Vector3 vector10 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector11 = LuaScriptMgr.GetVector3(L, 2);
			float radius4 = (float)LuaDLL.lua_tonumber(L, 3);
			Vector3 vector12 = LuaScriptMgr.GetVector3(L, 4);
			float distance2 = (float)LuaDLL.lua_tonumber(L, 6);
			RaycastHit hit2;
			bool b4 = Physics.CapsuleCast(vector10, vector11, radius4, vector12, out hit2, distance2);
			LuaScriptMgr.Push(L, b4);
			LuaScriptMgr.Push(L, hit2);
			return 2;
		}
		if (num == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable), typeof(float), typeof(LuaTable), typeof(float), typeof(int)))
		{
			Vector3 vector13 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector14 = LuaScriptMgr.GetVector3(L, 2);
			float radius5 = (float)LuaDLL.lua_tonumber(L, 3);
			Vector3 vector15 = LuaScriptMgr.GetVector3(L, 4);
			float distance3 = (float)LuaDLL.lua_tonumber(L, 5);
			int layerMask = (int)LuaDLL.lua_tonumber(L, 6);
			bool b5 = Physics.CapsuleCast(vector13, vector14, radius5, vector15, distance3, layerMask);
			LuaScriptMgr.Push(L, b5);
			return 1;
		}
		if (num == 7)
		{
			Vector3 vector16 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector17 = LuaScriptMgr.GetVector3(L, 2);
			float radius6 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector3 vector18 = LuaScriptMgr.GetVector3(L, 4);
			float distance4 = (float)LuaScriptMgr.GetNumber(L, 6);
			int layerMask2 = (int)LuaScriptMgr.GetNumber(L, 7);
			RaycastHit hit3;
			bool b6 = Physics.CapsuleCast(vector16, vector17, radius6, vector18, out hit3, distance4, layerMask2);
			LuaScriptMgr.Push(L, b6);
			LuaScriptMgr.Push(L, hit3);
			return 2;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Physics.CapsuleCast");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SphereCast(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			Ray ray = LuaScriptMgr.GetRay(L, 1);
			float radius = (float)LuaScriptMgr.GetNumber(L, 2);
			bool b = Physics.SphereCast(ray, radius);
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float), typeof(float)))
		{
			Ray ray2 = LuaScriptMgr.GetRay(L, 1);
			float radius2 = (float)LuaDLL.lua_tonumber(L, 2);
			float distance = (float)LuaDLL.lua_tonumber(L, 3);
			bool b2 = Physics.SphereCast(ray2, radius2, distance);
			LuaScriptMgr.Push(L, b2);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float), null))
		{
			Ray ray3 = LuaScriptMgr.GetRay(L, 1);
			float radius3 = (float)LuaDLL.lua_tonumber(L, 2);
			RaycastHit hit;
			bool b3 = Physics.SphereCast(ray3, radius3, out hit);
			LuaScriptMgr.Push(L, b3);
			LuaScriptMgr.Push(L, hit);
			return 2;
		}
		if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float), typeof(float), typeof(int)))
		{
			Ray ray4 = LuaScriptMgr.GetRay(L, 1);
			float radius4 = (float)LuaDLL.lua_tonumber(L, 2);
			float distance2 = (float)LuaDLL.lua_tonumber(L, 3);
			int layerMask = (int)LuaDLL.lua_tonumber(L, 4);
			bool b4 = Physics.SphereCast(ray4, radius4, distance2, layerMask);
			LuaScriptMgr.Push(L, b4);
			return 1;
		}
		if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float), null, typeof(float)))
		{
			Ray ray5 = LuaScriptMgr.GetRay(L, 1);
			float radius5 = (float)LuaDLL.lua_tonumber(L, 2);
			float distance3 = (float)LuaDLL.lua_tonumber(L, 4);
			RaycastHit hit2;
			bool b5 = Physics.SphereCast(ray5, radius5, out hit2, distance3);
			LuaScriptMgr.Push(L, b5);
			LuaScriptMgr.Push(L, hit2);
			return 2;
		}
		if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float), typeof(LuaTable), null))
		{
			Vector3 vector = LuaScriptMgr.GetVector3(L, 1);
			float radius6 = (float)LuaDLL.lua_tonumber(L, 2);
			Vector3 vector2 = LuaScriptMgr.GetVector3(L, 3);
			RaycastHit hit3;
			bool b6 = Physics.SphereCast(vector, radius6, vector2, out hit3);
			LuaScriptMgr.Push(L, b6);
			LuaScriptMgr.Push(L, hit3);
			return 2;
		}
		if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float), null, typeof(float), typeof(int)))
		{
			Ray ray6 = LuaScriptMgr.GetRay(L, 1);
			float radius7 = (float)LuaDLL.lua_tonumber(L, 2);
			float distance4 = (float)LuaDLL.lua_tonumber(L, 4);
			int layerMask2 = (int)LuaDLL.lua_tonumber(L, 5);
			RaycastHit hit4;
			bool b7 = Physics.SphereCast(ray6, radius7, out hit4, distance4, layerMask2);
			LuaScriptMgr.Push(L, b7);
			LuaScriptMgr.Push(L, hit4);
			return 2;
		}
		if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float), typeof(LuaTable), null, typeof(float)))
		{
			Vector3 vector3 = LuaScriptMgr.GetVector3(L, 1);
			float radius8 = (float)LuaDLL.lua_tonumber(L, 2);
			Vector3 vector4 = LuaScriptMgr.GetVector3(L, 3);
			float distance5 = (float)LuaDLL.lua_tonumber(L, 5);
			RaycastHit hit5;
			bool b8 = Physics.SphereCast(vector3, radius8, vector4, out hit5, distance5);
			LuaScriptMgr.Push(L, b8);
			LuaScriptMgr.Push(L, hit5);
			return 2;
		}
		if (num == 6)
		{
			Vector3 vector5 = LuaScriptMgr.GetVector3(L, 1);
			float radius9 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector3 vector6 = LuaScriptMgr.GetVector3(L, 3);
			float distance6 = (float)LuaScriptMgr.GetNumber(L, 5);
			int layerMask3 = (int)LuaScriptMgr.GetNumber(L, 6);
			RaycastHit hit6;
			bool b9 = Physics.SphereCast(vector5, radius9, vector6, out hit6, distance6, layerMask3);
			LuaScriptMgr.Push(L, b9);
			LuaScriptMgr.Push(L, hit6);
			return 2;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Physics.SphereCast");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CapsuleCastAll(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 4)
		{
			Vector3 vector = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector2 = LuaScriptMgr.GetVector3(L, 2);
			float radius = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector3 vector3 = LuaScriptMgr.GetVector3(L, 4);
			RaycastHit[] o = Physics.CapsuleCastAll(vector, vector2, radius, vector3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		if (num == 5)
		{
			Vector3 vector4 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector5 = LuaScriptMgr.GetVector3(L, 2);
			float radius2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector3 vector6 = LuaScriptMgr.GetVector3(L, 4);
			float distance = (float)LuaScriptMgr.GetNumber(L, 5);
			RaycastHit[] o2 = Physics.CapsuleCastAll(vector4, vector5, radius2, vector6, distance);
			LuaScriptMgr.PushArray(L, o2);
			return 1;
		}
		if (num == 6)
		{
			Vector3 vector7 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector8 = LuaScriptMgr.GetVector3(L, 2);
			float radius3 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector3 vector9 = LuaScriptMgr.GetVector3(L, 4);
			float distance2 = (float)LuaScriptMgr.GetNumber(L, 5);
			int layermask = (int)LuaScriptMgr.GetNumber(L, 6);
			RaycastHit[] o3 = Physics.CapsuleCastAll(vector7, vector8, radius3, vector9, distance2, layermask);
			LuaScriptMgr.PushArray(L, o3);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Physics.CapsuleCastAll");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SphereCastAll(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			Ray ray = LuaScriptMgr.GetRay(L, 1);
			float radius = (float)LuaScriptMgr.GetNumber(L, 2);
			RaycastHit[] o = Physics.SphereCastAll(ray, radius);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float), typeof(float)))
		{
			Ray ray2 = LuaScriptMgr.GetRay(L, 1);
			float radius2 = (float)LuaDLL.lua_tonumber(L, 2);
			float distance = (float)LuaDLL.lua_tonumber(L, 3);
			RaycastHit[] o2 = Physics.SphereCastAll(ray2, radius2, distance);
			LuaScriptMgr.PushArray(L, o2);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float), typeof(LuaTable)))
		{
			Vector3 vector = LuaScriptMgr.GetVector3(L, 1);
			float radius3 = (float)LuaDLL.lua_tonumber(L, 2);
			Vector3 vector2 = LuaScriptMgr.GetVector3(L, 3);
			RaycastHit[] o3 = Physics.SphereCastAll(vector, radius3, vector2);
			LuaScriptMgr.PushArray(L, o3);
			return 1;
		}
		if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float), typeof(LuaTable), typeof(float)))
		{
			Vector3 vector3 = LuaScriptMgr.GetVector3(L, 1);
			float radius4 = (float)LuaDLL.lua_tonumber(L, 2);
			Vector3 vector4 = LuaScriptMgr.GetVector3(L, 3);
			float distance2 = (float)LuaDLL.lua_tonumber(L, 4);
			RaycastHit[] o4 = Physics.SphereCastAll(vector3, radius4, vector4, distance2);
			LuaScriptMgr.PushArray(L, o4);
			return 1;
		}
		if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(float), typeof(float), typeof(int)))
		{
			Ray ray3 = LuaScriptMgr.GetRay(L, 1);
			float radius5 = (float)LuaDLL.lua_tonumber(L, 2);
			float distance3 = (float)LuaDLL.lua_tonumber(L, 3);
			int layerMask = (int)LuaDLL.lua_tonumber(L, 4);
			RaycastHit[] o5 = Physics.SphereCastAll(ray3, radius5, distance3, layerMask);
			LuaScriptMgr.PushArray(L, o5);
			return 1;
		}
		if (num == 5)
		{
			Vector3 vector5 = LuaScriptMgr.GetVector3(L, 1);
			float radius6 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector3 vector6 = LuaScriptMgr.GetVector3(L, 3);
			float distance4 = (float)LuaScriptMgr.GetNumber(L, 4);
			int layerMask2 = (int)LuaScriptMgr.GetNumber(L, 5);
			RaycastHit[] o6 = Physics.SphereCastAll(vector5, radius6, vector6, distance4, layerMask2);
			LuaScriptMgr.PushArray(L, o6);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Physics.SphereCastAll");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckSphere(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			Vector3 vector = LuaScriptMgr.GetVector3(L, 1);
			float radius = (float)LuaScriptMgr.GetNumber(L, 2);
			bool b = Physics.CheckSphere(vector, radius);
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 3)
		{
			Vector3 vector2 = LuaScriptMgr.GetVector3(L, 1);
			float radius2 = (float)LuaScriptMgr.GetNumber(L, 2);
			int layerMask = (int)LuaScriptMgr.GetNumber(L, 3);
			bool b2 = Physics.CheckSphere(vector2, radius2, layerMask);
			LuaScriptMgr.Push(L, b2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Physics.CheckSphere");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckCapsule(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 3)
		{
			Vector3 vector = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector2 = LuaScriptMgr.GetVector3(L, 2);
			float radius = (float)LuaScriptMgr.GetNumber(L, 3);
			bool b = Physics.CheckCapsule(vector, vector2, radius);
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 4)
		{
			Vector3 vector3 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 vector4 = LuaScriptMgr.GetVector3(L, 2);
			float radius2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int layermask = (int)LuaScriptMgr.GetNumber(L, 4);
			bool b2 = Physics.CheckCapsule(vector3, vector4, radius2, layermask);
			LuaScriptMgr.Push(L, b2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Physics.CheckCapsule");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IgnoreCollision(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			Collider collider = (Collider)LuaScriptMgr.GetUnityObject(L, 1, typeof(Collider));
			Collider collider2 = (Collider)LuaScriptMgr.GetUnityObject(L, 2, typeof(Collider));
			Physics.IgnoreCollision(collider, collider2);
			return 0;
		}
		if (num == 3)
		{
			Collider collider3 = (Collider)LuaScriptMgr.GetUnityObject(L, 1, typeof(Collider));
			Collider collider4 = (Collider)LuaScriptMgr.GetUnityObject(L, 2, typeof(Collider));
			bool boolean = LuaScriptMgr.GetBoolean(L, 3);
			Physics.IgnoreCollision(collider3, collider4, boolean);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Physics.IgnoreCollision");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IgnoreLayerCollision(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			int layer = (int)LuaScriptMgr.GetNumber(L, 1);
			int layer2 = (int)LuaScriptMgr.GetNumber(L, 2);
			Physics.IgnoreLayerCollision(layer, layer2);
			return 0;
		}
		if (num == 3)
		{
			int layer3 = (int)LuaScriptMgr.GetNumber(L, 1);
			int layer4 = (int)LuaScriptMgr.GetNumber(L, 2);
			bool boolean = LuaScriptMgr.GetBoolean(L, 3);
			Physics.IgnoreLayerCollision(layer3, layer4, boolean);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Physics.IgnoreLayerCollision");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetIgnoreLayerCollision(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int layer = (int)LuaScriptMgr.GetNumber(L, 1);
		int layer2 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool ignoreLayerCollision = Physics.GetIgnoreLayerCollision(layer, layer2);
		LuaScriptMgr.Push(L, ignoreLayerCollision);
		return 1;
	}
}
