using System;

namespace UILib
{
	public interface IXUIPlayTweenGroup
	{
		void PlayTween(bool bForward);

		void ResetTween(bool bForward);

		void StopTween();
	}
}
