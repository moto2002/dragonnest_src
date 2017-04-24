using Assets.SDK.JoyyouInput;
using System;
using System.Runtime.CompilerServices;

namespace Assets.SDK
{
	[InitAndroidSDKBUSSD(791000149, "Main Camera", "", false, true, true, false, true), InitAndroidTencent(1105309683, "xa0seqAScOhSsgrm", "wxfdab5af74990787a", "1450007239", "02a8d5ed226237996eb3f448dfac0b1c", "XGamePoint", null, false, true, true, false, false), InitSDOApple(1000, "Main Camera", false, true, true, false, true), InitSDOJailbreak(1000, "Main Camera", false, true, true, false, true), InitTencent(1105309683, "xa0seqAScOhSsgrm", "wxfdab5af74990787a", "1450007239", "02a8d5ed226237996eb3f448dfac0b1c", "XGamePoint", "", false, true, true, false, false), JoyYouSDKPlatformFilter("__Android_Tencent__")]
	public class JoyYouSDK : IShareDirector, IBaiduStat, I3RDPlatformSDK, I3RDPlatformSDKEX, IHuanlePlatform, IAdvertisement, IStatisticalData, IDeviceInfomation, IGameRecord
	{
		private enum eventType
		{
			nothing,
			eventStat,
			eventStart,
			eventEnd,
			pageStart,
			pageEnd,
			eventWithDuration
		}

		private static Joystick joystick;

		private static bool isSupported_IGameRecord;

		private bool isDelayInitDone;

		private static bool isInitialised;

		public static event IGameRecord_DelayInit doDelayInit
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				JoyYouSDK.doDelayInit = (IGameRecord_DelayInit)Delegate.Combine(JoyYouSDK.doDelayInit, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				JoyYouSDK.doDelayInit = (IGameRecord_DelayInit)Delegate.Remove(JoyYouSDK.doDelayInit, value);
			}
		}

		static JoyYouSDK()
		{
			SDKParams.Parse(typeof(JoyYouSDK));
		}

		void I3RDPlatformSDK.ShowLoginView()
		{
			if (JoyYouSDK.isInitialised)
			{
				JoyYouNativeInterface.ShowLoginView();
			}
		}

		void I3RDPlatformSDK.ShowLoginViewWithType(int type)
		{
			if (JoyYouSDK.isInitialised)
			{
				JoyYouNativeInterface.ShowLoginViewWithType(type);
			}
		}

		void I3RDPlatformSDK.Logout()
		{
			if (JoyYouSDK.isInitialised)
			{
				JoyYouNativeInterface.Logout();
			}
		}

		void I3RDPlatformSDK.Pay(int price, string billNo, string billTitle, string roleId, int zoneId)
		{
			if (JoyYouSDK.isInitialised)
			{
				JoyYouNativeInterface.ExchangeGoods(price, billNo, billTitle, roleId, zoneId);
			}
		}

		void I3RDPlatformSDK.ShowCenterView()
		{
			if (JoyYouSDK.isInitialised)
			{
				JoyYouNativeInterface.ShowCenterView();
			}
		}

		void I3RDPlatformSDKEX.SendGameExtData(string type, string jsonData)
		{
			if (JoyYouSDK.isInitialised)
			{
				JoyYouNativeInterface.SendGameExtData(type, jsonData);
			}
		}

		bool I3RDPlatformSDKEX.CheckStatus(string type, string jsonData)
		{
			bool result = true;
			if (JoyYouSDK.isInitialised)
			{
				result = JoyYouNativeInterface.CheckStatus(type, jsonData);
			}
			return result;
		}

		string I3RDPlatformSDKEX.GetSDKConfig(string type, string jsonData)
		{
			string result = string.Empty;
			if (JoyYouSDK.isInitialised)
			{
				result = JoyYouNativeInterface.GetSDKConfig(type, jsonData);
			}
			return result;
		}

		void I3RDPlatformSDKEX.QuitGame(string paramString)
		{
			if (JoyYouSDK.isInitialised)
			{
				JoyYouNativeInterface.QuitGame(paramString);
			}
		}

		void I3RDPlatformSDKEX.ShowFloatToolkit(bool visible, double x, double y)
		{
			if (JoyYouSDK.isInitialised)
			{
				JoyYouNativeInterface.ShowFloatToolkit(visible, x, y);
			}
		}

		void I3RDPlatformSDKEX.RequestRealUserRegister(string uid, bool IsQuery)
		{
			if (JoyYouSDK.isInitialised)
			{
				JoyYouNativeInterface.RequestRealUserRegister(uid, IsQuery);
			}
		}

