using System;

namespace WeTest.U3DAutomation
{
	[Serializable]
	public class PathNode
	{
		public string name;

		public int index;

		public string txt;

		public string img;

		public PathNode(string name, int index, string txt, string img)
		{
			this.name = name;
			this.index = index;
			this.txt = txt;
			this.img = img;
		}

		public PathNode()
		{
			this.name = null;
			this.img = null;
			this.txt = null;
			this.index = -1;
		}
	}
}
