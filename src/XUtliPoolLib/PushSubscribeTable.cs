using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PushSubscribeTable : CVSReader
	{
		public class RowData
		{
			public uint MsgId;

			public string Name;

			public uint[] Time;

			public uint[] WeekDay;

			public bool IsShow;

			public string SubscribeDescription;

			public string CancelDescription;

			public uint TxMsgId;
		}

		public List<PushSubscribeTable.RowData> Table = new List<PushSubscribeTable.RowData>();

		public PushSubscribeTable.RowData GetByMsgId(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchMsgId(key, 0, this.Table.Count - 1);
		}

		private PushSubscribeTable.RowData BinarySearchMsgId(uint key, int min, int max)
		{
			PushSubscribeTable.RowData rowData = this.Table[min];
			if (rowData.MsgId == key)
			{
				return rowData;
			}
			PushSubscribeTable.RowData rowData2 = this.Table[max];
			if (rowData2.MsgId == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			PushSubscribeTable.RowData rowData3 = this.Table[num];
			if (rowData3.MsgId.CompareTo(key) > 0)
			{
				return this.BinarySearchMsgId(key, min, num);
			}
			if (rowData3.MsgId.CompareTo(key) < 0)
			{
				return this.BinarySearchMsgId(key, num, max);
			}
			return rowData3;
		}

		private void AddRowMsgId(uint key, PushSubscribeTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			PushSubscribeTable.RowData rowData = this.Table[min];
			if (rowData.MsgId.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.MsgId == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PushSubscribeTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			PushSubscribeTable.RowData rowData2 = this.Table[max];
			if (rowData2.MsgId.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.MsgId == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PushSubscribeTable duplicate id:{0}  lineno: {1}", new object[]
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
			PushSubscribeTable.RowData rowData3 = this.Table[num];
			if (rowData3.MsgId.CompareTo(key) > 0)
			{
				this.AddRowMsgId(key, row, min, num);
				return;
			}
			if (rowData3.MsgId.CompareTo(key) < 0)
			{
				this.AddRowMsgId(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: PushSubscribeTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"MsgId",
				"Name",
				"Time",
				"WeekDay",
				"IsShow",
				"SubscribeDescription",
				"CancelDescription",
				"TxMsgId"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PushSubscribeTable.RowData rowData = new PushSubscribeTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.MsgId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Time))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.WeekDay))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.IsShow))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.SubscribeDescription))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.CancelDescription))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.TxMsgId))
			{
				return false;
			}
			this.AddRowMsgId(rowData.MsgId, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write(writer, false, Fields[this.ColMap[4]]);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PushSubscribeTable.RowData rowData = new PushSubscribeTable.RowData();
			base.Read<uint>(reader, ref rowData.MsgId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.Time, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.WeekDay, CVSReader.uintParse);
			this.columnno = 3;
			base.Read(reader, ref rowData.IsShow);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.SubscribeDescription, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.CancelDescription, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.TxMsgId, CVSReader.uintParse);
			this.columnno = 7;
			this.AddRowMsgId(rowData.MsgId, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
