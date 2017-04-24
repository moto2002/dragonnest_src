using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IXFmodBus : IXInterface
	{
		void SetBusVolume(string bus, float volume);

		void SetMainVolume(float volume);

		void SetBGMVolume(float volume);

		void SetSFXVolume(float volume);

		void PlayOneShot(string key, Vector3 pos);

		void StartEvent(string key);

		void StopEvent();
	}
}
