using System;

namespace Assets.JoyYouSDK.NativeImpl
{
	public interface ITPExNative
	{
		void ShowFloatToolkit(bool visible, double x, double y);

		void SendGameExtData(string type, string jsonData);

		void QuitGame(string paramString);

		void RequestRealUserRegister(string uid, bool IsQuery);
	}
}
