using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;

namespace com.tencent.pandora
{
	public class LuaSvr
	{
		public LuaState[] luaState;

		private static LuaSvrGameObject[] lgo;

		private int errorReported;

		public bool inited;

		private volatile int bindProgress;

		private int timerTick;

		public LuaSvr(int stateCount = 1)
		{
			this.luaState = new LuaState[stateCount];
			for (int i = 0; i < stateCount; i++)
			{
				this.luaState[i] = new LuaState();
			}
		}

		public void reset(Action<int> tick, Action complete, LuaSvrFlag flag = LuaSvrFlag.LSF_BASIC)
		{
			LuaTimer.delAll();
			for (int i = 0; i < this.luaState.Length; i++)
			{
				this.luaState[i].Close();
				this.luaState[i] = new LuaState();
			}
			this.init(tick, complete, flag);
		}

		private void doBind(object state)
		{
			IntPtr obj = (IntPtr)state;
			List<Action<IntPtr>> list = new List<Action<IntPtr>>();
			string assemblyString = "Assembly-CSharp";
			Assembly assembly = Assembly.Load(assemblyString);
			list.AddRange(this.getBindList(assembly, "com.tencent.pandora.BindUnity"));
			list.AddRange(this.getBindList(assembly, "com.tencent.pandora.BindUnityUI"));
			list.AddRange(this.getBindList(assembly, "com.tencent.pandora.BindCustom"));
			this.bindProgress = 2;
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				Action<IntPtr> action = list[i];
				action(obj);
				this.bindProgress = (int)((double)((float)i / (float)count) * 98.0) + 2;
			}
			this.bindProgress = 100;
		}

		private Action<IntPtr>[] getBindList(Assembly assembly, string ns)
		{
			Type type = assembly.GetType(ns);
			if (type != null)
			{
				return (Action<IntPtr>[])type.GetMethod("GetBindList").Invoke(null, null);
			}
			return new Action<IntPtr>[0];
		}

		[DebuggerHidden]
		public IEnumerator waitForBind(Action<int> tick, Action complete)
		{
			LuaSvr.<waitForBind>c__Iterator1 <waitForBind>c__Iterator = new LuaSvr.<waitForBind>c__Iterator1();
			<waitForBind>c__Iterator.tick = tick;
			<waitForBind>c__Iterator.complete = complete;
			<waitForBind>c__Iterator.<$>tick = tick;
			<waitForBind>c__Iterator.<$>complete = complete;
			<waitForBind>c__Iterator.<>f__this = this;
			return <waitForBind>c__Iterator;
		}

		private void doinit(IntPtr L, LuaSvrFlag flag)
		{
			LuaTimer.reg(L);
			LuaCoroutine.reg(L, LuaSvr.lgo[0]);
			Helper.reg(L);
			LuaValueType.reg(L);
			if ((flag & LuaSvrFlag.LSF_EXTLIB) != LuaSvrFlag.LSF_BASIC)
			{
				LuaDLL.luaS_openextlibs(L);
			}
			if ((flag & LuaSvrFlag.LSF_3RDDLL) != LuaSvrFlag.LSF_BASIC)
			{
				Lua3rdDLL.open(L);
			}
			for (int i = 0; i < this.luaState.Length; i++)
			{
				LuaSvr.lgo[i].state = this.luaState[i];
				LuaSvr.lgo[i].onUpdate = new Action<LuaState>(this.tick);
				LuaSvr.lgo[i].init();
			}
			this.inited = true;
		}

		private void checkTop(IntPtr L)
		{
			if (LuaDLL.pua_gettop(L) != this.errorReported)
			{
				SLogger.LogError("Some function not remove temp value from lua stack. You should fix it.");
				this.errorReported = LuaDLL.pua_gettop(L);
			}
		}

		public void init(Action<int> tick, Action complete, LuaSvrFlag flag = LuaSvrFlag.LSF_BASIC)
		{
			if (LuaSvr.lgo == null)
			{
				LuaSvr.lgo = new LuaSvrGameObject[this.luaState.Length];
				for (int i = 0; i < this.luaState.Length; i++)
				{
					GameObject gameObject = new GameObject("LuaStateProxy_" + i);
					LuaSvr.lgo[i] = gameObject.AddComponent<LuaSvrGameObject>();
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
				}
			}
			for (int j = 0; j < this.luaState.Length; j++)
			{
				IntPtr l = this.luaState[j].L;
				LuaObject.init(l);
				this.doBind(l);
				this.doinit(l, flag);
				complete();
				this.checkTop(l);
			}
		}

		public object start(string main, int state = 0)
		{
			if (main != null)
			{
				this.luaState[state].doFile(main);
				LuaFunction luaFunction = (LuaFunction)this.luaState[state]["main"];
				if (luaFunction != null)
				{
					return luaFunction.call();
				}
			}
			return null;
		}

		private void tick(LuaState ls)
		{
			if (!this.inited)
			{
				return;
			}
			if (LuaDLL.pua_gettop(ls.L) != this.errorReported)
			{
				this.errorReported = LuaDLL.pua_gettop(ls.L);
				SLogger.LogError(string.Format("Some function not remove temp value({0}) from lua stack. You should fix it.", LuaDLL.puaL_typename(ls.L, this.errorReported)));
			}
			ls.checkRef();
			if (this.timerTick++ % this.luaState.Length == 0)
			{
				LuaTimer.tick(Time.deltaTime);
			}
		}
	}
}
