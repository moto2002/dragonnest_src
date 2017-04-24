using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PreloadAnimationList : CVSReader
	{
		public class RowData
		{
			public int SceneID;

			public string AnimName;
		}

		public List<PreloadAnimationList.RowData> Table = new List<PreloadAnimationList.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SceneID",
				"AnimName"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PreloadAnimationList.RowData rowData = new PreloadAnimationList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SceneID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.AnimName))
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PreloadAnimationList.RowData rowData = new PreloadAnimationList.RowData();
			base.Read<int>(reader, ref rowData.SceneID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.AnimName, CVSReader.stringParse);
			this.columnno = 1;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
