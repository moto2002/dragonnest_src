using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IXNGUICallback
	{
		void RegisterClickEventHandler(IXNGUIClickEventHandler handler);

		GameObject SetXUILable(string name, string content);
	}
}
