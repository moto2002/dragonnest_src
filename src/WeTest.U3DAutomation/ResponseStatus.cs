using System;

namespace WeTest.U3DAutomation
{
	[Serializable]
	internal enum ResponseStatus
	{
		SUCCESS,
		NO_SUCH_CMD,
		UNPACK_ERROR,
		UN_KNOW_ERROR,
		GAMEOBJ_NOT_EXIST,
		COMPONENT_NOT_EXIST,
		NO_SUCH_HANDLER,
		REFLECTION_ERROR,
		NO_SUCH_RESOURCE
	}
}
