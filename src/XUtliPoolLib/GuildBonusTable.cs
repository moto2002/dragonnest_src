using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildBonusTable : CVSReader
	{
		public class RowData
		{
			public uint GuildBonusID;

			public uint GuildBonusType;

			public string GuildBonusName;

			public string GuildBonusDesc;

			public uint GuildBonusMaxPeopleNum;

			public bool GuildBonusIsRandomAccess;

			public uint GuildBonusOpenTime;

			public Seq2Ref<uint> GuildBonusReward;

			public uint GuildBonusVar;

			public bool GuildBonusIsManualSend;

			public string TriggerTime;
		}

		public List<GuildBonusTable.RowData> Table = new List<GuildBonusTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"GuildBonusID",
				"GuildBonusType",
				"GuildBonusName",
				"GuildBonusDesc",
				"GuildBonusMaxPeopleNum",
				"GuildBonusIsRandomAccess",
				"GuildBonusOpenTime",
				"GuildBonusReward",
				"GuildBonusVar",
				"GuildBonusIsManualSend",
				"TriggerTime"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildBonusTable.RowData rowData = new GuildBonusTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.GuildBonusID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.GuildBonusType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.GuildBonusName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.GuildBonusDesc))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.GuildBonusMaxPeopleNum))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.GuildBonusIsRandomAccess))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.GuildBonusOpenTime))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[7]], ref rowData.GuildBonusReward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.GuildBonusVar))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.GuildBonusIsManualSend))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.TriggerTime))
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write(writer, false, Fields[this.ColMap[5]]);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
			base.Write(writer, false, Fields[this.ColMap[9]]);
			base.Write<string>(writer, Fields[this.ColMap[10]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildBonusTable.RowData rowData = new GuildBonusTable.RowData();
			base.Read<uint>(reader, ref rowData.GuildBonusID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.GuildBonusType, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.GuildBonusName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.GuildBonusDesc, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.GuildBonusMaxPeopleNum, CVSReader.uintParse);
			this.columnno = 4;
			base.Read(reader, ref rowData.GuildBonusIsRandomAccess);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.GuildBonusOpenTime, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadSeq<uint>(reader, ref rowData.GuildBonusReward, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.GuildBonusVar, CVSReader.uintParse);
			this.columnno = 8;
			base.Read(reader, ref rowData.GuildBonusIsManualSend);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.TriggerTime, CVSReader.stringParse);
			this.columnno = 10;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
