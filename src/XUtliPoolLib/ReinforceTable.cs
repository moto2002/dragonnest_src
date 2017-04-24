using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ReinforceTable : CVSReader
	{
		public class RowData
		{
			public uint ReinforceLv;

			public Seq2ListRef<uint> ReinforceCost;

			public Seq2ListRef<uint> ReinforceT;

			public Seq2ListRef<uint> ReinforceY;

			public Seq2ListRef<uint> ReinforceK;

			public Seq2ListRef<uint> ReinforceS;

			public Seq2ListRef<uint> ReinforceX;

			public Seq2ListRef<uint> ReinforceW;

			public Seq2ListRef<uint> ReinforceF;

			public Seq2ListRef<uint> ReinforceL;

			public Seq2ListRef<uint> ReinforceE;

			public Seq2ListRef<uint> ReinforceJ;

			public Seq2ListRef<uint> ReinforceDecompose;

			public bool Special;
		}

		public List<ReinforceTable.RowData> Table = new List<ReinforceTable.RowData>();

		public ReinforceTable.RowData GetByReinforceLv(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchReinforceLv(key, 0, this.Table.Count - 1);
		}

		private ReinforceTable.RowData BinarySearchReinforceLv(uint key, int min, int max)
		{
			ReinforceTable.RowData rowData = this.Table[min];
			if (rowData.ReinforceLv == key)
			{
				return rowData;
			}
			ReinforceTable.RowData rowData2 = this.Table[max];
			if (rowData2.ReinforceLv == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ReinforceTable.RowData rowData3 = this.Table[num];
			if (rowData3.ReinforceLv.CompareTo(key) > 0)
			{
				return this.BinarySearchReinforceLv(key, min, num);
			}
			if (rowData3.ReinforceLv.CompareTo(key) < 0)
			{
				return this.BinarySearchReinforceLv(key, num, max);
			}
			return rowData3;
		}

		private void AddRowReinforceLv(uint key, ReinforceTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ReinforceTable.RowData rowData = this.Table[min];
			if (rowData.ReinforceLv.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ReinforceLv == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ReinforceTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ReinforceTable.RowData rowData2 = this.Table[max];
			if (rowData2.ReinforceLv.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ReinforceLv == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ReinforceTable duplicate id:{0}  lineno: {1}", new object[]
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
			ReinforceTable.RowData rowData3 = this.Table[num];
			if (rowData3.ReinforceLv.CompareTo(key) > 0)
			{
				this.AddRowReinforceLv(key, row, min, num);
				return;
			}
			if (rowData3.ReinforceLv.CompareTo(key) < 0)
			{
				this.AddRowReinforceLv(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ReinforceTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ReinforceLv",
				"ReinforceCost",
				"ReinforceT",
				"ReinforceY",
				"ReinforceK",
				"ReinforceS",
				"ReinforceX",
				"ReinforceW",
				"ReinforceF",
				"ReinforceL",
				"ReinforceE",
				"ReinforceJ",
				"ReinforceDecompose",
				"Special"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ReinforceTable.RowData rowData = new ReinforceTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ReinforceLv))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.ReinforceCost, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.ReinforceT, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.ReinforceY, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.ReinforceK, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.ReinforceS, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.ReinforceX, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[7]], ref rowData.ReinforceW, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[8]], ref rowData.ReinforceF, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[9]], ref rowData.ReinforceL, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[10]], ref rowData.ReinforceE, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[11]], ref rowData.ReinforceJ, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[12]], ref rowData.ReinforceDecompose, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.Special))
			{
				return false;
			}
			this.AddRowReinforceLv(rowData.ReinforceLv, rowData, 0, this.Table.Count - 1);
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
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
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
			base.Write(writer, false, Fields[this.ColMap[13]]);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ReinforceTable.RowData rowData = new ReinforceTable.RowData();
			base.Read<uint>(reader, ref rowData.ReinforceLv, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.ReinforceCost, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.ReinforceT, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.ReinforceY, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadSeqList<uint>(reader, ref rowData.ReinforceK, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadSeqList<uint>(reader, ref rowData.ReinforceS, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeqList<uint>(reader, ref rowData.ReinforceX, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadSeqList<uint>(reader, ref rowData.ReinforceW, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadSeqList<uint>(reader, ref rowData.ReinforceF, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadSeqList<uint>(reader, ref rowData.ReinforceL, CVSReader.uintParse);
			this.columnno = 9;
			base.ReadSeqList<uint>(reader, ref rowData.ReinforceE, CVSReader.uintParse);
			this.columnno = 10;
			base.ReadSeqList<uint>(reader, ref rowData.ReinforceJ, CVSReader.uintParse);
			this.columnno = 11;
			base.ReadSeqList<uint>(reader, ref rowData.ReinforceDecompose, CVSReader.uintParse);
			this.columnno = 12;
			base.Read(reader, ref rowData.Special);
			this.columnno = 13;
			this.AddRowReinforceLv(rowData.ReinforceLv, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
