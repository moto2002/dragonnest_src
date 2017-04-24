using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PlantSprite : CVSReader
	{
		public class RowData
		{
			public uint SpriteID;

			public uint OccurrenceWeitght;

			public uint ReduceGrowth;

			public uint EffectGrowRate;

			public uint Duration;

			public uint DamageRate;

			public Seq2ListRef<uint> AwardItems;

			public string[] Dialogues;

			public uint[] Plants;
		}

		public List<PlantSprite.RowData> Table = new List<PlantSprite.RowData>();

		public PlantSprite.RowData GetBySpriteID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchSpriteID(key, 0, this.Table.Count - 1);
		}

		private PlantSprite.RowData BinarySearchSpriteID(uint key, int min, int max)
		{
			PlantSprite.RowData rowData = this.Table[min];
			if (rowData.SpriteID == key)
			{
				return rowData;
			}
			PlantSprite.RowData rowData2 = this.Table[max];
			if (rowData2.SpriteID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			PlantSprite.RowData rowData3 = this.Table[num];
			if (rowData3.SpriteID.CompareTo(key) > 0)
			{
				return this.BinarySearchSpriteID(key, min, num);
			}
			if (rowData3.SpriteID.CompareTo(key) < 0)
			{
				return this.BinarySearchSpriteID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowSpriteID(uint key, PlantSprite.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			PlantSprite.RowData rowData = this.Table[min];
			if (rowData.SpriteID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.SpriteID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PlantSprite duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			PlantSprite.RowData rowData2 = this.Table[max];
			if (rowData2.SpriteID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.SpriteID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PlantSprite duplicate id:{0}  lineno: {1}", new object[]
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
			PlantSprite.RowData rowData3 = this.Table[num];
			if (rowData3.SpriteID.CompareTo(key) > 0)
			{
				this.AddRowSpriteID(key, row, min, num);
				return;
			}
			if (rowData3.SpriteID.CompareTo(key) < 0)
			{
				this.AddRowSpriteID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: PlantSprite duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SpriteID",
				"OccurrenceWeitght",
				"ReduceGrowth",
				"EffectGrowRate",
				"Duration",
				"DamageRate",
				"AwardItems",
				"Dialogues",
				"Plants"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PlantSprite.RowData rowData = new PlantSprite.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SpriteID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.OccurrenceWeitght))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ReduceGrowth))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.EffectGrowRate))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Duration))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.DamageRate))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.AwardItems, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.Dialogues))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.Plants))
			{
				return false;
			}
			this.AddRowSpriteID(rowData.SpriteID, rowData, 0, this.Table.Count - 1);
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
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
			base.WriteArray<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PlantSprite.RowData rowData = new PlantSprite.RowData();
			base.Read<uint>(reader, ref rowData.SpriteID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.OccurrenceWeitght, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.ReduceGrowth, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.EffectGrowRate, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.Duration, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.DamageRate, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeqList<uint>(reader, ref rowData.AwardItems, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadArray<string>(reader, ref rowData.Dialogues, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<uint>(reader, ref rowData.Plants, CVSReader.uintParse);
			this.columnno = 8;
			this.AddRowSpriteID(rowData.SpriteID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
