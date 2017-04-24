using LuaInterface;
using System;
using UnityEngine;

public class ParticleSystemWrap
{
	private static Type classType = typeof(ParticleSystem);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SetParticles", new LuaCSFunction(ParticleSystemWrap.SetParticles)),
			new LuaMethod("GetParticles", new LuaCSFunction(ParticleSystemWrap.GetParticles)),
			new LuaMethod("GetCollisionEvents", new LuaCSFunction(ParticleSystemWrap.GetCollisionEvents)),
			new LuaMethod("Simulate", new LuaCSFunction(ParticleSystemWrap.Simulate)),
			new LuaMethod("Play", new LuaCSFunction(ParticleSystemWrap.Play)),
			new LuaMethod("Stop", new LuaCSFunction(ParticleSystemWrap.Stop)),
			new LuaMethod("Pause", new LuaCSFunction(ParticleSystemWrap.Pause)),
			new LuaMethod("Clear", new LuaCSFunction(ParticleSystemWrap.Clear)),
			new LuaMethod("IsAlive", new LuaCSFunction(ParticleSystemWrap.IsAlive)),
			new LuaMethod("Emit", new LuaCSFunction(ParticleSystemWrap.Emit)),
			new LuaMethod("New", new LuaCSFunction(ParticleSystemWrap._CreateParticleSystem)),
			new LuaMethod("GetClassType", new LuaCSFunction(ParticleSystemWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(ParticleSystemWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("startDelay", new LuaCSFunction(ParticleSystemWrap.get_startDelay), new LuaCSFunction(ParticleSystemWrap.set_startDelay)),
			new LuaField("isPlaying", new LuaCSFunction(ParticleSystemWrap.get_isPlaying), null),
			new LuaField("isStopped", new LuaCSFunction(ParticleSystemWrap.get_isStopped), null),
			new LuaField("isPaused", new LuaCSFunction(ParticleSystemWrap.get_isPaused), null),
			new LuaField("loop", new LuaCSFunction(ParticleSystemWrap.get_loop), new LuaCSFunction(ParticleSystemWrap.set_loop)),
			new LuaField("playOnAwake", new LuaCSFunction(ParticleSystemWrap.get_playOnAwake), new LuaCSFunction(ParticleSystemWrap.set_playOnAwake)),
			new LuaField("time", new LuaCSFunction(ParticleSystemWrap.get_time), new LuaCSFunction(ParticleSystemWrap.set_time)),
			new LuaField("duration", new LuaCSFunction(ParticleSystemWrap.get_duration), null),
			new LuaField("playbackSpeed", new LuaCSFunction(ParticleSystemWrap.get_playbackSpeed), new LuaCSFunction(ParticleSystemWrap.set_playbackSpeed)),
			new LuaField("particleCount", new LuaCSFunction(ParticleSystemWrap.get_particleCount), null),
			new LuaField("safeCollisionEventSize", new LuaCSFunction(ParticleSystemWrap.get_safeCollisionEventSize), null),
			new LuaField("enableEmission", new LuaCSFunction(ParticleSystemWrap.get_enableEmission), new LuaCSFunction(ParticleSystemWrap.set_enableEmission)),
			new LuaField("emissionRate", new LuaCSFunction(ParticleSystemWrap.get_emissionRate), new LuaCSFunction(ParticleSystemWrap.set_emissionRate)),
			new LuaField("startSpeed", new LuaCSFunction(ParticleSystemWrap.get_startSpeed), new LuaCSFunction(ParticleSystemWrap.set_startSpeed)),
			new LuaField("startSize", new LuaCSFunction(ParticleSystemWrap.get_startSize), new LuaCSFunction(ParticleSystemWrap.set_startSize)),
			new LuaField("startColor", new LuaCSFunction(ParticleSystemWrap.get_startColor), new LuaCSFunction(ParticleSystemWrap.set_startColor)),
			new LuaField("startRotation", new LuaCSFunction(ParticleSystemWrap.get_startRotation), new LuaCSFunction(ParticleSystemWrap.set_startRotation)),
			new LuaField("startLifetime", new LuaCSFunction(ParticleSystemWrap.get_startLifetime), new LuaCSFunction(ParticleSystemWrap.set_startLifetime)),
			new LuaField("gravityModifier", new LuaCSFunction(ParticleSystemWrap.get_gravityModifier), new LuaCSFunction(ParticleSystemWrap.set_gravityModifier)),
			new LuaField("maxParticles", new LuaCSFunction(ParticleSystemWrap.get_maxParticles), new LuaCSFunction(ParticleSystemWrap.set_maxParticles)),
			new LuaField("simulationSpace", new LuaCSFunction(ParticleSystemWrap.get_simulationSpace), new LuaCSFunction(ParticleSystemWrap.set_simulationSpace)),
			new LuaField("randomSeed", new LuaCSFunction(ParticleSystemWrap.get_randomSeed), new LuaCSFunction(ParticleSystemWrap.set_randomSeed))
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ParticleSystem", typeof(ParticleSystem), regs, fields, typeof(Component));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateParticleSystem(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			ParticleSystem obj = new ParticleSystem();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, ParticleSystemWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_startDelay(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startDelay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startDelay on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.startDelay);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isPlaying(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPlaying");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPlaying on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.isPlaying);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isStopped(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isStopped");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isStopped on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.isStopped);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isPaused(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPaused");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPaused on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.isPaused);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_loop(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name loop");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index loop on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.loop);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_playOnAwake(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playOnAwake");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playOnAwake on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.playOnAwake);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_time(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index time on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.time);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_duration(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name duration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index duration on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.duration);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_playbackSpeed(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playbackSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playbackSpeed on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.playbackSpeed);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_particleCount(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name particleCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index particleCount on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.particleCount);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_safeCollisionEventSize(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name safeCollisionEventSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index safeCollisionEventSize on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.safeCollisionEventSize);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_enableEmission(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enableEmission");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enableEmission on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.enableEmission);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_emissionRate(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name emissionRate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index emissionRate on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.emissionRate);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_startSpeed(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startSpeed on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.startSpeed);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_startSize(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startSize on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.startSize);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_startColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startColor on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.startColor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_startRotation(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startRotation on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.startRotation);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_startLifetime(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startLifetime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startLifetime on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.startLifetime);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gravityModifier(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gravityModifier");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gravityModifier on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.gravityModifier);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxParticles(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxParticles");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxParticles on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.maxParticles);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_simulationSpace(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name simulationSpace");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index simulationSpace on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.simulationSpace);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_randomSeed(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name randomSeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index randomSeed on a nil value");
			}
		}
		LuaScriptMgr.Push(L, particleSystem.randomSeed);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_startDelay(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startDelay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startDelay on a nil value");
			}
		}
		particleSystem.startDelay = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_loop(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name loop");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index loop on a nil value");
			}
		}
		particleSystem.loop = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_playOnAwake(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playOnAwake");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playOnAwake on a nil value");
			}
		}
		particleSystem.playOnAwake = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_time(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index time on a nil value");
			}
		}
		particleSystem.time = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_playbackSpeed(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playbackSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playbackSpeed on a nil value");
			}
		}
		particleSystem.playbackSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_enableEmission(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enableEmission");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enableEmission on a nil value");
			}
		}
		particleSystem.enableEmission = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_emissionRate(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name emissionRate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index emissionRate on a nil value");
			}
		}
		particleSystem.emissionRate = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_startSpeed(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startSpeed on a nil value");
			}
		}
		particleSystem.startSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_startSize(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startSize on a nil value");
			}
		}
		particleSystem.startSize = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_startColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startColor on a nil value");
			}
		}
		particleSystem.startColor = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_startRotation(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startRotation on a nil value");
			}
		}
		particleSystem.startRotation = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_startLifetime(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startLifetime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startLifetime on a nil value");
			}
		}
		particleSystem.startLifetime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_gravityModifier(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gravityModifier");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gravityModifier on a nil value");
			}
		}
		particleSystem.gravityModifier = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxParticles(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxParticles");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxParticles on a nil value");
			}
		}
		particleSystem.maxParticles = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_simulationSpace(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name simulationSpace");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index simulationSpace on a nil value");
			}
		}
		particleSystem.simulationSpace = (ParticleSystemSimulationSpace)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(ParticleSystemSimulationSpace)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_randomSeed(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		ParticleSystem particleSystem = (ParticleSystem)luaObject;
		if (particleSystem == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name randomSeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index randomSeed on a nil value");
			}
		}
		particleSystem.randomSeed = (uint)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetParticles(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ParticleSystem particleSystem = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
		ParticleSystem.Particle[] arrayObject = LuaScriptMgr.GetArrayObject<ParticleSystem.Particle>(L, 2);
		int size = (int)LuaScriptMgr.GetNumber(L, 3);
		particleSystem.SetParticles(arrayObject, size);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetParticles(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ParticleSystem particleSystem = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
		ParticleSystem.Particle[] arrayObject = LuaScriptMgr.GetArrayObject<ParticleSystem.Particle>(L, 2);
		int particles = particleSystem.GetParticles(arrayObject);
		LuaScriptMgr.Push(L, particles);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCollisionEvents(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ParticleSystem particleSystem = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		ParticleSystem.CollisionEvent[] arrayObject = LuaScriptMgr.GetArrayObject<ParticleSystem.CollisionEvent>(L, 3);
		int collisionEvents = particleSystem.GetCollisionEvents(go, arrayObject);
		LuaScriptMgr.Push(L, collisionEvents);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Simulate(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			float t = (float)LuaScriptMgr.GetNumber(L, 2);
			particleSystem.Simulate(t);
			return 0;
		}
		if (num == 3)
		{
			ParticleSystem particleSystem2 = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			float t2 = (float)LuaScriptMgr.GetNumber(L, 2);
			bool boolean = LuaScriptMgr.GetBoolean(L, 3);
			particleSystem2.Simulate(t2, boolean);
			return 0;
		}
		if (num == 4)
		{
			ParticleSystem particleSystem3 = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			float t3 = (float)LuaScriptMgr.GetNumber(L, 2);
			bool boolean2 = LuaScriptMgr.GetBoolean(L, 3);
			bool boolean3 = LuaScriptMgr.GetBoolean(L, 4);
			particleSystem3.Simulate(t3, boolean2, boolean3);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Simulate");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			particleSystem.Play();
			return 0;
		}
		if (num == 2)
		{
			ParticleSystem particleSystem2 = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			bool boolean = LuaScriptMgr.GetBoolean(L, 2);
			particleSystem2.Play(boolean);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Play");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Stop(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			particleSystem.Stop();
			return 0;
		}
		if (num == 2)
		{
			ParticleSystem particleSystem2 = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			bool boolean = LuaScriptMgr.GetBoolean(L, 2);
			particleSystem2.Stop(boolean);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Stop");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Pause(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			particleSystem.Pause();
			return 0;
		}
		if (num == 2)
		{
			ParticleSystem particleSystem2 = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			bool boolean = LuaScriptMgr.GetBoolean(L, 2);
			particleSystem2.Pause(boolean);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Pause");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			particleSystem.Clear();
			return 0;
		}
		if (num == 2)
		{
			ParticleSystem particleSystem2 = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			bool boolean = LuaScriptMgr.GetBoolean(L, 2);
			particleSystem2.Clear(boolean);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Clear");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsAlive(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			bool b = particleSystem.IsAlive();
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 2)
		{
			ParticleSystem particleSystem2 = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			bool boolean = LuaScriptMgr.GetBoolean(L, 2);
			bool b2 = particleSystem2.IsAlive(boolean);
			LuaScriptMgr.Push(L, b2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.IsAlive");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Emit(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(ParticleSystem), typeof(ParticleSystem.Particle)))
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			ParticleSystem.Particle particle = (ParticleSystem.Particle)LuaScriptMgr.GetLuaObject(L, 2);
			particleSystem.Emit(particle);
			return 0;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(ParticleSystem), typeof(int)))
		{
			ParticleSystem particleSystem2 = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			int count = (int)LuaDLL.lua_tonumber(L, 2);
			particleSystem2.Emit(count);
			return 0;
		}
		if (num == 6)
		{
			ParticleSystem particleSystem3 = (ParticleSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem");
			Vector3 vector = LuaScriptMgr.GetVector3(L, 2);
			Vector3 vector2 = LuaScriptMgr.GetVector3(L, 3);
			float size = (float)LuaScriptMgr.GetNumber(L, 4);
			float lifetime = (float)LuaScriptMgr.GetNumber(L, 5);
			Color32 color = (Color32)LuaScriptMgr.GetNetObject(L, 6, typeof(Color32));
			particleSystem3.Emit(vector, vector2, size, lifetime, color);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Emit");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UnityEngine.Object x = LuaScriptMgr.GetLuaObject(L, 1) as UnityEngine.Object;
		UnityEngine.Object y = LuaScriptMgr.GetLuaObject(L, 2) as UnityEngine.Object;
		bool b = x == y;
		LuaScriptMgr.Push(L, b);
		return 1;
	}
}
