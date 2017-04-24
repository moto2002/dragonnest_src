using System;

namespace UILib
{
	public interface IXUICheckBox : IXUIObject
	{
		bool bChecked
		{
			get;
			set;
		}

		bool bInstantTween
		{
			get;
			set;
		}

		int spriteHeight
		{
			get;
			set;
		}

		int spriteWidth
		{
			get;
			set;
		}

		void RegisterOnCheckEventHandler(CheckBoxOnCheckEventHandler eventHandler);

		CheckBoxOnCheckEventHandler GetCheckEventHandler();

		void SetEnable(bool bEnable);

		void ForceSetFlag(bool bCheckd);

		void SetAlpha(float f);

		void SetAudioClip(string name);

		void SetGroup(int group);
	}
}
