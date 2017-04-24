using LuaCore;
using LuaInterface;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using UILib;
using UnityEngine;
using XUtliPoolLib;

public class Hotfix
{
	private static string URL = "http://10.0.128.3/webclient/Assets/Hotfix/";

	private static LuaStringBuffer sharedStringBuff0 = new LuaStringBuffer();

	private static LuaStringBuffer sharedStringBuff1 = new LuaStringBuffer();

	private static ILuaNetwork m_network;

	private static IModalDlg m_modalDlg;

	public static IUiUtility m_uiUtility;

	private static ILuaExtion m_luaExtion = null;

	private static IGameSysMgr m_GameSysMgr = null;

	private static long fileSize = 0L;

	private static long rowSize = 0L;

	private static long beforePos = 0L;

	private static IXNormalItemDrawer m_itemDrawer;

	private static IX3DAvatarMgr m_avatarMgr;

	private static int localversion
	{
		get
		{
			return PlayerPrefs.GetInt("hotfixversion", 0);
		}
	}

	public static ILuaExtion luaExtion
	{
		get
		{
			if (Hotfix.m_luaExtion == null || Hotfix.m_luaExtion.Deprecated)
			{
				Hotfix.m_luaExtion = XSingleton<XInterfaceMgr>.singleton.GetInterface<ILuaExtion>(XSingleton<XCommon>.singleton.XHash("ILuaExtion"));
			}
			return Hotfix.m_luaExtion;
		}
	}

	public static IGameSysMgr GameSysMgr
	{
		get
		{
			if (Hotfix.m_GameSysMgr == null || Hotfix.m_GameSysMgr.Deprecated)
			{
				Hotfix.m_GameSysMgr = XSingleton<XInterfaceMgr>.singleton.GetInterface<IGameSysMgr>(XSingleton<XCommon>.singleton.XHash("IGameSysMgr"));
			}
			return Hotfix.m_GameSysMgr;
		}
	}

	public static int onlineReTime
	{
		get
		{
			return (int)Hotfix.GameSysMgr.OnlineRewardRemainTime;
		}
	}

	private static void InitNet()
	{
		if (Hotfix.m_network == null || Hotfix.m_network.Deprecated)
		{
			Hotfix.m_network = XSingleton<XInterfaceMgr>.singleton.GetInterface<ILuaNetwork>(XSingleton<XCommon>.singleton.XHash("ILUANET"));
		}
	}

	public static void Init(Action finish)
	{
		if (finish != null)
		{
			finish();
		}
		Hotfix.RegistNotifyID();
		if (Hotfix.m_network != null)
		{
			Hotfix.m_network.InitLua(1024);
		}
	}

	[DebuggerHidden]
	private static IEnumerator LoadHotfix(Action finish)
	{
		Hotfix.<LoadHotfix>c__Iterator13 <LoadHotfix>c__Iterator = new Hotfix.<LoadHotfix>c__Iterator13();
		<LoadHotfix>c__Iterator.finish = finish;
		<LoadHotfix>c__Iterator.<$>finish = finish;
		return <LoadHotfix>c__Iterator;
	}

	public static int LuaWait(int delay, LuaFunction cb)
	{
		return Single<TimerManager>.Instance.AddTimer(delay, 1, delegate(int x)
		{
			cb.Call((double)x);
		});
	}

	public static int LuaLoop(int delay, int loop, LuaFunction cb)
	{
		return Single<TimerManager>.Instance.AddTimer(delay, loop, delegate(int x)
		{
			cb.Call((double)x);
		});
	}

	public static void RemoveTimer(int seq)
	{
		Single<TimerManager>.Instance.RemoveTimer(seq);
	}

	public static bool SendLuaPtc(uint _type, LuaStringBuffer _data)
	{
		return Hotfix.SendLuaBytePtc(_type, _data.buffer);
	}

	public static bool SendLuaBytePtc(uint _type, byte[] _req)
	{
		Hotfix.InitNet();
		if (Hotfix.m_network == null)
		{
			UnityEngine.Debug.LogError("network is null");
			return false;
		}
		return Hotfix.m_network.LuaSendPtc(_type, _req);
	}

