using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IXFmod : IXInterface
	{
		void StartEvent(string key, AudioChannel channel = AudioChannel.Action, bool stopPre = true, string para = "", float value = 0f);

		void Play(AudioChannel channel = AudioChannel.Action);

		void Stop(AudioChannel channel = AudioChannel.Action);

		bool IsPlaying(AudioChannel channel);

		void Destroy();

		void Update3DAttributes(Vector3 vec, AudioChannel channel = AudioChannel.Action);

		void PlayOneShot(string key, Vector3 pos);
	}
}
