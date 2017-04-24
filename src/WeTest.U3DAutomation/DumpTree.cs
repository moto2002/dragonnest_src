using System;

namespace WeTest.U3DAutomation
{
	[Serializable]
	public class DumpTree
	{
		public string scene;

		public string xml;

		public DumpTree()
		{
			this.scene = "";
			this.xml = "";
		}
	}
}
