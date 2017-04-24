using System;

namespace XUtliPoolLib
{
	public interface IObjectPool
	{
		int countAll
		{
			get;
		}

		int countActive
		{
			get;
		}

		int countInactive
		{
			get;
		}
	}
}
