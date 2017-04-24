using System;

namespace XUtliPoolLib
{
	public interface IXVideo : IXInterface
	{
		bool isPlaying
		{
			get;
		}

		void Play(bool loop = false);

		void Stop();
	}
}
