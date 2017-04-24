using System;
using UnityEngine;

namespace UILib
{
	public interface IXUITweenTool
	{
		bool bPlayForward
		{
			get;
		}

		int TweenGroup
		{
			get;
		}

		GameObject gameObject
		{
			get;
		}

		void SetTargetGameObject(GameObject go);

		void PlayTween(bool bForward, float duaration = -1f);

		void ResetTween(bool bForward);

		void ResetTweenByGroup(bool bForward, int group = 0);

		void ResetTweenExceptGroup(bool bForward, int group);

		void ResetTweenByCurGroup(bool bForward);

		void StopTween();

		void StopTweenByGroup(int group = 0);

		void StopTweenExceptGroup(int group);

		void SetPositionTweenPos(int group, Vector3 from, Vector3 to);

		void SetTweenGroup(int group);

		void SetTweenEnabledWhenFinish(bool enabled);

		void RegisterOnFinishEventHandler(OnTweenFinishEventHandler eventHandler);
	}
}
