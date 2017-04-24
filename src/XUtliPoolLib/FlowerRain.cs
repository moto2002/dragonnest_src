using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FlowerRain : CVSReader
	{
		public class RowData
		{
			public int FlowerID;

			public int Count;

			public string EffectPath;

			public int PlayTime;
		}

		public List<FlowerRain.RowData> Table = new List<FlowerRain.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"FlowerID",
				"Count",
				"EffectPath",
				"PlayTime"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FlowerRain.RowData rowData = new FlowerRain.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.FlowerID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Count))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.EffectPath))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.PlayTime))
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FlowerRain.RowData rowData = new FlowerRain.RowData();
			base.Read<int>(reader, ref rowData.FlowerID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Count, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.EffectPath, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.PlayTime, CVSReader.intParse);
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
