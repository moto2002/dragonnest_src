using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PushSetting : CVSReader
	{
		public class RowData
		{
			public uint Type;

			public string ConfigName;

			public uint TimeOrSystem;

			public string Time;

			public string WeekDay;

			public string ConfigKey;
		}

		public List<PushSetting.RowData> Table = new List<PushSetting.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Type",
				"ConfigName",
				"TimeOrSystem",
				"Time",
				"WeekDay",
				"ConfigKey"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PushSetting.RowData rowData = new PushSetting.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ConfigName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.TimeOrSystem))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Time))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.WeekDay))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.ConfigKey))
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
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PushSetting.RowData rowData = new PushSetting.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ConfigName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.TimeOrSystem, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Time, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.WeekDay, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.ConfigKey, CVSReader.stringParse);
			this.columnno = 5;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
