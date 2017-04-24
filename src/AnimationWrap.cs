using LuaInterface;
using System;
using System.Collections;
using UnityEngine;

public class AnimationWrap
{
	private static Type classType = typeof(Animation);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Stop", new LuaCSFunction(AnimationWrap.Stop)),
			new LuaMethod("Rewind", new LuaCSFunction(AnimationWrap.Rewind)),
			new LuaMethod("Sample", new LuaCSFunction(AnimationWrap.Sample)),
			new LuaMethod("IsPlaying", new LuaCSFunction(AnimationWrap.IsPlaying)),
			new LuaMethod("get_Item", new LuaCSFunction(AnimationWrap.get_Item)),
			new LuaMethod("Play", new LuaCSFunction(AnimationWrap.Play)),
			new LuaMethod("CrossFade", new LuaCSFunction(AnimationWrap.CrossFade)),
			new LuaMethod("Blend", new LuaCSFunction(AnimationWrap.Blend)),
			new LuaMethod("CrossFadeQueued", new LuaCSFunction(AnimationWrap.CrossFadeQueued)),
			new LuaMethod("PlayQueued", new LuaCSFunction(AnimationWrap.PlayQueued)),
			new LuaMethod("AddClip", new LuaCSFunction(AnimationWrap.AddClip)),
			new LuaMethod("RemoveClip", new LuaCSFunction(AnimationWrap.RemoveClip)),
			new LuaMethod("GetClipCount", new LuaCSFunction(AnimationWrap.GetClipCount)),
			new LuaMethod("SyncLayer", new LuaCSFunction(AnimationWrap.SyncLayer)),
			new LuaMethod("GetEnumerator", new LuaCSFunction(AnimationWrap.GetEnumerator)),
			new LuaMethod("GetClip", new LuaCSFunction(AnimationWrap.GetClip)),
			new LuaMethod("New", new LuaCSFunction(AnimationWrap._CreateAnimation)),
			new LuaMethod("GetClassType", new LuaCSFunction(AnimationWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(AnimationWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("clip", new LuaCSFunction(AnimationWrap.get_clip), new LuaCSFunction(AnimationWrap.set_clip)),
			new LuaField("playAutomatically", new LuaCSFunction(AnimationWrap.get_playAutomatically), new LuaCSFunction(AnimationWrap.set_playAutomatically)),
			new LuaField("wrapMode", new LuaCSFunction(AnimationWrap.get_wrapMode), new LuaCSFunction(AnimationWrap.set_wrapMode)),
			new LuaField("isPlaying", new LuaCSFunction(AnimationWrap.get_isPlaying), null),
			new LuaField("animatePhysics", new LuaCSFunction(AnimationWrap.get_animatePhysics), new LuaCSFunction(AnimationWrap.set_animatePhysics)),
			new LuaField("cullingType", new LuaCSFunction(AnimationWrap.get_cullingType), new LuaCSFunction(AnimationWrap.set_cullingType)),
			new LuaField("localBounds", new LuaCSFunction(AnimationWrap.get_localBounds), new LuaCSFunction(AnimationWrap.set_localBounds))
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Animation", typeof(Animation), regs, fields, typeof(Behaviour));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAnimation(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			Animation obj = new Animation();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Animation.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, AnimationWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clip(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Animation animation = (Animation)luaObject;
		if (animation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clip on a nil value");
			}
		}
		LuaScriptMgr.Push(L, animation.clip);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_playAutomatically(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Animation animation = (Animation)luaObject;
		if (animation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playAutomatically");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playAutomatically on a nil value");
			}
		}
		LuaScriptMgr.Push(L, animation.playAutomatically);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_wrapMode(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Animation animation = (Animation)luaObject;
		if (animation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name wrapMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index wrapMode on a nil value");
			}
		}
		LuaScriptMgr.Push(L, animation.wrapMode);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isPlaying(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Animation animation = (Animation)luaObject;
		if (animation == null)
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
		LuaScriptMgr.Push(L, animation.isPlaying);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_animatePhysics(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Animation animation = (Animation)luaObject;
		if (animation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animatePhysics");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animatePhysics on a nil value");
			}
		}
		LuaScriptMgr.Push(L, animation.animatePhysics);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cullingType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Animation animation = (Animation)luaObject;
		if (animation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cullingType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cullingType on a nil value");
			}
		}
		LuaScriptMgr.Push(L, animation.cullingType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localBounds(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Animation animation = (Animation)luaObject;
		if (animation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localBounds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localBounds on a nil value");
			}
		}
		LuaScriptMgr.Push(L, animation.localBounds);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clip(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Animation animation = (Animation)luaObject;
		if (animation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clip on a nil value");
			}
		}
		animation.clip = (AnimationClip)LuaScriptMgr.GetUnityObject(L, 3, typeof(AnimationClip));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_playAutomatically(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Animation animation = (Animation)luaObject;
		if (animation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playAutomatically");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playAutomatically on a nil value");
			}
		}
		animation.playAutomatically = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_wrapMode(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Animation animation = (Animation)luaObject;
		if (animation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name wrapMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index wrapMode on a nil value");
			}
		}
		animation.wrapMode = (WrapMode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(WrapMode)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_animatePhysics(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Animation animation = (Animation)luaObject;
		if (animation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animatePhysics");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animatePhysics on a nil value");
			}
		}
		animation.animatePhysics = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cullingType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Animation animation = (Animation)luaObject;
		if (animation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cullingType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cullingType on a nil value");
			}
		}
		animation.cullingType = (AnimationCullingType)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(AnimationCullingType)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_localBounds(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Animation animation = (Animation)luaObject;
		if (animation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localBounds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localBounds on a nil value");
			}
		}
		animation.localBounds = LuaScriptMgr.GetBounds(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Stop(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			animation.Stop();
			return 0;
		}
		if (num == 2)
		{
			Animation animation2 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString = LuaScriptMgr.GetLuaString(L, 2);
			animation2.Stop(luaString);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Animation.Stop");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Rewind(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			animation.Rewind();
			return 0;
		}
		if (num == 2)
		{
			Animation animation2 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString = LuaScriptMgr.GetLuaString(L, 2);
			animation2.Rewind(luaString);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Animation.Rewind");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Sample(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
		animation.Sample();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsPlaying(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		bool b = animation.IsPlaying(luaString);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		AnimationState obj = animation[luaString];
		LuaScriptMgr.Push(L, obj);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			bool b = animation.Play();
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Animation), typeof(string)))
		{
			Animation animation2 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string @string = LuaScriptMgr.GetString(L, 2);
			bool b2 = animation2.Play(@string);
			LuaScriptMgr.Push(L, b2);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Animation), typeof(PlayMode)))
		{
			Animation animation3 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			PlayMode mode = (PlayMode)((int)LuaScriptMgr.GetLuaObject(L, 2));
			bool b3 = animation3.Play(mode);
			LuaScriptMgr.Push(L, b3);
			return 1;
		}
		if (num == 3)
		{
			Animation animation4 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString = LuaScriptMgr.GetLuaString(L, 2);
			PlayMode mode2 = (PlayMode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(PlayMode)));
			bool b4 = animation4.Play(luaString, mode2);
			LuaScriptMgr.Push(L, b4);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Animation.Play");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CrossFade(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString = LuaScriptMgr.GetLuaString(L, 2);
			animation.CrossFade(luaString);
			return 0;
		}
		if (num == 3)
		{
			Animation animation2 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
			float fadeLength = (float)LuaScriptMgr.GetNumber(L, 3);
			animation2.CrossFade(luaString2, fadeLength);
			return 0;
		}
		if (num == 4)
		{
			Animation animation3 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString3 = LuaScriptMgr.GetLuaString(L, 2);
			float fadeLength2 = (float)LuaScriptMgr.GetNumber(L, 3);
			PlayMode mode = (PlayMode)((int)LuaScriptMgr.GetNetObject(L, 4, typeof(PlayMode)));
			animation3.CrossFade(luaString3, fadeLength2, mode);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Animation.CrossFade");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Blend(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString = LuaScriptMgr.GetLuaString(L, 2);
			animation.Blend(luaString);
			return 0;
		}
		if (num == 3)
		{
			Animation animation2 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
			float targetWeight = (float)LuaScriptMgr.GetNumber(L, 3);
			animation2.Blend(luaString2, targetWeight);
			return 0;
		}
		if (num == 4)
		{
			Animation animation3 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString3 = LuaScriptMgr.GetLuaString(L, 2);
			float targetWeight2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float fadeLength = (float)LuaScriptMgr.GetNumber(L, 4);
			animation3.Blend(luaString3, targetWeight2, fadeLength);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Animation.Blend");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CrossFadeQueued(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString = LuaScriptMgr.GetLuaString(L, 2);
			AnimationState obj = animation.CrossFadeQueued(luaString);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		if (num == 3)
		{
			Animation animation2 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
			float fadeLength = (float)LuaScriptMgr.GetNumber(L, 3);
			AnimationState obj2 = animation2.CrossFadeQueued(luaString2, fadeLength);
			LuaScriptMgr.Push(L, obj2);
			return 1;
		}
		if (num == 4)
		{
			Animation animation3 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString3 = LuaScriptMgr.GetLuaString(L, 2);
			float fadeLength2 = (float)LuaScriptMgr.GetNumber(L, 3);
			QueueMode queue = (QueueMode)((int)LuaScriptMgr.GetNetObject(L, 4, typeof(QueueMode)));
			AnimationState obj3 = animation3.CrossFadeQueued(luaString3, fadeLength2, queue);
			LuaScriptMgr.Push(L, obj3);
			return 1;
		}
		if (num == 5)
		{
			Animation animation4 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString4 = LuaScriptMgr.GetLuaString(L, 2);
			float fadeLength3 = (float)LuaScriptMgr.GetNumber(L, 3);
			QueueMode queue2 = (QueueMode)((int)LuaScriptMgr.GetNetObject(L, 4, typeof(QueueMode)));
			PlayMode mode = (PlayMode)((int)LuaScriptMgr.GetNetObject(L, 5, typeof(PlayMode)));
			AnimationState obj4 = animation4.CrossFadeQueued(luaString4, fadeLength3, queue2, mode);
			LuaScriptMgr.Push(L, obj4);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Animation.CrossFadeQueued");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayQueued(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString = LuaScriptMgr.GetLuaString(L, 2);
			AnimationState obj = animation.PlayQueued(luaString);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		if (num == 3)
		{
			Animation animation2 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
			QueueMode queue = (QueueMode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(QueueMode)));
			AnimationState obj2 = animation2.PlayQueued(luaString2, queue);
			LuaScriptMgr.Push(L, obj2);
			return 1;
		}
		if (num == 4)
		{
			Animation animation3 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string luaString3 = LuaScriptMgr.GetLuaString(L, 2);
			QueueMode queue2 = (QueueMode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(QueueMode)));
			PlayMode mode = (PlayMode)((int)LuaScriptMgr.GetNetObject(L, 4, typeof(PlayMode)));
			AnimationState obj3 = animation3.PlayQueued(luaString3, queue2, mode);
			LuaScriptMgr.Push(L, obj3);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Animation.PlayQueued");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddClip(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 3)
		{
			Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			AnimationClip clip = (AnimationClip)LuaScriptMgr.GetUnityObject(L, 2, typeof(AnimationClip));
			string luaString = LuaScriptMgr.GetLuaString(L, 3);
			animation.AddClip(clip, luaString);
			return 0;
		}
		if (num == 5)
		{
			Animation animation2 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			AnimationClip clip2 = (AnimationClip)LuaScriptMgr.GetUnityObject(L, 2, typeof(AnimationClip));
			string luaString2 = LuaScriptMgr.GetLuaString(L, 3);
			int firstFrame = (int)LuaScriptMgr.GetNumber(L, 4);
			int lastFrame = (int)LuaScriptMgr.GetNumber(L, 5);
			animation2.AddClip(clip2, luaString2, firstFrame, lastFrame);
			return 0;
		}
		if (num == 6)
		{
			Animation animation3 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			AnimationClip clip3 = (AnimationClip)LuaScriptMgr.GetUnityObject(L, 2, typeof(AnimationClip));
			string luaString3 = LuaScriptMgr.GetLuaString(L, 3);
			int firstFrame2 = (int)LuaScriptMgr.GetNumber(L, 4);
			int lastFrame2 = (int)LuaScriptMgr.GetNumber(L, 5);
			bool boolean = LuaScriptMgr.GetBoolean(L, 6);
			animation3.AddClip(clip3, luaString3, firstFrame2, lastFrame2, boolean);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Animation.AddClip");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveClip(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Animation), typeof(string)))
		{
			Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			string @string = LuaScriptMgr.GetString(L, 2);
			animation.RemoveClip(@string);
			return 0;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Animation), typeof(AnimationClip)))
		{
			Animation animation2 = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
			AnimationClip clip = (AnimationClip)LuaScriptMgr.GetLuaObject(L, 2);
			animation2.RemoveClip(clip);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Animation.RemoveClip");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClipCount(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
		int clipCount = animation.GetClipCount();
		LuaScriptMgr.Push(L, clipCount);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SyncLayer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
		int layer = (int)LuaScriptMgr.GetNumber(L, 2);
		animation.SyncLayer(layer);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetEnumerator(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
		IEnumerator enumerator = animation.GetEnumerator();
		LuaScriptMgr.Push(L, enumerator);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClip(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Animation animation = (Animation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		AnimationClip clip = animation.GetClip(luaString);
		LuaScriptMgr.Push(L, clip);
		return 1;
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
