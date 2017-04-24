using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class DanceConfig : CVSReader
	{
		public class RowData
		{
			public uint MotionID;

			public string MotionName;

			public int PresentID;

			public int SysID;

			public string SysIDName;

			public string Motion;

			public string Music;

			public int LoopCount;

			public string EffectPath;

			public float EffectTime;

			public int Type;

			public string HallBtnIcon;
		}

		public List<DanceConfig.RowData> Table = new List<DanceConfig.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"MotionID",
				"MotionName",
				"PresentID",
				"SysID",
				"SysIDName",
				"Motion",
				"Music",
				"LoopCount",
				"EffectPath",
				"EffectTime",
				"Type",
				"HallBtnIcon"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			DanceConfig.RowData rowData = new DanceConfig.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.MotionID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.MotionName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.PresentID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.SysID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.SysIDName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Motion))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Music))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.LoopCount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.EffectPath))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.EffectTime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.HallBtnIcon))
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
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<float>(writer, Fields[this.ColMap[9]], CVSReader.floatParse);
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[11]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			DanceConfig.RowData rowData = new DanceConfig.RowData();
			base.Read<uint>(reader, ref rowData.MotionID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.MotionName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.PresentID, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.SysID, CVSReader.intParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.SysIDName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Motion, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Music, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.LoopCount, CVSReader.intParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.EffectPath, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<float>(reader, ref rowData.EffectTime, CVSReader.floatParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.HallBtnIcon, CVSReader.stringParse);
			this.columnno = 11;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
