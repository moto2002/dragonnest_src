using System;

namespace WeTest.U3DAutomation
{
	public enum JsonToken
	{
		None,
		ObjectStart,
		PropertyName,
		ObjectEnd,
		ArrayStart,
		ArrayEnd,
		Int,
		Long,
		Double,
		Float,
		String,
		Boolean,
		Null
	}
}
