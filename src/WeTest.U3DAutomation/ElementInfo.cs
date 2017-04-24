using System;

namespace WeTest.U3DAutomation
{
	[Serializable]
	internal class ElementInfo
	{
		public int instance;

		public string name;

		public ElementInfo()
		{
		}

		public ElementInfo(string A_0, int A_1)
		{
			this.name = A_0;
			this.instance = A_1;
		}
	}
}
