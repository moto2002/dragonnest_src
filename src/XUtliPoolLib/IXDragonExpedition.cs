using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IXDragonExpedition
	{
		void Drag(float delta);

		GameObject Click();

		Transform GetGO(string name);

		void SetLimitPos(float MinPos);

		Camera GetDragonCamera();
	}
}
