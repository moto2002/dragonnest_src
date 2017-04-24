using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ChatOpen : CVSReader
	{
		public class RowData
		{
			public uint id;

			public string name;

			public int[] opens;

			public uint friends;

			public int posX;

			public int posY;

			public float alpha;

			public int pivot;

			public float scale;

			public int fade;

			public int real;

			public int radioX;

			public int radioY;

			public uint sceneid;

			public int max;
		}

		public List<ChatOpen.RowData> Table = new List<ChatOpen.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"id",
				"name",
				"opens",
				"friends",
				"posX",
				"posY",
				"alpha",
				"pivot",
				"scale",
				"fade",
				"real",
				"radioX",
				"radioY",
				"sceneid",
				"max"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ChatOpen.RowData rowData = new ChatOpen.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.opens))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.friends))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.posX))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.posY))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.alpha))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.pivot))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.scale))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.fade))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.real))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.radioX))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.radioY))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.sceneid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.max))
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
			base.WriteArray<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<float>(writer, Fields[this.ColMap[6]], CVSReader.floatParse);
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.Write<float>(writer, Fields[this.ColMap[8]], CVSReader.floatParse);
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[11]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[12]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[14]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ChatOpen.RowData rowData = new ChatOpen.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<int>(reader, ref rowData.opens, CVSReader.intParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.friends, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.posX, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.posY, CVSReader.intParse);
			this.columnno = 5;
			base.Read<float>(reader, ref rowData.alpha, CVSReader.floatParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.pivot, CVSReader.intParse);
			this.columnno = 7;
			base.Read<float>(reader, ref rowData.scale, CVSReader.floatParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.fade, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.real, CVSReader.intParse);
			this.columnno = 10;
			base.Read<int>(reader, ref rowData.radioX, CVSReader.intParse);
			this.columnno = 11;
			base.Read<int>(reader, ref rowData.radioY, CVSReader.intParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.sceneid, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<int>(reader, ref rowData.max, CVSReader.intParse);
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
