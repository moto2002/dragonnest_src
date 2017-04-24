using System;
using UnityEngine;

namespace Assets.SDK
{
	public static class JoyYouInterfaceSimulator
	{
		public static string NotificationObjeName
		{
			get;
			set;
		}

		static JoyYouInterfaceSimulator()
		{
			JoyYouInterfaceSimulator.NotificationObjeName = string.Empty;
		}

		public static void ShowLoginView()
		{
			JoyYouInterfaceSimulator.SendObjMsg("LoginCallBack", "Simulating API: \"ShowLoginView()\"");
		}

		public static void ShowLoginViewWithType(int type)
		{
			JoyYouInterfaceSimulator.SendObjMsg("LoginCallBack", "Simulating API: \"ShowLoginViewWithType(int type)\"");
		}

		public static void Logout()
		{
			JoyYouInterfaceSimulator.SendObjMsg("LogoutCallBack", "Simulating API: \"Logout()\"");
		}

		public static void ShowCenterView()
		{
			JoyYouInterfaceSimulator.SendObjMsg("UserCenteredClosedCallBack", "Simulating API: \"ShowCenterView()\"");
		}

		public static void Pay()
		{
			JoyYouInterfaceSimulator.SendObjMsg("PayCallBack", "Simulating API: \"Pay()\"");
		}

		public static void VerifyingUpdatePassCallBack(string msg)
		{
			JoyYouInterfaceSimulator.SendObjMsg("VerifyingUpdatePassCallBack", "Simulating API: \"ShowLoginView\"");
		}

		public static void onRegister()
		{
			Debug.Log("onRegister");
			JoyYouInterfaceSimulator.SendObjMsg("RegisterCallBack", "Simulating API: \"HLRegister\"");
		}

		public static void SendGameExtData(string type, string jsonData)
		{
			Debug.Log("SendGameExtData");
		}

		public static bool CheckStatus(string type, string jsonData)
		{
			Debug.Log("CheckStatus");
			return true;
		}

		public static string GetSDKConfig(string type, string jsonData)
		{
			return "Simulator";
		}

		public static void QuitGame(string paramString)
		{
			Debug.Log("QuitGame");
			JoyYouInterfaceSimulator.SendObjMsg("QuitGame", "Simulating API: \"QuitGame\"");
		}

		public static void getAdvIDFA()
		{
			Debug.Log("getAdvIDFA");
			JoyYouInterfaceSimulator.SendObjMsg("NotifyIDFA", "IDFA=XXXXXXXXXXXXXXXXX");
		}

		private static void SendObjMsg(string method, string message)
		{
			if (JoyYouInterfaceSimulator.NotificationObjeName != string.Empty)
			{
				GameObject gameObject = GameObject.Find(JoyYouInterfaceSimulator.NotificationObjeName);
				if (gameObject != null)
				{
					gameObject.SendMessage(method, message);
				}
			}
		}

		public static void InitGameRecordItf(string appKey, string _params)
		{
			Debug.Log("InitGameRecordItf -> appKey : " + appKey);
		}

		public static void GameRecordItf_ShowCtrlBar(bool visible)
		{
			Debug.Log("GameRecordItf -> ShowCtrlBar : " + visible.ToString());
		}

		public static void GameRecordItf_PauseRecording()
		{
		}

		public static void GameRecordItf_ResumeRecording()
		{
		}

		public static void GameRecordItf_StartRecording()
		{
		}

		public static void GameRecordItf_StopRecording()
		{
		}

		public static void GameRecordItf_ShowCoinWebView()
		{
		}

		public static void GameRecordItf_ShowRecordLibraryView()
		{
		}

		public static void GameRecordItf_ShowPlayerClub()
		{
		}
	}
}
