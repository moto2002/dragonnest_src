using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace com.tencent.pandora
{
	public class LuaDelegation : LuaObject
	{
		internal static int checkDelegate(IntPtr l, int p, out BetterList<Transform>.CompareFunc ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (BetterList<Transform>.CompareFunc)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (BetterList<Transform>.CompareFunc)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(Transform a1, Transform a2)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				LuaObject.pushValue(l, a2);
				ld.pcall(2, num);
				int result2;
				LuaObject.checkType(l, num + 1, out result2);
				LuaDLL.pua_settop(l, num - 1);
				return result2;
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out EventDelegate.Callback ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (EventDelegate.Callback)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (EventDelegate.Callback)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate
			{
				int num = LuaObject.pushTry(l);
				ld.pcall(0, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UIEventListener.BoolDelegate ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UIEventListener.BoolDelegate)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UIEventListener.BoolDelegate)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(GameObject a1, bool a2)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				LuaObject.pushValue(l, a2);
				ld.pcall(2, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UIEventListener.FloatDelegate ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UIEventListener.FloatDelegate)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UIEventListener.FloatDelegate)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(GameObject a1, float a2)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				LuaObject.pushValue(l, a2);
				ld.pcall(2, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UIEventListener.KeyCodeDelegate ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UIEventListener.KeyCodeDelegate)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UIEventListener.KeyCodeDelegate)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(GameObject a1, KeyCode a2)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				LuaObject.pushValue(l, a2);
				ld.pcall(2, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UIEventListener.ObjectDelegate ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UIEventListener.ObjectDelegate)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UIEventListener.ObjectDelegate)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(GameObject a1, GameObject a2)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				LuaObject.pushValue(l, a2);
				ld.pcall(2, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UIEventListener.VectorDelegate ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UIEventListener.VectorDelegate)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UIEventListener.VectorDelegate)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(GameObject a1, Vector2 a2)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				LuaObject.pushValue(l, a2);
				ld.pcall(2, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UIEventListener.VoidDelegate ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UIEventListener.VoidDelegate)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UIEventListener.VoidDelegate)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(GameObject a1)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				ld.pcall(1, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UIGrid.OnReposition ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UIGrid.OnReposition)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UIGrid.OnReposition)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate
			{
				int num = LuaObject.pushTry(l);
				ld.pcall(0, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UIInput.OnValidate ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UIInput.OnValidate)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UIInput.OnValidate)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(string a1, int a2, char a3)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				LuaObject.pushValue(l, a2);
				LuaObject.pushValue(l, a3);
				ld.pcall(3, num);
				char result2;
				LuaObject.checkType(l, num + 1, out result2);
				LuaDLL.pua_settop(l, num - 1);
				return result2;
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UIPanel.OnClippingMoved ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UIPanel.OnClippingMoved)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UIPanel.OnClippingMoved)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(UIPanel a1)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				ld.pcall(1, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UIPanel.OnGeometryUpdated ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UIPanel.OnGeometryUpdated)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UIPanel.OnGeometryUpdated)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate
			{
				int num = LuaObject.pushTry(l);
				ld.pcall(0, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UIProgressBar.OnDragFinished ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UIProgressBar.OnDragFinished)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UIProgressBar.OnDragFinished)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate
			{
				int num = LuaObject.pushTry(l);
				ld.pcall(0, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UIScrollView.OnDragFinished ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UIScrollView.OnDragFinished)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UIScrollView.OnDragFinished)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate
			{
				int num = LuaObject.pushTry(l);
				ld.pcall(0, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UIWidget.HitCheck ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UIWidget.HitCheck)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UIWidget.HitCheck)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(Vector3 a1)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				ld.pcall(1, num);
				bool result2;
				LuaObject.checkType(l, num + 1, out result2);
				LuaDLL.pua_settop(l, num - 1);
				return result2;
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UIWidget.OnDimensionsChanged ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UIWidget.OnDimensionsChanged)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UIWidget.OnDimensionsChanged)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate
			{
				int num = LuaObject.pushTry(l);
				ld.pcall(0, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out WrapContentItemUpdateEventHandler ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (WrapContentItemUpdateEventHandler)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (WrapContentItemUpdateEventHandler)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(Transform a1, int a2)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				LuaObject.pushValue(l, a2);
				ld.pcall(2, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out Action<Sprite> ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (Action<Sprite>)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (Action<Sprite>)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(Sprite a1)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				ld.pcall(1, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out Action<int> ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (Action<int>)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (Action<int>)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(int a1)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				ld.pcall(1, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out Action<int, Dictionary<int, object>> ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (Action<int, Dictionary<int, object>>)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (Action<int, Dictionary<int, object>>)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(int a1, Dictionary<int, object> a2)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				LuaObject.pushValue(l, a2);
				ld.pcall(2, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out Action<int, string> ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (Action<int, string>)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (Action<int, string>)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(int a1, string a2)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				LuaObject.pushValue(l, a2);
				ld.pcall(2, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out Action<string, string, Logger.Level> ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (Action<string, string, Logger.Level>)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (Action<string, string, Logger.Level>)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(string a1, string a2, Logger.Level a3)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				LuaObject.pushValue(l, a2);
				LuaObject.pushValue(l, a3);
				ld.pcall(3, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out Comparison<int> ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (Comparison<int>)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (Comparison<int>)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(int a1, int a2)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				LuaObject.pushValue(l, a2);
				ld.pcall(2, num);
				int result2;
				LuaObject.checkType(l, num + 1, out result2);
				LuaDLL.pua_settop(l, num - 1);
				return result2;
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out Func<int> ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (Func<int>)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (Func<int>)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate
			{
				int num = LuaObject.pushTry(l);
				ld.pcall(0, num);
				int result2;
				LuaObject.checkType(l, num + 1, out result2);
				LuaDLL.pua_settop(l, num - 1);
				return result2;
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out Predicate<int> ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (Predicate<int>)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (Predicate<int>)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(int a1)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				ld.pcall(1, num);
				bool result2;
				LuaObject.checkType(l, num + 1, out result2);
				LuaDLL.pua_settop(l, num - 1);
				return result2;
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out Application.LogCallback ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (Application.LogCallback)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (Application.LogCallback)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate(string a1, string a2, LogType a3)
			{
				int num = LuaObject.pushTry(l);
				LuaObject.pushValue(l, a1);
				LuaObject.pushValue(l, a2);
				LuaObject.pushValue(l, a3);
				ld.pcall(3, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}

		internal static int checkDelegate(IntPtr l, int p, out UnityAction ua)
		{
			int result = LuaObject.extractFunction(l, p);
			if (LuaDLL.pua_isnil(l, p))
			{
				ua = null;
				return result;
			}
			if (LuaDLL.pua_isuserdata(l, p) == 1)
			{
				ua = (UnityAction)LuaObject.checkObj(l, p);
				return result;
			}
			LuaDelegate ld;
			LuaObject.checkType(l, -1, out ld);
			LuaDLL.pua_pop(l, 1);
			if (ld.d != null)
			{
				ua = (UnityAction)ld.d;
				return result;
			}
			l = LuaState.get(l).L;
			ua = delegate
			{
				int num = LuaObject.pushTry(l);
				ld.pcall(0, num);
				LuaDLL.pua_settop(l, num - 1);
			};
			ld.d = ua;
			return result;
		}
	}
}
