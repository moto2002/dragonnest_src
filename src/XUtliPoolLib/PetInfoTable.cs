using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PetInfoTable : CVSReader
	{
		public class RowData
		{
			public uint id;

			public string name;

			public uint quality;

			public uint touchAttr;

			public uint touchHourMax;

			public uint touchDayMax;

			public uint followAttr;

			public uint followDayMax;

			public int hungryAuto;

			public uint[] Star;

			public uint[] LvRequire;

			public Seq2ListRef<uint> skill1;

			public Seq2ListRef<uint> skill2;

			public Seq2ListRef<uint> skill3;

			public uint LevelupInsight;

			public Seq2ListRef<uint> randSkills;

			public uint SpeedBuff;

			public string avatar;

			public string icon;

			public uint randSkillMax;

			public uint initHungry;

			public uint maxHungry;

			public uint initMood;

			public uint maxMood;

			public uint presentID;

			public Seq2ListRef<int> hungryAttr;

			public Seq2ListRef<uint> MinimumInsight;

			public uint Male;
		}

		public List<PetInfoTable.RowData> Table = new List<PetInfoTable.RowData>();

		public PetInfoTable.RowData GetByid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchid(key, 0, this.Table.Count - 1);
		}

		private PetInfoTable.RowData BinarySearchid(uint key, int min, int max)
		{
			PetInfoTable.RowData rowData = this.Table[min];
			if (rowData.id == key)
			{
				return rowData;
			}
			PetInfoTable.RowData rowData2 = this.Table[max];
			if (rowData2.id == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			PetInfoTable.RowData rowData3 = this.Table[num];
			if (rowData3.id.CompareTo(key) > 0)
			{
				return this.BinarySearchid(key, min, num);
			}
			if (rowData3.id.CompareTo(key) < 0)
			{
				return this.BinarySearchid(key, num, max);
			}
			return rowData3;
		}

		private void AddRowid(uint key, PetInfoTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			PetInfoTable.RowData rowData = this.Table[min];
			if (rowData.id.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetInfoTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			PetInfoTable.RowData rowData2 = this.Table[max];
			if (rowData2.id.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetInfoTable duplicate id:{0}  lineno: {1}", new object[]
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
			PetInfoTable.RowData rowData3 = this.Table[num];
			if (rowData3.id.CompareTo(key) > 0)
			{
				this.AddRowid(key, row, min, num);
				return;
			}
			if (rowData3.id.CompareTo(key) < 0)
			{
				this.AddRowid(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetInfoTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"id",
				"name",
				"quality",
				"touchAttr",
				"touchHourMax",
				"touchDayMax",
				"followAttr",
				"followDayMax",
				"hungryAuto",
				"Star",
				"LvRequire",
				"skill1",
				"skill2",
				"skill3",
				"LevelupInsight",
				"randSkills",
				"SpeedBuff",
				"avatar",
				"icon",
				"randSkillMax",
				"initHungry",
				"maxHungry",
				"initMood",
				"maxMood",
				"presentID",
				"hungryAttr",
				"MinimumInsight",
				"Male"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PetInfoTable.RowData rowData = new PetInfoTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.quality))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.touchAttr))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.touchHourMax))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.touchDayMax))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.followAttr))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.followDayMax))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.hungryAuto))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.Star))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.LvRequire))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[11]], ref rowData.skill1, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[12]], ref rowData.skill2, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[13]], ref rowData.skill3, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.LevelupInsight))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[15]], ref rowData.randSkills, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.SpeedBuff))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.avatar))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.randSkillMax))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[20]], ref rowData.initHungry))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[21]], ref rowData.maxHungry))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[22]], ref rowData.initMood))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[23]], ref rowData.maxMood))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[24]], ref rowData.presentID))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[25]], ref rowData.hungryAttr, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[26]], ref rowData.MinimumInsight, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[27]], ref rowData.Male))
			{
				return false;
			}
			this.AddRowid(rowData.id, rowData, 0, this.Table.Count - 1);
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
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[15]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[16]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[17]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[18]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[19]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[20]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[21]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[22]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[23]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[24]], CVSReader.uintParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[25]], CVSReader.intParse, 2, "I");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[26]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[27]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PetInfoTable.RowData rowData = new PetInfoTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.quality, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.touchAttr, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.touchHourMax, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.touchDayMax, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.followAttr, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.followDayMax, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.hungryAuto, CVSReader.intParse);
			this.columnno = 8;
			base.ReadArray<uint>(reader, ref rowData.Star, CVSReader.uintParse);
			this.columnno = 9;
			base.ReadArray<uint>(reader, ref rowData.LvRequire, CVSReader.uintParse);
			this.columnno = 10;
			base.ReadSeqList<uint>(reader, ref rowData.skill1, CVSReader.uintParse);
			this.columnno = 11;
			base.ReadSeqList<uint>(reader, ref rowData.skill2, CVSReader.uintParse);
			this.columnno = 12;
			base.ReadSeqList<uint>(reader, ref rowData.skill3, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.LevelupInsight, CVSReader.uintParse);
			this.columnno = 14;
			base.ReadSeqList<uint>(reader, ref rowData.randSkills, CVSReader.uintParse);
			this.columnno = 15;
			base.Read<uint>(reader, ref rowData.SpeedBuff, CVSReader.uintParse);
			this.columnno = 16;
			base.Read<string>(reader, ref rowData.avatar, CVSReader.stringParse);
			this.columnno = 17;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 18;
			base.Read<uint>(reader, ref rowData.randSkillMax, CVSReader.uintParse);
			this.columnno = 19;
			base.Read<uint>(reader, ref rowData.initHungry, CVSReader.uintParse);
			this.columnno = 20;
			base.Read<uint>(reader, ref rowData.maxHungry, CVSReader.uintParse);
			this.columnno = 21;
			base.Read<uint>(reader, ref rowData.initMood, CVSReader.uintParse);
			this.columnno = 22;
			base.Read<uint>(reader, ref rowData.maxMood, CVSReader.uintParse);
			this.columnno = 23;
			base.Read<uint>(reader, ref rowData.presentID, CVSReader.uintParse);
			this.columnno = 24;
			base.ReadSeqList<int>(reader, ref rowData.hungryAttr, CVSReader.intParse);
			this.columnno = 25;
			base.ReadSeqList<uint>(reader, ref rowData.MinimumInsight, CVSReader.uintParse);
			this.columnno = 26;
			base.Read<uint>(reader, ref rowData.Male, CVSReader.uintParse);
			this.columnno = 27;
			this.AddRowid(rowData.id, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
