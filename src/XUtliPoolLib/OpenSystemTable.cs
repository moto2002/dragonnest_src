using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class OpenSystemTable : CVSReader
	{
		public class RowData
		{
			public int TaskID;

			public int PlayerLevel;

			public int SystemID;

			public int NewbieGuideID;

			public string SystemDescription;

			public string Icon;

			public int Priority;

			public int[] TitanItems;

			public uint[] NoRedPointLevel;

			public Seq2ListRef<uint> Reward;

			public int FatherID;

			public uint OpenDay;

			public bool IsOpen;
		}

		public List<OpenSystemTable.RowData> Table = new List<OpenSystemTable.RowData>();

		public OpenSystemTable.RowData GetBySystemID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchSystemID(key, 0, this.Table.Count - 1);
		}

		private OpenSystemTable.RowData BinarySearchSystemID(int key, int min, int max)
		{
			OpenSystemTable.RowData rowData = this.Table[min];
			if (rowData.SystemID == key)
			{
				return rowData;
			}
			OpenSystemTable.RowData rowData2 = this.Table[max];
			if (rowData2.SystemID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			OpenSystemTable.RowData rowData3 = this.Table[num];
			if (rowData3.SystemID.CompareTo(key) > 0)
			{
				return this.BinarySearchSystemID(key, min, num);
			}
			if (rowData3.SystemID.CompareTo(key) < 0)
			{
				return this.BinarySearchSystemID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowSystemID(int key, OpenSystemTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			OpenSystemTable.RowData rowData = this.Table[min];
			if (rowData.SystemID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.SystemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: OpenSystemTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			OpenSystemTable.RowData rowData2 = this.Table[max];
			if (rowData2.SystemID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.SystemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: OpenSystemTable duplicate id:{0}  lineno: {1}", new object[]
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
			OpenSystemTable.RowData rowData3 = this.Table[num];
			if (rowData3.SystemID.CompareTo(key) > 0)
			{
				this.AddRowSystemID(key, row, min, num);
				return;
			}
			if (rowData3.SystemID.CompareTo(key) < 0)
			{
				this.AddRowSystemID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: OpenSystemTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"TaskID",
				"PlayerLevel",
				"SystemID",
				"NewbieGuideID",
				"SystemDescription",
				"Icon",
				"Priority",
				"TitanItems",
				"NoRedPointLevel",
				"Reward",
				"FatherID",
				"OpenDay",
				"IsOpen"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			OpenSystemTable.RowData rowData = new OpenSystemTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.TaskID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.PlayerLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SystemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.NewbieGuideID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.SystemDescription))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Priority))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.TitanItems))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.NoRedPointLevel))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[9]], ref rowData.Reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.FatherID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.OpenDay))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.IsOpen))
			{
				return false;
			}
			this.AddRowSystemID(rowData.SystemID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse, 2, "U");
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse);
			base.Write(writer, false, Fields[this.ColMap[12]]);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			OpenSystemTable.RowData rowData = new OpenSystemTable.RowData();
			base.Read<int>(reader, ref rowData.TaskID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.PlayerLevel, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.NewbieGuideID, CVSReader.intParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.SystemDescription, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.Priority, CVSReader.intParse);
			this.columnno = 6;
			base.ReadArray<int>(reader, ref rowData.TitanItems, CVSReader.intParse);
			this.columnno = 7;
			base.ReadArray<uint>(reader, ref rowData.NoRedPointLevel, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadSeqList<uint>(reader, ref rowData.Reward, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.FatherID, CVSReader.intParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.OpenDay, CVSReader.uintParse);
			this.columnno = 11;
			base.Read(reader, ref rowData.IsOpen);
			this.columnno = 12;
			this.AddRowSystemID(rowData.SystemID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
