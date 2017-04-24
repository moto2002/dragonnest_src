using System;

namespace Assets.SDK
{
	public interface IGameRecord
	{
		void StartRecording();

		void StopRecording();

		void PauseRecording();

		void ResumeRecording();

		void ShowControlBar(bool visible);

		void ShowVideoStore();

		void ShowPlayerClub();

		void ShowWelfareCenter();
	}
}
