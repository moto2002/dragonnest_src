using System;

namespace XUtliPoolLib
{
	public interface IGuildGroup : IXInterface
	{
		void GuildGroupResult(string apiId, string result, int errorCode);

		void RefreshWXGroupBtn();
	}
}
