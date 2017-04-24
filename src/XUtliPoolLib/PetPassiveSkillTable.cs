using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PetPassiveSkillTable : CVSReader
	{
		public class RowData
		{
			public uint id;

			public string name;

			public uint quality;

			public string tips;

			public Seq2ListRef<uint> attrs;

			public uint probability;

			public string Icon;

			public string Detail;

			public Seq2ListRef<uint> attrlvl;
		}

		public List<PetPassiveSkillTable.RowData> Table = new List<PetPassiveSkillTable.RowData>();

		public PetPassiveSkillTable.RowData GetByid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchid(key, 0, this.Table.Count - 1);
		}

		private PetPassiveSkillTable.RowData BinarySearchid(uint key, int min, int max)
		{
			PetPassiveSkillTable.RowData rowData = this.Table[min];
			if (rowData.id == key)
			{
				return rowData;
			}
			PetPassiveSkillTable.RowData rowData2 = this.Table[max];
			if (rowData2.id == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			PetPassiveSkillTable.RowData rowData3 = this.Table[num];
			if (rowData3.id.CompareTo(key) > 0)
			{
				return this.BinarySearchid(key, min, num);
			}
			if (rowData3.id.CompareTo(key) < 0)
			{
				return this.BinarySearchid(key, num, max);
			}
			return rowData3;
		}

		private void AddRowid(uint key, PetPassiveSkillTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			PetPassiveSkillTable.RowData rowData = this.Table[min];
			if (rowData.id.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetPassiveSkillTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			PetPassiveSkillTable.RowData rowData2 = this.Table[max];
			if (rowData2.id.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetPassiveSkillTable duplicate id:{0}  lineno: {1}", new object[]
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
			PetPassiveSkillTable.RowData rowData3 = this.Table[num];
			if (rowData3.id.CompareTo(key) > 0)
			{
				this.AddRowid(key, row, min, num);
				return;
			}
			if (rowData3.id.CompareTo(key) < 0)
			{
				this.AddRowid(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetPassiveSkillTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"id",
				"name",
				"quality",
				"tips",
				"attrs",
				"probability",
				"Icon",
				"Detail",
				"attrlvl"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PetPassiveSkillTable.RowData rowData = new PetPassiveSkillTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.quality))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.tips))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.attrs, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.probability))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.Detail))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[8]], ref rowData.attrlvl, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.AddRowid(rowData.id, rowData, 0, this.Table.Count - 1);
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
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PetPassiveSkillTable.RowData rowData = new PetPassiveSkillTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.quality, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.tips, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadSeqList<uint>(reader, ref rowData.attrs, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.probability, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Detail, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadSeqList<uint>(reader, ref rowData.attrlvl, CVSReader.uintParse);
			this.columnno = 8;
			this.AddRowid(rowData.id, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
