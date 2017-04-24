using System;

namespace Assets.SDK
{
	public interface I3RDPlatformSDKEX
	{
		void ShowFloatToolkit(bool visible, double x, double y);

		void SendGameExtData(string type, string jsonData);

		bool CheckStatus(string type, string jsonData);

		string GetSDKConfig(string type, string jsonData);

		void QuitGame(string paramString);

		void RequestRealUserRegister(string uid, bool IsQuery);
	}
}