	public static void RegistNotifyID()
	{
		Hotfix.InitNet();
		object[] array = XLua.FetchRegistID();
		if (array != null)
		{
			for (int i = 0; i < array.Length; i += 2)
			{
				uint type = Convert.ToUInt32(array[i]);
				bool copyBuffer = Convert.ToUInt32(array[i + 1]) != 0u;
				Hotfix.m_network.LuaRigsterPtc(type, copyBuffer);
			}
		}
	}

	public static void RegistPtc(uint type, bool copyBuffer)
	{
		Hotfix.InitNet();
		Hotfix.m_network.LuaRigsterPtc(type, copyBuffer);
	}

	public static void RegisterLuaRPC(uint _type, bool copyBuffer, LuaFunction _res, LuaFunction _err)
	{
		Hotfix.InitNet();
		if (Hotfix.m_network == null)
		{
			UnityEngine.Debug.LogError("network is null");
		}
		else
		{
			Hotfix.m_network.LuaRigsterRPC(_type, copyBuffer, delegate(byte[] bytes, int length)
			{
				if (bytes == null)
				{
					_res.Call(new object[]
					{
						null,
						0
					});
				}
				else
				{
					_res.Call(new object[]
					{
						Hotfix.LuaProtoBuffer(bytes, length),
						length
					});
				}
			}, delegate(int errcode)
			{
				_err.Call((double)errcode);
			});
		}
	}

	public static void SendLuaRPC(uint _type, LuaStringBuffer _data, LuaFunction _res, LuaFunction _err)
	{
		Hotfix._SendLuaRPC(_type, _data, _res, _err, false);
	}

	public static void SendLuaRPCWithReq(uint _type, LuaStringBuffer _data, LuaFunction _res, LuaFunction _err)
	{
		Hotfix._SendLuaRPC(_type, _data, _res, _err, true);
	}

	private static void _SendLuaRPC(uint _type, LuaStringBuffer _data, LuaFunction _res, LuaFunction _err, bool withReq)
	{
		Hotfix._SendLuaByteRPC(_type, _data.buffer, _res, _err, withReq);
	}

	public static void SendLuaByteRPC(uint _type, byte[] _req, LuaFunction _res, LuaFunction _err)
	{
		Hotfix._SendLuaByteRPC(_type, _req, _res, _err, false);
	}

	public static void SendLuaByteRPCWithReq(uint _type, byte[] _req, LuaFunction _res, LuaFunction _err)
	{
		Hotfix._SendLuaByteRPC(_type, _req, _res, _err, true);
	}

	private static void _SendLuaByteRPC(uint _type, byte[] _req, LuaFunction _res, LuaFunction _err, bool withReq)
	{
		Hotfix.InitNet();
		if (Hotfix.m_network == null)
		{
			UnityEngine.Debug.LogError("network is null");
		}
		else
		{
			Hotfix.m_network.LuaSendRPC(_type, _req, delegate(byte[] bytes, int length)
			{
				if (withReq)
				{
					_res.Call(new object[]
					{
						Hotfix.LuaProtoBuffer(_req, length),
						Hotfix.LuaProtoBuffer1(bytes, length),
						length
					});
				}
				else
				{
					_res.Call(new object[]
					{
						Hotfix.LuaProtoBuffer(bytes, length),
						length
					});
				}
			}, delegate(int errcode)
			{
				_err.Call((double)errcode);
			});
		}
	}

	public static void LuaMessageBoxConfirm(string str, LuaFunction okDel, LuaFunction cancelDel)
	{
		if (Hotfix.m_modalDlg == null || Hotfix.m_modalDlg.Deprecated)
		{
			Hotfix.m_modalDlg = XSingleton<XInterfaceMgr>.singleton.GetInterface<IModalDlg>(XSingleton<XCommon>.singleton.XHash("IModalDlg"));
		}
		if (Hotfix.m_modalDlg == null)
		{
			UnityEngine.Debug.LogError("modal dlg is null!");
		}
		else
		{
			Hotfix.m_modalDlg.LuaShow(str, delegate(IXUIButton btn)
			{
				if (okDel != null)
				{
					okDel.Call();
				}
				return true;
			}, delegate(IXUIButton btn)
			{
				if (cancelDel != null)
				{
					cancelDel.Call();
				}
				return true;
			});
		}
	}

