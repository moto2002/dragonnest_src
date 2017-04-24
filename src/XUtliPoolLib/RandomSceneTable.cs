using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class RandomSceneTable : CVSReader
	{
		public class RowData
		{
			public uint RandomID;

			public uint SceneID;

			public uint Prob;
		}

		public List<RandomSceneTable.RowData> Table = new List<RandomSceneTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"RandomID",
				"SceneID",
				"Prob"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			RandomSceneTable.RowData rowData = new RandomSceneTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.RandomID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SceneID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Prob))
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
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			RandomSceneTable.RowData rowData = new RandomSceneTable.RowData();
			base.Read<uint>(reader, ref rowData.RandomID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.Prob, CVSReader.uintParse);
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