		void IAdvertisement.CreateBanner(int x, int y, int width, int height, ADV_SIZE size, string content)
		{
			JoyYouNativeInterface.AdvCreateBanner(x, y, width, height, size, content);
		}

		void IAdvertisement.BannerRefresh(int second)
		{
			JoyYouNativeInterface.AdvBannerRefresh(second);
		}

		void IAdvertisement.RemoveBanner()
		{
			JoyYouNativeInterface.AdvRemoveBanner();
		}

		void IAdvertisement.getAdvIDFA()
		{
			JoyYouNativeInterface.getAdvIDFA();
		}

		void IBaiduStat.singleEventLog(string eventId, string eventLabel)
		{
			JoyYouNativeInterface.BaiduStat(1, eventId, eventLabel, 0);
		}

		void IBaiduStat.eventStart(string eventId, string eventLabel)
		{
			JoyYouNativeInterface.BaiduStat(2, eventId, eventLabel, 0);
		}

		void IBaiduStat.eventEnd(string eventId, string eventLabel)
		{
			JoyYouNativeInterface.BaiduStat(3, eventId, eventLabel, 0);
		}

		void IBaiduStat.eventWithDurationTime(string eventId, string eventLabel, int duration)
		{
			JoyYouNativeInterface.BaiduStat(6, eventId, eventLabel, duration);
		}

		void IBaiduStat.pageStart(string pageName)
		{
			JoyYouNativeInterface.BaiduStat(4, pageName, string.Empty, 0);
		}

		void IBaiduStat.pageEnd(string pageName)
		{
			JoyYouNativeInterface.BaiduStat(5, pageName, string.Empty, 0);
		}

		string IDeviceInfomation.GetMACAddress()
		{
			return JoyYouNativeInterface.GetMACAddress();
		}

		Joystick IDeviceInfomation.GetJoystick()
		{
			if (JoyYouSDK.joystick == null)
			{
				JoyYouSDK.joystick = new Joystick();
			}
			return JoyYouSDK.joystick;
		}

		void IDeviceInfomation.ProcessJoystick(string message)
		{
			((IDeviceInfomation)this).GetJoystick().ParserPhysicMessage(message);
		}

		void IGameRecord.PauseRecording()
		{
			if (JoyYouSDK.isSupported_IGameRecord)
			{
				this.doIGameRecord_DelayInit();
				JoyYouNativeInterface.GameRecordItf_PauseRecording();
			}
		}

		void IGameRecord.ResumeRecording()
		{
			if (JoyYouSDK.isSupported_IGameRecord)
			{
				this.doIGameRecord_DelayInit();
				JoyYouNativeInterface.GameRecordItf_ResumeRecording();
			}
		}

		void IGameRecord.StartRecording()
		{
			if (JoyYouSDK.isSupported_IGameRecord)
			{
				this.doIGameRecord_DelayInit();
				JoyYouNativeInterface.GameRecordItf_StartRecording();
			}
		}

		void IGameRecord.StopRecording()
		{
			if (JoyYouSDK.isSupported_IGameRecord)
			{
				this.doIGameRecord_DelayInit();
				JoyYouNativeInterface.GameRecordItf_StopRecording();
			}
		}

		void IGameRecord.ShowControlBar(bool visible)
		{
			if (JoyYouSDK.isSupported_IGameRecord)
			{
				this.doIGameRecord_DelayInit();
				JoyYouNativeInterface.GameRecordItf_ShowCtrlBar(visible);
			}
		}

		void IGameRecord.ShowWelfareCenter()
		{
			if (JoyYouSDK.isSupported_IGameRecord)
			{
				this.doIGameRecord_DelayInit();
				JoyYouNativeInterface.GameRecordItf_ShowWelfareCenter();
			}
		}

		void IGameRecord.ShowVideoStore()
		{
			if (JoyYouSDK.isSupported_IGameRecord)
			{
				this.doIGameRecord_DelayInit();
				JoyYouNativeInterface.GameRecordItf_ShowVideoStore();
			}
		}

		void IGameRecord.ShowPlayerClub()
		{
			if (JoyYouSDK.isSupported_IGameRecord)
			{
				this.doIGameRecord_DelayInit();
				JoyYouNativeInterface.GameRecordItf_ShowPlayerClub();
			}
		}

		void IHuanlePlatform.HLRegister(string username, string password, string email)
		{
			JoyYouNativeInterface.HLRegister(username, password, email);
		}

		void IHuanlePlatform.HLLogin(string username, string password)
		{
			JoyYouNativeInterface.HLLogin(username, password);
		}

		void IHuanlePlatform.HLLogout()
		{
			JoyYouNativeInterface.HLLogout();
		}

