using Assets.SDK.JoyyouInput;
using System;

namespace Assets.SDK
{
	public interface IDeviceInfomation
	{
		string GetMACAddress();

		Joystick GetJoystick();

		void ProcessJoystick(string message);
	}
}
