using System;

namespace XUtliPoolLib
{
	public interface ITssSdk
	{
		void OnLogin(int platf, string openId, uint worldId, string roleId);

		void OnRcvWhichNeedToSendClientSdk(byte[] data, uint length);
	}
}
