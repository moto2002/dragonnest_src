using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_ParticleSystem : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem o = new ParticleSystem();
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
	public static int SetParticles(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			ParticleSystem.Particle[] particles;
			LuaObject.checkArray<ParticleSystem.Particle>(l, 2, out particles);
			int size;
			LuaObject.checkType(l, 3, out size);
			particleSystem.SetParticles(particles, size);
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
	public static int GetParticles(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			ParticleSystem.Particle[] particles;
			LuaObject.checkArray<ParticleSystem.Particle>(l, 2, out particles);
			int particles2 = particleSystem.GetParticles(particles);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particles2);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetCollisionEvents(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			GameObject go;
			LuaObject.checkType<GameObject>(l, 2, out go);
			ParticleSystem.CollisionEvent[] collisionEvents;
			LuaObject.checkArray<ParticleSystem.CollisionEvent>(l, 3, out collisionEvents);
			int collisionEvents2 = particleSystem.GetCollisionEvents(go, collisionEvents);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, collisionEvents2);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Simulate(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
				float t;
				LuaObject.checkType(l, 2, out t);
				particleSystem.Simulate(t);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 3)
			{
				ParticleSystem particleSystem2 = (ParticleSystem)LuaObject.checkSelf(l);
				float t2;
				LuaObject.checkType(l, 2, out t2);
				bool withChildren;
				LuaObject.checkType(l, 3, out withChildren);
				particleSystem2.Simulate(t2, withChildren);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 4)
			{
				ParticleSystem particleSystem3 = (ParticleSystem)LuaObject.checkSelf(l);
				float t3;
				LuaObject.checkType(l, 2, out t3);
				bool withChildren2;
				LuaObject.checkType(l, 3, out withChildren2);
				bool restart;
				LuaObject.checkType(l, 4, out restart);
				particleSystem3.Simulate(t3, withChildren2, restart);
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
	public static int Play(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
				particleSystem.Play();
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 2)
			{
				ParticleSystem particleSystem2 = (ParticleSystem)LuaObject.checkSelf(l);
				bool withChildren;
				LuaObject.checkType(l, 2, out withChildren);
				particleSystem2.Play(withChildren);
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
	public static int Stop(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
				particleSystem.Stop();
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 2)
			{
				ParticleSystem particleSystem2 = (ParticleSystem)LuaObject.checkSelf(l);
				bool withChildren;
				LuaObject.checkType(l, 2, out withChildren);
				particleSystem2.Stop(withChildren);
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
	public static int Pause(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
				particleSystem.Pause();
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 2)
			{
				ParticleSystem particleSystem2 = (ParticleSystem)LuaObject.checkSelf(l);
				bool withChildren;
				LuaObject.checkType(l, 2, out withChildren);
				particleSystem2.Pause(withChildren);
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
	public static int Clear(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
				particleSystem.Clear();
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 2)
			{
				ParticleSystem particleSystem2 = (ParticleSystem)LuaObject.checkSelf(l);
				bool withChildren;
				LuaObject.checkType(l, 2, out withChildren);
				particleSystem2.Clear(withChildren);
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
	public static int IsAlive(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
				bool b = particleSystem.IsAlive();
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b);
				result = 2;
			}
			else if (num == 2)
			{
				ParticleSystem particleSystem2 = (ParticleSystem)LuaObject.checkSelf(l);
				bool withChildren;
				LuaObject.checkType(l, 2, out withChildren);
				bool b2 = particleSystem2.IsAlive(withChildren);
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
	public static int Emit(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, num, 2, typeof(ParticleSystem.Particle)))
			{
				ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
				ParticleSystem.Particle particle;
				LuaObject.checkValueType<ParticleSystem.Particle>(l, 2, out particle);
				particleSystem.Emit(particle);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(int)))
			{
				ParticleSystem particleSystem2 = (ParticleSystem)LuaObject.checkSelf(l);
				int count;
				LuaObject.checkType(l, 2, out count);
				particleSystem2.Emit(count);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 6)
			{
				ParticleSystem particleSystem3 = (ParticleSystem)LuaObject.checkSelf(l);
				Vector3 position;
				LuaObject.checkType(l, 2, out position);
				Vector3 velocity;
				LuaObject.checkType(l, 3, out velocity);
				float size;
				LuaObject.checkType(l, 4, out size);
				float lifetime;
				LuaObject.checkType(l, 5, out lifetime);
				Color32 color;
				LuaObject.checkValueType<Color32>(l, 6, out color);
				particleSystem3.Emit(position, velocity, size, lifetime, color);
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
	public static int get_startDelay(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.startDelay);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_startDelay(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			float startDelay;
			LuaObject.checkType(l, 2, out startDelay);
			particleSystem.startDelay = startDelay;
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
	public static int get_isPlaying(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.isPlaying);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isStopped(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.isStopped);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isPaused(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.isPaused);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_loop(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.loop);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_loop(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			bool loop;
			LuaObject.checkType(l, 2, out loop);
			particleSystem.loop = loop;
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
	public static int get_playOnAwake(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.playOnAwake);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_playOnAwake(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			bool playOnAwake;
			LuaObject.checkType(l, 2, out playOnAwake);
			particleSystem.playOnAwake = playOnAwake;
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
	public static int get_time(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.time);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_time(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			float time;
			LuaObject.checkType(l, 2, out time);
			particleSystem.time = time;
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
	public static int get_duration(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.duration);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_playbackSpeed(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.playbackSpeed);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_playbackSpeed(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			float playbackSpeed;
			LuaObject.checkType(l, 2, out playbackSpeed);
			particleSystem.playbackSpeed = playbackSpeed;
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
	public static int get_particleCount(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.particleCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_safeCollisionEventSize(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.safeCollisionEventSize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_enableEmission(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.enableEmission);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_enableEmission(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			bool enableEmission;
			LuaObject.checkType(l, 2, out enableEmission);
			particleSystem.enableEmission = enableEmission;
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
	public static int get_emissionRate(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.emissionRate);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_emissionRate(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			float emissionRate;
			LuaObject.checkType(l, 2, out emissionRate);
			particleSystem.emissionRate = emissionRate;
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
	public static int get_startSpeed(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.startSpeed);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_startSpeed(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			float startSpeed;
			LuaObject.checkType(l, 2, out startSpeed);
			particleSystem.startSpeed = startSpeed;
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
	public static int get_startSize(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.startSize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_startSize(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			float startSize;
			LuaObject.checkType(l, 2, out startSize);
			particleSystem.startSize = startSize;
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
	public static int get_startColor(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.startColor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_startColor(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			Color startColor;
			LuaObject.checkType(l, 2, out startColor);
			particleSystem.startColor = startColor;
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
	public static int get_startRotation(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.startRotation);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_startRotation(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			float startRotation;
			LuaObject.checkType(l, 2, out startRotation);
			particleSystem.startRotation = startRotation;
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
	public static int get_startLifetime(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.startLifetime);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_startLifetime(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			float startLifetime;
			LuaObject.checkType(l, 2, out startLifetime);
			particleSystem.startLifetime = startLifetime;
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
	public static int get_gravityModifier(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.gravityModifier);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_gravityModifier(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			float gravityModifier;
			LuaObject.checkType(l, 2, out gravityModifier);
			particleSystem.gravityModifier = gravityModifier;
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
	public static int get_maxParticles(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.maxParticles);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_maxParticles(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			int maxParticles;
			LuaObject.checkType(l, 2, out maxParticles);
			particleSystem.maxParticles = maxParticles;
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
	public static int get_simulationSpace(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)particleSystem.simulationSpace);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_simulationSpace(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			ParticleSystemSimulationSpace simulationSpace;
			LuaObject.checkEnum<ParticleSystemSimulationSpace>(l, 2, out simulationSpace);
			particleSystem.simulationSpace = simulationSpace;
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
	public static int get_randomSeed(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, particleSystem.randomSeed);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_randomSeed(IntPtr l)
	{
		int result;
		try
		{
			ParticleSystem particleSystem = (ParticleSystem)LuaObject.checkSelf(l);
			uint randomSeed;
			LuaObject.checkType(l, 2, out randomSeed);
			particleSystem.randomSeed = randomSeed;
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
		LuaObject.getTypeTable(l, "UnityEngine.ParticleSystem");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_ParticleSystem.SetParticles));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_ParticleSystem.GetParticles));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_ParticleSystem.GetCollisionEvents));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_ParticleSystem.Simulate));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_ParticleSystem.Play));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_ParticleSystem.Stop));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_ParticleSystem.Pause));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_ParticleSystem.Clear));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_ParticleSystem.IsAlive));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_ParticleSystem.Emit));
		LuaObject.addMember(l, "startDelay", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_startDelay), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_startDelay), true);
		LuaObject.addMember(l, "isPlaying", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_isPlaying), null, true);
		LuaObject.addMember(l, "isStopped", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_isStopped), null, true);
		LuaObject.addMember(l, "isPaused", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_isPaused), null, true);
		LuaObject.addMember(l, "loop", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_loop), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_loop), true);
		LuaObject.addMember(l, "playOnAwake", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_playOnAwake), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_playOnAwake), true);
		LuaObject.addMember(l, "time", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_time), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_time), true);
		LuaObject.addMember(l, "duration", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_duration), null, true);
		LuaObject.addMember(l, "playbackSpeed", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_playbackSpeed), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_playbackSpeed), true);
		LuaObject.addMember(l, "particleCount", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_particleCount), null, true);
		LuaObject.addMember(l, "safeCollisionEventSize", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_safeCollisionEventSize), null, true);
		LuaObject.addMember(l, "enableEmission", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_enableEmission), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_enableEmission), true);
		LuaObject.addMember(l, "emissionRate", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_emissionRate), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_emissionRate), true);
		LuaObject.addMember(l, "startSpeed", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_startSpeed), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_startSpeed), true);
		LuaObject.addMember(l, "startSize", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_startSize), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_startSize), true);
		LuaObject.addMember(l, "startColor", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_startColor), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_startColor), true);
		LuaObject.addMember(l, "startRotation", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_startRotation), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_startRotation), true);
		LuaObject.addMember(l, "startLifetime", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_startLifetime), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_startLifetime), true);
		LuaObject.addMember(l, "gravityModifier", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_gravityModifier), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_gravityModifier), true);
		LuaObject.addMember(l, "maxParticles", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_maxParticles), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_maxParticles), true);
		LuaObject.addMember(l, "simulationSpace", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_simulationSpace), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_simulationSpace), true);
		LuaObject.addMember(l, "randomSeed", new LuaCSFunction(Lua_UnityEngine_ParticleSystem.get_randomSeed), new LuaCSFunction(Lua_UnityEngine_ParticleSystem.set_randomSeed), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_ParticleSystem.constructor), typeof(ParticleSystem), typeof(Component));
	}
}