		void IHuanlePlatform.HLResendAppstoreReceiptDataForRole(string roleId)
		{
			JoyYouNativeInterface.HLResendAppstoreReceiptDataForRole(roleId);
		}

		void IShareDirector.ShareTimeline(SHARE_TYPE type, string title, string description, string imageURI)
		{
			JoyYouNativeInterface.ShareTimeline((int)type, title, description, imageURI);
		}

		void IStatisticalData.setLogEnable(bool bEnable)
		{
			JoyYouNativeInterface.setLogEnable_StatisticalDataItf(bEnable);
		}

		void IStatisticalData.initAppCPA(string appId, string channelId)
		{
			JoyYouNativeInterface.initAppCPA(appId, channelId);
		}

		void IStatisticalData.onRegister(string userId)
		{
			JoyYouNativeInterface.onRegister(userId);
		}

		void IStatisticalData.onLogin(string userId)
		{
			JoyYouNativeInterface.onLogin(userId);
		}

		void IStatisticalData.onPay(string userId, string orderId, int amount, string currency)
		{
			JoyYouNativeInterface.onPay(userId, orderId, amount, currency);
		}

		void IStatisticalData.initStatisticalGame(string appId, string partnerId)
		{
			JoyYouNativeInterface.initStatisticalGame(appId, partnerId);
		}

		bool IStatisticalData.isStandaloneGame()
		{
			return JoyYouNativeInterface.isStandaloneGame();
		}

		void IStatisticalData.setStandaloneGame(bool isSG)
		{
			JoyYouNativeInterface.setStandaloneGame(isSG);
		}

		void IStatisticalData.initAccount(string accountId)
		{
			JoyYouNativeInterface.initAccount(accountId);
		}

		void IStatisticalData.setAccountType(GameAccountType type)
		{
			JoyYouNativeInterface.setAccountType(type);
		}

		void IStatisticalData.setAccountName(string name)
		{
			JoyYouNativeInterface.setAccountName(name);
		}

		void IStatisticalData.setAccountLevel(int level)
		{
			JoyYouNativeInterface.setAccountLevel(level);
		}

		void IStatisticalData.setAccountGameServer(string gameServer)
		{
			JoyYouNativeInterface.setAccountGameServer(gameServer);
		}

		void IStatisticalData.setAccountGender(GameGender gender)
		{
			JoyYouNativeInterface.setAccountGender(gender);
		}

		void IStatisticalData.setAccountAge(int age)
		{
			JoyYouNativeInterface.setAccountAge(age);
		}

		void IStatisticalData.accountPay(string messageId, string status, string accountID, string orderID, double currencyAmount, string currencyType, double virtualCurrencyAmount, long chargeTime, string iapID, string paymentType, string gameServer, string gameVersion, int level, string mission)
		{
			JoyYouNativeInterface.accountPay(messageId, status, accountID, orderID, currencyAmount, currencyType, virtualCurrencyAmount, chargeTime, iapID, paymentType, gameServer, gameVersion, level, mission);
		}

		void IStatisticalData.onAccountPurchase(string item, int itemNumber, double priceInVirtualCurrency)
		{
			JoyYouNativeInterface.onAccountPurchase(item, itemNumber, priceInVirtualCurrency);
		}

		void IStatisticalData.onAccountUse(string item, int itemNumber)
		{
			JoyYouNativeInterface.onAccountUse(item, itemNumber);
		}

		void IStatisticalData.onAccountMissionBegin(string missionId)
		{
			JoyYouNativeInterface.onAccountMissionBegin(missionId);
		}

		void IStatisticalData.onAccountMissionCompleted(string missionId)
		{
			JoyYouNativeInterface.onAccountMissionCompleted(missionId);
		}

		void IStatisticalData.onAccountMissionFailed(string missionId, string cause)
		{
			JoyYouNativeInterface.onAccountMissionFailed(missionId, cause);
		}

		void IStatisticalData.onAccountCurrencyReward(double virtualCurrencyAmount, string reason)
		{
			JoyYouNativeInterface.onAccountCurrencyReward(virtualCurrencyAmount, reason);
		}

		private void doIGameRecord_DelayInit()
		{
			if (!this.isDelayInitDone && JoyYouSDK.doDelayInit != null)
			{
				try
				{
					JoyYouSDK.doDelayInit();
					this.isDelayInitDone = true;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.StackTrace);
				}
			}
		}

		public static void AddEventObs(IGameRecord_DelayInit ds)
		{
			JoyYouSDK.doDelayInit = (IGameRecord_DelayInit)Delegate.Combine(JoyYouSDK.doDelayInit, ds);
		}
	}
}
