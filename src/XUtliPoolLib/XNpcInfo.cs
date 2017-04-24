using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class XNpcInfo : CVSReader
	{
		public class RowData
		{
			public uint ID;

			public string Name;

			public uint PresentID;

			public string Icon;

			public string Portrait;

			public uint SceneID;

			public float[] Position;

			public float[] Rotation;

			public uint RequiredTaskID;

			public string[] Content;

			public int[] FunctionList;

			public uint Gazing;

			public string[] Voice;

			public string[] ShowUp;

			public bool OnlyHead;

			public int LinkSystem;

			public uint NPCType;

			public uint DisappearTask;
		}

		public List<XNpcInfo.RowData> Table = new List<XNpcInfo.RowData>();

		public XNpcInfo.RowData GetByNPCID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchNPCID(key, 0, this.Table.Count - 1);
		}

		private XNpcInfo.RowData BinarySearchNPCID(uint key, int min, int max)
		{
			XNpcInfo.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			XNpcInfo.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			XNpcInfo.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				return this.BinarySearchNPCID(key, min, num);
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				return this.BinarySearchNPCID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowNPCID(uint key, XNpcInfo.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			XNpcInfo.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: XNpcInfo duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			XNpcInfo.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: XNpcInfo duplicate id:{0}  lineno: {1}", new object[]
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
			XNpcInfo.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				this.AddRowNPCID(key, row, min, num);
				return;
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				this.AddRowNPCID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: XNpcInfo duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"NPCID",
				"NPCName",
				"PresentID",
				"NPCIcon",
				"NPCPortrait",
				"NPCScene",
				"NPCPosition",
				"NPCRotation",
				"RequiredTaskID",
				"Content",
				"FunctionList",
				"Gazing",
				"Voice",
				"ShowUp",
				"OnlyHead",
				"LinkSystem",
				"NPCType",
				"DisappearTask"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			XNpcInfo.RowData rowData = new XNpcInfo.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.PresentID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Portrait))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.SceneID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Position))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.Rotation))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.RequiredTaskID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.Content))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.FunctionList))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.Gazing))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.Voice))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.ShowUp))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.OnlyHead))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.LinkSystem))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.NPCType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.DisappearTask))
			{
				return false;
			}
			this.AddRowNPCID(rowData.ID, rowData, 0, this.Table.Count - 1);
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
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[6]], CVSReader.floatParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[7]], CVSReader.floatParse);
			base.Write<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[12]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[13]], CVSReader.stringParse);
			base.Write(writer, false, Fields[this.ColMap[14]]);
			base.Write<int>(writer, Fields[this.ColMap[15]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[16]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[17]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			XNpcInfo.RowData rowData = new XNpcInfo.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.PresentID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Portrait, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadArray<float>(reader, ref rowData.Position, CVSReader.floatParse);
			this.columnno = 6;
			base.ReadArray<float>(reader, ref rowData.Rotation, CVSReader.floatParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.RequiredTaskID, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadArray<string>(reader, ref rowData.Content, CVSReader.stringParse);
			this.columnno = 9;
			base.ReadArray<int>(reader, ref rowData.FunctionList, CVSReader.intParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.Gazing, CVSReader.uintParse);
			this.columnno = 11;
			base.ReadArray<string>(reader, ref rowData.Voice, CVSReader.stringParse);
			this.columnno = 12;
			base.ReadArray<string>(reader, ref rowData.ShowUp, CVSReader.stringParse);
			this.columnno = 13;
			base.Read(reader, ref rowData.OnlyHead);
			this.columnno = 14;
			base.Read<int>(reader, ref rowData.LinkSystem, CVSReader.intParse);
			this.columnno = 15;
			base.Read<uint>(reader, ref rowData.NPCType, CVSReader.uintParse);
			this.columnno = 16;
			base.Read<uint>(reader, ref rowData.DisappearTask, CVSReader.uintParse);
			this.columnno = 17;
			this.AddRowNPCID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
