using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PlantSeed : CVSReader
	{
		public class RowData
		{
			public uint SeedID;

			public string SeedName;

			public Seq2Ref<int> PlantID;

			public string PlantName;

			public string Desc;

			public Seq2Ref<uint> FirstGrowSection;

			public Seq2Ref<uint> SecondGrowSection;

			public Seq2Ref<uint> RipeSection;

			public uint GrowUpAmount;

			public uint GrowUpAmountPerMinute;

			public uint PredictGrowUpTime;

			public uint HarvestRate;

			public Seq2Ref<uint> HarvestPlant;

			public string HarvestPlantName;

			public uint ExtraDropRate;

			public Seq2Ref<uint> ExtraDropItem;

			public string ExtraDropItemName;

			public uint IncreaseGrowUpRate;

			public uint ReduceGrowUpRate;

			public uint PlantStateCD;

			public uint MatureDuration;

			public uint BadStateGrowUpRate;

			public Seq2Ref<int> StealAward;

			public Seq2Ref<int> TrainAward;

			public uint FirstGrowModelSpriteId;

			public uint SecondGrowSpriteId;

			public uint RipeSpriteID;

			public uint CanStealMaxTimes;

			public uint InitUpAmount;
		}

		public List<PlantSeed.RowData> Table = new List<PlantSeed.RowData>();

		public PlantSeed.RowData GetBySeedID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchSeedID(key, 0, this.Table.Count - 1);
		}

		private PlantSeed.RowData BinarySearchSeedID(uint key, int min, int max)
		{
			PlantSeed.RowData rowData = this.Table[min];
			if (rowData.SeedID == key)
			{
				return rowData;
			}
			PlantSeed.RowData rowData2 = this.Table[max];
			if (rowData2.SeedID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			PlantSeed.RowData rowData3 = this.Table[num];
			if (rowData3.SeedID.CompareTo(key) > 0)
			{
				return this.BinarySearchSeedID(key, min, num);
			}
			if (rowData3.SeedID.CompareTo(key) < 0)
			{
				return this.BinarySearchSeedID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowSeedID(uint key, PlantSeed.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			PlantSeed.RowData rowData = this.Table[min];
			if (rowData.SeedID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.SeedID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PlantSeed duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			PlantSeed.RowData rowData2 = this.Table[max];
			if (rowData2.SeedID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.SeedID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PlantSeed duplicate id:{0}  lineno: {1}", new object[]
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
			PlantSeed.RowData rowData3 = this.Table[num];
			if (rowData3.SeedID.CompareTo(key) > 0)
			{
				this.AddRowSeedID(key, row, min, num);
				return;
			}
			if (rowData3.SeedID.CompareTo(key) < 0)
			{
				this.AddRowSeedID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: PlantSeed duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SeedID",
				"SeedName",
				"PlantID",
				"PlantName",
				"Desc",
				"FirstGrowSection",
				"SecondGrowSection",
				"RipeSection",
				"GrowUpAmount",
				"GrowUpAmountPerMinute",
				"PredictGrowUpTime",
				"HarvestRate",
				"HarvestPlant",
				"HarvestPlantName",
				"ExtraDropRate",
				"ExtraDropItem",
				"ExtraDropItemName",
				"IncreaseGrowUpRate",
				"ReduceGrowUpRate",
				"PlantStateCD",
				"MatureDuration",
				"BadStateGrowUpRate",
				"StealAward",
				"TrainAward",
				"FirstGrowModelSpriteId",
				"SecondGrowSpriteId",
				"RipeSpriteID",
				"CanStealMaxTimes",
				"InitUpAmount"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PlantSeed.RowData rowData = new PlantSeed.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SeedID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SeedName))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[2]], ref rowData.PlantID, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.PlantName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Desc))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.FirstGrowSection, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.SecondGrowSection, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[7]], ref rowData.RipeSection, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.GrowUpAmount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.GrowUpAmountPerMinute))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.PredictGrowUpTime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.HarvestRate))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[12]], ref rowData.HarvestPlant, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.HarvestPlantName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.ExtraDropRate))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[15]], ref rowData.ExtraDropItem, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.ExtraDropItemName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.IncreaseGrowUpRate))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.ReduceGrowUpRate))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.PlantStateCD))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[20]], ref rowData.MatureDuration))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[21]], ref rowData.BadStateGrowUpRate))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[22]], ref rowData.StealAward, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[23]], ref rowData.TrainAward, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[24]], ref rowData.FirstGrowModelSpriteId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[25]], ref rowData.SecondGrowSpriteId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[26]], ref rowData.RipeSpriteID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[27]], ref rowData.CanStealMaxTimes))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[28]], ref rowData.InitUpAmount))
			{
				return false;
			}
			this.AddRowSeedID(rowData.SeedID, rowData, 0, this.Table.Count - 1);
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
			base.WriteSeq<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse, 2, "I");
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[13]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[15]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[16]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[17]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[18]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[19]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[20]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[21]], CVSReader.uintParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[22]], CVSReader.intParse, 2, "I");
			base.WriteSeq<int>(writer, Fields[this.ColMap[23]], CVSReader.intParse, 2, "I");
			base.Write<uint>(writer, Fields[this.ColMap[24]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[25]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[26]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[27]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[28]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PlantSeed.RowData rowData = new PlantSeed.RowData();
			base.Read<uint>(reader, ref rowData.SeedID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SeedName, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadSeq<int>(reader, ref rowData.PlantID, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.PlantName, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadSeq<uint>(reader, ref rowData.FirstGrowSection, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeq<uint>(reader, ref rowData.SecondGrowSection, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadSeq<uint>(reader, ref rowData.RipeSection, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.GrowUpAmount, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.GrowUpAmountPerMinute, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.PredictGrowUpTime, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.HarvestRate, CVSReader.uintParse);
			this.columnno = 11;
			base.ReadSeq<uint>(reader, ref rowData.HarvestPlant, CVSReader.uintParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.HarvestPlantName, CVSReader.stringParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.ExtraDropRate, CVSReader.uintParse);
			this.columnno = 14;
			base.ReadSeq<uint>(reader, ref rowData.ExtraDropItem, CVSReader.uintParse);
			this.columnno = 15;
			base.Read<string>(reader, ref rowData.ExtraDropItemName, CVSReader.stringParse);
			this.columnno = 16;
			base.Read<uint>(reader, ref rowData.IncreaseGrowUpRate, CVSReader.uintParse);
			this.columnno = 17;
			base.Read<uint>(reader, ref rowData.ReduceGrowUpRate, CVSReader.uintParse);
			this.columnno = 18;
			base.Read<uint>(reader, ref rowData.PlantStateCD, CVSReader.uintParse);
			this.columnno = 19;
			base.Read<uint>(reader, ref rowData.MatureDuration, CVSReader.uintParse);
			this.columnno = 20;
			base.Read<uint>(reader, ref rowData.BadStateGrowUpRate, CVSReader.uintParse);
			this.columnno = 21;
			base.ReadSeq<int>(reader, ref rowData.StealAward, CVSReader.intParse);
			this.columnno = 22;
			base.ReadSeq<int>(reader, ref rowData.TrainAward, CVSReader.intParse);
			this.columnno = 23;
			base.Read<uint>(reader, ref rowData.FirstGrowModelSpriteId, CVSReader.uintParse);
			this.columnno = 24;
			base.Read<uint>(reader, ref rowData.SecondGrowSpriteId, CVSReader.uintParse);
			this.columnno = 25;
			base.Read<uint>(reader, ref rowData.RipeSpriteID, CVSReader.uintParse);
			this.columnno = 26;
			base.Read<uint>(reader, ref rowData.CanStealMaxTimes, CVSReader.uintParse);
			this.columnno = 27;
			base.Read<uint>(reader, ref rowData.InitUpAmount, CVSReader.uintParse);
			this.columnno = 28;
			this.AddRowSeedID(rowData.SeedID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
