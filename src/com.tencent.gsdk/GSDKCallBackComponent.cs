using System;
using UnityEngine;

namespace com.tencent.gsdk
{
	internal class GSDKCallBackComponent : MonoBehaviour
	{
		public void GSDKStartCallback(string config)
		{
			GSDKUtils.Logger("config: " + config);
			string[] array = config.Split(new char[]
			{
				'|'
			});
			if (array.Length != 4)
			{
				return;
			}
			int num = 20;
			int num2 = 3000;
			string message = array[1];
			int num3;
			bool flag = int.TryParse(array[0], out num3) && int.TryParse(array[2], out num) && int.TryParse(array[3], out num2);
			if (num3 != 0)
			{
				MonoBehaviour.print(message);
			}
			else if (flag && num > 0 && num2 >= 0)
			{
				GSDK.StartFps(0 - num, num2);
			}
		}
	}
}
