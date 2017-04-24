using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class JadeEquipTable : CVSReader
	{
		public class RowData
		{
			public uint[] Jade1Type;

			public uint[] Jade2Type;

			public uint[] Jade3Type;

			public uint[] Jade4Type;
		}

		public List<JadeEquipTable.RowData> Table = new List<JadeEquipTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Jade1Type",
				"Jade2Type",
				"Jade3Type",
				"Jade4Type"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			JadeEquipTable.RowData rowData = new JadeEquipTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Jade1Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Jade2Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Jade3Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Jade4Type))
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
			base.WriteArray<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			JadeEquipTable.RowData rowData = new JadeEquipTable.RowData();
			base.ReadArray<uint>(reader, ref rowData.Jade1Type, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.Jade2Type, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.Jade3Type, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.Jade4Type, CVSReader.uintParse);
			this.columnno = 3;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
