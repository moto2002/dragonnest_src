using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FashionSuitTable : CVSReader
	{
		public class RowData
		{
			public int SuitID;

			public string SuitName;

			public int SuitQuality;

			public string[] SuitIcon;

			public uint[] FashionID;

			public Seq2ListRef<uint> Effect2;

			public Seq2ListRef<uint> Effect3;

			public Seq2ListRef<uint> Effect4;

			public Seq2ListRef<uint> Effect5;

			public Seq2ListRef<uint> Effect6;

			public Seq2ListRef<uint> Effect7;

			public Seq2ListRef<uint> All1;

			public Seq2ListRef<uint> All2;

			public Seq2ListRef<uint> All3;

			public Seq2ListRef<uint> All4;

			public string SuitAtlas;

			public int All0SP;

			public int All1SP;

			public int All2SP;

			public int All3SP;

			public int All4SP;

			public bool NoSale;

			public int ShowLevel;

			public int OverAll;
		}

		public List<FashionSuitTable.RowData> Table = new List<FashionSuitTable.RowData>();

		public FashionSuitTable.RowData GetBySuitID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchSuitID(key, 0, this.Table.Count - 1);
		}

		private FashionSuitTable.RowData BinarySearchSuitID(int key, int min, int max)
		{
			FashionSuitTable.RowData rowData = this.Table[min];
			if (rowData.SuitID == key)
			{
				return rowData;
			}
			FashionSuitTable.RowData rowData2 = this.Table[max];
			if (rowData2.SuitID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			FashionSuitTable.RowData rowData3 = this.Table[num];
			if (rowData3.SuitID.CompareTo(key) > 0)
			{
				return this.BinarySearchSuitID(key, min, num);
			}
			if (rowData3.SuitID.CompareTo(key) < 0)
			{
				return this.BinarySearchSuitID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowSuitID(int key, FashionSuitTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			FashionSuitTable.RowData rowData = this.Table[min];
			if (rowData.SuitID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.SuitID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FashionSuitTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			FashionSuitTable.RowData rowData2 = this.Table[max];
			if (rowData2.SuitID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.SuitID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FashionSuitTable duplicate id:{0}  lineno: {1}", new object[]
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
			FashionSuitTable.RowData rowData3 = this.Table[num];
			if (rowData3.SuitID.CompareTo(key) > 0)
			{
				this.AddRowSuitID(key, row, min, num);
				return;
			}
			if (rowData3.SuitID.CompareTo(key) < 0)
			{
				this.AddRowSuitID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: FashionSuitTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SuitID",
				"SuitName",
				"SuitQuality",
				"SuitIcon",
				"FashionID",
				"Effect2",
				"Effect3",
				"Effect4",
				"Effect5",
				"Effect6",
				"Effect7",
				"All1",
				"All2",
				"All3",
				"All4",
				"SuitAtlas",
				"All0SP",
				"All1SP",
				"All2SP",
				"All3SP",
				"All4SP",
				"NoSale",
				"ShowLevel",
				"OverAll"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FashionSuitTable.RowData rowData = new FashionSuitTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SuitID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SuitName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SuitQuality))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.SuitIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.FashionID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.Effect2, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.Effect3, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[7]], ref rowData.Effect4, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[8]], ref rowData.Effect5, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[9]], ref rowData.Effect6, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[10]], ref rowData.Effect7, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[11]], ref rowData.All1, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[12]], ref rowData.All2, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[13]], ref rowData.All3, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[14]], ref rowData.All4, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.SuitAtlas))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.All0SP))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.All1SP))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.All2SP))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.All3SP))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[20]], ref rowData.All4SP))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[21]], ref rowData.NoSale))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[22]], ref rowData.ShowLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[23]], ref rowData.OverAll))
			{
				return false;
			}
			this.AddRowSuitID(rowData.SuitID, rowData, 0, this.Table.Count - 1);
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
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
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
			base.Write<string>(writer, Fields[this.ColMap[15]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[16]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[17]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[18]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[19]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[20]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[21]]);
			base.Write<int>(writer, Fields[this.ColMap[22]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[23]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FashionSuitTable.RowData rowData = new FashionSuitTable.RowData();
			base.Read<int>(reader, ref rowData.SuitID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SuitName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.SuitQuality, CVSReader.intParse);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.SuitIcon, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadArray<uint>(reader, ref rowData.FashionID, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadSeqList<uint>(reader, ref rowData.Effect2, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeqList<uint>(reader, ref rowData.Effect3, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadSeqList<uint>(reader, ref rowData.Effect4, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadSeqList<uint>(reader, ref rowData.Effect5, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadSeqList<uint>(reader, ref rowData.Effect6, CVSReader.uintParse);
			this.columnno = 9;
			base.ReadSeqList<uint>(reader, ref rowData.Effect7, CVSReader.uintParse);
			this.columnno = 10;
			base.ReadSeqList<uint>(reader, ref rowData.All1, CVSReader.uintParse);
			this.columnno = 11;
			base.ReadSeqList<uint>(reader, ref rowData.All2, CVSReader.uintParse);
			this.columnno = 12;
			base.ReadSeqList<uint>(reader, ref rowData.All3, CVSReader.uintParse);
			this.columnno = 13;
			base.ReadSeqList<uint>(reader, ref rowData.All4, CVSReader.uintParse);
			this.columnno = 14;
			base.Read<string>(reader, ref rowData.SuitAtlas, CVSReader.stringParse);
			this.columnno = 15;
			base.Read<int>(reader, ref rowData.All0SP, CVSReader.intParse);
			this.columnno = 16;
			base.Read<int>(reader, ref rowData.All1SP, CVSReader.intParse);
			this.columnno = 17;
			base.Read<int>(reader, ref rowData.All2SP, CVSReader.intParse);
			this.columnno = 18;
			base.Read<int>(reader, ref rowData.All3SP, CVSReader.intParse);
			this.columnno = 19;
			base.Read<int>(reader, ref rowData.All4SP, CVSReader.intParse);
			this.columnno = 20;
			base.Read(reader, ref rowData.NoSale);
			this.columnno = 21;
			base.Read<int>(reader, ref rowData.ShowLevel, CVSReader.intParse);
			this.columnno = 22;
			base.Read<int>(reader, ref rowData.OverAll, CVSReader.intParse);
			this.columnno = 23;
			this.AddRowSuitID(rowData.SuitID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
