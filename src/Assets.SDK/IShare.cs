using System;

namespace Assets.SDK
{
	public interface IShare
	{
		void ShareText(string content);

		void ShareTimeline(string title, string description, string imageURL);
	}
}
