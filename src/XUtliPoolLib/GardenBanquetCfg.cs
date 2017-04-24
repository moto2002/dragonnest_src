using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GardenBanquetCfg : CVSReader
	{
		public class RowData
		{
			public uint BanquetID;

			public Seq2ListRef<uint> Stuffs;

			public Seq2Ref<uint> StuffBuffID;

			public Seq2ListRef<uint> BanquetAwards;

			public string BanquetName;

			public uint VoiceOver1Duration;

			public uint VoiceOver2Duration;

			public uint VoiceOver3Duration;

			public uint VoiceOver4Duration;

			public string VoiceOver1;

			public string VoiceOver2;

			public string VoiceOver3;

			public string VoiceOver4;

			public string Desc;
		}

		public List<GardenBanquetCfg.RowData> Table = new List<GardenBanquetCfg.RowData>();

		public GardenBanquetCfg.RowData GetByBanquetID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchBanquetID(key, 0, this.Table.Count - 1);
		}

		private GardenBanquetCfg.RowData BinarySearchBanquetID(uint key, int min, int max)
		{
			GardenBanquetCfg.RowData rowData = this.Table[min];
			if (rowData.BanquetID == key)
			{
				return rowData;
			}
			GardenBanquetCfg.RowData rowData2 = this.Table[max];
			if (rowData2.BanquetID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GardenBanquetCfg.RowData rowData3 = this.Table[num];
			if (rowData3.BanquetID.CompareTo(key) > 0)
			{
				return this.BinarySearchBanquetID(key, min, num);
			}
			if (rowData3.BanquetID.CompareTo(key) < 0)
			{
				return this.BinarySearchBanquetID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowBanquetID(uint key, GardenBanquetCfg.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GardenBanquetCfg.RowData rowData = this.Table[min];
			if (rowData.BanquetID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.BanquetID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GardenBanquetCfg duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GardenBanquetCfg.RowData rowData2 = this.Table[max];
			if (rowData2.BanquetID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.BanquetID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GardenBanquetCfg duplicate id:{0}  lineno: {1}", new object[]
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
			GardenBanquetCfg.RowData rowData3 = this.Table[num];
			if (rowData3.BanquetID.CompareTo(key) > 0)
			{
				this.AddRowBanquetID(key, row, min, num);
				return;
			}
			if (rowData3.BanquetID.CompareTo(key) < 0)
			{
				this.AddRowBanquetID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GardenBanquetCfg duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"BanquetID",
				"Stuffs",
				"StuffBuffID",
				"BanquetAwards",
				"BanquetName",
				"VoiceOver1Duration",
				"VoiceOver2Duration",
				"VoiceOver3Duration",
				"VoiceOver4Duration",
				"VoiceOver1",
				"VoiceOver2",
				"VoiceOver3",
				"VoiceOver4",
				"Desc"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GardenBanquetCfg.RowData rowData = new GardenBanquetCfg.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.BanquetID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.Stuffs, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.StuffBuffID, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.BanquetAwards, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.BanquetName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.VoiceOver1Duration))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.VoiceOver2Duration))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.VoiceOver3Duration))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.VoiceOver4Duration))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.VoiceOver1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.VoiceOver2))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.VoiceOver3))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.VoiceOver4))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.Desc))
			{
				return false;
			}
			this.AddRowBanquetID(rowData.BanquetID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[10]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[11]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[12]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[13]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GardenBanquetCfg.RowData rowData = new GardenBanquetCfg.RowData();
			base.Read<uint>(reader, ref rowData.BanquetID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.Stuffs, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeq<uint>(reader, ref rowData.StuffBuffID, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.BanquetAwards, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.BanquetName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.VoiceOver1Duration, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.VoiceOver2Duration, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.VoiceOver3Duration, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.VoiceOver4Duration, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.VoiceOver1, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.VoiceOver2, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.VoiceOver3, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.VoiceOver4, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 13;
			this.AddRowBanquetID(rowData.BanquetID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
