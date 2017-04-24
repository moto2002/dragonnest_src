using System;

namespace XUtliPoolLib
{
	public interface ILuaNetwork : IXInterface
	{
		void InitLua(int rpcCache);

		bool LuaRigsterPtc(uint type, bool copyBuffer);

		void LuaRigsterRPC(uint _type, bool copyBuffer, DelLuaRespond _onRes, DelLuaError _onError);

		bool LuaSendPtc(uint _type, byte[] _reqBuff);

		bool LuaSendRPC(uint _type, byte[] _reqBuff, DelLuaRespond _onRes, DelLuaError _onError);
	}
}