	public static void LuaShowSystemTip(string text)
	{
		if (Hotfix.m_uiUtility == null || Hotfix.m_uiUtility.Deprecated)
		{
			Hotfix.m_uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
		}
		if (Hotfix.m_uiUtility == null)
		{
			UnityEngine.Debug.LogError("uiUtility is null!");
		}
		else
		{
			Hotfix.m_uiUtility.ShowSystemTip(text, "fece00");
		}
	}

	public static void LuaShowSystemTipErrCode(int errCode)
	{
		if (Hotfix.m_uiUtility == null || Hotfix.m_uiUtility.Deprecated)
		{
			Hotfix.m_uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
		}
		if (Hotfix.m_uiUtility == null)
		{
			UnityEngine.Debug.LogError("uiUtility is null!");
		}
		else
		{
			Hotfix.m_uiUtility.ShowSystemTip(errCode, "fece00");
		}
	}

	public static void LuaShowItemAccess(int itemID)
	{
		if (Hotfix.m_uiUtility == null || Hotfix.m_uiUtility.Deprecated)
		{
			Hotfix.m_uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
		}
		if (Hotfix.m_uiUtility == null)
		{
			UnityEngine.Debug.LogError("uiUtility is null!");
		}
		else
		{
			Hotfix.m_uiUtility.ShowItemAccess(itemID, null);
		}
	}

	public static void LuaShowItemTooltipDialog(int itemID, GameObject icon)
	{
		if (Hotfix.m_uiUtility == null || Hotfix.m_uiUtility.Deprecated)
		{
			Hotfix.m_uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
		}
		if (Hotfix.m_uiUtility == null)
		{
			UnityEngine.Debug.LogError("uiUtility is null!");
		}
		else
		{
			Hotfix.m_uiUtility.ShowTooltipDialog(itemID, icon);
		}
	}

	public static void LuaShowDetailTooltipDialog(int itemID, GameObject icon)
	{
		if (Hotfix.m_uiUtility == null || Hotfix.m_uiUtility.Deprecated)
		{
			Hotfix.m_uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
		}
		if (Hotfix.m_uiUtility == null)
		{
			UnityEngine.Debug.LogError("uiUtility is null!");
		}
		else
		{
			Hotfix.m_uiUtility.ShowDetailTooltip(itemID, icon);
		}
	}

	public static void LuaShowItemTooltipDialogByUID(string strUID, GameObject icon)
	{
		if (Hotfix.m_uiUtility == null || Hotfix.m_uiUtility.Deprecated)
		{
			Hotfix.m_uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
		}
		if (Hotfix.m_uiUtility == null)
		{
			UnityEngine.Debug.LogError("uiUtility is null!");
		}
		else
		{
			Hotfix.m_uiUtility.ShowTooltipDialogByUID(strUID, icon);
		}
	}

	public static void SetPlayer(string key, string value)
	{
		Hotfix.luaExtion.SetPlayerProprerty(key, value);
	}

	public static object GetPlayer(string key)
	{
		return Hotfix.luaExtion.GetPlayeProprerty(key);
	}

	public static object CallPlayerMethod(bool isPublic, string method, params object[] args)
	{
		return Hotfix.luaExtion.CallPlayerMethod(isPublic, method, args);
	}

	public static void SetDocumentMember(string doc, string key, object value, bool isPublic, bool isField)
	{
		Hotfix.luaExtion.SetDocumentMember(doc, key, value, isPublic, isField);
	}

	public static object GetDocumentMember(string doc, string key, bool isPublic, bool isField)
	{
		return Hotfix.luaExtion.GetDocumentMember(doc, key, isPublic, isField);
	}

	public static string GetGetDocumentLongMember(string doc, string key, bool isPublic, bool isField)
	{
		return Hotfix.GetDocumentMember(doc, key, isPublic, isField).ToString();
	}

	public static object GetDocumentStaticMember(string doc, string key, bool isPublic, bool isField)
	{
		return Hotfix.luaExtion.GetDocumentStaticMember(doc, key, isPublic, isField);
	}

