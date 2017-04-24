using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PandoraHeart : CVSReader
	{
		public class RowData
		{
			public uint PandoraID;

			public uint ProfID;

			public uint FireID;

			public Seq2ListRef<uint> Reward;

			public uint CommonDropID;

			public uint BetterDropID;

			public uint BestDropID;

			public Seq2Ref<uint> EnterBetterDropTimes;

			public Seq2Ref<uint> EnterBestDropTimes;

			public uint[] DisplaySlot0;

			public uint[] DisplayAngle0;

			public uint[] DisplaySlot1;

			public uint[] DisplayAngle1;

			public uint[] DisplaySlot2;

			public uint[] DisplayAngle2;

			public string DisplayName0;

			public string DisplayName1;

			public string DisplayName2;
		}

		public List<PandoraHeart.RowData> Table = new List<PandoraHeart.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"PandoraID",
				"ProfID",
				"FireID",
				"Reward",
				"CommonDropID",
				"BetterDropID",
				"BestDropID",
				"EnterBetterDropTimes",
				"EnterBestDropTimes",
				"DisplaySlot0",
				"DisplayAngle0",
				"DisplaySlot1",
				"DisplayAngle1",
				"DisplaySlot2",
				"DisplayAngle2",
				"DisplayName0",
				"DisplayName1",
				"DisplayName2"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PandoraHeart.RowData rowData = new PandoraHeart.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.PandoraID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ProfID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.FireID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.Reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.CommonDropID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.BetterDropID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.BestDropID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[7]], ref rowData.EnterBetterDropTimes, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[8]], ref rowData.EnterBestDropTimes, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.DisplaySlot0))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.DisplayAngle0))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.DisplaySlot1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.DisplayAngle1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.DisplaySlot2))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.DisplayAngle2))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.DisplayName0))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.DisplayName1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.DisplayName2))
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
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse, 2, "U");
			base.WriteArray<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[15]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[16]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[17]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PandoraHeart.RowData rowData = new PandoraHeart.RowData();
			base.Read<uint>(reader, ref rowData.PandoraID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ProfID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.FireID, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.Reward, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.CommonDropID, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.BetterDropID, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.BestDropID, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadSeq<uint>(reader, ref rowData.EnterBetterDropTimes, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadSeq<uint>(reader, ref rowData.EnterBestDropTimes, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadArray<uint>(reader, ref rowData.DisplaySlot0, CVSReader.uintParse);
			this.columnno = 9;
			base.ReadArray<uint>(reader, ref rowData.DisplayAngle0, CVSReader.uintParse);
			this.columnno = 10;
			base.ReadArray<uint>(reader, ref rowData.DisplaySlot1, CVSReader.uintParse);
			this.columnno = 11;
			base.ReadArray<uint>(reader, ref rowData.DisplayAngle1, CVSReader.uintParse);
			this.columnno = 12;
			base.ReadArray<uint>(reader, ref rowData.DisplaySlot2, CVSReader.uintParse);
			this.columnno = 13;
			base.ReadArray<uint>(reader, ref rowData.DisplayAngle2, CVSReader.uintParse);
			this.columnno = 14;
			base.Read<string>(reader, ref rowData.DisplayName0, CVSReader.stringParse);
			this.columnno = 15;
			base.Read<string>(reader, ref rowData.DisplayName1, CVSReader.stringParse);
			this.columnno = 16;
			base.Read<string>(reader, ref rowData.DisplayName2, CVSReader.stringParse);
			this.columnno = 17;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
