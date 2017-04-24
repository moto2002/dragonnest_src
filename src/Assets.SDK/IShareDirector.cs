using System;

namespace Assets.SDK
{
	public interface IShareDirector
	{
		void ShareTimeline(SHARE_TYPE type, string title, string description, string imageURI);
	}
}
