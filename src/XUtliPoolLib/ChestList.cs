using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ChestList : CVSReader
	{
		public class RowData
		{
			public int ItemID;

			public uint[] DropID;

			public int SelMode;

			public int VipLevelReq;

			public int DailyUseCount;

			public int Profession;

			public bool MultiOpen;

			public uint[] Times;
		}

		public List<ChestList.RowData> Table = new List<ChestList.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ItemID",
				"DropID",
				"SelMode",
				"VipLevelReq",
				"DailyUseCount",
				"Profession",
				"MultiOpen",
				"Times"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ChestList.RowData rowData = new ChestList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ItemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.DropID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SelMode))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.VipLevelReq))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.DailyUseCount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Profession))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.MultiOpen))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.Times))
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
			base.WriteArray<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[6]]);
			base.WriteArray<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ChestList.RowData rowData = new ChestList.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.DropID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.SelMode, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.VipLevelReq, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.DailyUseCount, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.Profession, CVSReader.intParse);
			this.columnno = 5;
			base.Read(reader, ref rowData.MultiOpen);
			this.columnno = 6;
			base.ReadArray<uint>(reader, ref rowData.Times, CVSReader.uintParse);
			this.columnno = 7;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
