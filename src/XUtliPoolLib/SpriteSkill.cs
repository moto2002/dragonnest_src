using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SpriteSkill : CVSReader
	{
		public class RowData
		{
			public uint SkillID;

			public string SkillName;

			public uint SkillQuality;

			public uint PassiveSkillType;

			public string Tips;

			public string Icon;

			public string Detail;

			public Seq2ListRef<uint> Attrs;

			public Seq2ListRef<uint> Buffs;

			public int Duration;

			public int CD;

			public Seq2ListRef<uint> BaseAttrs;

			public string NoticeDetail;

			public Seq2Ref<int> ShowNotice;

			public string Audio;
		}

		public List<SpriteSkill.RowData> Table = new List<SpriteSkill.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SkillID",
				"SkillName",
				"SkillQuality",
				"PassiveSkillType",
				"Tips",
				"Icon",
				"Detail",
				"Attrs",
				"Buffs",
				"Duration",
				"CD",
				"BaseAttrs",
				"NoticeDetail",
				"ShowNotice",
				"Audio"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SpriteSkill.RowData rowData = new SpriteSkill.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SkillID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SkillName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SkillQuality))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.PassiveSkillType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Tips))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Detail))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[7]], ref rowData.Attrs, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[8]], ref rowData.Buffs, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.Duration))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.CD))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[11]], ref rowData.BaseAttrs, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.NoticeDetail))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[13]], ref rowData.ShowNotice, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.Audio))
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
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse, 2, "U");
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[12]], CVSReader.stringParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[13]], CVSReader.intParse, 2, "I");
			base.Write<string>(writer, Fields[this.ColMap[14]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SpriteSkill.RowData rowData = new SpriteSkill.RowData();
			base.Read<uint>(reader, ref rowData.SkillID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SkillName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SkillQuality, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.PassiveSkillType, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Tips, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Detail, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadSeqList<uint>(reader, ref rowData.Attrs, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadSeqList<uint>(reader, ref rowData.Buffs, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.Duration, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.CD, CVSReader.intParse);
			this.columnno = 10;
			base.ReadSeqList<uint>(reader, ref rowData.BaseAttrs, CVSReader.uintParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.NoticeDetail, CVSReader.stringParse);
			this.columnno = 12;
			base.ReadSeq<int>(reader, ref rowData.ShowNotice, CVSReader.intParse);
			this.columnno = 13;
			base.Read<string>(reader, ref rowData.Audio, CVSReader.stringParse);
			this.columnno = 14;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
