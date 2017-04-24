using System;

namespace WeTest.U3DAutomation
{
	[Serializable]
	public class CustomCaller
	{
		public string name;

		public string args;

		public CustomCaller(string name, string args)
		{
			this.name = name;
			this.args = args;
		}

		public CustomCaller()
		{
		}
	}
}
