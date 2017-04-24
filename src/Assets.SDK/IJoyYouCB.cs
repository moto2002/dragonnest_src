using System;

namespace Assets.SDK
{
	public interface IJoyYouCB
	{
		void RegisterCallBack(string result);

		void LoginCallBack(string token);

		void LogoutCallBack(string msg);

		void UserViewClosedCallBack(string msg);

		void PayCallBack(string msg);

		void VerifyingUpdatePassCallBack(string msg);

		void ShareContentCallBack(string msg);

		void NotifyIDFA(string msg);

		void RealUserRegisterCallBack(string msg);

		void NotifyJoystick(string msg);
	}
}
