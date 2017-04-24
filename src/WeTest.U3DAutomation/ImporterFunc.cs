using System;

namespace WeTest.U3DAutomation
{
	public delegate TValue ImporterFunc<TJson, TValue>(TJson input);
}
