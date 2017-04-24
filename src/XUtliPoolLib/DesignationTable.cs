using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class DesignationTable : CVSReader
	{
		public class RowData
		{
			public int ID;

			public string Designation;

			public int Type;

			public string Explanation;

			public int CompleteType;

			public int[] CompleteValue;

			public int Pragmaticality;

			public string Effect;

			public Seq2ListRef<uint> Attribute;

			public string Color;

			public int GainShowIcon;

			public int SortID;

			public Seq2Ref<int> Level;

			public bool ShowInChat;

			public int Channel;
		}

		public List<DesignationTable.RowData> Table = new List<DesignationTable.RowData>();

		public DesignationTable.RowData GetByID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private DesignationTable.RowData BinarySearchID(int key, int min, int max)
		{
			DesignationTable.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			DesignationTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			DesignationTable.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				return this.BinarySearchID(key, min, num);
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				return this.BinarySearchID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowID(int key, DesignationTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			DesignationTable.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: DesignationTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			DesignationTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: DesignationTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			if (max - min <= 1)
			{
				this.Table.Insert(min + 1, row);
				return;
			}
			int num = min + (max - min) / 2;
			DesignationTable.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				this.AddRowID(key, row, min, num);
				return;
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				this.AddRowID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: DesignationTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"Designation",
				"Type",
				"Explanation",
				"CompleteType",
				"CompleteValue",
				"Pragmaticality",
				"Effect",
				"Attribute",
				"Color",
				"GainShowIcon",
				"SortID",
				"Level",
				"ShowInChat",
				"Channel"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			DesignationTable.RowData rowData = new DesignationTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Designation))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Explanation))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.CompleteType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.CompleteValue))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Pragmaticality))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.Effect))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[8]], ref rowData.Attribute, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.Color))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.GainShowIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.SortID))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[12]], ref rowData.Level, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.ShowInChat))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.Channel))
			{
				return false;
			}
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[11]], CVSReader.intParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[12]], CVSReader.intParse, 2, "I");
			base.Write(writer, false, Fields[this.ColMap[13]]);
			base.Write<int>(writer, Fields[this.ColMap[14]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			DesignationTable.RowData rowData = new DesignationTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Designation, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Explanation, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.CompleteType, CVSReader.intParse);
			this.columnno = 4;
			base.ReadArray<int>(reader, ref rowData.CompleteValue, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.Pragmaticality, CVSReader.intParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Effect, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadSeqList<uint>(reader, ref rowData.Attribute, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.Color, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.GainShowIcon, CVSReader.intParse);
			this.columnno = 10;
			base.Read<int>(reader, ref rowData.SortID, CVSReader.intParse);
			this.columnno = 11;
			base.ReadSeq<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 12;
			base.Read(reader, ref rowData.ShowInChat);
			this.columnno = 13;
			base.Read<int>(reader, ref rowData.Channel, CVSReader.intParse);
			this.columnno = 14;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
