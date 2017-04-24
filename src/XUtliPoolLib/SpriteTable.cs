using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SpriteTable : CVSReader
	{
		public class RowData
		{
			public uint SpriteID;

			public string SpriteName;

			public uint SpriteQuality;

			public string SpriteIcon;

			public uint SpriteModelID;

			public string SpriteDescription;

			public string ShowEffect;

			public uint SpriteSkillID;

			public uint PassiveSkillsID;

			public uint PassiveSkillMax;

			public uint AttrID1;

			public uint AttrID2;

			public uint AttrID3;

			public uint AttrID4;

			public uint AttrID5;

			public uint BaseAttr1;

			public uint BaseAttr2;

			public uint BaseAttr3;

			public uint BaseAttr4;

			public uint BaseAttr5;

			public Seq2Ref<uint> InitialRange1;

			public Seq2Ref<uint> InitialRange2;

			public Seq2Ref<uint> InitialRange3;

			public Seq2Ref<uint> InitialRange4;

			public Seq2Ref<uint> InitialRange5;

			public Seq2Ref<uint> Range1;

			public Seq2Ref<uint> Range2;

			public Seq2Ref<uint> Range3;

			public Seq2Ref<uint> Range4;

			public Seq2Ref<uint> Range5;

			public Seq3ListRef<int> SmeltAttr1;

			public Seq3ListRef<int> SmeltAttr2;

			public Seq3ListRef<int> SmeltAttr3;

			public Seq3ListRef<int> SmeltAttr4;

			public Seq3ListRef<int> SmeltAttr5;

			public uint AttrMin1;

			public uint AttrMax1;

			public uint AttrMin2;

			public uint AttrMax2;

			public uint AttrMin3;

			public uint AttrMax3;

			public uint AttrMin4;

			public uint AttrMax4;

			public uint AttrMin5;

			public uint AttrMax5;

			public uint[] DropID;

			public int[] SpriteShow;

			public uint PresentID;

			public string Color;

			public string DeathAnim;

			public string ReviveAnim;

			public int IllustrationShow;
		}

		public List<SpriteTable.RowData> Table = new List<SpriteTable.RowData>();

		public SpriteTable.RowData GetBySpriteID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchSpriteID(key, 0, this.Table.Count - 1);
		}

		public SpriteTable.RowData GetByPresentID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			int i = 0;
			int count = this.Table.Count;
			while (i < count)
			{
				if (this.Table[i].PresentID == key)
				{
					return this.Table[i];
				}
				i++;
			}
			return null;
		}

		private SpriteTable.RowData BinarySearchSpriteID(uint key, int min, int max)
		{
			SpriteTable.RowData rowData = this.Table[min];
			if (rowData.SpriteID == key)
			{
				return rowData;
			}
			SpriteTable.RowData rowData2 = this.Table[max];
			if (rowData2.SpriteID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			SpriteTable.RowData rowData3 = this.Table[num];
			if (rowData3.SpriteID.CompareTo(key) > 0)
			{
				return this.BinarySearchSpriteID(key, min, num);
			}
			if (rowData3.SpriteID.CompareTo(key) < 0)
			{
				return this.BinarySearchSpriteID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowSpriteID(uint key, SpriteTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			SpriteTable.RowData rowData = this.Table[min];
			if (rowData.SpriteID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.SpriteID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SpriteTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			SpriteTable.RowData rowData2 = this.Table[max];
			if (rowData2.SpriteID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.SpriteID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SpriteTable duplicate id:{0}  lineno: {1}", new object[]
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
			SpriteTable.RowData rowData3 = this.Table[num];
			if (rowData3.SpriteID.CompareTo(key) > 0)
			{
				this.AddRowSpriteID(key, row, min, num);
				return;
			}
			if (rowData3.SpriteID.CompareTo(key) < 0)
			{
				this.AddRowSpriteID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: SpriteTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SpriteID",
				"SpriteName",
				"SpriteQuality",
				"SpriteIcon",
				"SpriteModelID",
				"SpriteDescription",
				"ShowEffect",
				"SpriteSkillID",
				"PassiveSkillsID",
				"PassiveSkillMax",
				"AttrID1",
				"AttrID2",
				"AttrID3",
				"AttrID4",
				"AttrID5",
				"BaseAttr1",
				"BaseAttr2",
				"BaseAttr3",
				"BaseAttr4",
				"BaseAttr5",
				"InitialRange1",
				"InitialRange2",
				"InitialRange3",
				"InitialRange4",
				"InitialRange5",
				"Range1",
				"Range2",
				"Range3",
				"Range4",
				"Range5",
				"SmeltAttr1",
				"SmeltAttr2",
				"SmeltAttr3",
				"SmeltAttr4",
				"SmeltAttr5",
				"AttrMin1",
				"AttrMax1",
				"AttrMin2",
				"AttrMax2",
				"AttrMin3",
				"AttrMax3",
				"AttrMin4",
				"AttrMax4",
				"AttrMin5",
				"AttrMax5",
				"DropID",
				"SpriteShow",
				"PresentID",
				"Color",
				"DeathAnim",
				"ReviveAnim",
				"IllustrationShow"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SpriteTable.RowData rowData = new SpriteTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SpriteID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SpriteName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SpriteQuality))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.SpriteIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.SpriteModelID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.SpriteDescription))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.ShowEffect))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.SpriteSkillID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.PassiveSkillsID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.PassiveSkillMax))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.AttrID1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.AttrID2))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.AttrID3))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.AttrID4))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.AttrID5))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.BaseAttr1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.BaseAttr2))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.BaseAttr3))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.BaseAttr4))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.BaseAttr5))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[20]], ref rowData.InitialRange1, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[21]], ref rowData.InitialRange2, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[22]], ref rowData.InitialRange3, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[23]], ref rowData.InitialRange4, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[24]], ref rowData.InitialRange5, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[25]], ref rowData.Range1, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[26]], ref rowData.Range2, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[27]], ref rowData.Range3, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[28]], ref rowData.Range4, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[29]], ref rowData.Range5, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[30]], ref rowData.SmeltAttr1, CVSReader.intParse, "3I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[31]], ref rowData.SmeltAttr2, CVSReader.intParse, "3I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[32]], ref rowData.SmeltAttr3, CVSReader.intParse, "3I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[33]], ref rowData.SmeltAttr4, CVSReader.intParse, "3I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[34]], ref rowData.SmeltAttr5, CVSReader.intParse, "3I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[35]], ref rowData.AttrMin1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[36]], ref rowData.AttrMax1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[37]], ref rowData.AttrMin2))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[38]], ref rowData.AttrMax2))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[39]], ref rowData.AttrMin3))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[40]], ref rowData.AttrMax3))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[41]], ref rowData.AttrMin4))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[42]], ref rowData.AttrMax4))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[43]], ref rowData.AttrMin5))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[44]], ref rowData.AttrMax5))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[45]], ref rowData.DropID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[46]], ref rowData.SpriteShow))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[47]], ref rowData.PresentID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[48]], ref rowData.Color))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[49]], ref rowData.DeathAnim))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[50]], ref rowData.ReviveAnim))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[51]], ref rowData.IllustrationShow))
			{
				return false;
			}
			this.AddRowSpriteID(rowData.SpriteID, rowData, 0, this.Table.Count - 1);
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
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[15]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[16]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[17]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[18]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[19]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[20]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[21]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[22]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[23]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[24]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[25]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[26]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[27]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[28]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[29]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[30]], CVSReader.intParse, 3, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[31]], CVSReader.intParse, 3, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[32]], CVSReader.intParse, 3, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[33]], CVSReader.intParse, 3, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[34]], CVSReader.intParse, 3, "I");
			base.Write<uint>(writer, Fields[this.ColMap[35]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[36]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[37]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[38]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[39]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[40]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[41]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[42]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[43]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[44]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[45]], CVSReader.uintParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[46]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[47]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[48]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[49]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[50]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[51]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SpriteTable.RowData rowData = new SpriteTable.RowData();
			base.Read<uint>(reader, ref rowData.SpriteID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SpriteName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SpriteQuality, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.SpriteIcon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.SpriteModelID, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.SpriteDescription, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.ShowEffect, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.SpriteSkillID, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.PassiveSkillsID, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.PassiveSkillMax, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.AttrID1, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.AttrID2, CVSReader.uintParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.AttrID3, CVSReader.uintParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.AttrID4, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.AttrID5, CVSReader.uintParse);
			this.columnno = 14;
			base.Read<uint>(reader, ref rowData.BaseAttr1, CVSReader.uintParse);
			this.columnno = 15;
			base.Read<uint>(reader, ref rowData.BaseAttr2, CVSReader.uintParse);
			this.columnno = 16;
			base.Read<uint>(reader, ref rowData.BaseAttr3, CVSReader.uintParse);
			this.columnno = 17;
			base.Read<uint>(reader, ref rowData.BaseAttr4, CVSReader.uintParse);
			this.columnno = 18;
			base.Read<uint>(reader, ref rowData.BaseAttr5, CVSReader.uintParse);
			this.columnno = 19;
			base.ReadSeq<uint>(reader, ref rowData.InitialRange1, CVSReader.uintParse);
			this.columnno = 20;
			base.ReadSeq<uint>(reader, ref rowData.InitialRange2, CVSReader.uintParse);
			this.columnno = 21;
			base.ReadSeq<uint>(reader, ref rowData.InitialRange3, CVSReader.uintParse);
			this.columnno = 22;
			base.ReadSeq<uint>(reader, ref rowData.InitialRange4, CVSReader.uintParse);
			this.columnno = 23;
			base.ReadSeq<uint>(reader, ref rowData.InitialRange5, CVSReader.uintParse);
			this.columnno = 24;
			base.ReadSeq<uint>(reader, ref rowData.Range1, CVSReader.uintParse);
			this.columnno = 25;
			base.ReadSeq<uint>(reader, ref rowData.Range2, CVSReader.uintParse);
			this.columnno = 26;
			base.ReadSeq<uint>(reader, ref rowData.Range3, CVSReader.uintParse);
			this.columnno = 27;
			base.ReadSeq<uint>(reader, ref rowData.Range4, CVSReader.uintParse);
			this.columnno = 28;
			base.ReadSeq<uint>(reader, ref rowData.Range5, CVSReader.uintParse);
			this.columnno = 29;
			base.ReadSeqList<int>(reader, ref rowData.SmeltAttr1, CVSReader.intParse);
			this.columnno = 30;
			base.ReadSeqList<int>(reader, ref rowData.SmeltAttr2, CVSReader.intParse);
			this.columnno = 31;
			base.ReadSeqList<int>(reader, ref rowData.SmeltAttr3, CVSReader.intParse);
			this.columnno = 32;
			base.ReadSeqList<int>(reader, ref rowData.SmeltAttr4, CVSReader.intParse);
			this.columnno = 33;
			base.ReadSeqList<int>(reader, ref rowData.SmeltAttr5, CVSReader.intParse);
			this.columnno = 34;
			base.Read<uint>(reader, ref rowData.AttrMin1, CVSReader.uintParse);
			this.columnno = 35;
			base.Read<uint>(reader, ref rowData.AttrMax1, CVSReader.uintParse);
			this.columnno = 36;
			base.Read<uint>(reader, ref rowData.AttrMin2, CVSReader.uintParse);
			this.columnno = 37;
			base.Read<uint>(reader, ref rowData.AttrMax2, CVSReader.uintParse);
			this.columnno = 38;
			base.Read<uint>(reader, ref rowData.AttrMin3, CVSReader.uintParse);
			this.columnno = 39;
			base.Read<uint>(reader, ref rowData.AttrMax3, CVSReader.uintParse);
			this.columnno = 40;
			base.Read<uint>(reader, ref rowData.AttrMin4, CVSReader.uintParse);
			this.columnno = 41;
			base.Read<uint>(reader, ref rowData.AttrMax4, CVSReader.uintParse);
			this.columnno = 42;
			base.Read<uint>(reader, ref rowData.AttrMin5, CVSReader.uintParse);
			this.columnno = 43;
			base.Read<uint>(reader, ref rowData.AttrMax5, CVSReader.uintParse);
			this.columnno = 44;
			base.ReadArray<uint>(reader, ref rowData.DropID, CVSReader.uintParse);
			this.columnno = 45;
			base.ReadArray<int>(reader, ref rowData.SpriteShow, CVSReader.intParse);
			this.columnno = 46;
			base.Read<uint>(reader, ref rowData.PresentID, CVSReader.uintParse);
			this.columnno = 47;
			base.Read<string>(reader, ref rowData.Color, CVSReader.stringParse);
			this.columnno = 48;
			base.Read<string>(reader, ref rowData.DeathAnim, CVSReader.stringParse);
			this.columnno = 49;
			base.Read<string>(reader, ref rowData.ReviveAnim, CVSReader.stringParse);
			this.columnno = 50;
			base.Read<int>(reader, ref rowData.IllustrationShow, CVSReader.intParse);
			this.columnno = 51;
			this.AddRowSpriteID(rowData.SpriteID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
