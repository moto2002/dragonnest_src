using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class EnchantEquip : CVSReader
	{
		public class RowData
		{
			public uint EnchantID;

			public uint[] Pos;

			public Seq4ListRef<uint> Attribute;

			public Seq2ListRef<uint> Cost;

			public uint Num;

			public uint VisiblePos;

			public uint EnchantLevel;
		}

		public List<EnchantEquip.RowData> Table = new List<EnchantEquip.RowData>();

		public EnchantEquip.RowData GetByEnchantID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchEnchantID(key, 0, this.Table.Count - 1);
		}

		private EnchantEquip.RowData BinarySearchEnchantID(uint key, int min, int max)
		{
			EnchantEquip.RowData rowData = this.Table[min];
			if (rowData.EnchantID == key)
			{
				return rowData;
			}
			EnchantEquip.RowData rowData2 = this.Table[max];
			if (rowData2.EnchantID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			EnchantEquip.RowData rowData3 = this.Table[num];
			if (rowData3.EnchantID.CompareTo(key) > 0)
			{
				return this.BinarySearchEnchantID(key, min, num);
			}
			if (rowData3.EnchantID.CompareTo(key) < 0)
			{
				return this.BinarySearchEnchantID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowEnchantID(uint key, EnchantEquip.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			EnchantEquip.RowData rowData = this.Table[min];
			if (rowData.EnchantID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.EnchantID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: EnchantEquip duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			EnchantEquip.RowData rowData2 = this.Table[max];
			if (rowData2.EnchantID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.EnchantID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: EnchantEquip duplicate id:{0}  lineno: {1}", new object[]
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
			EnchantEquip.RowData rowData3 = this.Table[num];
			if (rowData3.EnchantID.CompareTo(key) > 0)
			{
				this.AddRowEnchantID(key, row, min, num);
				return;
			}
			if (rowData3.EnchantID.CompareTo(key) < 0)
			{
				this.AddRowEnchantID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: EnchantEquip duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"EnchantID",
				"Pos",
				"Attribute",
				"Cost",
				"Num",
				"VisiblePos",
				"EnchantLevel"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			EnchantEquip.RowData rowData = new EnchantEquip.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.EnchantID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Pos))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.Attribute, CVSReader.uintParse, "4U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.Cost, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Num))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.VisiblePos))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.EnchantLevel))
			{
				return false;
			}
			this.AddRowEnchantID(rowData.EnchantID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 4, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			EnchantEquip.RowData rowData = new EnchantEquip.RowData();
			base.Read<uint>(reader, ref rowData.EnchantID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.Pos, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.Attribute, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.Cost, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.Num, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.VisiblePos, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.EnchantLevel, CVSReader.uintParse);
			this.columnno = 6;
			this.AddRowEnchantID(rowData.EnchantID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
