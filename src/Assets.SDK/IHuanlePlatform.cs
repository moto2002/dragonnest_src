using System;

namespace Assets.SDK
{
	public interface IHuanlePlatform : I3RDPlatformSDK, I3RDPlatformSDKEX
	{
		void HLRegister(string username, string password, string email);

		void HLLogin(string username, string password);

		void HLLogout();

		void HLResendAppstoreReceiptDataForRole(string roleId);
	}
}
