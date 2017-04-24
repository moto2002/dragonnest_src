using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	public class XInterfaceMgr : XSingleton<XInterfaceMgr>
	{
		private Dictionary<uint, IXInterface> _interfaces = new Dictionary<uint, IXInterface>();

		public T GetInterface<T>(uint key) where T : IXInterface
		{
			IXInterface iXInterface = null;
			this._interfaces.TryGetValue(key, out iXInterface);
			return (T)((object)iXInterface);
		}

		public T AttachInterface<T>(uint key, T value) where T : IXInterface
		{
			if (this._interfaces.ContainsKey(key))
			{
				this._interfaces[key].Deprecated = true;
				XSingleton<XDebug>.singleton.AddLog("Duplication key for interface ", this._interfaces[key].ToString(), " and ", value.ToString(), null, null, XDebugColor.XDebug_None);
				this._interfaces[key] = value;
			}
			else
			{
				this._interfaces.Add(key, value);
			}
			this._interfaces[key].Deprecated = false;
			return value;
		}

		public void DetachInterface(uint key)
		{
			if (this._interfaces.ContainsKey(key))
			{
				this._interfaces[key].Deprecated = true;
				this._interfaces.Remove(key);
			}
		}

		public override bool Init()
		{
			return true;
		}

		public override void Uninit()
		{
			this._interfaces.Clear();
		}
	}
}
