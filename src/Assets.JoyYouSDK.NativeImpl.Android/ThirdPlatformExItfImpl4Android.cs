using Assets.SDK;
using System;

namespace Assets.JoyYouSDK.NativeImpl.Android
{
	public class ThirdPlatformExItfImpl4Android : I3RDPlatformSDKEX
	{
		void I3RDPlatformSDKEX.SendGameExtData(string type, string jsonData)
		{
			AndroidBridge.CommonPlatformCall("SendGameExtData", new object[]
			{
				type,
				jsonData
			});
		}

		bool I3RDPlatformSDKEX.CheckStatus(string type, string jsonData)
		{
			return AndroidBridge.CommonPlatformCall<bool>("CheckStatus", new object[]
			{
				type,
				jsonData
			});
		}

		string I3RDPlatformSDKEX.GetSDKConfig(string type, string jsonData)
		{
			string empty = string.Empty;
			return AndroidBridge.CommonPlatformCall<string>("GetSDKConfig", new object[]
			{
				type,
				jsonData
			});
		}

		void I3RDPlatformSDKEX.QuitGame(string paramString)
		{
			AndroidBridge.CommonPlatformCall("Release", new object[0]);
		}

		void I3RDPlatformSDKEX.ShowFloatToolkit(bool visible, double x, double y)
		{
			AndroidBridge.CommonPlatformCall("ShowFloatToolkit", new object[]
			{
				visible,
				x,
				y
			});
		}

		void I3RDPlatformSDKEX.RequestRealUserRegister(string uid, bool IsQuery)
		{
			AndroidBridge.CommonPlatformCall("RequestRealUserRegister", new object[]
			{
				uid,
				IsQuery
			});
		}
	}
}
