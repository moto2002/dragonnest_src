using System;

namespace XUtliPoolLib
{
	internal interface IXRedpointExMgr : IXRedpointMgr, IXRedpointRelationMgr, IXRedpointForbidMgr
	{
		void SetCurrentLevel(uint level);

		void AddSysForbidLevels(int sys, uint level);

		void RemoveSysForbidLevels(int sys, uint level);
	}
}
