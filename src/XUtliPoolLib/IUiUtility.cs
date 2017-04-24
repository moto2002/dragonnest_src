using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IUiUtility : IXInterface
	{
		void ShowSystemTip(string text, string rgb = "fece00");

		void ShowSystemTip(int errcode, string rgb = "fece00");

		void ShowItemAccess(int itemid, AccessCallback callback = null);

		void ShowTooltipDialog(int itemID, GameObject icon = null);

		void ShowDetailTooltip(int itemID, GameObject icon = null);

		void ShowTooltipDialogByUID(string strUID, GameObject icon = null);

		string GlobalConfigGetValue(string cfgName);

		void OnPayCallback(string msg);

		void OnQQVipPayCallback(string msg);

		void OnReplayStart();

		void PushBarrage(string nick, string content);

		void StartBroadcast(bool start);

		void OnGameCenterWakeUp(int type);

		void OnPayMarketingInfo(List<PayMarketingInfo> listInfo);

		void OnGetPlatFriendsInfo();

		void SerialHandle3DTouch(string msg);

		void SerialHandleScreenLock(string msg);

		string GetPartitionId();

		string GetRoleId();

		void OnSetBg(bool on);

		void OnSetWebViewMenu(int menutype);

		void OnWebViewBackGame(int backtype);

		void OnWebViewRefershRefPoint(string jsonstr);

		void OnWebViewSetheaderInfo(string jsonstr);

		void OnWebViewCloseLoading(int show);

		void OnWebViewShowReconnect(int show);

		void OnWebViewClose();

		void OnWebViewLiveTab();

		void ShowPandoraPopView(bool bShow);

		void NoticeShareResult(string result);

		bool CheckQQInstalled();

		bool CheckWXInstalled();
	}
}
