using System;

namespace XUtliPoolLib
{
	public interface IBroardcast
	{
		bool IsBroadState();

		void SetAccount(int platf, string openid, string token);

		void StartLiveBroadcast(string title, string desc);

		void StopBroadcast();

		int GetState();

		void EnterHall();

		bool ShowCamera(bool show);
	}
}
