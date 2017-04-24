using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class LevelSealTypeTable : CVSReader
	{
		public class RowData
		{
			public uint Type;

			public uint Level;

			public uint Time;

			public uint[] UnlockBossID;

			public string UnlockBossName;

			public uint UnlockBossCount;

			public string NowSealImage;

			public string NextSealImageL;

			public string NextSealImageR;

			public string NextSealImageBig;

			public string MailTitle;

			public string MailContent;

			public Seq2ListRef<uint> Award;

			public Seq2Ref<uint> ExchangeInfo;

			public Seq2ListRef<uint> CollectAward;

			public Seq2ListRef<string> CollectAwardMailText;

			public Seq2ListRef<uint> PlayerAward;

			public Seq2Ref<string> PlayerAwardText;

			public uint ClearFindBackMinLevel;

			public int ApplyStudentLevel;

			public int ApplyMasterPromptLevel;
		}

		public List<LevelSealTypeTable.RowData> Table = new List<LevelSealTypeTable.RowData>();

		public LevelSealTypeTable.RowData GetByType(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchType(key, 0, this.Table.Count - 1);
		}

		private LevelSealTypeTable.RowData BinarySearchType(uint key, int min, int max)
		{
			LevelSealTypeTable.RowData rowData = this.Table[min];
			if (rowData.Type == key)
			{
				return rowData;
			}
			LevelSealTypeTable.RowData rowData2 = this.Table[max];
			if (rowData2.Type == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			LevelSealTypeTable.RowData rowData3 = this.Table[num];
			if (rowData3.Type.CompareTo(key) > 0)
			{
				return this.BinarySearchType(key, min, num);
			}
			if (rowData3.Type.CompareTo(key) < 0)
			{
				return this.BinarySearchType(key, num, max);
			}
			return rowData3;
		}

		private void AddRowType(uint key, LevelSealTypeTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			LevelSealTypeTable.RowData rowData = this.Table[min];
			if (rowData.Type.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.Type == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: LevelSealTypeTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			LevelSealTypeTable.RowData rowData2 = this.Table[max];
			if (rowData2.Type.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.Type == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: LevelSealTypeTable duplicate id:{0}  lineno: {1}", new object[]
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
			LevelSealTypeTable.RowData rowData3 = this.Table[num];
			if (rowData3.Type.CompareTo(key) > 0)
			{
				this.AddRowType(key, row, min, num);
				return;
			}
			if (rowData3.Type.CompareTo(key) < 0)
			{
				this.AddRowType(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: LevelSealTypeTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Type",
				"Level",
				"Time",
				"UnlockBossID",
				"UnlockBossName",
				"UnLockBossCount",
				"NowSealImage",
				"NextSealImageL",
				"NextSealImageR",
				"NextSealImageBig",
				"MailTitle",
				"MailContent",
				"Award",
				"ExchangeInfo",
				"CollectAward",
				"CollectAwardMailText",
				"PlayerAward",
				"PlayerAwardText",
				"ClearFindBackMinLevel",
				"ApplyStudentLevel",
				"ApplyMasterPromptLevel"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			LevelSealTypeTable.RowData rowData = new LevelSealTypeTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Time))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.UnlockBossID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.UnlockBossName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.UnlockBossCount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.NowSealImage))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.NextSealImageL))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.NextSealImageR))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.NextSealImageBig))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.MailTitle))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.MailContent))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[12]], ref rowData.Award, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[13]], ref rowData.ExchangeInfo, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[14]], ref rowData.CollectAward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<string>(Fields[this.ColMap[15]], ref rowData.CollectAwardMailText, CVSReader.stringParse, "2S"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[16]], ref rowData.PlayerAward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<string>(Fields[this.ColMap[17]], ref rowData.PlayerAwardText, CVSReader.stringParse, "2S"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.ClearFindBackMinLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.ApplyStudentLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[20]], ref rowData.ApplyMasterPromptLevel))
			{
				return false;
			}
			this.AddRowType(rowData.Type, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[10]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[11]], CVSReader.stringParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<string>(writer, Fields[this.ColMap[15]], CVSReader.stringParse, 2, "S");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[16]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<string>(writer, Fields[this.ColMap[17]], CVSReader.stringParse, 2, "S");
			base.Write<uint>(writer, Fields[this.ColMap[18]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[19]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[20]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			LevelSealTypeTable.RowData rowData = new LevelSealTypeTable.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.Time, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.UnlockBossID, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.UnlockBossName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.UnlockBossCount, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.NowSealImage, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.NextSealImageL, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.NextSealImageR, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.NextSealImageBig, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.MailTitle, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.MailContent, CVSReader.stringParse);
			this.columnno = 11;
			base.ReadSeqList<uint>(reader, ref rowData.Award, CVSReader.uintParse);
			this.columnno = 12;
			base.ReadSeq<uint>(reader, ref rowData.ExchangeInfo, CVSReader.uintParse);
			this.columnno = 13;
			base.ReadSeqList<uint>(reader, ref rowData.CollectAward, CVSReader.uintParse);
			this.columnno = 14;
			base.ReadSeqList<string>(reader, ref rowData.CollectAwardMailText, CVSReader.stringParse);
			this.columnno = 15;
			base.ReadSeqList<uint>(reader, ref rowData.PlayerAward, CVSReader.uintParse);
			this.columnno = 16;
			base.ReadSeq<string>(reader, ref rowData.PlayerAwardText, CVSReader.stringParse);
			this.columnno = 17;
			base.Read<uint>(reader, ref rowData.ClearFindBackMinLevel, CVSReader.uintParse);
			this.columnno = 18;
			base.Read<int>(reader, ref rowData.ApplyStudentLevel, CVSReader.intParse);
			this.columnno = 19;
			base.Read<int>(reader, ref rowData.ApplyMasterPromptLevel, CVSReader.intParse);
			this.columnno = 20;
			this.AddRowType(rowData.Type, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
