using System;
using UnityEngine;

namespace com.tencent.pandora
{
	public class LuaSvrGameObject : MonoBehaviour
	{
		public LuaState state;

		public Action<LuaState> onUpdate;

		private void OnDestroy()
		{
			if (this.state != null)
			{
			}
		}

		public void init()
		{
		}

		private void Update()
		{
			if (this.onUpdate != null)
			{
				this.onUpdate(this.state);
			}
		}
	}
}
