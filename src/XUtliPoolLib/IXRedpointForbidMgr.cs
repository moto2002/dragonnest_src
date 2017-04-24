using System;

namespace XUtliPoolLib
{
	internal interface IXRedpointForbidMgr
	{
		void AddForbid(int sys, bool bImmUpdateUI = true);

		void AddForbids(int[] systems, bool bImmUpdateUI = true);

		void RemoveForbid(int sys, bool bImmUpdateUI = true);

		void RemoveForbids(int[] systems, bool bImmUpdateUI = true);

		void ClearForbids(bool bImmUpdateUI = true);
	}
}
