using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using WeTest.U3DAutomation;

internal class m
{
	private delegate void a(j A_0);

	[CompilerGenerated]
	private sealed class b : IEnumerator<object>
	{
		private object a;

		private int b;

		public m c;

		public j d;

		bool IEnumerator.f()
		{
			switch (this.b)
			{
			case 0:
				this.b = -1;
				break;
			case 1:
				this.b = -1;
				goto IL_1F7;
			case 2:
				return false;
			case 3:
				this.b = -1;
				break;
			default:
				return false;
			}
			this.d = global::o.b();
			if (this.d == null)
			{
				this.a = null;
				this.b = 1;
				return true;
			}
			global::u.d(string.Concat(new object[]
			{
				"Find command : ",
				this.d.e,
				" value :",
				this.d.c
			}));
			try
			{
				m.a a = null;
				if (this.c.c.TryGetValue(this.d.e, out a))
				{
					long num = DateTime.Now.Ticks / 10000L;
					a(this.d);
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append("[");
					stringBuilder.Append(this.d.a);
					stringBuilder.Append("] Cmd: ");
					stringBuilder.Append(this.d.e);
					stringBuilder.Append(" costs: ");
					stringBuilder.Append(DateTime.Now.Ticks / 10000L - num);
					stringBuilder.Append("ms");
					global::u.c(stringBuilder.ToString());
					this.c.d += (double)((DateTime.Now.Ticks / 10000L - num) / 1000L);
				}
				else
				{
					this.d.f = ResponseStatus.NO_SUCH_CMD;
					global::o.a(this.d);
				}
			}
			catch (Exception ex)
			{
				global::u.c("Handle Command expection =>" + ex.Message + " \n" + ex.StackTrace);
				this.d.f = ResponseStatus.UN_KNOW_ERROR;
				global::o.a(this.d);
			}
			IL_1F7:
			this.a = null;
			this.b = 3;
			return true;
		}

		[DebuggerHidden]
		object IEnumerator<object>.b()
		{
			return this.a;
		}

		[DebuggerHidden]
		void IEnumerator.e()
		{
			throw new NotSupportedException();
		}

		void IDisposable.a()
		{
		}

		[DebuggerHidden]
		object IEnumerator.g()
		{
			return this.a;
		}

		[DebuggerHidden]
		public b(int A_0)
		{
			this.b = A_0;
		}
	}

	private long a;

	private static m b = new m();

	private Dictionary<Cmd, m.a> c = new Dictionary<Cmd, m.a>();

	private double d;

	public float e = 0.5f;

	private double f;

	private int g;

	private float h;

	private int i;

	private int j;

	private object k = new object();

	private bool l = true;

	public bool m;

	public Socket n;

	private c o;

	private void b()
	{
		this.c.Add(Cmd.GET_VERSION, new m.a(this.c));
		this.c.Add(Cmd.FIND_ELEMENTS, new m.a(this.u));
		this.c.Add(Cmd.FIND_ELEMENT_PATH, new m.a(this.g));
		this.c.Add(Cmd.GET_ELEMENTS_BOUND, new m.a(this.h));
		this.c.Add(Cmd.GET_ELEMENT_TEXT, new m.a(this.k));
		this.c.Add(Cmd.GET_ELEMENT_IMAGE, new m.a(this.v));
		this.c.Add(Cmd.DUMP_TREE, new m.a(this.w));
		this.c.Add(Cmd.GET_REGISTERED_HANDLERS, new m.a(this.s));
		this.c.Add(Cmd.CALL_REGISTER_HANDLER, new m.a(this.p));
		this.c.Add(Cmd.GET_CURRENT_SCENE, new m.a(this.r));
		this.c.Add(Cmd.GET_UI_INTERACT_STATUS, new m.a(this.a));
		this.c.Add(Cmd.HANDLE_TOUCH_EVENTS, new m.a(this.j));
		this.c.Add(Cmd.SET_INPUT_TEXT, new m.a(this.l));
		this.c.Add(Cmd.GET_ELEMENT_WORLD_BOUND, new m.a(this.t));
		this.c.Add(Cmd.FIND_ELEMENT_BY_POS, new m.a(this.q));
		this.c.Add(Cmd.GET_FPS, new m.a(this.d));
		this.c.Add(Cmd.GET_TRAFFIC_DATA, new m.a(this.i));
		this.c.Add(Cmd.ENTER_RECORD, new m.a(this.o));
		this.c.Add(Cmd.LEAVE_RECORD, new m.a(this.b));
		this.c.Add(Cmd.GET_OBJECT_FIELD, new m.a(this.f));
	}