	public static object CallDocumentMethod(string doc, bool isPublic, string method, params object[] args)
	{
		return Hotfix.luaExtion.CallDocumentMethod(doc, isPublic, method, args);
	}

	public static string CallDocumentLongMethod(string doc, bool isPublic, string method, params object[] args)
	{
		return Hotfix.luaExtion.CallDocumentMethod(doc, isPublic, method, args).ToString();
	}

	public static object CallDocumentStaticMethod(string doc, bool isPublic, string method, params object[] args)
	{
		return Hotfix.luaExtion.CallDocumentStaticMethod(doc, isPublic, method, args);
	}

	public static object GetSingleMember(string className, string key, bool isPublic, bool isField, bool isStatic)
	{
		return Hotfix.luaExtion.GetSingleMember(className, key, isPublic, isField, isStatic);
	}

	public static string GetSingleLongMember(string className, string key, bool isPublic, bool isField, bool isStatic)
	{
		return Hotfix.GetSingleMember(className, key, isPublic, isField, isStatic).ToString();
	}

	public static void SetSingleMember(string className, string key, object value, bool isPublic, bool isField, bool isStatic)
	{
		Hotfix.luaExtion.SetSingleMember(className, key, value, isPublic, isField, isStatic);
	}

	public static object CallSingleMethod(string className, bool isPublic, bool isStatic, string methodName, params object[] args)
	{
		return Hotfix.luaExtion.CallSingleMethod(className, isPublic, isStatic, methodName, args);
	}

	public static string CallSingleLongMethod(string className, bool isPublic, bool isStatic, string methodName, params object[] args)
	{
		return Hotfix.luaExtion.CallSingleMethod(className, isPublic, isStatic, methodName, args).ToString();
	}

	public static object GetEnumType(string classname, string value)
	{
		return Hotfix.luaExtion.GetEnumType(classname, value);
	}

	public static string GetStringTable(string key, params object[] args)
	{
		return Hotfix.luaExtion.GetStringTable(key, args);
	}

	public static string GetGlobalString(string key)
	{
		return Hotfix.luaExtion.GetGlobalString(key);
	}

	public static string GetObjectString(object o, string name)
	{
		return o.GetPublicField(name).ToString();
	}

	public static XLuaLong GetLuaLong(string str)
	{
		return Hotfix.luaExtion.Get(str);
	}

	public static void RefreshPlayerName()
	{
		Hotfix.luaExtion.RefreshPlayerName();
	}

	public static bool OpenSys(int sys)
	{
		Hotfix.GameSysMgr.OpenSystem(sys);
		return Hotfix.GameSysMgr.IsSystemOpen(sys);
	}

	public static void AttachSysRedPointRelative(int sys, int childSys, bool bImmCalculate)
	{
		Hotfix.GameSysMgr.AttachSysRedPointRelative(sys, childSys, bImmCalculate);
	}

	public static void AttachSysRedPointRelativeUI(int sys, GameObject go)
	{
		Hotfix.GameSysMgr.AttachSysRedPointRelativeUI(sys, go);
	}

	public static void DetachSysRedPointRelative(int sys)
	{
		Hotfix.GameSysMgr.DetachSysRedPointRelative(sys);
	}

	public static void DetachSysRedPointRelativeUI(int sys)
	{
		Hotfix.GameSysMgr.DetachSysRedPointRelativeUI(sys);
	}

	public static void ForceUpdateSysRedPointImmediately(int sys, bool redpoint)
	{
		Hotfix.GameSysMgr.ForceUpdateSysRedPointImmediately(sys, redpoint);
	}

	public static bool GetSysRedPointState(int sys)
	{
		return Hotfix.GameSysMgr.GetSysRedPointState(sys);
	}

	public static void LuaDoFile(string name)
	{
		LuaScriptMgr luaScriptMgr = HotfixManager.Instance.GetLuaScriptMgr();
		if (luaScriptMgr != null)
		{
			luaScriptMgr.DoFile(name);
		}
	}

	public static LuaFunction LuaGetFunction(string func)
	{
		LuaScriptMgr luaScriptMgr = HotfixManager.Instance.GetLuaScriptMgr();
		if (luaScriptMgr != null)
		{
			return luaScriptMgr.GetLuaFunction(func);
		}
		UnityEngine.Debug.LogError("LuaScriptMgr is null");
		return null;
	}

