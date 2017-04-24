using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class RandomBossTable : CVSReader
	{
		public class RowData
		{
			public int RandomID;

			public int EntityID;

			public int Prob;
		}

		public List<RandomBossTable.RowData> Table = new List<RandomBossTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"RandomID",
				"EntityID",
				"Prob"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			RandomBossTable.RowData rowData = new RandomBossTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.RandomID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.EntityID))
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
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			RandomBossTable.RowData rowData = new RandomBossTable.RowData();
			base.Read<int>(reader, ref rowData.RandomID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.EntityID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Prob, CVSReader.intParse);
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
