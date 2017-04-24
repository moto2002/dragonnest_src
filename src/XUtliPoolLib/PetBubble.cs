using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PetBubble : CVSReader
	{
		public class RowData
		{
			public uint id;

			public uint ActionID;

			public string ActionFile;

			public string Condition;

			public string[] Bubble;

			public float BubbleTime;

			public uint Weights;

			public string SEFile;
		}

		public List<PetBubble.RowData> Table = new List<PetBubble.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"id",
				"ActionID",
				"ActionFile",
				"Condition",
				"Bubble",
				"BubbleTime",
				"Weights",
				"SEFile"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PetBubble.RowData rowData = new PetBubble.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ActionID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ActionFile))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Condition))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Bubble))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.BubbleTime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Weights))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.SEFile))
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
			base.WriteArray<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<float>(writer, Fields[this.ColMap[5]], CVSReader.floatParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PetBubble.RowData rowData = new PetBubble.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ActionID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.ActionFile, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Condition, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadArray<string>(reader, ref rowData.Bubble, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<float>(reader, ref rowData.BubbleTime, CVSReader.floatParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.Weights, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.SEFile, CVSReader.stringParse);
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