	public static string LuaTableBuffer(string location)
	{
		Stream stream = XSingleton<XResourceLoaderMgr>.singleton.ReadText(location, true);
		StreamReader streamReader = new StreamReader(stream);
		return streamReader.ReadToEnd();
	}

	public static BinaryReader LuaTableBin(string location)
	{
		Stream input = XSingleton<XResourceLoaderMgr>.singleton.ReadText(location, true);
		return new BinaryReader(input);
	}

	public static void ReturnableStream(BinaryReader reader)
	{
		XSingleton<XResourceLoaderMgr>.singleton.ClearStream(reader.BaseStream);
	}

	public static string ReadLong(BinaryReader reader)
	{
		return reader.ReadInt64().ToString();
	}

	public static void ReadFileSize(BinaryReader reader)
	{
		Hotfix.fileSize = reader.ReadInt64();
	}

	public static void CheckFileSize(BinaryReader reader, string tableName)
	{
		long position = reader.BaseStream.Position;
		if (position != Hotfix.fileSize)
		{
			XSingleton<XDebug>.singleton.AddErrorLog2("read table error:{0} size:{1} read size:{2}", new object[]
			{
				tableName,
				Hotfix.fileSize,
				position
			});
		}
	}

	public static void ReadRowSize(BinaryReader reader)
	{
		Hotfix.rowSize = reader.ReadInt64();
		Hotfix.beforePos = reader.BaseStream.Position;
	}

	public static void CheckRowSize(BinaryReader reader, string tableName, int lineno)
	{
		long position = reader.BaseStream.Position;
		long num = position - Hotfix.beforePos;
		if (Hotfix.rowSize > num)
		{
			reader.BaseStream.Seek(Hotfix.rowSize - num, SeekOrigin.Current);
		}
		else if (Hotfix.rowSize < num)
		{
			XSingleton<XDebug>.singleton.AddErrorLog2("read table error:{0} line:{1}", new object[]
			{
				tableName,
				lineno
			});
		}
	}

	public static LuaStringBuffer LuaProtoBuffer(byte[] bytes, int length)
	{
		Hotfix.sharedStringBuff0.Copy(bytes, length);
		return Hotfix.sharedStringBuff0;
	}

	public static LuaStringBuffer LuaProtoBuffer1(byte[] bytes, int length)
	{
		Hotfix.sharedStringBuff1.Copy(bytes, length);
		return Hotfix.sharedStringBuff1;
	}

	public static void SetClickCallback(GameObject go, LuaFunction cb)
	{
		UIEventListener.Get(go).onClick = delegate(GameObject g)
		{
			cb.Call(new object[]
			{
				go
			});
		};
	}

	public static void SetPressCallback(GameObject go, LuaFunction cb)
	{
		UIEventListener.Get(go).onPress = delegate(GameObject g, bool press)
		{
			cb.Call(new object[]
			{
				g,
				press
			});
		};
	}

	public static void SetDragCallback(GameObject go, LuaFunction cb)
	{
		UIEventListener.Get(go).onDrag = delegate(GameObject g, Vector2 delta)
		{
			cb.Call(new object[]
			{
				g,
				delta.x,
				delta.y
			});
		};
	}

	public static void SetSubmmitCallback(GameObject go, LuaFunction cb)
	{
		UIEventListener.Get(go).onSubmit = delegate(GameObject g)
		{
			cb.Call(new object[]
			{
				g
			});
		};
	}

	public static void InitWrapContent(GameObject goWrapContent, LuaFunction cb)
	{
		IXUIWrapContent iXUIWrapContent = goWrapContent.GetComponent("XUIWrapContent") as IXUIWrapContent;
		iXUIWrapContent.RegisterItemUpdateEventHandler(delegate(Transform t, int index)
		{
			cb.Call(new object[]
			{
				t,
				index
			});
		});
	}

