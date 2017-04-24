using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class DropList : CVSReader
	{
		public class RowData
		{
			public int DropID;

			public int ItemID;

			public int ItemCount;

			public int DropProb;

			public Seq2Ref<uint> price;

			public Seq2Ref<uint> DropLevel;

			public bool ItemBind;
		}

		public List<DropList.RowData> Table = new List<DropList.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"DropID",
				"ItemID",
				"ItemCount",
				"DropProb",
				"price",
				"DropLevel",
				"ItemBind"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			DropList.RowData rowData = new DropList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.DropID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ItemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ItemCount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.DropProb))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.price, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.DropLevel, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.ItemBind))
			{
				return false;
			}
			this.Table.Add(rowData);
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
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse, 2, "U");
			base.Write(writer, false, Fields[this.ColMap[6]]);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			DropList.RowData rowData = new DropList.RowData();
			base.Read<int>(reader, ref rowData.DropID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.ItemCount, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.DropProb, CVSReader.intParse);
			this.columnno = 3;
			base.ReadSeq<uint>(reader, ref rowData.price, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadSeq<uint>(reader, ref rowData.DropLevel, CVSReader.uintParse);
			this.columnno = 5;
			base.Read(reader, ref rowData.ItemBind);
			this.columnno = 6;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
