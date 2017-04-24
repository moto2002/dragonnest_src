using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FirstPassTable : CVSReader
	{
		public class RowData
		{
			public int ID;

			public int[] SceneID;

			public int RewardID;

			public Seq3ListRef<int> CommendReward;

			public int SystemId;

			public string Des;

			public string BgTexName;

			public uint DNId;

			public uint NestType;

			public string RankTittle;
		}

		public List<FirstPassTable.RowData> Table = new List<FirstPassTable.RowData>();

		public FirstPassTable.RowData GetByID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private FirstPassTable.RowData BinarySearchID(int key, int min, int max)
		{
			FirstPassTable.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			FirstPassTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			FirstPassTable.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				return this.BinarySearchID(key, min, num);
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				return this.BinarySearchID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowID(int key, FirstPassTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			FirstPassTable.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FirstPassTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			FirstPassTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FirstPassTable duplicate id:{0}  lineno: {1}", new object[]
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
			FirstPassTable.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				this.AddRowID(key, row, min, num);
				return;
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				this.AddRowID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: FirstPassTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"SceneID",
				"RewardID",
				"CommendReward",
				"SystemId",
				"Des",
				"BgTexName",
				"DNId",
				"NestType",
				"RankTittle"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FirstPassTable.RowData rowData = new FirstPassTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SceneID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.RewardID))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[3]], ref rowData.CommendReward, CVSReader.intParse, "3I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.SystemId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Des))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.BgTexName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.DNId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.NestType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.RankTittle))
			{
				return false;
			}
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse, 3, "I");
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FirstPassTable.RowData rowData = new FirstPassTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<int>(reader, ref rowData.SceneID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.RewardID, CVSReader.intParse);
			this.columnno = 2;
			base.ReadSeqList<int>(reader, ref rowData.CommendReward, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.SystemId, CVSReader.intParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Des, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.BgTexName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.DNId, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.NestType, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.RankTittle, CVSReader.stringParse);
			this.columnno = 9;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