	private m()
	{
		this.b();
		this.o = new c();
		this.a = DateTime.Now.Ticks / 10000L;
	}

	public static m a()
	{
		return global::m.b;
	}

	public IEnumerator g()
	{
		m.b b = new m.b(0);
		b.c = this;
		return b;
	}

	protected void f()
	{
		try
		{
			List<TouchEvent> list = global::t.b().d();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					TouchEvent touchEvent = list[i];
					global::r.e().a(touchEvent.x, touchEvent.y, touchEvent.type);
				}
			}
		}
		catch (Exception ex)
		{
			global::u.a(ex.Message + "\n" + ex.StackTrace);
		}
	}

	protected void d()
	{
		try
		{
			Cmd a_ = Cmd.TOUCH_NOTIFY;
			j j = new j(a_, this.n);
			Touch[] touches = Input.touches;
			int num = touches.Length;
			if (num != 0)
			{
				bool flag = false;
				TouchNotify touchNotify = new TouchNotify();
				string loadedLevelName = Application.loadedLevelName;
				touchNotify.scene = loadedLevelName;
				int num2 = 0;
				while (num2 < num && num2 < 5)
				{
					Touch touch = touches[num2];
					global::u.c("Touch delta time = {0},x = {1},y={2} ,fingerId = {3},phase = {4}", new object[]
					{
						touch.deltaTime * Time.timeScale,
						touch.position.x,
						touch.position.y,
						touch.fingerId,
						touch.phase
					});
					if (touch.phase == TouchPhase.Began && !flag)
					{
						GameObject gameObject = null;
						try
						{
							gameObject = x.a(new Point(touch.position.x, touch.position.y));
						}
						catch (Exception ex)
						{
							global::u.d(ex.StackTrace);
						}
						if (gameObject != null && x.a(gameObject))
						{
							flag = true;
							string text = global::g.b(gameObject);
							global::u.c("Touch UI = " + text);
							touchNotify.name = text;
						}
					}
					if (touch.phase != TouchPhase.Canceled && touch.phase != TouchPhase.Stationary && touch.phase != TouchPhase.Moved)
					{
						TouchData touchData = new TouchData();
						touchData.deltatime = (float)(DateTime.Now.Ticks / 10000L - this.a);
						touchData.fingerId = (short)touch.fingerId;
						Point point = CoordinateTool.ConvertUnity2Mobile(touch.position);
						touchData.x = point.X;
						touchData.y = point.Y;
						touchData.relativeX = touch.position.x / (float)Screen.width;
						touchData.relativeY = ((float)Screen.height - touch.position.y) / (float)Screen.height;
						TouchPhase phase = touch.phase;
						if (phase != TouchPhase.Began)
						{
							if (phase == TouchPhase.Ended)
							{
								touchData.phase = 2;
							}
						}
						else
						{
							touchData.phase = 1;
						}
						touchNotify.touches.Add(touchData);
					}
					num2++;
				}
				if (touchNotify.touches.Count > 0)
				{
					j.b = touchNotify;
					global::o.a(j);
				}
			}
		}
		catch (Exception ex2)
		{
			global::u.a(ex2.Message + "\n" + ex2.StackTrace);
			Cmd a_2 = Cmd.TOUCH_NOTIFY;
			global::o.a(new j(a_2, this.n)
			{
				b = ex2.Message + "\n" + ex2.StackTrace,
				f = ResponseStatus.UN_KNOW_ERROR
			});
		}
	}

	public void h()
	{
		this.f();
		if (this.m)
		{
			this.d();
		}
	}

	protected void c(j A_0)
	{
		VersionData versionData = new VersionData();
		versionData.engineVersion = Application.unityVersion;
		A_0.b = versionData;
		global::u.c(string.Concat(new string[]
		{
			"Engine=",
			versionData.engine,
			"; Version=",
			versionData.sdkVersion,
			"; UnityVersion=",
			versionData.engineVersion,
			"; UI=",
			versionData.sdkUIType
		}));
		global::o.a(A_0);
	}

	protected void u(j A_0)
	{
		global::u.c("handleGetElements +" + A_0.c);
		List<string> list = JsonParser.Deserialization<List<string>>(A_0);
		List<ElementInfo> list2 = new List<ElementInfo>();
		foreach (string current in list)
		{
			global::u.c("element name = " + current);
			ElementInfo elementInfo = new ElementInfo();
			list2.Add(elementInfo);
			try
			{
				GameObject gameObject = GameObjectManager.INSTANCE.FindGameObject(current);
				if (gameObject != null)
				{
					elementInfo.instance = GameObjectManager.INSTANCE.AddGameObject(gameObject);
					elementInfo.name = current;
				}
				else
				{
					elementInfo.instance = -1;
					elementInfo.name = current;
				}
			}
			catch (Exception ex)
			{
				global::u.a(ex.Message + " " + ex.StackTrace);
				elementInfo.instance = -1;
			}
		}
		A_0.b = list2;
		global::o.a(A_0);
	}

	protected void g(j A_0)
	{
		global::u.c("handleGetElementsByPath " + A_0.c);
		List<PathNode> nodes = JsonParser.Deserialization<List<PathNode>>(A_0);
		List<ElementInfo> list = new List<ElementInfo>();
		A_0.b = list;
		try
		{
			List<GameObject> list2 = GameObjectManager.INSTANCE.FindByPath(nodes);
			foreach (GameObject current in list2)
			{
				string a_ = global::g.b(current);
				int a_2 = GameObjectManager.INSTANCE.AddGameObject(current);
				ElementInfo elementInfo = new ElementInfo(a_, a_2);
				list.Add(elementInfo);
				global::u.c(string.Concat(new object[]
				{
					"Element name = ",
					elementInfo.name,
					" ,instance =",
					elementInfo.instance
				}));
			}
		}
		catch (Exception ex)
		{
			global::u.a(ex.Message + " " + ex.StackTrace);
			A_0.f = ResponseStatus.UN_KNOW_ERROR;
		}
		global::o.a(A_0);
	}

	protected void h(j A_0)
	{
		global::u.c("handleGetElementsBound" + A_0.c);
		List<int> list = JsonParser.Deserialization<List<int>>(A_0);
		List<BoundInfo> list2 = new List<BoundInfo>();
		foreach (int current in list)
		{
			GameObject gameObject = GameObjectManager.INSTANCE.FindGameObjectGlobal(current);
			BoundInfo boundInfo = new BoundInfo();
			boundInfo.instance = current;
			list2.Add(boundInfo);
			try
			{
				if (gameObject != null)
				{
					Rectangle rectangle = this.o.d(gameObject);
					if (rectangle == null)
					{
						boundInfo.visible = false;
					}
					else
					{
						boundInfo.x = rectangle.x;
						boundInfo.y = rectangle.y;
						boundInfo.width = rectangle.width;
						boundInfo.height = rectangle.height;
						boundInfo.path = global::g.b(gameObject);
					}
				}
				else
				{
					boundInfo.existed = false;
				}
			}
			catch (Exception ex)
			{
				global::u.a(ex.Message + " " + ex.StackTrace);
				boundInfo.visible = false;
			}
		}
		foreach (BoundInfo current2 in list2)
		{
			global::u.c(string.Concat(new object[]
			{
				"Bound width = ",
				current2.width,
				" height = ",
				current2.height,
				" x = ",
				current2.x,
				" y=",
				current2.y,
				" existed = ",
				current2.existed,
				" visible = ",
				current2.visible
			}));
		}
		A_0.b = list2;
		global::o.a(A_0);
	}

	protected void k(j A_0)
	{
		global::u.c("handleGetNodeText +" + A_0.c);
		try
		{
			int num = int.Parse(A_0.c);
			GameObject gameObject = GameObjectManager.INSTANCE.FindGameObjectGlobal(num);
			if (null == gameObject)
			{
				A_0.f = ResponseStatus.GAMEOBJ_NOT_EXIST;
				A_0.b = "GameObject " + num + " is not exists";
				return;
			}
			string text = this.o.e(gameObject);
			if (text == null)
			{
				A_0.b = "No Component with text";
				A_0.f = ResponseStatus.NO_SUCH_RESOURCE;
			}
			else
			{
				A_0.b = text;
			}
		}
		catch (Exception ex)
		{
			global::u.a(ex.Message + " " + ex.StackTrace);
			A_0.f = ResponseStatus.UN_KNOW_ERROR;
			A_0.b = ex.Message + " " + ex.StackTrace;
		}
		global::o.a(A_0);
	}

	protected void v(j A_0)
	{
		global::u.c("handleGetNodeImage +" + A_0.c);
		int num = int.Parse(A_0.c);
		try
		{
			GameObject gameObject = GameObjectManager.INSTANCE.FindGameObjectGlobal(num);
			if (null == gameObject)
			{
				A_0.f = ResponseStatus.GAMEOBJ_NOT_EXIST;
				A_0.b = "GameObject " + num + " is not exists";
				return;
			}
			string text = this.o.a(gameObject);
			if (text == null)
			{
				A_0.b = "No Component with image";
				A_0.f = ResponseStatus.NO_SUCH_RESOURCE;
			}
			else
			{
				A_0.b = text;
			}
		}
		catch (Exception ex)
		{
			global::u.a(ex.Message + " " + ex.StackTrace);
			A_0.f = ResponseStatus.UN_KNOW_ERROR;
			A_0.b = ex.Message + " " + ex.StackTrace;
		}
		global::o.a(A_0);
	}

	protected void w(j A_0)
	{
		global::u.c("handleDumpTree ");
		try
		{
			string xml = global::g.a();
			string loadedLevelName = Application.loadedLevelName;
			A_0.b = new DumpTree
			{
				scene = loadedLevelName,
				xml = xml
			};
		}
		catch (Exception ex)
		{
			global::u.a(ex.Message + " " + ex.StackTrace);
			A_0.f = ResponseStatus.UN_KNOW_ERROR;
			A_0.b = ex.Message + " " + ex.StackTrace;
		}
		global::o.a(A_0);
	}

	protected void s(j A_0)
	{
		global::u.c("handleGetRegisterHandlers");
		try
		{
			List<string> registered = CustomHandler.GetRegistered();
			A_0.b = registered;
		}
		catch (Exception ex)
		{
			global::u.a(ex.Message + " " + ex.StackTrace);
			A_0.f = ResponseStatus.UN_KNOW_ERROR;
			A_0.b = ex.Message + " " + ex.StackTrace;
		}
		global::o.a(A_0);
	}

	protected void p(j A_0)
	{
		global::u.c("handleCallRegisteredHandler");
		try
		{
			CustomCaller customCaller = JsonParser.Deserialization<CustomCaller>(A_0);
			string text;
			bool flag = CustomHandler.Call(customCaller.name, customCaller.args, out text);
			if (flag)
			{
				A_0.b = text;
			}
			else
			{
				A_0.f = ResponseStatus.NO_SUCH_HANDLER;
				A_0.b = "No such handler: " + customCaller.name;
			}
		}
		catch (Exception ex)
		{
			global::u.a(ex.Message + " " + ex.StackTrace);
			A_0.f = ResponseStatus.UN_KNOW_ERROR;
			A_0.b = ex.Message + " " + ex.StackTrace;
		}
		global::o.a(A_0);
	}

	protected void r(j A_0)
	{
		global::u.c("handleGetCurrentScene");
		try
		{
			A_0.b = Application.loadedLevelName;
		}
		catch (Exception ex)
		{
			global::u.a(ex.Message + " " + ex.StackTrace);
			A_0.f = ResponseStatus.UN_KNOW_ERROR;
			A_0.b = ex.Message + " " + ex.StackTrace;
		}
		global::o.a(A_0);
	}

	protected void a(j A_0)
	{
		global::u.c("handleGetCurrentScene");
		try
		{
			InteractStatus interactStatus = new InteractStatus();
			List<InteractElement> elements = this.o.a();
			interactStatus.elements = elements;
			interactStatus.scenename = global::b.a();
			A_0.b = interactStatus;
		}
		catch (Exception ex)
		{
			global::u.a(ex.Message + " " + ex.StackTrace);
			A_0.f = ResponseStatus.UN_KNOW_ERROR;
			A_0.b = ex.Message + " " + ex.StackTrace;
		}
		global::o.a(A_0);
	}

	protected void j(j A_0)
	{
		global::u.c("HandleTouchActions");
		TouchEvent[] array;
		if (A_0.d != null)
		{
			array = (TouchEvent[])A_0.d;
		}
		else
		{
			array = JsonParser.Deserialization<TouchEvent[]>(A_0);
		}
		q q = new q();
		q.a = A_0;
		q.b = array;
		global::t.b().a(q);
	}

	protected void l(j A_0)
	{
		global::u.c("handleSetInputText +" + A_0.c);
		TextSetter textSetter = JsonParser.Deserialization<TextSetter>(A_0);
		try
		{
			GameObject gameObject = GameObjectManager.INSTANCE.FindGameObjectGlobal(textSetter.instance);
			if (null == gameObject)
			{
				A_0.f = ResponseStatus.GAMEOBJ_NOT_EXIST;
				A_0.b = "GameObject " + global::m.b + " is not exists";
				global::o.a(A_0);
				return;
			}
			string text = this.o.a(gameObject, textSetter.content);
			A_0.b = text;
		}
		catch (Exception ex)
		{
			global::u.a(ex.Message + " " + ex.StackTrace);
			A_0.f = ResponseStatus.UN_KNOW_ERROR;
			A_0.b = ex.Message + " " + ex.StackTrace;
		}
		global::o.a(A_0);
	}

	protected void t(j A_0)
	{
		global::u.c("handleGetWorldBound");
		List<int> list = JsonParser.Deserialization<List<int>>(A_0);
		List<WorldBound> list2 = new List<WorldBound>();
		for (int i = 0; i < list.Count; i++)
		{
			int id = list[i];
			GameObject gameObject = GameObjectManager.INSTANCE.FindGameObjectGlobal(id);
			WorldBound worldBound = null;
			try
			{
				if (gameObject != null)
				{
					worldBound = this.o.g(gameObject);
				}
				else
				{
					worldBound = new WorldBound();
					worldBound.existed = false;
				}
			}
			catch (Exception ex)
			{
				global::u.a(ex.Message + " " + ex.StackTrace);
				worldBound = new WorldBound();
				worldBound.existed = false;
			}
			worldBound.id = id;
			list2.Add(worldBound);
		}
		A_0.b = list2;
		global::o.a(A_0);
	}

	protected void q(j A_0)
	{
		global::u.c("handleGetElementByPos");
		try
		{
			List<double> list = JsonParser.Deserialization<List<double>>(A_0);
			float x = (float)list[0];
			float y = (float)list[1];
			List<GameObject> list2 = this.o.a(new Point(x, y));
			if (list2 == null || list2.Count == 0)
			{
				A_0.f = ResponseStatus.GAMEOBJ_NOT_EXIST;
				A_0.b = "";
				global::o.a(A_0);
				return;
			}
			ElementInfo elementInfo = new ElementInfo();
			GameObject gameObject = list2[0];
			string a_ = global::g.b(gameObject);
			int a_2 = GameObjectManager.INSTANCE.AddGameObject(gameObject);
			elementInfo = new ElementInfo(a_, a_2);
			global::u.c(string.Concat(new object[]
			{
				"Element name = ",
				elementInfo.name,
				" ,instance =",
				elementInfo.instance
			}));
			A_0.b = elementInfo;
		}
		catch (Exception ex)
		{
			global::u.a(ex.Message + " " + ex.StackTrace);
			A_0.f = ResponseStatus.UN_KNOW_ERROR;
			A_0.b = ex.Message + " " + ex.StackTrace;
		}
		global::o.a(A_0);
	}

	protected void d(j A_0)
	{
		global::u.c("handleGetFPS");
		try
		{
			A_0.b = (uint)this.h;
		}
		catch (Exception ex)
		{
			global::u.a(ex.Message + " " + ex.StackTrace);
			A_0.f = ResponseStatus.UN_KNOW_ERROR;
			A_0.b = ex.Message + " " + ex.StackTrace;
		}
		global::o.a(A_0);
	}

	protected void i(j A_0)
	{
		global::u.c("handleGetStreamData");
		AppNetTrafficRes appNetTrafficRes = new AppNetTrafficRes();
		if (!this.l)
		{
			A_0.f = ResponseStatus.UN_KNOW_ERROR;
			A_0.b = "";
		}
		else
		{
			try
			{
				AppNetReq appNetReq = JsonParser.Deserialization<AppNetReq>(A_0);
				int uid = appNetReq.uid;
				UnityEngine.Debug.Log("----------------" + uid + "----------------");
				string a_ = "/proc/uid_stat/" + uid + "/tcp_rcv";
				string a_2 = "/proc/uid_stat/" + uid + "/tcp_snd";
				int num = 0;
				int num2 = 0;
				lock (this.k)
				{
					int num3 = this.a(a_);
					int num4 = this.a(a_2);
					if (num3 == -1 || num4 == -1)
					{
						this.l = false;
					}
					num = num3 - this.i;
					num2 = num4 - this.j;
				}
				global::u.d(string.Concat(new object[]
				{
					"App(uid:",
					uid,
					"） recv size:",
					num,
					" send size:",
					num2
				}));
				appNetTrafficRes.input = num;
				appNetTrafficRes.output = num2;
				A_0.b = appNetTrafficRes;
			}
			catch (Exception ex)
			{
				global::u.a(ex.Message + " " + ex.StackTrace);
				A_0.f = ResponseStatus.UN_KNOW_ERROR;
				A_0.b = ex.Message + " " + ex.StackTrace;
			}
		}
		global::o.a(A_0);
	}

	public void c()
	{
		this.g++;
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		if ((double)realtimeSinceStartup > this.f + (double)this.e)
		{
			double num = (double)realtimeSinceStartup - this.f - this.d;
			if (num == 0.0)
			{
				this.h = 0f;
			}
			else
			{
				this.h = (float)((double)this.g / num);
			}
			this.d = 0.0;
			this.g = 0;
			this.f = (double)realtimeSinceStartup;
		}
	}

	private int a(string A_0)
	{
		StreamReader streamReader = null;
		int result = -1;
		try
		{
			streamReader = new StreamReader(A_0, Encoding.Default);
			using (streamReader)
			{
				string s = streamReader.ReadLine();
				result = int.Parse(s);
			}
		}
		catch (Exception ex)
		{
			global::u.c("read from" + A_0 + " failed\n" + ex.Message);
		}
		finally
		{
			if (streamReader != null)
			{
				streamReader.Close();
			}
		}
		return result;
	}

	protected void o(j A_0)
	{
		global::u.c("handleEnterRecord");
		this.n = A_0.a;
		global::o.a(A_0);
		this.m = true;
	}

	protected void b(j A_0)
	{
		global::u.c("handleLeaveRecord");
		this.m = false;
		global::o.a(A_0);
	}

	protected void f(j A_0)
	{
		global::u.c("handleGetElementsBound" + A_0.c);
		ComponentField componentField = JsonParser.Deserialization<ComponentField>(A_0);
		GameObject gameObject = GameObjectManager.INSTANCE.FindGameObjectGlobal(componentField.instance);
		if (gameObject == null)
		{
			A_0.f = ResponseStatus.GAMEOBJ_NOT_EXIST;
		}
		else
		{
			try
			{
				object componentAttribute = ReflectionTools.GetComponentAttribute(gameObject, componentField.comopentName, componentField.attributeName);
				if (componentAttribute != null)
				{
					A_0.b = componentAttribute.ToString();
				}
			}
			catch (Exception ex)
			{
				A_0.f = ResponseStatus.REFLECTION_ERROR;
				A_0.b = ex.Message;
			}
		}
		global::o.a(A_0);
	}
}
