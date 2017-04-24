using System;

namespace WeTest.U3DAutomation
{
	[Serializable]
	public class BoundInfo
	{
		public int instance;

		public bool visible;

		public bool existed;

		public float width;

		public float height;

		public float x;

		public float y;

		public string path;

		public BoundInfo()
		{
			this.existed = true;
			this.visible = true;
			this.path = "";
		}
	}
}
