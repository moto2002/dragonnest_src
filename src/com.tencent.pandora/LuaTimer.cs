using System;
using System.Collections.Generic;

namespace com.tencent.pandora
{
	public class LuaTimer : LuaObject
	{
		private class Timer
		{
			internal int sn;

			internal int cycle;

			internal int deadline;

			internal Func<int, bool> handler;

			internal bool delete;

			internal LinkedList<LuaTimer.Timer> container;
		}

		private class Wheel
		{
			internal static int dial_scale = 256;

			internal int head;

			internal LinkedList<LuaTimer.Timer>[] vecDial;

			internal int dialSize;

			internal int timeRange;

			internal LuaTimer.Wheel nextWheel;

			internal Wheel(int dialSize)
			{
				this.dialSize = dialSize;
				this.timeRange = dialSize * LuaTimer.Wheel.dial_scale;
				this.head = 0;
				this.vecDial = new LinkedList<LuaTimer.Timer>[LuaTimer.Wheel.dial_scale];
				for (int i = 0; i < LuaTimer.Wheel.dial_scale; i++)
				{
					this.vecDial[i] = new LinkedList<LuaTimer.Timer>();
				}
			}

			internal LinkedList<LuaTimer.Timer> nextDial()
			{
				return this.vecDial[this.head++];
			}

			internal void add(int delay, LuaTimer.Timer tm)
			{
				int num = (this.head + (delay - (this.dialSize - LuaTimer.jiffies_msec)) / this.dialSize) % LuaTimer.Wheel.dial_scale;
				LinkedList<LuaTimer.Timer> linkedList = this.vecDial[num];
				linkedList.AddLast(LuaTimer.GetTimerNodeFormPool(tm));
				tm.container = linkedList;
			}
		}

		private static int nextSn = 0;

		private static int jiffies_msec = 20;

		private static float jiffies_sec = (float)LuaTimer.jiffies_msec * 0.001f;

		private static LuaTimer.Wheel[] wheels;

		private static float pileSecs;

		private static float nowTime;

		private static Dictionary<int, LuaTimer.Timer> mapSnTimer;

		private static LinkedList<LuaTimer.Timer> executeTimers;

		private static Queue<LinkedListNode<LuaTimer.Timer>> TIMER_NODE_POOL = new Queue<LinkedListNode<LuaTimer.Timer>>(64);

		private static int createdCount = 0;

		private static int recycledCount = 0;

		private static int intpow(int n, int m)
		{
			int num = 1;
			for (int i = 0; i < m; i++)
			{
				num *= n;
			}
			return num;
		}

		private static void innerAdd(int deadline, LuaTimer.Timer tm)
		{
			tm.deadline = deadline;
			int num = Math.Max(0, deadline - LuaTimer.now());
			LuaTimer.Wheel wheel = LuaTimer.wheels[LuaTimer.wheels.Length - 1];
			for (int i = 0; i < LuaTimer.wheels.Length; i++)
			{
				LuaTimer.Wheel wheel2 = LuaTimer.wheels[i];
				if (num < wheel2.timeRange)
				{
					wheel = wheel2;
					break;
				}
			}
			wheel.add(num, tm);
		}

		private static void innerDel(LuaTimer.Timer tm)
		{
			LuaTimer.innerDel(tm, true);
		}

		private static void innerDel(LuaTimer.Timer tm, bool removeFromMap)
		{
			tm.delete = true;
			if (tm.container != null)
			{
				LinkedListNode<LuaTimer.Timer> linkedListNode = tm.container.Find(tm);
				if (linkedListNode != null)
				{
					tm.container.Remove(linkedListNode);
					LuaTimer.RecycleTimerNodeToPool(linkedListNode);
				}
				tm.container = null;
			}
			if (removeFromMap)
			{
				LuaTimer.mapSnTimer.Remove(tm.sn);
			}
		}

		private static int now()
		{
			return (int)(LuaTimer.nowTime * 1000f);
		}

