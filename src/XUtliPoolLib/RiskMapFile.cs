using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class RiskMapFile : CVSReader
	{
		public class RowData
		{
			public int MapID;

			public int NeedLevel;

			public string FileName;

			public int StepSizeX;

			public int StepSizeY;

			public int StartUIX;

			public int StartUIY;

			public Seq3ListRef<int> BoxPreview;

			public string MapBgName;

			public string MapTittleName;

			public string MapGridBg;
		}

		public List<RiskMapFile.RowData> Table = new List<RiskMapFile.RowData>();

		public RiskMapFile.RowData GetByMapID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchMapID(key, 0, this.Table.Count - 1);
		}

		private RiskMapFile.RowData BinarySearchMapID(int key, int min, int max)
		{
			RiskMapFile.RowData rowData = this.Table[min];
			if (rowData.MapID == key)
			{
				return rowData;
			}
			RiskMapFile.RowData rowData2 = this.Table[max];
			if (rowData2.MapID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			RiskMapFile.RowData rowData3 = this.Table[num];
			if (rowData3.MapID.CompareTo(key) > 0)
			{
				return this.BinarySearchMapID(key, min, num);
			}
			if (rowData3.MapID.CompareTo(key) < 0)
			{
				return this.BinarySearchMapID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowMapID(int key, RiskMapFile.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			RiskMapFile.RowData rowData = this.Table[min];
			if (rowData.MapID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.MapID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: RiskMapFile duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			RiskMapFile.RowData rowData2 = this.Table[max];
			if (rowData2.MapID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.MapID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: RiskMapFile duplicate id:{0}  lineno: {1}", new object[]
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
			RiskMapFile.RowData rowData3 = this.Table[num];
			if (rowData3.MapID.CompareTo(key) > 0)
			{
				this.AddRowMapID(key, row, min, num);
				return;
			}
			if (rowData3.MapID.CompareTo(key) < 0)
			{
				this.AddRowMapID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: RiskMapFile duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"MapID",
				"NeedLevel",
				"FileName",
				"StepSizeX",
				"StepSizeY",
				"StartUIX",
				"StartUIY",
				"BoxPreview",
				"MapBgName",
				"MapTittleName",
				"MapGridBg"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			RiskMapFile.RowData rowData = new RiskMapFile.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.MapID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.NeedLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.FileName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.StepSizeX))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.StepSizeY))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.StartUIX))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.StartUIY))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[7]], ref rowData.BoxPreview, CVSReader.intParse, "3I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.MapBgName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.MapTittleName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.MapGridBg))
			{
				return false;
			}
			this.AddRowMapID(rowData.MapID, rowData, 0, this.Table.Count - 1);
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse, 3, "I");
			base.Write<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[10]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			RiskMapFile.RowData rowData = new RiskMapFile.RowData();
			base.Read<int>(reader, ref rowData.MapID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.NeedLevel, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.FileName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.StepSizeX, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.StepSizeY, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.StartUIX, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.StartUIY, CVSReader.intParse);
			this.columnno = 6;
			base.ReadSeqList<int>(reader, ref rowData.BoxPreview, CVSReader.intParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.MapBgName, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.MapTittleName, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.MapGridBg, CVSReader.stringParse);
			this.columnno = 10;
			this.AddRowMapID(rowData.MapID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
