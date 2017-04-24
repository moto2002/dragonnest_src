using System;

namespace Assets.SDK
{
	public interface IBaiduStat
	{
		void singleEventLog(string eventId, string eventLabel);

		void eventStart(string eventId, string eventLabel);

		void eventEnd(string eventId, string eventLabel);

		void eventWithDurationTime(string eventId, string eventLabel, int duration);

		void pageStart(string pageName);

		void pageEnd(string pageName);
	}
}
