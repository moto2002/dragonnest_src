using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildSalaryTable : CVSReader
	{
		public class RowData
		{
			public uint GuildLevel;

			public uint[] GuildReview;

			public uint AwardPenalty;

			public Seq2ListRef<uint> NumberTransformation;

			public Seq2ListRef<uint> PrestigeTransformation;

			public Seq2ListRef<uint> ActiveTransformation;

			public Seq2ListRef<uint> EXPTransformation;

			public Seq2ListRef<uint> SSalary1;

			public Seq2ListRef<uint> SSalary2;

			public Seq2ListRef<uint> SSalary3;

			public Seq2ListRef<uint> SSalary4;

			public Seq2ListRef<uint> SSalary5;

			public Seq2ListRef<uint> ASalary1;

			public Seq2ListRef<uint> ASalary2;

			public Seq2ListRef<uint> ASalary3;

			public Seq2ListRef<uint> ASalary4;

			public Seq2ListRef<uint> ASalary5;

			public Seq2ListRef<uint> BSalary1;

			public Seq2ListRef<uint> BSalary2;

			public Seq2ListRef<uint> BSalary3;

			public Seq2ListRef<uint> BSalary4;

			public Seq2ListRef<uint> BSalary5;

			public Seq2ListRef<uint> CSalary1;

			public Seq2ListRef<uint> CSalary2;

			public Seq2ListRef<uint> CSalary3;

			public Seq2ListRef<uint> CSalary4;

			public Seq2ListRef<uint> CSalary5;

			public Seq2ListRef<uint> DSalary1;

			public Seq2ListRef<uint> DSalary2;

			public Seq2ListRef<uint> DSalary3;

			public Seq2ListRef<uint> DSalary4;

			public Seq2ListRef<uint> DSalary5;
		}

		public List<GuildSalaryTable.RowData> Table = new List<GuildSalaryTable.RowData>();

		public GuildSalaryTable.RowData GetByGuildLevel(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchGuildLevel(key, 0, this.Table.Count - 1);
		}

		private GuildSalaryTable.RowData BinarySearchGuildLevel(uint key, int min, int max)
		{
			GuildSalaryTable.RowData rowData = this.Table[min];
			if (rowData.GuildLevel == key)
			{
				return rowData;
			}
			GuildSalaryTable.RowData rowData2 = this.Table[max];
			if (rowData2.GuildLevel == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GuildSalaryTable.RowData rowData3 = this.Table[num];
			if (rowData3.GuildLevel.CompareTo(key) > 0)
			{
				return this.BinarySearchGuildLevel(key, min, num);
			}
			if (rowData3.GuildLevel.CompareTo(key) < 0)
			{
				return this.BinarySearchGuildLevel(key, num, max);
			}
			return rowData3;
		}

		private void AddRowGuildLevel(uint key, GuildSalaryTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GuildSalaryTable.RowData rowData = this.Table[min];
			if (rowData.GuildLevel.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.GuildLevel == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildSalaryTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GuildSalaryTable.RowData rowData2 = this.Table[max];
			if (rowData2.GuildLevel.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.GuildLevel == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildSalaryTable duplicate id:{0}  lineno: {1}", new object[]
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
			GuildSalaryTable.RowData rowData3 = this.Table[num];
			if (rowData3.GuildLevel.CompareTo(key) > 0)
			{
				this.AddRowGuildLevel(key, row, min, num);
				return;
			}
			if (rowData3.GuildLevel.CompareTo(key) < 0)
			{
				this.AddRowGuildLevel(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildSalaryTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"GuildLevel",
				"GuildReview",
				"AwardPenalty",
				"NumberTransformation",
				"PrestigeTransformation",
				"ActiveTransformation",
				"EXPTransformation",
				"SSalary1",
				"SSalary2",
				"SSalary3",
				"SSalary4",
				"SSalary5",
				"ASalary1",
				"ASalary2",
				"ASalary3",
				"ASalary4",
				"ASalary5",
				"BSalary1",
				"BSalary2",
				"BSalary3",
				"BSalary4",
				"BSalary5",
				"CSalary1",
				"CSalary2",
				"CSalary3",
				"CSalary4",
				"CSalary5",
				"DSalary1",
				"DSalary2",
				"DSalary3",
				"DSalary4",
				"DSalary5"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildSalaryTable.RowData rowData = new GuildSalaryTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.GuildLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.GuildReview))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.AwardPenalty))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.NumberTransformation, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.PrestigeTransformation, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.ActiveTransformation, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.EXPTransformation, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[7]], ref rowData.SSalary1, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[8]], ref rowData.SSalary2, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[9]], ref rowData.SSalary3, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[10]], ref rowData.SSalary4, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[11]], ref rowData.SSalary5, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[12]], ref rowData.ASalary1, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[13]], ref rowData.ASalary2, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[14]], ref rowData.ASalary3, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[15]], ref rowData.ASalary4, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[16]], ref rowData.ASalary5, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[17]], ref rowData.BSalary1, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[18]], ref rowData.BSalary2, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[19]], ref rowData.BSalary3, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[20]], ref rowData.BSalary4, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[21]], ref rowData.BSalary5, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[22]], ref rowData.CSalary1, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[23]], ref rowData.CSalary2, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[24]], ref rowData.CSalary3, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[25]], ref rowData.CSalary4, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[26]], ref rowData.CSalary5, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[27]], ref rowData.DSalary1, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[28]], ref rowData.DSalary2, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[29]], ref rowData.DSalary3, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[30]], ref rowData.DSalary4, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[31]], ref rowData.DSalary5, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.AddRowGuildLevel(rowData.GuildLevel, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[15]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[16]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[17]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[18]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[19]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[20]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[21]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[22]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[23]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[24]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[25]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[26]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[27]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[28]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[29]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[30]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[31]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildSalaryTable.RowData rowData = new GuildSalaryTable.RowData();
			base.Read<uint>(reader, ref rowData.GuildLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.GuildReview, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.AwardPenalty, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.NumberTransformation, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadSeqList<uint>(reader, ref rowData.PrestigeTransformation, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadSeqList<uint>(reader, ref rowData.ActiveTransformation, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeqList<uint>(reader, ref rowData.EXPTransformation, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadSeqList<uint>(reader, ref rowData.SSalary1, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadSeqList<uint>(reader, ref rowData.SSalary2, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadSeqList<uint>(reader, ref rowData.SSalary3, CVSReader.uintParse);
			this.columnno = 9;
			base.ReadSeqList<uint>(reader, ref rowData.SSalary4, CVSReader.uintParse);
			this.columnno = 10;
			base.ReadSeqList<uint>(reader, ref rowData.SSalary5, CVSReader.uintParse);
			this.columnno = 11;
			base.ReadSeqList<uint>(reader, ref rowData.ASalary1, CVSReader.uintParse);
			this.columnno = 12;
			base.ReadSeqList<uint>(reader, ref rowData.ASalary2, CVSReader.uintParse);
			this.columnno = 13;
			base.ReadSeqList<uint>(reader, ref rowData.ASalary3, CVSReader.uintParse);
			this.columnno = 14;
			base.ReadSeqList<uint>(reader, ref rowData.ASalary4, CVSReader.uintParse);
			this.columnno = 15;
			base.ReadSeqList<uint>(reader, ref rowData.ASalary5, CVSReader.uintParse);
			this.columnno = 16;
			base.ReadSeqList<uint>(reader, ref rowData.BSalary1, CVSReader.uintParse);
			this.columnno = 17;
			base.ReadSeqList<uint>(reader, ref rowData.BSalary2, CVSReader.uintParse);
			this.columnno = 18;
			base.ReadSeqList<uint>(reader, ref rowData.BSalary3, CVSReader.uintParse);
			this.columnno = 19;
			base.ReadSeqList<uint>(reader, ref rowData.BSalary4, CVSReader.uintParse);
			this.columnno = 20;
			base.ReadSeqList<uint>(reader, ref rowData.BSalary5, CVSReader.uintParse);
			this.columnno = 21;
			base.ReadSeqList<uint>(reader, ref rowData.CSalary1, CVSReader.uintParse);
			this.columnno = 22;
			base.ReadSeqList<uint>(reader, ref rowData.CSalary2, CVSReader.uintParse);
			this.columnno = 23;
			base.ReadSeqList<uint>(reader, ref rowData.CSalary3, CVSReader.uintParse);
			this.columnno = 24;
			base.ReadSeqList<uint>(reader, ref rowData.CSalary4, CVSReader.uintParse);
			this.columnno = 25;
			base.ReadSeqList<uint>(reader, ref rowData.CSalary5, CVSReader.uintParse);
			this.columnno = 26;
			base.ReadSeqList<uint>(reader, ref rowData.DSalary1, CVSReader.uintParse);
			this.columnno = 27;
			base.ReadSeqList<uint>(reader, ref rowData.DSalary2, CVSReader.uintParse);
			this.columnno = 28;
			base.ReadSeqList<uint>(reader, ref rowData.DSalary3, CVSReader.uintParse);
			this.columnno = 29;
			base.ReadSeqList<uint>(reader, ref rowData.DSalary4, CVSReader.uintParse);
			this.columnno = 30;
			base.ReadSeqList<uint>(reader, ref rowData.DSalary5, CVSReader.uintParse);
			this.columnno = 31;
			this.AddRowGuildLevel(rowData.GuildLevel, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
