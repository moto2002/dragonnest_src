using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SceneFxTable : CVSReader
	{
		public class RowData
		{
			public string unityscene;

			public string name;

			public float[] position;

			public float[] rotation;

			public float[] scale;
		}

		public List<SceneFxTable.RowData> Table = new List<SceneFxTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"unityscene",
				"name",
				"position",
				"rotation",
				"scale"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SceneFxTable.RowData rowData = new SceneFxTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.unityscene))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.position))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.rotation))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.scale))
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
			base.Write<string>(writer, Fields[this.ColMap[0]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[2]], CVSReader.floatParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[3]], CVSReader.floatParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[4]], CVSReader.floatParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SceneFxTable.RowData rowData = new SceneFxTable.RowData();
			base.Read<string>(reader, ref rowData.unityscene, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<float>(reader, ref rowData.position, CVSReader.floatParse);
			this.columnno = 2;
			base.ReadArray<float>(reader, ref rowData.rotation, CVSReader.floatParse);
			this.columnno = 3;
			base.ReadArray<float>(reader, ref rowData.scale, CVSReader.floatParse);
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
