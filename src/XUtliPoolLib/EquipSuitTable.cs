using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class EquipSuitTable : CVSReader
	{
		public class RowData
		{
			public int SuitID;

			public string SuitName;

			public int SuitQuality;

			public int[] EquipID;

			public Seq2Ref<float> Effect1;

			public Seq2Ref<float> Effect2;

			public Seq2Ref<float> Effect3;

			public Seq2Ref<float> Effect4;

			public Seq2Ref<float> Effect5;

			public Seq2Ref<float> Effect6;

			public Seq2Ref<float> Effect7;

			public Seq2Ref<float> Effect8;

			public Seq2Ref<float> Effect9;

			public Seq2Ref<float> Effect10;

			public int ProfID;

			public int Level;

			public bool IsCreateShow;
		}

		public List<EquipSuitTable.RowData> Table = new List<EquipSuitTable.RowData>();

		public EquipSuitTable.RowData GetBySuitID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchSuitID(key, 0, this.Table.Count - 1);
		}

		private EquipSuitTable.RowData BinarySearchSuitID(int key, int min, int max)
		{
			EquipSuitTable.RowData rowData = this.Table[min];
			if (rowData.SuitID == key)
			{
				return rowData;
			}
			EquipSuitTable.RowData rowData2 = this.Table[max];
			if (rowData2.SuitID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			EquipSuitTable.RowData rowData3 = this.Table[num];
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

		private void AddRowSuitID(int key, EquipSuitTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			EquipSuitTable.RowData rowData = this.Table[min];
			if (rowData.SuitID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.SuitID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: EquipSuitTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			EquipSuitTable.RowData rowData2 = this.Table[max];
			if (rowData2.SuitID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.SuitID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: EquipSuitTable duplicate id:{0}  lineno: {1}", new object[]
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
			EquipSuitTable.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: EquipSuitTable duplicate id:{0}  lineno: {1}", new object[]
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
				"EquipID",
				"Effect1",
				"Effect2",
				"Effect3",
				"Effect4",
				"Effect5",
				"Effect6",
				"Effect7",
				"Effect8",
				"Effect9",
				"Effect10",
				"ProfID",
				"Level",
				"IsCreateShow"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			EquipSuitTable.RowData rowData = new EquipSuitTable.RowData();
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
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.EquipID))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[4]], ref rowData.Effect1, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[5]], ref rowData.Effect2, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[6]], ref rowData.Effect3, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[7]], ref rowData.Effect4, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[8]], ref rowData.Effect5, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[9]], ref rowData.Effect6, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[10]], ref rowData.Effect7, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[11]], ref rowData.Effect8, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[12]], ref rowData.Effect9, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[13]], ref rowData.Effect10, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.ProfID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.Level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.IsCreateShow))
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
			base.WriteArray<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.WriteSeq<float>(writer, Fields[this.ColMap[4]], CVSReader.floatParse, 2, "F");
			base.WriteSeq<float>(writer, Fields[this.ColMap[5]], CVSReader.floatParse, 2, "F");
			base.WriteSeq<float>(writer, Fields[this.ColMap[6]], CVSReader.floatParse, 2, "F");
			base.WriteSeq<float>(writer, Fields[this.ColMap[7]], CVSReader.floatParse, 2, "F");
			base.WriteSeq<float>(writer, Fields[this.ColMap[8]], CVSReader.floatParse, 2, "F");
			base.WriteSeq<float>(writer, Fields[this.ColMap[9]], CVSReader.floatParse, 2, "F");
			base.WriteSeq<float>(writer, Fields[this.ColMap[10]], CVSReader.floatParse, 2, "F");
			base.WriteSeq<float>(writer, Fields[this.ColMap[11]], CVSReader.floatParse, 2, "F");
			base.WriteSeq<float>(writer, Fields[this.ColMap[12]], CVSReader.floatParse, 2, "F");
			base.WriteSeq<float>(writer, Fields[this.ColMap[13]], CVSReader.floatParse, 2, "F");
			base.Write<int>(writer, Fields[this.ColMap[14]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[15]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[16]]);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			EquipSuitTable.RowData rowData = new EquipSuitTable.RowData();
			base.Read<int>(reader, ref rowData.SuitID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SuitName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.SuitQuality, CVSReader.intParse);
			this.columnno = 2;
			base.ReadArray<int>(reader, ref rowData.EquipID, CVSReader.intParse);
			this.columnno = 3;
			base.ReadSeq<float>(reader, ref rowData.Effect1, CVSReader.floatParse);
			this.columnno = 4;
			base.ReadSeq<float>(reader, ref rowData.Effect2, CVSReader.floatParse);
			this.columnno = 5;
			base.ReadSeq<float>(reader, ref rowData.Effect3, CVSReader.floatParse);
			this.columnno = 6;
			base.ReadSeq<float>(reader, ref rowData.Effect4, CVSReader.floatParse);
			this.columnno = 7;
			base.ReadSeq<float>(reader, ref rowData.Effect5, CVSReader.floatParse);
			this.columnno = 8;
			base.ReadSeq<float>(reader, ref rowData.Effect6, CVSReader.floatParse);
			this.columnno = 9;
			base.ReadSeq<float>(reader, ref rowData.Effect7, CVSReader.floatParse);
			this.columnno = 10;
			base.ReadSeq<float>(reader, ref rowData.Effect8, CVSReader.floatParse);
			this.columnno = 11;
			base.ReadSeq<float>(reader, ref rowData.Effect9, CVSReader.floatParse);
			this.columnno = 12;
			base.ReadSeq<float>(reader, ref rowData.Effect10, CVSReader.floatParse);
			this.columnno = 13;
			base.Read<int>(reader, ref rowData.ProfID, CVSReader.intParse);
			this.columnno = 14;
			base.Read<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 15;
			base.Read(reader, ref rowData.IsCreateShow);
			this.columnno = 16;
			this.AddRowSuitID(rowData.SuitID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
