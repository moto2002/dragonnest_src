using System;

namespace XUtliPoolLib
{
	public interface ILuaNetSender
	{
		bool Send(uint _type, bool isRpc, uint tagID, byte[] _reqBuff);
	}
}