		internal static void tick(float deltaTime)
		{
			LuaTimer.nowTime += deltaTime;
			LuaTimer.pileSecs += deltaTime;
			int num = 0;
			while (LuaTimer.pileSecs >= LuaTimer.jiffies_sec)
			{
				LuaTimer.pileSecs -= LuaTimer.jiffies_sec;
				num++;
			}
			for (int i = 0; i < num; i++)
			{
				LinkedList<LuaTimer.Timer> linkedList = LuaTimer.wheels[0].nextDial();
				LinkedListNode<LuaTimer.Timer> linkedListNode = linkedList.First;
				for (int j = 0; j < linkedList.Count; j++)
				{
					LuaTimer.Timer value = linkedListNode.Value;
					LuaTimer.executeTimers.AddLast(LuaTimer.GetTimerNodeFormPool(value));
					linkedListNode = linkedListNode.Next;
				}
				while (linkedList.Count > 0)
				{
					LinkedListNode<LuaTimer.Timer> first = linkedList.First;
					linkedList.RemoveFirst();
					LuaTimer.RecycleTimerNodeToPool(first);
				}
				for (int k = 0; k < LuaTimer.wheels.Length; k++)
				{
					LuaTimer.Wheel wheel = LuaTimer.wheels[k];
					if (wheel.head != LuaTimer.Wheel.dial_scale)
					{
						break;
					}
					wheel.head = 0;
					if (wheel.nextWheel != null)
					{
						LinkedList<LuaTimer.Timer> linkedList2 = wheel.nextWheel.nextDial();
						LinkedListNode<LuaTimer.Timer> linkedListNode2 = linkedList2.First;
						for (int l = 0; l < linkedList2.Count; l++)
						{
							LuaTimer.Timer value2 = linkedListNode2.Value;
							if (value2.delete)
							{
								LuaTimer.mapSnTimer.Remove(value2.sn);
							}
							else
							{
								LuaTimer.innerAdd(value2.deadline, value2);
							}
							linkedListNode2 = linkedListNode2.Next;
						}
						while (linkedList2.Count > 0)
						{
							LinkedListNode<LuaTimer.Timer> first2 = linkedList2.First;
							linkedList2.RemoveFirst();
							LuaTimer.RecycleTimerNodeToPool(first2);
						}
					}
				}
			}
			while (LuaTimer.executeTimers.Count > 0)
			{
				LinkedListNode<LuaTimer.Timer> first3 = LuaTimer.executeTimers.First;
				LuaTimer.Timer value3 = first3.Value;
				LuaTimer.RecycleTimerNodeToPool(first3);
				LuaTimer.executeTimers.RemoveFirst();
				if (!value3.delete && value3.handler(value3.sn) && value3.cycle > 0)
				{
					LuaTimer.innerAdd(LuaTimer.now() + value3.cycle, value3);
				}
				else
				{
					LuaTimer.mapSnTimer.Remove(value3.sn);
				}
			}
		}

		private static void init()
		{
			int num = 2;
			LuaTimer.wheels = new LuaTimer.Wheel[num];
			for (int i = 0; i < num; i++)
			{
				LuaTimer.wheels[i] = new LuaTimer.Wheel(LuaTimer.jiffies_msec * LuaTimer.intpow(LuaTimer.Wheel.dial_scale, i));
				if (i > 0)
				{
					LuaTimer.wheels[i - 1].nextWheel = LuaTimer.wheels[i];
				}
			}
			LuaTimer.mapSnTimer = new Dictionary<int, LuaTimer.Timer>();
			LuaTimer.executeTimers = new LinkedList<LuaTimer.Timer>();
		}

		private static int fetchSn()
		{
			return ++LuaTimer.nextSn;
		}

		internal static int add(int delay, Action<int> handler)
		{
			return LuaTimer.add(delay, 0, delegate(int sn)
			{
				handler(sn);
				return false;
			});
		}

		internal static int add(int delay, int cycle, Func<int, bool> handler)
		{
			LuaTimer.Timer timer = new LuaTimer.Timer();
			timer.sn = LuaTimer.fetchSn();
			timer.cycle = cycle;
			timer.handler = handler;
			timer.delete = false;
			LuaTimer.mapSnTimer[timer.sn] = timer;
			LuaTimer.innerAdd(LuaTimer.now() + delay, timer);
			return timer.sn;
		}

