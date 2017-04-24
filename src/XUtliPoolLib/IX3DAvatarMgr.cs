using System;
using UILib;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IX3DAvatarMgr : IXInterface
	{
		int AllocDummyPool(string user, int maxCount);

		void ReturnDummyPool(int index);

		void EnableMainDummy(bool enable, IUIDummy snapShot);

		void OnUIUnloadMainDummy(IUIDummy snapShot);

		void SetMainDummy(bool ui);

		void Clean(bool transfer);

		void RotateMain(Vector3 localEulerAngles);

		void RotateMain(float degree);

		XAnimationClip SetMainAnimation(string anim);

		void ResetMainAnimation();

		string CreateCommonDummy(int dummyPool, uint presentID, IUIDummy snapShot, IXDummy orig, float scale);

		void DestroyDummy(int dummyPool, string idStr);

		void SetDummyAnim(int dummyPool, string idStr, string anim);

		void SetMainDummyAnim(string anim);
	}
}
