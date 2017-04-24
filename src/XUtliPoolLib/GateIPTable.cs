using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GateIPTable : CVSReader
	{
		public class RowData
		{
			public int ServerID;

			public string ServerName;

			public string ZoneName;

			public int State;

			public string[] IPAddr;

			public int StateTxt;

			public uint[] Channel;
		}

		public List<GateIPTable.RowData> Table = new List<GateIPTable.RowData>();

		public GateIPTable.RowData GetByServerID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchServerID(key, 0, this.Table.Count - 1);
		}

		private GateIPTable.RowData BinarySearchServerID(int key, int min, int max)
		{
			GateIPTable.RowData rowData = this.Table[min];
			if (rowData.ServerID == key)
			{
				return rowData;
			}
			GateIPTable.RowData rowData2 = this.Table[max];
			if (rowData2.ServerID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GateIPTable.RowData rowData3 = this.Table[num];
			if (rowData3.ServerID.CompareTo(key) > 0)
			{
				return this.BinarySearchServerID(key, min, num);
			}
			if (rowData3.ServerID.CompareTo(key) < 0)
			{
				return this.BinarySearchServerID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowServerID(int key, GateIPTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GateIPTable.RowData rowData = this.Table[min];
			if (rowData.ServerID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ServerID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GateIPTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GateIPTable.RowData rowData2 = this.Table[max];
			if (rowData2.ServerID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ServerID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GateIPTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			if (max - min <= 1)
			{
				this.Table.Insert(min + 1, row);
				return;
			}
			int num = min + (max - min) / 2;
			GateIPTable.RowData rowData3 = this.Table[num];
			if (rowData3.ServerID.CompareTo(key) > 0)
			{
				this.AddRowServerID(key, row, min, num);
				return;
			}
			if (rowData3.ServerID.CompareTo(key) < 0)
			{
				this.AddRowServerID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GateIPTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ServerID",
				"ServerName",
				"ZoneName",
				"State",
				"IPAddr",
				"StateTxt",
				"Channel"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GateIPTable.RowData rowData = new GateIPTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ServerID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ServerName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ZoneName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.State))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.IPAddr))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.StateTxt))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Channel))
			{
				return false;
			}
			this.AddRowServerID(rowData.ServerID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GateIPTable.RowData rowData = new GateIPTable.RowData();
			base.Read<int>(reader, ref rowData.ServerID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ServerName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.ZoneName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.State, CVSReader.intParse);
			this.columnno = 3;
			base.ReadArray<string>(reader, ref rowData.IPAddr, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.StateTxt, CVSReader.intParse);
			this.columnno = 5;
			base.ReadArray<uint>(reader, ref rowData.Channel, CVSReader.uintParse);
			this.columnno = 6;
			this.AddRowServerID(rowData.ServerID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
