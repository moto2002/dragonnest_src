using System;

namespace LuaInterface
{
	public class LuaEventHandler
	{
		public LuaFunction handler;

		public void handleEvent(object[] args)
		{
			this.handler.Call(args);
		}
	}
}