		internal static void del(int sn)
		{
			LuaTimer.Timer tm;
			if (LuaTimer.mapSnTimer.TryGetValue(sn, out tm))
			{
				LuaTimer.innerDel(tm);
			}
		}

		internal static void delAll()
		{
			if (LuaTimer.mapSnTimer != null)
			{
				foreach (KeyValuePair<int, LuaTimer.Timer> current in LuaTimer.mapSnTimer)
				{
					LuaTimer.innerDel(current.Value, false);
				}
				LuaTimer.mapSnTimer.Clear();
			}
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int Delete(IntPtr l)
		{
			int result;
			try
			{
				int sn;
				LuaObject.checkType(l, 1, out sn);
				LuaTimer.del(sn);
				result = LuaObject.ok(l);
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int Add(IntPtr l)
		{
			int result;
			try
			{
				int num = LuaDLL.pua_gettop(l);
				if (num == 2)
				{
					int delay;
					LuaObject.checkType(l, 1, out delay);
					LuaDelegate ld;
					LuaObject.checkType(l, 2, out ld);
					Action<int> action;
					if (ld.d != null)
					{
						action = (Action<int>)ld.d;
					}
					else
					{
						IntPtr ml = LuaState.get(l).L;
						action = delegate(int id)
						{
							int num2 = LuaObject.pushTry(ml);
							LuaObject.pushValue(ml, id);
							ld.pcall(1, num2);
							LuaDLL.pua_settop(ml, num2 - 1);
						};
					}
					ld.d = action;
					LuaObject.pushValue(l, true);
					LuaObject.pushValue(l, LuaTimer.add(delay, action));
					result = 2;
				}
				else if (num == 3)
				{
					int delay2;
					LuaObject.checkType(l, 1, out delay2);
					int cycle;
					LuaObject.checkType(l, 2, out cycle);
					LuaDelegate ld;
					LuaObject.checkType(l, 3, out ld);
					Func<int, bool> func;
					if (ld.d != null)
					{
						func = (Func<int, bool>)ld.d;
					}
					else
					{
						IntPtr ml = LuaState.get(l).L;
						func = delegate(int id)
						{
							int num2 = LuaObject.pushTry(ml);
							LuaObject.pushValue(ml, id);
							ld.pcall(1, num2);
							bool result2 = LuaDLL.pua_toboolean(ml, -1);
							LuaDLL.pua_settop(ml, num2 - 1);
							return result2;
						};
					}
					ld.d = func;
					LuaObject.pushValue(l, true);
					LuaObject.pushValue(l, LuaTimer.add(delay2, cycle, func));
					result = 2;
				}
				else
				{
					result = LuaObject.error(l, "Argument error");
				}
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int DeleteAll(IntPtr l)
		{
			if (LuaTimer.mapSnTimer == null)
			{
				return 0;
			}
			int result;
			try
			{
				LuaTimer.delAll();
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
			LuaTimer.init();
			LuaObject.getTypeTable(l, "LuaTimer");
			LuaObject.addMember(l, new LuaCSFunction(LuaTimer.Add), false);
			LuaObject.addMember(l, new LuaCSFunction(LuaTimer.Delete), false);
			LuaObject.addMember(l, new LuaCSFunction(LuaTimer.DeleteAll), false);
			LuaObject.createTypeMetatable(l, typeof(LuaTimer));
		}

		private static LinkedListNode<LuaTimer.Timer> GetTimerNodeFormPool(LuaTimer.Timer timer)
		{
			LinkedListNode<LuaTimer.Timer> linkedListNode;
			if (LuaTimer.TIMER_NODE_POOL.Count == 0)
			{
				linkedListNode = new LinkedListNode<LuaTimer.Timer>(timer);
			}
			else
			{
				linkedListNode = LuaTimer.TIMER_NODE_POOL.Dequeue();
				linkedListNode.Value = timer;
			}
			return linkedListNode;
		}

		private static void RecycleTimerNodeToPool(LinkedListNode<LuaTimer.Timer> node)
		{
			node.Value = null;
			LuaTimer.TIMER_NODE_POOL.Enqueue(node);
		}
	}
}
