using System;

namespace XUtliPoolLib
{
	public interface ILuaFunction
	{
		object[] Call();

		object[] Call(params object[] args);

		object[] Call(double arg1);

		void Dispose();

		void Release();

		int GetReference();
	}
}
