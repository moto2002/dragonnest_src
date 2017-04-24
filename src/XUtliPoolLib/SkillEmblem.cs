using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SkillEmblem : CVSReader
	{
		public class RowData
		{
			public uint EmblemID;

			public string SkillScript;

			public uint SkillType;

			public uint SkillPercent;

			public string SkillName;

			public uint SkillPPT;
		}

		public List<SkillEmblem.RowData> Table = new List<SkillEmblem.RowData>();

		public SkillEmblem.RowData GetByEmblemID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchEmblemID(key, 0, this.Table.Count - 1);
		}

		private SkillEmblem.RowData BinarySearchEmblemID(uint key, int min, int max)
		{
			SkillEmblem.RowData rowData = this.Table[min];
			if (rowData.EmblemID == key)
			{
				return rowData;
			}
			SkillEmblem.RowData rowData2 = this.Table[max];
			if (rowData2.EmblemID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			SkillEmblem.RowData rowData3 = this.Table[num];
			if (rowData3.EmblemID.CompareTo(key) > 0)
			{
				return this.BinarySearchEmblemID(key, min, num);
			}
			if (rowData3.EmblemID.CompareTo(key) < 0)
			{
				return this.BinarySearchEmblemID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowEmblemID(uint key, SkillEmblem.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			SkillEmblem.RowData rowData = this.Table[min];
			if (rowData.EmblemID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.EmblemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SkillEmblem duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			SkillEmblem.RowData rowData2 = this.Table[max];
			if (rowData2.EmblemID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.EmblemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SkillEmblem duplicate id:{0}  lineno: {1}", new object[]
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
			SkillEmblem.RowData rowData3 = this.Table[num];
			if (rowData3.EmblemID.CompareTo(key) > 0)
			{
				this.AddRowEmblemID(key, row, min, num);
				return;
			}
			if (rowData3.EmblemID.CompareTo(key) < 0)
			{
				this.AddRowEmblemID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: SkillEmblem duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"EmblemID",
				"SkillScript",
				"SkillType",
				"SkillPercent",
				"SkillName",
				"SkillPPT"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SkillEmblem.RowData rowData = new SkillEmblem.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.EmblemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SkillScript))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SkillType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.SkillPercent))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.SkillName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.SkillPPT))
			{
				return false;
			}
			this.AddRowEmblemID(rowData.EmblemID, rowData, 0, this.Table.Count - 1);
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
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SkillEmblem.RowData rowData = new SkillEmblem.RowData();
			base.Read<uint>(reader, ref rowData.EmblemID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SkillScript, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SkillType, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SkillPercent, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.SkillName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SkillPPT, CVSReader.uintParse);
			this.columnno = 5;
			this.AddRowEmblemID(rowData.EmblemID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
