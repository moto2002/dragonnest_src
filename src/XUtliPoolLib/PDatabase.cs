using MiniJSON;
using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	public class PDatabase : XSingleton<PDatabase>
	{
		public PlayerInfo playerInfo;

		public FriendInfo friendsInfo;

		public WXGroupInfo wxGroupInfo;

		public void HandleExData(string msg)
		{
			XSingleton<XDebug>.singleton.AddLog("[PDatabase]HandleExData msg" + msg, null, null, null, null, null, XDebugColor.XDebug_None);
			switch (this.GetApiId(msg))
			{
			case 1:
				this.SerialPlayerInfo(msg);
				return;
			case 2:
				this.SerialFriendsInfo(msg);
				return;
			case 3:
			case 4:
			case 5:
			case 10:
			case 11:
			case 13:
			case 14:
			case 15:
				break;
			case 6:
				this.SerialGuildGroupResult(msg);
				return;
			case 7:
				this.SerialGuildGroupInfo(msg);
				return;
			case 8:
				this.SerialGuildGroupResult(msg);
				return;
			case 9:
				this.SerialGuildGroupShare(msg);
				return;
			case 12:
				this.SerialHandleReplay(msg);
				return;
			case 16:
				this.SerialQQVipPayInfo(msg);
				return;
			case 17:
				this.SerialPaySubscribeInfo(msg);
				return;
			case 18:
				this.SerialMarketingInfo(msg);
				return;
			case 19:
				this.SerialGameCenterLaunch(msg);
				return;
			case 20:
				this.SerialHandle3DTouch(msg);
				return;
			case 21:
				this.SerialHandleScreenLock(msg);
				break;
			default:
				return;
			}
		}

		private int GetApiId(string msg)
		{
			Dictionary<string, object> dictionary = Json.Deserialize(msg) as Dictionary<string, object>;
			int result = 1;
			int.TryParse(dictionary["apiId"].ToString(), out result);
			return result;
		}

		public void SerialPlayerInfo(string msg)
		{
			this.playerInfo = XSingleton<PUtil>.singleton.Deserialize<PlayerInfo>(msg);
		}

		public void SerialFriendsInfo(string msg)
		{
			this.friendsInfo = XSingleton<PUtil>.singleton.Deserialize<FriendInfo>(msg);
			IUiUtility @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
			if (@interface == null)
			{
				XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialFriendsInfo entrance == null", null, null, null, null, null, XDebugColor.XDebug_None);
				return;
			}
			@interface.OnGetPlatFriendsInfo();
		}

		public void SerialGuildGroupResult(string msg)
		{
			XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupResult msg" + msg, null, null, null, null, null, XDebugColor.XDebug_None);
			WXGroupResult wXGroupResult = XSingleton<PUtil>.singleton.Deserialize<WXGroupResult>(msg);
			if (wXGroupResult == null)
			{
				XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupResult wxGroupResult == null", null, null, null, null, null, XDebugColor.XDebug_None);
				return;
			}
			IGuildGroup @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IGuildGroup>(XSingleton<XCommon>.singleton.XHash("IGuildGroup"));
			if (@interface == null)
			{
				XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupResult entrance == null", null, null, null, null, null, XDebugColor.XDebug_None);
				return;
			}
			@interface.GuildGroupResult(wXGroupResult.apiId.ToString(), wXGroupResult.data.flag, wXGroupResult.data.errorCode);
		}

		public void SerialGuildGroupInfo(string msg)
		{
			XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupInfo msg" + msg, null, null, null, null, null, XDebugColor.XDebug_None);
			this.wxGroupInfo = XSingleton<PUtil>.singleton.Deserialize<WXGroupInfo>(msg);
			if (this.wxGroupInfo == null)
			{
				XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupInfo wxGroupInfo == null", null, null, null, null, null, XDebugColor.XDebug_None);
				return;
			}
			IGuildGroup @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IGuildGroup>(XSingleton<XCommon>.singleton.XHash("IGuildGroup"));
			if (@interface == null)
			{
				XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupInfo entrance == null", null, null, null, null, null, XDebugColor.XDebug_None);
				return;
			}
			@interface.RefreshWXGroupBtn();
		}

		public void SerialGuildGroupShare(string msg)
		{
			XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupShare msg" + msg, null, null, null, null, null, XDebugColor.XDebug_None);
			Dictionary<string, object> dictionary = Json.Deserialize(msg) as Dictionary<string, object>;
			if (dictionary == null)
			{
				XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupShare dict == null", null, null, null, null, null, XDebugColor.XDebug_None);
				return;
			}
			IGuildGroup @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IGuildGroup>(XSingleton<XCommon>.singleton.XHash("IGuildGroup"));
			if (@interface == null)
			{
				XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupShare entrance == null", null, null, null, null, null, XDebugColor.XDebug_None);
				return;
			}
			object obj = null;
			object obj2 = null;
			if (dictionary.TryGetValue("apiId", out obj) && dictionary.TryGetValue("data", out obj2))
			{
				XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupShare apiId & data", null, null, null, null, null, XDebugColor.XDebug_None);
				@interface.GuildGroupResult(obj.ToString(), obj2.ToString(), 0);
			}
			if (obj2 != null)
			{
				IUiUtility interface2 = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
				if (interface2 != null)
				{
					interface2.NoticeShareResult(obj2.ToString());
				}
			}
		}

		public void SerialQQVipPayInfo(string msg)
		{
			XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialQQVipPayInfo msg" + msg, null, null, null, null, null, XDebugColor.XDebug_None);
			Dictionary<string, object> dictionary = Json.Deserialize(msg) as Dictionary<string, object>;
			if (dictionary == null)
			{
				XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialQQVipPayInfo dict == null", null, null, null, null, null, XDebugColor.XDebug_None);
				return;
			}
			IUiUtility @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
			object obj;
			if (dictionary.TryGetValue("data", out obj))
			{
				Dictionary<string, object> dictionary2 = obj as Dictionary<string, object>;
				object obj2;
				if (dictionary2.TryGetValue("flag", out obj2) && @interface != null)
				{
					XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialQQVipPayInfo result =" + obj2.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
					@interface.OnQQVipPayCallback(obj2.ToString());
				}
			}
		}

		private void SerialGameCenterLaunch(string msg)
		{
			XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGameCenterLaunch msg" + msg, null, null, null, null, null, XDebugColor.XDebug_None);
			Dictionary<string, object> dictionary = Json.Deserialize(msg) as Dictionary<string, object>;
			if (dictionary == null)
			{
				XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGameCenterLaunch dict == null", null, null, null, null, null, XDebugColor.XDebug_None);
				return;
			}
			IUiUtility @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
			object obj;
			if (dictionary.TryGetValue("data", out obj) && @interface != null)
			{
				Dictionary<string, object> dictionary2 = obj as Dictionary<string, object>;
				object obj2 = null;
				if (dictionary2 != null && dictionary2.TryGetValue("wakeup_platform", out obj2))
				{
					XSingleton<XDebug>.singleton.AddLog("[SerialGameCenterLaunch] platform: " + obj2.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
					if ((long)obj2 == 1L)
					{
						XSingleton<XDebug>.singleton.AddLog("[SerialGameCenterLaunch] platform == 1", null, null, null, null, null, XDebugColor.XDebug_None);
						object obj3 = null;
						if (dictionary2.TryGetValue("wakeup_wx_extInfo", out obj3) && obj3.ToString() == "WX_GameCenter")
						{
							@interface.OnGameCenterWakeUp(3);
							XSingleton<XDebug>.singleton.AddLog("[SerialGameCenterLaunch] StartUpType.StartUp_WX", null, null, null, null, null, XDebugColor.XDebug_None);
							return;
						}
					}
					else if ((long)obj2 == 2L)
					{
						XSingleton<XDebug>.singleton.AddLog("[SerialGameCenterLaunch] platform == 2", null, null, null, null, null, XDebugColor.XDebug_None);
						object obj4 = null;
						if (dictionary2.TryGetValue("wakeup_qq_extInfo", out obj4) && obj4.ToString() == "sq_gamecenter")
						{
							@interface.OnGameCenterWakeUp(2);
							XSingleton<XDebug>.singleton.AddLog("[SerialGameCenterLaunch] StartUpType.StartUp_QQ", null, null, null, null, null, XDebugColor.XDebug_None);
						}
					}
				}
			}
		}

		private void SerialHandle3DTouch(string msg)
		{
			IUiUtility @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
			if (@interface != null)
			{
				@interface.SerialHandle3DTouch(msg);
			}
		}

		private void SerialHandleScreenLock(string msg)
		{
			IUiUtility @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
			if (@interface != null)
			{
				@interface.SerialHandleScreenLock(msg);
			}
		}

		private void SerialMarketingInfo(string msg)
		{
			XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo msg" + msg, null, null, null, null, null, XDebugColor.XDebug_None);
			Dictionary<string, object> dictionary = Json.Deserialize(msg) as Dictionary<string, object>;
			if (dictionary == null)
			{
				XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo dict == null", null, null, null, null, null, XDebugColor.XDebug_None);
				return;
			}
			IUiUtility @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
			object obj;
			if (dictionary.TryGetValue("data", out obj) && @interface != null)
			{
				XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo data", null, null, null, null, null, XDebugColor.XDebug_None);
				Dictionary<string, object> dictionary2 = obj as Dictionary<string, object>;
				object obj2;
				if (dictionary2 != null && dictionary2.TryGetValue("flag", out obj2))
				{
					XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo flag", null, null, null, null, null, XDebugColor.XDebug_None);
					object obj3;
					if (obj2.ToString() == "Success" && dictionary2 != null && dictionary2.TryGetValue("mpinfo", out obj3))
					{
						XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo mpinfo", null, null, null, null, null, XDebugColor.XDebug_None);
						List<object> list = obj3 as List<object>;
						if (list != null)
						{
							XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo array != null", null, null, null, null, null, XDebugColor.XDebug_None);
							List<PayMarketingInfo> list2 = new List<PayMarketingInfo>();
							for (int i = 0; i < list.Count; i++)
							{
								object obj4 = list[i];
								Dictionary<string, object> dictionary3 = obj4 as Dictionary<string, object>;
								PayMarketingInfo payMarketingInfo = new PayMarketingInfo();
								object obj5;
								if (dictionary3 != null && dictionary3.TryGetValue("num", out obj5))
								{
									XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo num = " + obj5.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
									payMarketingInfo.diamondCount = int.Parse(obj5.ToString());
								}
								object obj6;
								if (dictionary3 != null && dictionary3.TryGetValue("send_num", out obj6))
								{
									XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo send_num = " + obj6.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
									payMarketingInfo.sendCount = int.Parse(obj6.ToString());
								}
								object obj7;
								if (dictionary3 != null && dictionary3.TryGetValue("send_ext", out obj7))
								{
									XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo send_ext = " + obj7.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
									payMarketingInfo.sendExt = obj7.ToString();
								}
								list2.Add(payMarketingInfo);
							}
							@interface.OnPayMarketingInfo(list2);
						}
					}
				}
			}
		}

		private void SerialPaySubscribeInfo(string msg)
		{
			XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialPaySubscribeInfo msg" + msg, null, null, null, null, null, XDebugColor.XDebug_None);
			Dictionary<string, object> dictionary = Json.Deserialize(msg) as Dictionary<string, object>;
			if (dictionary == null)
			{
				XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialPaySubscribeInfo dict == null", null, null, null, null, null, XDebugColor.XDebug_None);
				return;
			}
			IUiUtility @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
			object obj;
			if (dictionary.TryGetValue("data", out obj))
			{
				Dictionary<string, object> dictionary2 = obj as Dictionary<string, object>;
				object obj2;
				if (dictionary2 != null && dictionary2.TryGetValue("flag", out obj2) && @interface != null)
				{
					XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialPaySubscribeInfo result =" + obj2.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
					@interface.OnPayCallback(obj2.ToString());
					return;
				}
			}
			if (@interface != null)
			{
				@interface.OnPayCallback("Failure");
			}
		}

		private void SerialHandleReplay(string msg)
		{
			IUiUtility @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
			if (@interface != null)
			{
				@interface.OnReplayStart();
			}
		}
	}
}
