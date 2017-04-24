using System;

namespace XUtliPoolLib
{
	internal interface IXRedpointRelationMgr
	{
		void AddRelation(int child, int parent, bool bImmUpdateUI = false);

		void AddRelations(int child, int[] parents, bool bImmUpdateUI = false);

		void RemoveRelation(int child, int parent, bool bImmUpdateUI = false);

		void RemoveRelations(int child, int[] parents, bool bImmUpdateUI = false);

		void RemoveAllRelations(int child, bool bImmUpdateUI = false);

		void ClearAllRelations(bool bImmUpdateUI = false);
	}
}
