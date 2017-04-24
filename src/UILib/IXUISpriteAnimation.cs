using System;

namespace UILib
{
	public interface IXUISpriteAnimation : IXUIObject
	{
		void SetNamePrefix(string name);

		void SetFrameRate(int rate);

		void Reset();

		void StopAndReset();

		void RegisterFinishCallback(SpriteAnimationFinishCallback callback);

		void MakePixelPerfect();
	}
}