	public static void SetWrapContentCount(GameObject goWrapContent, int wrapCount, bool bResetPosition)
	{
		IXUIWrapContent iXUIWrapContent = goWrapContent.GetComponent("XUIWrapContent") as IXUIWrapContent;
		iXUIWrapContent.SetContentCount(wrapCount, false);
		if (bResetPosition)
		{
			IXUIScrollView iXUIScrollView = goWrapContent.transform.parent.GetComponent("XUIScrollView") as IXUIScrollView;
			iXUIScrollView.ResetPosition();
		}
	}

	public static XUIPool SetupPool(GameObject parent, GameObject tpl, uint Count)
	{
		XUIPool xUIPool = new XUIPool(null);
		xUIPool.SetupPool(parent, tpl, Count, false);
		return xUIPool;
	}

	public static void DrawItemView(GameObject goItemView, int itemID, int count, bool showCount)
	{
		if (Hotfix.m_itemDrawer == null || Hotfix.m_itemDrawer.Deprecated)
		{
			Hotfix.m_itemDrawer = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXNormalItemDrawer>(XSingleton<XCommon>.singleton.XHash("IXNormalItemDrawer"));
		}
		if (Hotfix.m_itemDrawer == null)
		{
			UnityEngine.Debug.LogError("IXNormalItemDrawer is null");
		}
		else
		{
			Hotfix.m_itemDrawer.DrawItem(goItemView, itemID, count, showCount);
		}
	}

	public static void SetTexture(UITexture text, string localtion, bool makepiexl)
	{
		text.mainTexture = XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<Texture>(localtion, ".png", true);
		if (makepiexl)
		{
			text.MakePixelPerfect();
		}
	}

	public static void DestoryTexture(UITexture uitex, string location)
	{
		if (uitex != null)
		{
			Texture mainTexture = uitex.mainTexture;
			if (mainTexture != null)
			{
				uitex.mainTexture = null;
				XSingleton<XResourceLoaderMgr>.singleton.DestroyShareResource(location, mainTexture);
			}
		}
	}

	public static void EnableMainDummy(bool enable, UIDummy snapShot)
	{
		if (Hotfix.m_avatarMgr == null || Hotfix.m_avatarMgr.Deprecated)
		{
			Hotfix.m_avatarMgr = XSingleton<XInterfaceMgr>.singleton.GetInterface<IX3DAvatarMgr>(XSingleton<XCommon>.singleton.XHash("IX3DAvatarMgr"));
		}
		Hotfix.m_avatarMgr.EnableMainDummy(enable, snapShot);
	}

	public static void SetMainDummy(bool ui)
	{
		if (Hotfix.m_avatarMgr == null || Hotfix.m_avatarMgr.Deprecated)
		{
			Hotfix.m_avatarMgr = XSingleton<XInterfaceMgr>.singleton.GetInterface<IX3DAvatarMgr>(XSingleton<XCommon>.singleton.XHash("IX3DAvatarMgr"));
		}
		Hotfix.m_avatarMgr.SetMainDummy(ui);
	}

	public static XAnimationClip SetMainAnimation(string anim)
	{
		if (Hotfix.m_avatarMgr == null || Hotfix.m_avatarMgr.Deprecated)
		{
			Hotfix.m_avatarMgr = XSingleton<XInterfaceMgr>.singleton.GetInterface<IX3DAvatarMgr>(XSingleton<XCommon>.singleton.XHash("IX3DAvatarMgr"));
		}
		return Hotfix.m_avatarMgr.SetMainAnimation(anim);
	}

	public static void ResetMainAnimation()
	{
		if (Hotfix.m_avatarMgr == null || Hotfix.m_avatarMgr.Deprecated)
		{
			Hotfix.m_avatarMgr = XSingleton<XInterfaceMgr>.singleton.GetInterface<IX3DAvatarMgr>(XSingleton<XCommon>.singleton.XHash("IX3DAvatarMgr"));
		}
		Hotfix.m_avatarMgr.ResetMainAnimation();
	}

	public static string CreateCommonDummy(int dummyPool, uint presentID, IUIDummy snapShot, float scale)
	{
		if (Hotfix.m_avatarMgr == null || Hotfix.m_avatarMgr.Deprecated)
		{
			Hotfix.m_avatarMgr = XSingleton<XInterfaceMgr>.singleton.GetInterface<IX3DAvatarMgr>(XSingleton<XCommon>.singleton.XHash("IX3DAvatarMgr"));
		}
		return Hotfix.m_avatarMgr.CreateCommonDummy(dummyPool, presentID, snapShot, null, scale);
	}

