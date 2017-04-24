using System;

namespace XUtliPoolLib
{
	public interface ILuaUIManager
	{
		bool IsUIShowed();

		bool Load(string name);

		bool Hide(string name);

		bool Destroy(string name);

		void Clear();
	}
}
