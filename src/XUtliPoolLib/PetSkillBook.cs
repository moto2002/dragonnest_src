using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PetSkillBook : CVSReader
	{
		public class RowData
		{
			public uint itemid;

			public uint skillid;

			public Seq2ListRef<uint> pro;

			public string Description;
		}

		public List<PetSkillBook.RowData> Table = new List<PetSkillBook.RowData>();

		public PetSkillBook.RowData GetByitemid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchitemid(key, 0, this.Table.Count - 1);
		}

		private PetSkillBook.RowData BinarySearchitemid(uint key, int min, int max)
		{
			PetSkillBook.RowData rowData = this.Table[min];
			if (rowData.itemid == key)
			{
				return rowData;
			}
			PetSkillBook.RowData rowData2 = this.Table[max];
			if (rowData2.itemid == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			PetSkillBook.RowData rowData3 = this.Table[num];
			if (rowData3.itemid.CompareTo(key) > 0)
			{
				return this.BinarySearchitemid(key, min, num);
			}
			if (rowData3.itemid.CompareTo(key) < 0)
			{
				return this.BinarySearchitemid(key, num, max);
			}
			return rowData3;
		}

		private void AddRowitemid(uint key, PetSkillBook.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			PetSkillBook.RowData rowData = this.Table[min];
			if (rowData.itemid.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.itemid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetSkillBook duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			PetSkillBook.RowData rowData2 = this.Table[max];
			if (rowData2.itemid.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.itemid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetSkillBook duplicate id:{0}  lineno: {1}", new object[]
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
			PetSkillBook.RowData rowData3 = this.Table[num];
			if (rowData3.itemid.CompareTo(key) > 0)
			{
				this.AddRowitemid(key, row, min, num);
				return;
			}
			if (rowData3.itemid.CompareTo(key) < 0)
			{
				this.AddRowitemid(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetSkillBook duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"itemid",
				"skillid",
				"pro",
				"Description"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PetSkillBook.RowData rowData = new PetSkillBook.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.itemid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.skillid))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.pro, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Description))
			{
				return false;
			}
			this.AddRowitemid(rowData.itemid, rowData, 0, this.Table.Count - 1);
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
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PetSkillBook.RowData rowData = new PetSkillBook.RowData();
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.skillid, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.pro, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 3;
			this.AddRowitemid(rowData.itemid, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
