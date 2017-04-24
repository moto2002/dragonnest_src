using System;
using UnityEngine;

namespace Assets.SDK
{
	public static class JoyYouNativeInterface
	{
		private const string IStatisticalData_native_objname = "__IStatisticalData";

		private const string IHuanleSDK_native_objname = "__ICommonSDKPlatform";

		private const string IDeviceInfo_native_objname = "__IDeviceInfomation";

		private const string IGameRecord_native_objname = "__IGameRecord";

		private const string IAdvertisement_native_objname = "__IAdvertisement";

		private const string _ITF_EX_ShareTimeLine = "__ShareTimeline__";

		private const string _ITF_EX_ShareSdkInit = "__ShareSdkInit__";

		private static string defaultAdvContentMSG = string.Empty;

		private static void U3D_initSDK(int appId, string appKey, bool logEnable, bool isLongConnect, bool rechargeEnable, int rechargeAmount, string closeRechargeAlertMessage, string paramSendMsgNotiClass, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown)
		{
			JoyYouNativeInterface.AndroidInvoke("__ICommonSDKPlatform", "Init", new object[]
			{
				appId,
				appKey,
				logEnable,
				isLongConnect,
				rechargeEnable,
				rechargeAmount,
				closeRechargeAlertMessage,
				paramSendMsgNotiClass,
				isOriPortrait,
				isOriLandscapeLeft,
				isOriLandscapeRight,
				isOriPortraitUpsideDown
			});
		}

		private static void U3D_showLoginView()
		{
			JoyYouNativeInterface.AndroidInvoke("__ICommonSDKPlatform", "Login", new object[]
			{
				null,
				string.Empty,
				string.Empty
			});
		}

		private static void U3D_showLoginViewWithType(int type)
		{
			JoyYouNativeInterface.AndroidInvoke("__ICommonSDKPlatform", "Login", new object[]
			{
				type
			});
		}

		private static void U3D_showCenterView()
		{
			JoyYouNativeInterface.AndroidInvoke("__ICommonSDKPlatform", "ShowUserCentered", new object[0]);
		}

		private static void U3D_exchangeGoods(int paramPrice, string paramBillNo, string paramBillTitle, string paramRoleId, int paramZoneId)
		{
			JoyYouNativeInterface.AndroidInvoke("__ICommonSDKPlatform", "PayGoods", new object[]
			{
				paramPrice,
				paramBillNo,
				paramBillTitle,
				paramRoleId,
				paramZoneId
			});
		}

		private static void U3D_logout()
		{
			JoyYouNativeInterface.AndroidInvoke("__ICommonSDKPlatform", "Logout", new object[0]);
		}

		public static void InitSDK(int appId, string appKey, bool logEnable, bool isLongConnect, bool rechargeEnable, int rechargeAmount, string closeRechargeAlertMsg, string notificationObjectName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.U3D_initSDK(appId, appKey, logEnable, isLongConnect, rechargeEnable, rechargeAmount, closeRechargeAlertMsg, notificationObjectName, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown);
			}
			else
			{
				JoyYouInterfaceSimulator.NotificationObjeName = notificationObjectName;
			}
		}

