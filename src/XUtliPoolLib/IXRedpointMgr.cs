using System;
using UnityEngine;

namespace XUtliPoolLib
{
	internal interface IXRedpointMgr : IXRedpointRelationMgr, IXRedpointForbidMgr
	{
		void AddSysRedpointUI(int sys, GameObject go, SetRedpointUIHandler callback = null);

		void RemoveSysRedpointUI(int sys, GameObject go);

		void RemoveAllSysRedpointsUI(int sys);

		void ClearAllSysRedpointsUI();

		void SetSysRedpointState(int sys, bool redpoint, bool bImmUpdateUI = true);
	}
}
