using System;

namespace WeTest.U3DAutomation
{
	[Serializable]
	internal class Response
	{
		public int cmd;

		public ResponseStatus status;

		public object data;
	}
}
