using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IXOperationRecord : IXInterface
	{
		int FindRecordID(Transform go);
	}
}
