using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ProfessionTable : CVSReader
	{
		public class RowData
		{
			public uint ID;

			public string Name;

			public int Sex;

			public uint PresentID;

			public Seq2ListRef<string> InitSkill;

			public Seq2ListRef<string> InitBindSkill;

			public uint AttackType;
		}

		public List<ProfessionTable.RowData> Table = new List<ProfessionTable.RowData>();

		public ProfessionTable.RowData GetByProfID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchProfID(key, 0, this.Table.Count - 1);
		}

		private ProfessionTable.RowData BinarySearchProfID(uint key, int min, int max)
		{
			ProfessionTable.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			ProfessionTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ProfessionTable.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				return this.BinarySearchProfID(key, min, num);
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				return this.BinarySearchProfID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowProfID(uint key, ProfessionTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ProfessionTable.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ProfessionTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ProfessionTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ProfessionTable duplicate id:{0}  lineno: {1}", new object[]
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
			ProfessionTable.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				this.AddRowProfID(key, row, min, num);
				return;
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				this.AddRowProfID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ProfessionTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ProfID",
				"ProfName",
				"ProfSex",
				"PresentID",
				"InitSkill",
				"InitBindSkill",
				"AttackType"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ProfessionTable.RowData rowData = new ProfessionTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Sex))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.PresentID))
			{
				return false;
			}
			if (!base.Parse<string>(Fields[this.ColMap[4]], ref rowData.InitSkill, CVSReader.stringParse, "2S"))
			{
				return false;
			}
			if (!base.Parse<string>(Fields[this.ColMap[5]], ref rowData.InitBindSkill, CVSReader.stringParse, "2S"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.AttackType))
			{
				return false;
			}
			this.AddRowProfID(rowData.ID, rowData, 0, this.Table.Count - 1);
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
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.WriteSeqList<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse, 2, "S");
			base.WriteSeqList<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse, 2, "S");
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ProfessionTable.RowData rowData = new ProfessionTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Sex, CVSReader.intParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.PresentID, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadSeqList<string>(reader, ref rowData.InitSkill, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadSeqList<string>(reader, ref rowData.InitBindSkill, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.AttackType, CVSReader.uintParse);
			this.columnno = 6;
			this.AddRowProfID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
