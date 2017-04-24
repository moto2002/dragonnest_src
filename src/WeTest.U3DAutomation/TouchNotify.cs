using System;
using System.Collections.Generic;

namespace WeTest.U3DAutomation
{
	[Serializable]
	public class TouchNotify
	{
		public string scene;

		public string name;

		public List<TouchData> touches;

		public TouchNotify()
		{
			this.scene = "";
			this.name = "";
			this.touches = new List<TouchData>();
		}
	}
}
