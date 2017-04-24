using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class JadeTable : CVSReader
	{
		public class RowData
		{
			public uint JadeID;

			public uint JadeEquip;

			public Seq2ListRef<uint> JadeAttributes;

			public Seq2Ref<uint> JadeCompose;

			public uint JadeLevel;

			public string MosaicPlace;
		}

		public List<JadeTable.RowData> Table = new List<JadeTable.RowData>();

		public JadeTable.RowData GetByJadeID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchJadeID(key, 0, this.Table.Count - 1);
		}

		private JadeTable.RowData BinarySearchJadeID(uint key, int min, int max)
		{
			JadeTable.RowData rowData = this.Table[min];
			if (rowData.JadeID == key)
			{
				return rowData;
			}
			JadeTable.RowData rowData2 = this.Table[max];
			if (rowData2.JadeID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			JadeTable.RowData rowData3 = this.Table[num];
			if (rowData3.JadeID.CompareTo(key) > 0)
			{
				return this.BinarySearchJadeID(key, min, num);
			}
			if (rowData3.JadeID.CompareTo(key) < 0)
			{
				return this.BinarySearchJadeID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowJadeID(uint key, JadeTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			JadeTable.RowData rowData = this.Table[min];
			if (rowData.JadeID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.JadeID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: JadeTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			JadeTable.RowData rowData2 = this.Table[max];
			if (rowData2.JadeID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.JadeID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: JadeTable duplicate id:{0}  lineno: {1}", new object[]
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
			JadeTable.RowData rowData3 = this.Table[num];
			if (rowData3.JadeID.CompareTo(key) > 0)
			{
				this.AddRowJadeID(key, row, min, num);
				return;
			}
			if (rowData3.JadeID.CompareTo(key) < 0)
			{
				this.AddRowJadeID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: JadeTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"JadeID",
				"JadeEquip",
				"JadeAttributes",
				"JadeCompose",
				"JadeLevel",
				"MosaicPlace"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			JadeTable.RowData rowData = new JadeTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.JadeID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.JadeEquip))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.JadeAttributes, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.JadeCompose, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.JadeLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.MosaicPlace))
			{
				return false;
			}
			this.AddRowJadeID(rowData.JadeID, rowData, 0, this.Table.Count - 1);
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
			base.WriteSeq<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			JadeTable.RowData rowData = new JadeTable.RowData();
			base.Read<uint>(reader, ref rowData.JadeID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.JadeEquip, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.JadeAttributes, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeq<uint>(reader, ref rowData.JadeCompose, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.JadeLevel, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.MosaicPlace, CVSReader.stringParse);
			this.columnno = 5;
			this.AddRowJadeID(rowData.JadeID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
