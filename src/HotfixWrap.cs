using LuaInterface;
using System;
using System.IO;
using UILib;
using UnityEngine;
using XUtliPoolLib;

public class HotfixWrap
{
	private static Type classType = typeof(Hotfix);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Init", new LuaCSFunction(HotfixWrap.Init)),
			new LuaMethod("LuaWait", new LuaCSFunction(HotfixWrap.LuaWait)),
			new LuaMethod("LuaLoop", new LuaCSFunction(HotfixWrap.LuaLoop)),
			new LuaMethod("RemoveTimer", new LuaCSFunction(HotfixWrap.RemoveTimer)),
			new LuaMethod("SendLuaPtc", new LuaCSFunction(HotfixWrap.SendLuaPtc)),
			new LuaMethod("SendLuaBytePtc", new LuaCSFunction(HotfixWrap.SendLuaBytePtc)),
			new LuaMethod("RegistNotifyID", new LuaCSFunction(HotfixWrap.RegistNotifyID)),
			new LuaMethod("RegistPtc", new LuaCSFunction(HotfixWrap.RegistPtc)),
			new LuaMethod("RegisterLuaRPC", new LuaCSFunction(HotfixWrap.RegisterLuaRPC)),
			new LuaMethod("SendLuaRPC", new LuaCSFunction(HotfixWrap.SendLuaRPC)),
			new LuaMethod("SendLuaRPCWithReq", new LuaCSFunction(HotfixWrap.SendLuaRPCWithReq)),
			new LuaMethod("SendLuaByteRPC", new LuaCSFunction(HotfixWrap.SendLuaByteRPC)),
			new LuaMethod("SendLuaByteRPCWithReq", new LuaCSFunction(HotfixWrap.SendLuaByteRPCWithReq)),
			new LuaMethod("LuaMessageBoxConfirm", new LuaCSFunction(HotfixWrap.LuaMessageBoxConfirm)),
			new LuaMethod("LuaShowSystemTip", new LuaCSFunction(HotfixWrap.LuaShowSystemTip)),
			new LuaMethod("LuaShowSystemTipErrCode", new LuaCSFunction(HotfixWrap.LuaShowSystemTipErrCode)),
			new LuaMethod("LuaShowItemAccess", new LuaCSFunction(HotfixWrap.LuaShowItemAccess)),
			new LuaMethod("LuaShowItemTooltipDialog", new LuaCSFunction(HotfixWrap.LuaShowItemTooltipDialog)),
			new LuaMethod("LuaShowDetailTooltipDialog", new LuaCSFunction(HotfixWrap.LuaShowDetailTooltipDialog)),
			new LuaMethod("LuaShowItemTooltipDialogByUID", new LuaCSFunction(HotfixWrap.LuaShowItemTooltipDialogByUID)),
			new LuaMethod("SetPlayer", new LuaCSFunction(HotfixWrap.SetPlayer)),
			new LuaMethod("GetPlayer", new LuaCSFunction(HotfixWrap.GetPlayer)),
			new LuaMethod("CallPlayerMethod", new LuaCSFunction(HotfixWrap.CallPlayerMethod)),
			new LuaMethod("SetDocumentMember", new LuaCSFunction(HotfixWrap.SetDocumentMember)),
			new LuaMethod("GetDocumentMember", new LuaCSFunction(HotfixWrap.GetDocumentMember)),
			new LuaMethod("GetGetDocumentLongMember", new LuaCSFunction(HotfixWrap.GetGetDocumentLongMember)),
			new LuaMethod("GetDocumentStaticMember", new LuaCSFunction(HotfixWrap.GetDocumentStaticMember)),
			new LuaMethod("CallDocumentMethod", new LuaCSFunction(HotfixWrap.CallDocumentMethod)),
			new LuaMethod("CallDocumentLongMethod", new LuaCSFunction(HotfixWrap.CallDocumentLongMethod)),
			new LuaMethod("CallDocumentStaticMethod", new LuaCSFunction(HotfixWrap.CallDocumentStaticMethod)),
			new LuaMethod("GetSingleMember", new LuaCSFunction(HotfixWrap.GetSingleMember)),
			new LuaMethod("GetSingleLongMember", new LuaCSFunction(HotfixWrap.GetSingleLongMember)),
			new LuaMethod("SetSingleMember", new LuaCSFunction(HotfixWrap.SetSingleMember)),
			new LuaMethod("CallSingleMethod", new LuaCSFunction(HotfixWrap.CallSingleMethod)),
			new LuaMethod("CallSingleLongMethod", new LuaCSFunction(HotfixWrap.CallSingleLongMethod)),
			new LuaMethod("GetEnumType", new LuaCSFunction(HotfixWrap.GetEnumType)),
			new LuaMethod("GetStringTable", new LuaCSFunction(HotfixWrap.GetStringTable)),
			new LuaMethod("GetGlobalString", new LuaCSFunction(HotfixWrap.GetGlobalString)),
			new LuaMethod("GetObjectString", new LuaCSFunction(HotfixWrap.GetObjectString)),
			new LuaMethod("GetLuaLong", new LuaCSFunction(HotfixWrap.GetLuaLong)),
			new LuaMethod("RefreshPlayerName", new LuaCSFunction(HotfixWrap.RefreshPlayerName)),
			new LuaMethod("OpenSys", new LuaCSFunction(HotfixWrap.OpenSys)),
			new LuaMethod("AttachSysRedPointRelative", new LuaCSFunction(HotfixWrap.AttachSysRedPointRelative)),
			new LuaMethod("AttachSysRedPointRelativeUI", new LuaCSFunction(HotfixWrap.AttachSysRedPointRelativeUI)),
			new LuaMethod("DetachSysRedPointRelative", new LuaCSFunction(HotfixWrap.DetachSysRedPointRelative)),
			new LuaMethod("DetachSysRedPointRelativeUI", new LuaCSFunction(HotfixWrap.DetachSysRedPointRelativeUI)),
			new LuaMethod("ForceUpdateSysRedPointImmediately", new LuaCSFunction(HotfixWrap.ForceUpdateSysRedPointImmediately)),
			new LuaMethod("GetSysRedPointState", new LuaCSFunction(HotfixWrap.GetSysRedPointState)),
			new LuaMethod("LuaDoFile", new LuaCSFunction(HotfixWrap.LuaDoFile)),
			new LuaMethod("LuaGetFunction", new LuaCSFunction(HotfixWrap.LuaGetFunction)),
			new LuaMethod("LuaTableBuffer", new LuaCSFunction(HotfixWrap.LuaTableBuffer)),
			new LuaMethod("LuaTableBin", new LuaCSFunction(HotfixWrap.LuaTableBin)),
			new LuaMethod("ReturnableStream", new LuaCSFunction(HotfixWrap.ReturnableStream)),
			new LuaMethod("ReadLong", new LuaCSFunction(HotfixWrap.ReadLong)),
			new LuaMethod("ReadFileSize", new LuaCSFunction(HotfixWrap.ReadFileSize)),
			new LuaMethod("CheckFileSize", new LuaCSFunction(HotfixWrap.CheckFileSize)),
			new LuaMethod("ReadRowSize", new LuaCSFunction(HotfixWrap.ReadRowSize)),
			new LuaMethod("CheckRowSize", new LuaCSFunction(HotfixWrap.CheckRowSize)),
			new LuaMethod("LuaProtoBuffer", new LuaCSFunction(HotfixWrap.LuaProtoBuffer)),
			new LuaMethod("LuaProtoBuffer1", new LuaCSFunction(HotfixWrap.LuaProtoBuffer1)),
			new LuaMethod("SetClickCallback", new LuaCSFunction(HotfixWrap.SetClickCallback)),
			new LuaMethod("SetPressCallback", new LuaCSFunction(HotfixWrap.SetPressCallback)),
			new LuaMethod("SetDragCallback", new LuaCSFunction(HotfixWrap.SetDragCallback)),
			new LuaMethod("SetSubmmitCallback", new LuaCSFunction(HotfixWrap.SetSubmmitCallback)),
			new LuaMethod("InitWrapContent", new LuaCSFunction(HotfixWrap.InitWrapContent)),
			new LuaMethod("SetWrapContentCount", new LuaCSFunction(HotfixWrap.SetWrapContentCount)),
			new LuaMethod("SetupPool", new LuaCSFunction(HotfixWrap.SetupPool)),
			new LuaMethod("DrawItemView", new LuaCSFunction(HotfixWrap.DrawItemView)),
			new LuaMethod("SetTexture", new LuaCSFunction(HotfixWrap.SetTexture)),
			new LuaMethod("DestoryTexture", new LuaCSFunction(HotfixWrap.DestoryTexture)),
			new LuaMethod("EnableMainDummy", new LuaCSFunction(HotfixWrap.EnableMainDummy)),
			new LuaMethod("SetMainDummy", new LuaCSFunction(HotfixWrap.SetMainDummy)),
			new LuaMethod("SetMainAnimation", new LuaCSFunction(HotfixWrap.SetMainAnimation)),
			new LuaMethod("ResetMainAnimation", new LuaCSFunction(HotfixWrap.ResetMainAnimation)),
			new LuaMethod("CreateCommonDummy", new LuaCSFunction(HotfixWrap.CreateCommonDummy)),
			new LuaMethod("SetDummyAnim", new LuaCSFunction(HotfixWrap.SetDummyAnim)),
			new LuaMethod("SetMainDummyAnim", new LuaCSFunction(HotfixWrap.SetMainDummyAnim)),
			new LuaMethod("DestroyDummy", new LuaCSFunction(HotfixWrap.DestroyDummy)),
			new LuaMethod("ParseSeq", new LuaCSFunction(HotfixWrap.ParseSeq)),
			new LuaMethod("TransInt64", new LuaCSFunction(HotfixWrap.TransInt64)),
			new LuaMethod("TansString", new LuaCSFunction(HotfixWrap.TansString)),
			new LuaMethod("OpInit64", new LuaCSFunction(HotfixWrap.OpInit64)),
			new LuaMethod("PrintBytes", new LuaCSFunction(HotfixWrap.PrintBytes)),
			new LuaMethod("New", new LuaCSFunction(HotfixWrap._CreateHotfix)),
			new LuaMethod("GetClassType", new LuaCSFunction(HotfixWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("m_uiUtility", new LuaCSFunction(HotfixWrap.get_m_uiUtility), new LuaCSFunction(HotfixWrap.set_m_uiUtility)),
			new LuaField("luaExtion", new LuaCSFunction(HotfixWrap.get_luaExtion), null),
			new LuaField("GameSysMgr", new LuaCSFunction(HotfixWrap.get_GameSysMgr), null),
			new LuaField("onlineReTime", new LuaCSFunction(HotfixWrap.get_onlineReTime), null)
		};
		LuaScriptMgr.RegisterLib(L, "Hotfix", typeof(Hotfix), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateHotfix(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			Hotfix o = new Hotfix();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Hotfix.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, HotfixWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_m_uiUtility(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Hotfix.m_uiUtility);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_luaExtion(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Hotfix.luaExtion);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GameSysMgr(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Hotfix.GameSysMgr);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onlineReTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Hotfix.onlineReTime);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_m_uiUtility(IntPtr L)
	{
		Hotfix.m_uiUtility = (IUiUtility)LuaScriptMgr.GetNetObject(L, 3, typeof(IUiUtility));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
		Action finish;
		if (luaTypes != LuaTypes.LUA_TFUNCTION)
		{
			finish = (Action)LuaScriptMgr.GetNetObject(L, 1, typeof(Action));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 1);
			finish = delegate
			{
				func.Call();
			};
		}
		Hotfix.Init(finish);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaWait(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int delay = (int)LuaScriptMgr.GetNumber(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 2);
		int d = Hotfix.LuaWait(delay, luaFunction);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaLoop(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		int delay = (int)LuaScriptMgr.GetNumber(L, 1);
		int loop = (int)LuaScriptMgr.GetNumber(L, 2);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 3);
		int d = Hotfix.LuaLoop(delay, loop, luaFunction);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveTimer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int seq = (int)LuaScriptMgr.GetNumber(L, 1);
		Hotfix.RemoveTimer(seq);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SendLuaPtc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		uint type = (uint)LuaScriptMgr.GetNumber(L, 1);
		LuaStringBuffer stringBuffer = LuaScriptMgr.GetStringBuffer(L, 2);
		bool b = Hotfix.SendLuaPtc(type, stringBuffer);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SendLuaBytePtc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		uint type = (uint)LuaScriptMgr.GetNumber(L, 1);
		byte[] arrayNumber = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
		bool b = Hotfix.SendLuaBytePtc(type, arrayNumber);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegistNotifyID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Hotfix.RegistNotifyID();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegistPtc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		uint type = (uint)LuaScriptMgr.GetNumber(L, 1);
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		Hotfix.RegistPtc(type, boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegisterLuaRPC(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		uint type = (uint)LuaScriptMgr.GetNumber(L, 1);
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 3);
		LuaFunction luaFunction2 = LuaScriptMgr.GetLuaFunction(L, 4);
		Hotfix.RegisterLuaRPC(type, boolean, luaFunction, luaFunction2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SendLuaRPC(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		uint type = (uint)LuaScriptMgr.GetNumber(L, 1);
		LuaStringBuffer stringBuffer = LuaScriptMgr.GetStringBuffer(L, 2);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 3);
		LuaFunction luaFunction2 = LuaScriptMgr.GetLuaFunction(L, 4);
		Hotfix.SendLuaRPC(type, stringBuffer, luaFunction, luaFunction2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SendLuaRPCWithReq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		uint type = (uint)LuaScriptMgr.GetNumber(L, 1);
		LuaStringBuffer stringBuffer = LuaScriptMgr.GetStringBuffer(L, 2);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 3);
		LuaFunction luaFunction2 = LuaScriptMgr.GetLuaFunction(L, 4);
		Hotfix.SendLuaRPCWithReq(type, stringBuffer, luaFunction, luaFunction2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SendLuaByteRPC(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		uint type = (uint)LuaScriptMgr.GetNumber(L, 1);
		byte[] arrayNumber = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 3);
		LuaFunction luaFunction2 = LuaScriptMgr.GetLuaFunction(L, 4);
		Hotfix.SendLuaByteRPC(type, arrayNumber, luaFunction, luaFunction2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SendLuaByteRPCWithReq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		uint type = (uint)LuaScriptMgr.GetNumber(L, 1);
		byte[] arrayNumber = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 3);
		LuaFunction luaFunction2 = LuaScriptMgr.GetLuaFunction(L, 4);
		Hotfix.SendLuaByteRPCWithReq(type, arrayNumber, luaFunction, luaFunction2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaMessageBoxConfirm(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 2);
		LuaFunction luaFunction2 = LuaScriptMgr.GetLuaFunction(L, 3);
		Hotfix.LuaMessageBoxConfirm(luaString, luaFunction, luaFunction2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaShowSystemTip(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		Hotfix.LuaShowSystemTip(luaString);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaShowSystemTipErrCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int errCode = (int)LuaScriptMgr.GetNumber(L, 1);
		Hotfix.LuaShowSystemTipErrCode(errCode);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaShowItemAccess(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int itemID = (int)LuaScriptMgr.GetNumber(L, 1);
		Hotfix.LuaShowItemAccess(itemID);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaShowItemTooltipDialog(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int itemID = (int)LuaScriptMgr.GetNumber(L, 1);
		GameObject icon = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		Hotfix.LuaShowItemTooltipDialog(itemID, icon);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaShowDetailTooltipDialog(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int itemID = (int)LuaScriptMgr.GetNumber(L, 1);
		GameObject icon = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		Hotfix.LuaShowDetailTooltipDialog(itemID, icon);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaShowItemTooltipDialogByUID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		GameObject icon = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		Hotfix.LuaShowItemTooltipDialogByUID(luaString, icon);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPlayer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		Hotfix.SetPlayer(luaString, luaString2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPlayer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		object player = Hotfix.GetPlayer(luaString);
		LuaScriptMgr.PushVarObject(L, player);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallPlayerMethod(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		bool boolean = LuaScriptMgr.GetBoolean(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 3, num - 2);
		object o = Hotfix.CallPlayerMethod(boolean, luaString, paramsObject);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDocumentMember(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		object varObject = LuaScriptMgr.GetVarObject(L, 3);
		bool boolean = LuaScriptMgr.GetBoolean(L, 4);
		bool boolean2 = LuaScriptMgr.GetBoolean(L, 5);
		Hotfix.SetDocumentMember(luaString, luaString2, varObject, boolean, boolean2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDocumentMember(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		bool boolean = LuaScriptMgr.GetBoolean(L, 3);
		bool boolean2 = LuaScriptMgr.GetBoolean(L, 4);
		object documentMember = Hotfix.GetDocumentMember(luaString, luaString2, boolean, boolean2);
		LuaScriptMgr.PushVarObject(L, documentMember);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetGetDocumentLongMember(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		bool boolean = LuaScriptMgr.GetBoolean(L, 3);
		bool boolean2 = LuaScriptMgr.GetBoolean(L, 4);
		string getDocumentLongMember = Hotfix.GetGetDocumentLongMember(luaString, luaString2, boolean, boolean2);
		LuaScriptMgr.Push(L, getDocumentLongMember);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDocumentStaticMember(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		bool boolean = LuaScriptMgr.GetBoolean(L, 3);
		bool boolean2 = LuaScriptMgr.GetBoolean(L, 4);
		object documentStaticMember = Hotfix.GetDocumentStaticMember(luaString, luaString2, boolean, boolean2);
		LuaScriptMgr.PushVarObject(L, documentStaticMember);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallDocumentMethod(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 3);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 4, num - 3);
		object o = Hotfix.CallDocumentMethod(luaString, boolean, luaString2, paramsObject);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallDocumentLongMethod(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 3);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 4, num - 3);
		string str = Hotfix.CallDocumentLongMethod(luaString, boolean, luaString2, paramsObject);
		LuaScriptMgr.Push(L, str);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallDocumentStaticMethod(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 3);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 4, num - 3);
		object o = Hotfix.CallDocumentStaticMethod(luaString, boolean, luaString2, paramsObject);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSingleMember(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		bool boolean = LuaScriptMgr.GetBoolean(L, 3);
		bool boolean2 = LuaScriptMgr.GetBoolean(L, 4);
		bool boolean3 = LuaScriptMgr.GetBoolean(L, 5);
		object singleMember = Hotfix.GetSingleMember(luaString, luaString2, boolean, boolean2, boolean3);
		LuaScriptMgr.PushVarObject(L, singleMember);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSingleLongMember(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		bool boolean = LuaScriptMgr.GetBoolean(L, 3);
		bool boolean2 = LuaScriptMgr.GetBoolean(L, 4);
		bool boolean3 = LuaScriptMgr.GetBoolean(L, 5);
		string singleLongMember = Hotfix.GetSingleLongMember(luaString, luaString2, boolean, boolean2, boolean3);
		LuaScriptMgr.Push(L, singleLongMember);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetSingleMember(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 6);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		object varObject = LuaScriptMgr.GetVarObject(L, 3);
		bool boolean = LuaScriptMgr.GetBoolean(L, 4);
		bool boolean2 = LuaScriptMgr.GetBoolean(L, 5);
		bool boolean3 = LuaScriptMgr.GetBoolean(L, 6);
		Hotfix.SetSingleMember(luaString, luaString2, varObject, boolean, boolean2, boolean3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallSingleMethod(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		bool boolean2 = LuaScriptMgr.GetBoolean(L, 3);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 4);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 5, num - 4);
		object o = Hotfix.CallSingleMethod(luaString, boolean, boolean2, luaString2, paramsObject);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallSingleLongMethod(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		bool boolean2 = LuaScriptMgr.GetBoolean(L, 3);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 4);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 5, num - 4);
		string str = Hotfix.CallSingleLongMethod(luaString, boolean, boolean2, luaString2, paramsObject);
		LuaScriptMgr.Push(L, str);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetEnumType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		object enumType = Hotfix.GetEnumType(luaString, luaString2);
		LuaScriptMgr.PushVarObject(L, enumType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetStringTable(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 2, num - 1);
		string stringTable = Hotfix.GetStringTable(luaString, paramsObject);
		LuaScriptMgr.Push(L, stringTable);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetGlobalString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string globalString = Hotfix.GetGlobalString(luaString);
		LuaScriptMgr.Push(L, globalString);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetObjectString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		object varObject = LuaScriptMgr.GetVarObject(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		string objectString = Hotfix.GetObjectString(varObject, luaString);
		LuaScriptMgr.Push(L, objectString);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLuaLong(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		XLuaLong luaLong = Hotfix.GetLuaLong(luaString);
		LuaScriptMgr.PushObject(L, luaLong);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RefreshPlayerName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Hotfix.RefreshPlayerName();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OpenSys(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int sys = (int)LuaScriptMgr.GetNumber(L, 1);
		bool b = Hotfix.OpenSys(sys);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AttachSysRedPointRelative(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		int sys = (int)LuaScriptMgr.GetNumber(L, 1);
		int childSys = (int)LuaScriptMgr.GetNumber(L, 2);
		bool boolean = LuaScriptMgr.GetBoolean(L, 3);
		Hotfix.AttachSysRedPointRelative(sys, childSys, boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AttachSysRedPointRelativeUI(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int sys = (int)LuaScriptMgr.GetNumber(L, 1);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		Hotfix.AttachSysRedPointRelativeUI(sys, go);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DetachSysRedPointRelative(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int sys = (int)LuaScriptMgr.GetNumber(L, 1);
		Hotfix.DetachSysRedPointRelative(sys);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DetachSysRedPointRelativeUI(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int sys = (int)LuaScriptMgr.GetNumber(L, 1);
		Hotfix.DetachSysRedPointRelativeUI(sys);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ForceUpdateSysRedPointImmediately(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int sys = (int)LuaScriptMgr.GetNumber(L, 1);
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		Hotfix.ForceUpdateSysRedPointImmediately(sys, boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSysRedPointState(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int sys = (int)LuaScriptMgr.GetNumber(L, 1);
		bool sysRedPointState = Hotfix.GetSysRedPointState(sys);
		LuaScriptMgr.Push(L, sysRedPointState);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaDoFile(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		Hotfix.LuaDoFile(luaString);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaGetFunction(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		LuaFunction func = Hotfix.LuaGetFunction(luaString);
		LuaScriptMgr.Push(L, func);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaTableBuffer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string str = Hotfix.LuaTableBuffer(luaString);
		LuaScriptMgr.Push(L, str);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaTableBin(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		BinaryReader o = Hotfix.LuaTableBin(luaString);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReturnableStream(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader reader = (BinaryReader)LuaScriptMgr.GetNetObject(L, 1, typeof(BinaryReader));
		Hotfix.ReturnableStream(reader);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadLong(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader reader = (BinaryReader)LuaScriptMgr.GetNetObject(L, 1, typeof(BinaryReader));
		string str = Hotfix.ReadLong(reader);
		LuaScriptMgr.Push(L, str);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadFileSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader reader = (BinaryReader)LuaScriptMgr.GetNetObject(L, 1, typeof(BinaryReader));
		Hotfix.ReadFileSize(reader);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckFileSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		BinaryReader reader = (BinaryReader)LuaScriptMgr.GetNetObject(L, 1, typeof(BinaryReader));
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		Hotfix.CheckFileSize(reader, luaString);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadRowSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader reader = (BinaryReader)LuaScriptMgr.GetNetObject(L, 1, typeof(BinaryReader));
		Hotfix.ReadRowSize(reader);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckRowSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		BinaryReader reader = (BinaryReader)LuaScriptMgr.GetNetObject(L, 1, typeof(BinaryReader));
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		int lineno = (int)LuaScriptMgr.GetNumber(L, 3);
		Hotfix.CheckRowSize(reader, luaString, lineno);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaProtoBuffer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		byte[] arrayNumber = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
		int length = (int)LuaScriptMgr.GetNumber(L, 2);
		LuaStringBuffer lsb = Hotfix.LuaProtoBuffer(arrayNumber, length);
		LuaScriptMgr.Push(L, lsb);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaProtoBuffer1(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		byte[] arrayNumber = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
		int length = (int)LuaScriptMgr.GetNumber(L, 2);
		LuaStringBuffer lsb = Hotfix.LuaProtoBuffer1(arrayNumber, length);
		LuaScriptMgr.Push(L, lsb);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetClickCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 2);
		Hotfix.SetClickCallback(go, luaFunction);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPressCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 2);
		Hotfix.SetPressCallback(go, luaFunction);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDragCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 2);
		Hotfix.SetDragCallback(go, luaFunction);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetSubmmitCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 2);
		Hotfix.SetSubmmitCallback(go, luaFunction);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InitWrapContent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject goWrapContent = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 2);
		Hotfix.InitWrapContent(goWrapContent, luaFunction);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetWrapContentCount(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		GameObject goWrapContent = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		int wrapCount = (int)LuaScriptMgr.GetNumber(L, 2);
		bool boolean = LuaScriptMgr.GetBoolean(L, 3);
		Hotfix.SetWrapContentCount(goWrapContent, wrapCount, boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetupPool(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		GameObject parent = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		GameObject tpl = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		uint count = (uint)LuaScriptMgr.GetNumber(L, 3);
		XUIPool o = Hotfix.SetupPool(parent, tpl, count);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DrawItemView(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		GameObject goItemView = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		int itemID = (int)LuaScriptMgr.GetNumber(L, 2);
		int count = (int)LuaScriptMgr.GetNumber(L, 3);
		bool boolean = LuaScriptMgr.GetBoolean(L, 4);
		Hotfix.DrawItemView(goItemView, itemID, count, boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTexture(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UITexture text = (UITexture)LuaScriptMgr.GetUnityObject(L, 1, typeof(UITexture));
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		bool boolean = LuaScriptMgr.GetBoolean(L, 3);
		Hotfix.SetTexture(text, luaString, boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DestoryTexture(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UITexture uitex = (UITexture)LuaScriptMgr.GetUnityObject(L, 1, typeof(UITexture));
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		Hotfix.DestoryTexture(uitex, luaString);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EnableMainDummy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		bool boolean = LuaScriptMgr.GetBoolean(L, 1);
		UIDummy snapShot = (UIDummy)LuaScriptMgr.GetUnityObject(L, 2, typeof(UIDummy));
		Hotfix.EnableMainDummy(boolean, snapShot);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetMainDummy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		bool boolean = LuaScriptMgr.GetBoolean(L, 1);
		Hotfix.SetMainDummy(boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetMainAnimation(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		XAnimationClip obj = Hotfix.SetMainAnimation(luaString);
		LuaScriptMgr.Push(L, obj);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetMainAnimation(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Hotfix.ResetMainAnimation();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateCommonDummy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		int dummyPool = (int)LuaScriptMgr.GetNumber(L, 1);
		uint presentID = (uint)LuaScriptMgr.GetNumber(L, 2);
		IUIDummy snapShot = (IUIDummy)LuaScriptMgr.GetNetObject(L, 3, typeof(IUIDummy));
		float scale = (float)LuaScriptMgr.GetNumber(L, 4);
		string str = Hotfix.CreateCommonDummy(dummyPool, presentID, snapShot, scale);
		LuaScriptMgr.Push(L, str);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDummyAnim(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Hotfix hotfix = (Hotfix)LuaScriptMgr.GetNetObjectSelf(L, 1, "Hotfix");
		int dummyPool = (int)LuaScriptMgr.GetNumber(L, 2);
		string luaString = LuaScriptMgr.GetLuaString(L, 3);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 4);
		hotfix.SetDummyAnim(dummyPool, luaString, luaString2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetMainDummyAnim(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Hotfix hotfix = (Hotfix)LuaScriptMgr.GetNetObjectSelf(L, 1, "Hotfix");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		hotfix.SetMainDummyAnim(luaString);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DestroyDummy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int dummyPool = (int)LuaScriptMgr.GetNumber(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		Hotfix.DestroyDummy(dummyPool, luaString);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ParseSeq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		object varObject = LuaScriptMgr.GetVarObject(L, 1);
		int index = (int)LuaScriptMgr.GetNumber(L, 2);
		int key = (int)LuaScriptMgr.GetNumber(L, 3);
		object o = Hotfix.ParseSeq(varObject, index, key);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TransInt64(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		ulong d = Hotfix.TransInt64(luaString);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TansString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ulong o = (ulong)LuaScriptMgr.GetNumber(L, 1);
		string str = Hotfix.TansString(o);
		LuaScriptMgr.Push(L, str);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OpInit64(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		int op = (int)LuaScriptMgr.GetNumber(L, 3);
		string str = Hotfix.OpInit64(luaString, luaString2, op);
		LuaScriptMgr.Push(L, str);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PrintBytes(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			byte[] arrayNumber = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
			Hotfix.PrintBytes(arrayNumber);
			return 0;
		}
		if (num == 2)
		{
			string luaString = LuaScriptMgr.GetLuaString(L, 1);
			byte[] arrayNumber2 = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
			Hotfix.PrintBytes(luaString, arrayNumber2);
			return 0;
		}
		if (num == 3)
		{
			string luaString2 = LuaScriptMgr.GetLuaString(L, 1);
			byte[] arrayNumber3 = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
			int length = (int)LuaScriptMgr.GetNumber(L, 3);
			Hotfix.PrintBytes(luaString2, arrayNumber3, length);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Hotfix.PrintBytes");
		return 0;
	}
}
