using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class XSceneFx : CVSReader
	{
		public class RowData
		{
			public int SceneID;

			public string FxName;

			public int FxCount;
		}

		public List<XSceneFx.RowData> Table = new List<XSceneFx.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SceneID",
				"FxName",
				"FxCount"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			XSceneFx.RowData rowData = new XSceneFx.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SceneID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.FxName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.FxCount))
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
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			XSceneFx.RowData rowData = new XSceneFx.RowData();
			base.Read<int>(reader, ref rowData.SceneID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.FxName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.FxCount, CVSReader.intParse);
			this.columnno = 2;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
