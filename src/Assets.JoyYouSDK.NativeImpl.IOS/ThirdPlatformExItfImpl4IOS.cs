using Assets.SDK;
using System;

namespace Assets.JoyYouSDK.NativeImpl.IOS
{
	internal class ThirdPlatformExItfImpl4IOS : I3RDPlatformSDKEX
	{
		void I3RDPlatformSDKEX.SendGameExtData(string type, string jsonData)
		{
		}

		bool I3RDPlatformSDKEX.CheckStatus(string type, string jsonData)
		{
			return true;
		}

		string I3RDPlatformSDKEX.GetSDKConfig(string type, string jsonData)
		{
			return string.Empty;
		}

		void I3RDPlatformSDKEX.QuitGame(string paramString)
		{
		}

		void I3RDPlatformSDKEX.ShowFloatToolkit(bool visible, double x, double y)
		{
		}

		void I3RDPlatformSDKEX.RequestRealUserRegister(string uid, bool IsQuery)
		{
		}
	}
}
