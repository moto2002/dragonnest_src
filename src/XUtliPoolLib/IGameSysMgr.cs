using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IGameSysMgr : IXInterface
	{
		float OnlineRewardRemainTime
		{
			get;
			set;
		}

		bool Init();

		void Uninit();

		void InitWhenSelectRole(uint level);

		bool IsSystemOpen(int sys);

		string GetSysName(int sysid);

		string GetSysIcon(int sysid);

		string GetSysAnnounceIcon(int sysid);

		void OpenSystem(int sys);

		void ForceUpdateSysRedPointImmediately(int sys, bool redpoint);

		void AttachSysRedPointRelative(int sys, int childSys, bool bImmCalculate);

		void AttachSysRedPointRelativeUI(int sys, GameObject go);

		void DetachSysRedPointRelative(int sys);

		void DetachSysRedPointRelativeUI(int sys);

		void GamePause(bool pause);

		bool GetSysRedPointState(int sys);
	}
}
