using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FashionComposeSet : CVSReader
	{
		public class RowData
		{
			public uint Type;

			public uint LevelSeal;

			public Seq4Ref<string> Time;

			public Seq2Ref<uint> FashionSet;
		}

		public List<FashionComposeSet.RowData> Table = new List<FashionComposeSet.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Type",
				"LevelSeal",
				"Time",
				"FashionSet"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FashionComposeSet.RowData rowData = new FashionComposeSet.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.LevelSeal))
			{
				return false;
			}
			if (!base.Parse<string>(Fields[this.ColMap[2]], ref rowData.Time, CVSReader.stringParse, "4S"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.FashionSet, CVSReader.uintParse, "2U"))
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
			base.WriteSeq<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse, 4, "S");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FashionComposeSet.RowData rowData = new FashionComposeSet.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.LevelSeal, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeq<string>(reader, ref rowData.Time, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadSeq<uint>(reader, ref rowData.FashionSet, CVSReader.uintParse);
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