	public void SetDummyAnim(int dummyPool, string idStr, string anim)
	{
		if (Hotfix.m_avatarMgr == null || Hotfix.m_avatarMgr.Deprecated)
		{
			Hotfix.m_avatarMgr = XSingleton<XInterfaceMgr>.singleton.GetInterface<IX3DAvatarMgr>(XSingleton<XCommon>.singleton.XHash("IX3DAvatarMgr"));
		}
		Hotfix.m_avatarMgr.SetDummyAnim(dummyPool, idStr, anim);
	}

	public void SetMainDummyAnim(string anim)
	{
		if (Hotfix.m_avatarMgr == null || Hotfix.m_avatarMgr.Deprecated)
		{
			Hotfix.m_avatarMgr = XSingleton<XInterfaceMgr>.singleton.GetInterface<IX3DAvatarMgr>(XSingleton<XCommon>.singleton.XHash("IX3DAvatarMgr"));
		}
		Hotfix.m_avatarMgr.SetMainDummyAnim(anim);
	}

	public static void DestroyDummy(int dummyPool, string idStr)
	{
		if (Hotfix.m_avatarMgr == null || Hotfix.m_avatarMgr.Deprecated)
		{
			Hotfix.m_avatarMgr = XSingleton<XInterfaceMgr>.singleton.GetInterface<IX3DAvatarMgr>(XSingleton<XCommon>.singleton.XHash("IX3DAvatarMgr"));
		}
		Hotfix.m_avatarMgr.DestroyDummy(dummyPool, idStr);
	}

	public static object ParseSeq(object t, int index, int key)
	{
		if (t.GetType() == typeof(Seq2ListRef<uint>))
		{
			Seq2ListRef<uint> seq2ListRef = (Seq2ListRef<uint>)t;
			int num = CVSReader.indexBuffer[seq2ListRef.indexOffset + index];
			return Seq2ListRef<uint>.buffRef[num + key];
		}
		if (t.GetType() == typeof(Seq2ListRef<int>))
		{
			Seq2ListRef<int> seq2ListRef2 = (Seq2ListRef<int>)t;
			int num2 = CVSReader.indexBuffer[seq2ListRef2.indexOffset + index];
			return Seq2ListRef<int>.buffRef[num2 + key];
		}
		if (t.GetType() == typeof(Seq2ListRef<float>))
		{
			Seq2ListRef<float> seq2ListRef3 = (Seq2ListRef<float>)t;
			int num3 = CVSReader.indexBuffer[seq2ListRef3.indexOffset + index];
			return Seq2ListRef<float>.buffRef[num3 + key];
		}
		Seq2ListRef<string> seq2ListRef4 = (Seq2ListRef<string>)t;
		int num4 = CVSReader.indexBuffer[seq2ListRef4.indexOffset + index];
		return Seq2ListRef<string>.buffRef[num4 + key];
	}

	public static ulong TransInt64(string a)
	{
		ulong result = 0uL;
		ulong.TryParse(a, out result);
		return result;
	}

	public static string TansString(ulong o)
	{
		return o.ToString();
	}

	public static string OpInit64(string a, string b, int op)
	{
		ulong num = 0uL;
		ulong num2 = 0uL;
		ulong.TryParse(a, out num);
		ulong.TryParse(b, out num2);
		ulong num3 = 0uL;
		switch (op)
		{
		case 0:
			num3 = num + num2;
			break;
		case 1:
			num3 = num - num2;
			break;
		case 2:
			num3 = num * num2;
			break;
		case 3:
			num3 = num / num2;
			break;
		case 4:
			num3 = num % num2;
			break;
		}
		return num3.ToString();
	}

	public static void PrintBytes(byte[] bytes)
	{
		Hotfix.PrintBytes("LUA", bytes);
	}

	public static void PrintBytes(string tag, byte[] bytes, int length)
	{
	}

	public static void PrintBytes(string tag, byte[] bytes)
	{
	}
}