		public static void ShowLoginView()
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.U3D_showLoginView();
			}
			else
			{
				JoyYouInterfaceSimulator.ShowLoginView();
			}
		}

		public static void ShowLoginViewWithType(int type)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.U3D_showLoginViewWithType(type);
			}
			else
			{
				JoyYouInterfaceSimulator.ShowLoginViewWithType(type);
			}
		}

		public static void ShowCenterView()
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.U3D_showCenterView();
			}
			else
			{
				JoyYouInterfaceSimulator.ShowCenterView();
			}
		}

		public static void Logout()
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.U3D_logout();
			}
			else
			{
				JoyYouInterfaceSimulator.Logout();
			}
		}

		public static void ExchangeGoods(int price, string billNo, string billTitle, string roleId, int zoneId)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.U3D_exchangeGoods(price, billNo, billTitle, roleId, zoneId);
			}
			else
			{
				JoyYouInterfaceSimulator.Pay();
			}
		}

		public static void SendGameExtData(string type, string jsonData)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__ICommonSDKPlatform", "SendGameExtData", new object[]
				{
					type,
					jsonData
				});
			}
			else
			{
				JoyYouInterfaceSimulator.SendGameExtData(type, jsonData);
			}
		}

		public static bool CheckStatus(string type, string jsonData)
		{
			bool result;
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				result = JoyYouNativeInterface.AndroidInvoke<bool>("__ICommonSDKPlatform", "CheckStatus", new object[]
				{
					type,
					jsonData
				});
			}
			else
			{
				result = JoyYouInterfaceSimulator.CheckStatus(type, jsonData);
			}
			return result;
		}

		public static string GetSDKConfig(string type, string jsonData)
		{
			string result = string.Empty;
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				result = JoyYouNativeInterface.AndroidInvoke<string>("__ICommonSDKPlatform", "GetSDKConfig", new object[]
				{
					type,
					jsonData
				});
			}
			else
			{
				result = JoyYouInterfaceSimulator.GetSDKConfig(type, jsonData);
			}
			return result;
		}

		public static void ShareTimeline(int type, string title, string description, string imageURI)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				string format = "{{ \"type\":{0}, \"title\":\"{1}\", \"description\":\"{2}\", \"imageURI\":\"{3}\" }}";
				string jsonData = string.Format(format, new object[]
				{
					type,
					title,
					description,
					imageURI
				});
				JoyYouNativeInterface.SendGameExtData("__ShareTimeline__", jsonData);
			}
		}

		public static void ShowFloatToolkit(bool visible, double x, double y)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__ICommonSDKPlatform", "ShowFloatToolkit", new object[]
				{
					visible,
					x,
					y
				});
			}
		}

		public static void QuitGame(string paramString)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__ICommonSDKPlatform", "Release", new object[0]);
			}
			else
			{
				JoyYouInterfaceSimulator.QuitGame(paramString);
			}
		}

		public static void HLRegister(string username, string password, string email)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__ICommonSDKPlatform", "Register", new object[]
				{
					username,
					password,
					email
				});
			}
			else
			{
				JoyYouInterfaceSimulator.onRegister();
			}
		}

		public static void HLLogin(string username, string password)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__ICommonSDKPlatform", "Login", new object[]
				{
					username,
					password,
					string.Empty
				});
			}
			else
			{
				JoyYouInterfaceSimulator.ShowLoginView();
			}
		}

		public static void HLLogout()
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__ICommonSDKPlatform", "Logout", new object[0]);
			}
			else
			{
				JoyYouInterfaceSimulator.Logout();
			}
		}

		public static void setLogEnable_StatisticalDataItf(bool bEnable)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "setLogEnable", new object[]
			{
				bEnable
			});
		}

		public static void initAppCPA(string appId, string channelId)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "initAppCPA", new object[]
			{
				appId,
				channelId
			});
		}

		public static void onRegister(string userId)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "onRegister", new object[]
			{
				userId
			});
		}

		public static void onLogin(string userId)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "onLogin", new object[]
			{
				userId
			});
		}

		public static void onPay(string userId, string orderId, int amount, string currency)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "onPay", new object[]
			{
				userId,
				orderId,
				amount,
				currency
			});
		}

		public static void initStatisticalGame(string appId, string partnerId)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "initStatisticalGame", new object[]
			{
				appId,
				partnerId
			});
		}

		public static bool isStandaloneGame()
		{
			return JoyYouNativeInterface.AndroidInvoke<bool>("__IStatisticalData", "isStandaloneGame", new object[0]);
		}

		public static void setStandaloneGame(bool isSG)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "setStandaloneGame", new object[]
			{
				isSG
			});
		}

		public static void initAccount(string accountId)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "initAccount", new object[]
			{
				accountId
			});
		}

		public static void setAccountType(GameAccountType type)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "setAccountTypeByString", new object[]
			{
				type.ToString()
			});
		}

		public static void setAccountName(string name)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "setAccountName", new object[]
			{
				name
			});
		}

		public static void setAccountLevel(int level)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "setAccountLevel", new object[]
			{
				level
			});
		}

		public static void setAccountGameServer(string gameServer)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "setAccountGameServer", new object[]
			{
				gameServer
			});
		}

		public static void setAccountGender(GameGender gender)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "setAccountGenderByString", new object[]
			{
				gender.ToString()
			});
		}

		public static void setAccountAge(int age)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "setAccountAge", new object[]
			{
				age
			});
		}

		public static void accountPay(string messageId, string status, string accountID, string orderID, double currencyAmount, string currencyType, double virtualCurrencyAmount, long chargeTime, string iapID, string paymentType, string gameServer, string gameVersion, int level, string mission)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "accountPay", new object[]
			{
				messageId,
				status,
				accountID,
				orderID,
				currencyAmount,
				currencyType,
				virtualCurrencyAmount,
				chargeTime,
				iapID,
				paymentType,
				gameServer,
				gameVersion,
				level,
				mission
			});
		}

		public static void onAccountPurchase(string item, int itemNumber, double priceInVirtualCurrency)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "onAccountPurchase", new object[]
			{
				item,
				itemNumber,
				priceInVirtualCurrency
			});
		}

		public static void onAccountUse(string item, int itemNumber)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "onAccountUse", new object[]
			{
				item,
				itemNumber
			});
		}

		public static void onAccountMissionBegin(string missionId)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "onAccountMissionBegin", new object[]
			{
				missionId
			});
		}

		public static void onAccountMissionCompleted(string missionId)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "onAccountMissionCompleted", new object[]
			{
				missionId
			});
		}

		public static void onAccountMissionFailed(string missionId, string cause)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "onAccountMissionFailed", new object[]
			{
				missionId,
				cause
			});
		}

		public static void onAccountCurrencyReward(double virtualCurrencyAmount, string reason)
		{
			JoyYouNativeInterface.AndroidInvoke("__IStatisticalData", "onAccountCurrencyReward", new object[]
			{
				virtualCurrencyAmount,
				reason
			});
		}

		private static void AndroidInvoke(string _itf_obj_name, string method, params object[] args)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				{
					using (AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity"))
					{
						using (AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.joyyou.itf.JoyyouInterfaceFactory"))
						{
							string itfInitMethodName = JoyYouNativeInterface.getItfInitMethodName(_itf_obj_name);
							androidJavaClass2.CallStatic(itfInitMethodName, new object[]
							{
								@static
							});
							using (AndroidJavaObject static2 = androidJavaClass2.GetStatic<AndroidJavaObject>(_itf_obj_name))
							{
								static2.Call(method, args);
							}
						}
					}
				}
			}
		}

		private static string getItfInitMethodName(string _itf_obj_name)
		{
			return (!(_itf_obj_name == "__ICommonSDKPlatform")) ? ((!(_itf_obj_name == "__IStatisticalData")) ? ((!(_itf_obj_name == "__IDeviceInfomation")) ? ((!(_itf_obj_name == "__IGameRecord")) ? ((!(_itf_obj_name == "__IAdvertisement")) ? "ERROR_ITF_NAME" : "initInstance4Advertisement") : "initInstance4GameRecord") : "initInstance4DeviceInfomation") : "initInstance4Statistical") : "initInstance4BridgedCommonSDKPlatform";
		}

		private static T AndroidInvoke<T>(string _itf_obj_name, string method, params object[] args)
		{
			T result = default(T);
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				{
					using (AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity"))
					{
						using (AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.joyyou.itf.JoyyouInterfaceFactory"))
						{
							string itfInitMethodName = JoyYouNativeInterface.getItfInitMethodName(_itf_obj_name);
							androidJavaClass2.CallStatic(itfInitMethodName, new object[]
							{
								@static
							});
							using (AndroidJavaObject static2 = androidJavaClass2.GetStatic<AndroidJavaObject>(_itf_obj_name))
							{
								return static2.Call<T>(method, args);
							}
						}
					}
				}
				return result;
			}
			return result;
		}

		public static void ShareSdkInit(int type, string jsonData)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				string format = "{{ \"type\":{0}, \"data\":{1} }}";
				string jsonData2 = string.Format(format, type, jsonData);
				JoyYouNativeInterface.SendGameExtData("__ShareSdkInit__", jsonData2);
			}
		}

		public static void BaiduStat(int type, string name, string label, int time)
		{
		}

		public static void initAdv(string propertyId, string defaultContentId, bool logEnable)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__IAdvertisement", "Init", new object[]
				{
					propertyId
				});
				if (logEnable)
				{
					JoyYouNativeInterface.AndroidInvoke("__IAdvertisement", "SetLogLevelByString", new object[]
					{
						"L_VERBOSE"
					});
				}
				else
				{
					JoyYouNativeInterface.AndroidInvoke("__IAdvertisement", "SetLogLevelByString", new object[]
					{
						"L_NONE"
					});
				}
			}
		}

		public static void AdvCreateBanner(int x, int y, int width, int height, ADV_SIZE size, string contentId)
		{
			if (contentId == string.Empty || contentId == null)
			{
				contentId = JoyYouNativeInterface.defaultAdvContentMSG;
			}
			JoyYouNativeInterface.AndroidInvoke("__IAdvertisement", "CreateBanner", new object[]
			{
				x,
				y,
				width,
				height,
				size.ToString(),
				contentId
			});
		}

		public static void AdvBannerRefresh(int sec)
		{
			JoyYouNativeInterface.AndroidInvoke("__IAdvertisement", "BannerRefresh", new object[]
			{
				sec
			});
		}

		public static void AdvRemoveBanner()
		{
			JoyYouNativeInterface.AndroidInvoke("__IAdvertisement", "RemoveBanner", new object[0]);
		}

		public static void getAdvIDFA()
		{
			if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor)
			{
				JoyYouInterfaceSimulator.getAdvIDFA();
			}
		}

		public static string GetMACAddress()
		{
			return JoyYouNativeInterface.AndroidInvoke<string>("__IDeviceInfomation", "getMACAddress", new object[0]);
		}

		public static void RequestRealUserRegister(string uid, bool IsQuery)
		{
			JoyYouNativeInterface.AndroidInvoke("__ICommonSDKPlatform", "RequestRealUserRegister", new object[]
			{
				uid,
				IsQuery
			});
		}

		public static void InitGameRecordItf(string appKey, string _params)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__IGameRecord", "Init", new object[]
				{
					appKey,
					_params
				});
			}
			else
			{
				JoyYouInterfaceSimulator.InitGameRecordItf(appKey, _params);
			}
		}

		public static void GameRecordItf_ShowCtrlBar(bool visible)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__IGameRecord", "ShowControlBar", new object[]
				{
					visible
				});
			}
			else
			{
				JoyYouInterfaceSimulator.GameRecordItf_ShowCtrlBar(visible);
			}
		}

		public static void GameRecordItf_PauseRecording()
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__IGameRecord", "PauseRecording", new object[0]);
			}
			else
			{
				JoyYouInterfaceSimulator.GameRecordItf_PauseRecording();
			}
		}

		public static void GameRecordItf_ResumeRecording()
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__IGameRecord", "ResumeRecording", new object[0]);
			}
			else
			{
				JoyYouInterfaceSimulator.GameRecordItf_ResumeRecording();
			}
		}

		public static void GameRecordItf_StartRecording()
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__IGameRecord", "StartRecording", new object[0]);
			}
			else
			{
				JoyYouInterfaceSimulator.GameRecordItf_StartRecording();
			}
		}

		public static void GameRecordItf_StopRecording()
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__IGameRecord", "StopRecording", new object[0]);
			}
			else
			{
				JoyYouInterfaceSimulator.GameRecordItf_StopRecording();
			}
		}

		public static void GameRecordItf_ShowWelfareCenter()
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__IGameRecord", "ShowWelfareCenter", new object[0]);
			}
			else
			{
				JoyYouInterfaceSimulator.GameRecordItf_ShowCoinWebView();
			}
		}

		public static void GameRecordItf_ShowVideoStore()
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__IGameRecord", "ShowVideoStore", new object[0]);
			}
			else
			{
				JoyYouInterfaceSimulator.GameRecordItf_ShowRecordLibraryView();
			}
		}

		public static void GameRecordItf_ShowPlayerClub()
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				JoyYouNativeInterface.AndroidInvoke("__IGameRecord", "ShowPlayerClub", new object[0]);
			}
			else
			{
				JoyYouInterfaceSimulator.GameRecordItf_ShowPlayerClub();
			}
		}

		public static void HLResendAppstoreReceiptDataForRole(string roleId)
		{
			JoyYouNativeInterface.SendGameExtData(roleId, string.Empty);
		}
	}
}
