using System;

namespace XUtliPoolLib
{
	public interface IXGameSirControl
	{
		bool IsOpen
		{
			get;
		}

		void Init();

		void StartSir();

		void StopSir();

		bool IsConnected();

		int GetGameSirState();

		bool GetButton(string buttonName);

		float GetAxis(string axisName);

		void ShowGameSirDialog();
	}
}
