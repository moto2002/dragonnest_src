using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PandoraHeartReward : CVSReader
	{
		public class RowData
		{
			public uint pandoraid;

			public uint itemid;

			public uint itemcount;

			public string itemname;

			public uint quality;

			public uint notice;

			public uint praise;

			public Seq2Ref<uint> showlevel;
		}

		public List<PandoraHeartReward.RowData> Table = new List<PandoraHeartReward.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"pandoraid",
				"itemid",
				"itemcount",
				"itemname",
				"quality",
				"notice",
				"praise",
				"showlevel"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PandoraHeartReward.RowData rowData = new PandoraHeartReward.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.pandoraid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.itemid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.itemcount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.itemname))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.quality))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.notice))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.praise))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[7]], ref rowData.showlevel, CVSReader.uintParse, "2U"))
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
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PandoraHeartReward.RowData rowData = new PandoraHeartReward.RowData();
			base.Read<uint>(reader, ref rowData.pandoraid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.itemcount, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.itemname, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.quality, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.notice, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.praise, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadSeq<uint>(reader, ref rowData.showlevel, CVSReader.uintParse);
			this.columnno = 7;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
