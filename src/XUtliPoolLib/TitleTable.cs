using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class TitleTable : CVSReader
	{
		public class RowData
		{
			public uint RankID;

			public string RankName;

			public string RankIcon;

			public string AffectRoute;

			public uint NeedPowerPoint;

			public Seq2ListRef<uint> NeedItem;

			public Seq2ListRef<uint> Attribute;

			public string RankPath;

			public string desc;

			public uint BasicProfession;
		}

		public List<TitleTable.RowData> Table = new List<TitleTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"RankID",
				"RankName",
				"RankIcon",
				"AffectRoute",
				"NeedPowerPoint",
				"NeedItem",
				"Attribute",
				"RankPath",
				"desc",
				"BasicProfession"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			TitleTable.RowData rowData = new TitleTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.RankID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.RankName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.RankIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.AffectRoute))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.NeedPowerPoint))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.NeedItem, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.Attribute, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.RankPath))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.desc))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.BasicProfession))
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			TitleTable.RowData rowData = new TitleTable.RowData();
			base.Read<uint>(reader, ref rowData.RankID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.RankName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.RankIcon, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.AffectRoute, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.NeedPowerPoint, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadSeqList<uint>(reader, ref rowData.NeedItem, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeqList<uint>(reader, ref rowData.Attribute, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.RankPath, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.desc, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.BasicProfession, CVSReader.uintParse);
			this.columnno = 9;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
