using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class BossRushTable : CVSReader
	{
		public class RowData
		{
			public int bossid;

			public Seq2Ref<int> level;

			public int[] bossdifficult;

			public int rank;

			public float atkpercent;

			public float defpercent;

			public float lifepercent;

			public string bosstip;

			public int ragetime;

			public Seq2Ref<int> ragebuff;

			public int qniqueid;

			public int percent;

			public Seq2ListRef<uint> reward;

			public string comment;

			public string bosstip2;

			public string bossTexture;
		}

		public List<BossRushTable.RowData> Table = new List<BossRushTable.RowData>();

		public BossRushTable.RowData GetByqniqueid(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchqniqueid(key, 0, this.Table.Count - 1);
		}

		private BossRushTable.RowData BinarySearchqniqueid(int key, int min, int max)
		{
			BossRushTable.RowData rowData = this.Table[min];
			if (rowData.qniqueid == key)
			{
				return rowData;
			}
			BossRushTable.RowData rowData2 = this.Table[max];
			if (rowData2.qniqueid == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			BossRushTable.RowData rowData3 = this.Table[num];
			if (rowData3.qniqueid.CompareTo(key) > 0)
			{
				return this.BinarySearchqniqueid(key, min, num);
			}
			if (rowData3.qniqueid.CompareTo(key) < 0)
			{
				return this.BinarySearchqniqueid(key, num, max);
			}
			return rowData3;
		}

		private void AddRowqniqueid(int key, BossRushTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			BossRushTable.RowData rowData = this.Table[min];
			if (rowData.qniqueid.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.qniqueid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: BossRushTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			BossRushTable.RowData rowData2 = this.Table[max];
			if (rowData2.qniqueid.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.qniqueid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: BossRushTable duplicate id:{0}  lineno: {1}", new object[]
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
			BossRushTable.RowData rowData3 = this.Table[num];
			if (rowData3.qniqueid.CompareTo(key) > 0)
			{
				this.AddRowqniqueid(key, row, min, num);
				return;
			}
			if (rowData3.qniqueid.CompareTo(key) < 0)
			{
				this.AddRowqniqueid(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: BossRushTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"bossid",
				"level",
				"bossdifficult",
				"rank",
				"atkpercent",
				"defpercent",
				"lifepercent",
				"bosstip",
				"ragetime",
				"ragebuff",
				"qniqueid",
				"percent",
				"reward",
				"comment",
				"bosstip2",
				"bossTexture"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			BossRushTable.RowData rowData = new BossRushTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.bossid))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[1]], ref rowData.level, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.bossdifficult))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.rank))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.atkpercent))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.defpercent))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.lifepercent))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.bosstip))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.ragetime))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[9]], ref rowData.ragebuff, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.qniqueid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.percent))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[12]], ref rowData.reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.comment))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.bosstip2))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.bossTexture))
			{
				return false;
			}
			this.AddRowqniqueid(rowData.qniqueid, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse, 2, "I");
			base.WriteArray<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<float>(writer, Fields[this.ColMap[4]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[5]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[6]], CVSReader.floatParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[11]], CVSReader.intParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[13]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[14]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[15]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			BossRushTable.RowData rowData = new BossRushTable.RowData();
			base.Read<int>(reader, ref rowData.bossid, CVSReader.intParse);
			this.columnno = 0;
			base.ReadSeq<int>(reader, ref rowData.level, CVSReader.intParse);
			this.columnno = 1;
			base.ReadArray<int>(reader, ref rowData.bossdifficult, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.rank, CVSReader.intParse);
			this.columnno = 3;
			base.Read<float>(reader, ref rowData.atkpercent, CVSReader.floatParse);
			this.columnno = 4;
			base.Read<float>(reader, ref rowData.defpercent, CVSReader.floatParse);
			this.columnno = 5;
			base.Read<float>(reader, ref rowData.lifepercent, CVSReader.floatParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.bosstip, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.ragetime, CVSReader.intParse);
			this.columnno = 8;
			base.ReadSeq<int>(reader, ref rowData.ragebuff, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.qniqueid, CVSReader.intParse);
			this.columnno = 10;
			base.Read<int>(reader, ref rowData.percent, CVSReader.intParse);
			this.columnno = 11;
			base.ReadSeqList<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.comment, CVSReader.stringParse);
			this.columnno = 13;
			base.Read<string>(reader, ref rowData.bosstip2, CVSReader.stringParse);
			this.columnno = 14;
			base.Read<string>(reader, ref rowData.bossTexture, CVSReader.stringParse);
			this.columnno = 15;
			this.AddRowqniqueid(rowData.qniqueid, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
