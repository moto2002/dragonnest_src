using System;

namespace Assets.SDK
{
	public interface I3RDPlatformSDK
	{
		void ShowLoginView();

		void ShowLoginViewWithType(int type);

		void Logout();

		void Pay(int price, string billNo, string billTitle, string roleId, int zoneId);

		void ShowCenterView();
	}
}
