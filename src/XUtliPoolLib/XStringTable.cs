using System;

namespace XUtliPoolLib
{
	public class XStringTable : XSingleton<XStringTable>
	{
		private XTableAsyncLoader _async_loader;

		private StringTable _reader = new StringTable();

		private bool _inited;

		public bool ReInit(byte[] data)
		{
			this.Uninit();
			if (XSingleton<XResourceLoaderMgr>.singleton.ReadFile(data, this._reader))
			{
				this._inited = true;
				return true;
			}
			return false;
		}

		public bool SyncInit()
		{
			if (this._inited)
			{
				return true;
			}
			this._inited = XSingleton<XResourceLoaderMgr>.singleton.ReadFile("Table/StringTable", this._reader);
			bool arg_2B_0 = this._inited;
			return this._inited;
		}

		public override bool Init()
		{
			if (this._inited)
			{
				return true;
			}
			if (this._async_loader == null)
			{
				this._async_loader = new XTableAsyncLoader();
				this._async_loader.AddTask("Table/StringTable", this._reader);
				this._async_loader.Execute(null);
			}
			this._inited = this._async_loader.IsDone;
			return this._inited;
		}

		public override void Uninit()
		{
			this._inited = false;
			this._async_loader = null;
		}

		public string GetString(string key)
		{
			StringTable.RowData byEnum = this._reader.GetByEnum(key);
			if (byEnum != null)
			{
				return byEnum.Text;
			}
			if (key != "UNKNOWN_TARGET")
			{
				return this.GetString("UNKNOWN_TARGET") + " " + key;
			}
			return "UNKNOWN_TARGET not found in StringTable";
		}

		public StringTable.RowData GetData(string key)
		{
			return this._reader.GetByEnum(key);
		}
	}
}
