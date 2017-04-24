using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class EnhanceFxTable : CVSReader
	{
		public class RowData
		{
			public uint EnhanceLevel;

			public string MainWeaponFx;

			public uint ProfID;

			public string MainWeaponMat;

			public string Tips;
		}

		public List<EnhanceFxTable.RowData> Table = new List<EnhanceFxTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"EnhanceLevel",
				"MainWeaponFx",
				"ProfID",
				"MainWeaponMat",
				"Tips"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			EnhanceFxTable.RowData rowData = new EnhanceFxTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.EnhanceLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.MainWeaponFx))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ProfID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.MainWeaponMat))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Tips))
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
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			EnhanceFxTable.RowData rowData = new EnhanceFxTable.RowData();
			base.Read<uint>(reader, ref rowData.EnhanceLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.MainWeaponFx, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.ProfID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.MainWeaponMat, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Tips, CVSReader.stringParse);
			this.columnno = 4;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
