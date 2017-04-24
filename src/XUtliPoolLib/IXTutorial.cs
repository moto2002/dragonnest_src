using System;

namespace XUtliPoolLib
{
	public interface IXTutorial : IXInterface
	{
		bool NoforceClick
		{
			get;
		}

		bool Exculsive
		{
			get;
		}

		void OnTutorialClicked();
	}
}
