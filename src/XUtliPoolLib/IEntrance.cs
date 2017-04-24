using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IEntrance : IXInterface
	{
		bool Awaked
		{
			get;
		}

		void Awake();

		void Start();

		void NetUpdate();

		void PreUpdate();

		void Update();

		void PostUpdate();

		void FadeUpdate();

		void Quit();

		void Authorization(string token);

		void AuthorizationSignOut(string msg);

		void SetQualityLevel(int level);

		void MonoObjectRegister(string key, MonoBehaviour behavior);
	}
}
