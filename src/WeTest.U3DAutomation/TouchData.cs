using System;

namespace WeTest.U3DAutomation
{
	[Serializable]
	public class TouchData
	{
		public float deltatime;

		public byte phase;

		public float x;

		public float y;

		public float relativeX;

		public float relativeY;

		public short fingerId;
	}
}
