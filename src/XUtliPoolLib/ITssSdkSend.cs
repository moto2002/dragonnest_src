using System;

namespace XUtliPoolLib
{
	public interface ITssSdkSend : IXInterface
	{
		void SendDataToServer(byte[] data, uint length);
	}
}
