using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class DefaultEquip : CVSReader
	{
		public class RowData
		{
			public int ProfID;

			public string Helmet;

			public string Face;

			public string Body;

			public string Leg;

			public string Boots;

			public string Glove;

			public string Weapon;

			public string[] WeaponPoint;

			public string WingPoint;

			public string SecondWeapon;

			public string Wing;

			public string Tail;

			public string Decal;

			public string Hair;

			public string TailPoint;

			public string FishingPoint;
		}

		public List<DefaultEquip.RowData> Table = new List<DefaultEquip.RowData>();

		public DefaultEquip.RowData GetByProfID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchProfID(key, 0, this.Table.Count - 1);
		}

		private DefaultEquip.RowData BinarySearchProfID(int key, int min, int max)
		{
			DefaultEquip.RowData rowData = this.Table[min];
			if (rowData.ProfID == key)
			{
				return rowData;
			}
			DefaultEquip.RowData rowData2 = this.Table[max];
			if (rowData2.ProfID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			DefaultEquip.RowData rowData3 = this.Table[num];
			if (rowData3.ProfID.CompareTo(key) > 0)
			{
				return this.BinarySearchProfID(key, min, num);
			}
			if (rowData3.ProfID.CompareTo(key) < 0)
			{
				return this.BinarySearchProfID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowProfID(int key, DefaultEquip.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			DefaultEquip.RowData rowData = this.Table[min];
			if (rowData.ProfID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ProfID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: DefaultEquip duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			DefaultEquip.RowData rowData2 = this.Table[max];
			if (rowData2.ProfID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ProfID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: DefaultEquip duplicate id:{0}  lineno: {1}", new object[]
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
			DefaultEquip.RowData rowData3 = this.Table[num];
			if (rowData3.ProfID.CompareTo(key) > 0)
			{
				this.AddRowProfID(key, row, min, num);
				return;
			}
			if (rowData3.ProfID.CompareTo(key) < 0)
			{
				this.AddRowProfID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: DefaultEquip duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ProfID",
				"Helmet",
				"Face",
				"Body",
				"Leg",
				"Boots",
				"Glove",
				"Weapon",
				"WeaponPoint",
				"WingPoint",
				"SecondWeapon",
				"Wing",
				"Tail",
				"Decal",
				"Hair",
				"TailPoint",
				"FishingPoint"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			DefaultEquip.RowData rowData = new DefaultEquip.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ProfID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Helmet))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Face))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Body))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Leg))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Boots))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Glove))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.Weapon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.WeaponPoint))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.WingPoint))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.SecondWeapon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.Wing))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.Tail))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.Decal))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.Hair))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.TailPoint))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.FishingPoint))
			{
				return false;
			}
			this.AddRowProfID(rowData.ProfID, rowData, 0, this.Table.Count - 1);
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[10]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[11]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[12]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[13]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[14]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[15]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[16]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			DefaultEquip.RowData rowData = new DefaultEquip.RowData();
			base.Read<int>(reader, ref rowData.ProfID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Helmet, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Face, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Body, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Leg, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Boots, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Glove, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Weapon, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<string>(reader, ref rowData.WeaponPoint, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.WingPoint, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.SecondWeapon, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.Wing, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.Tail, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.Decal, CVSReader.stringParse);
			this.columnno = 13;
			base.Read<string>(reader, ref rowData.Hair, CVSReader.stringParse);
			this.columnno = 14;
			base.Read<string>(reader, ref rowData.TailPoint, CVSReader.stringParse);
			this.columnno = 15;
			base.Read<string>(reader, ref rowData.FishingPoint, CVSReader.stringParse);
			this.columnno = 16;
			this.AddRowProfID(rowData.ProfID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
