using System;

namespace UILib
{
	public interface IXRadarMap
	{
		void Refresh();

		void SetSite(int pos, float value);
	}
}
