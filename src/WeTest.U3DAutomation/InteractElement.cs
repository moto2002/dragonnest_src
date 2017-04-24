using System;

namespace WeTest.U3DAutomation
{
	[Serializable]
	public class InteractElement
	{
		public string name;

		public int instanceid;

		public AutoTravelNodeType nodetype;

		public AutoBound bound;

		public InteractElement()
		{
			this.bound = new AutoBound();
		}
	}
}
