using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ProfSkillTable : CVSReader
	{
		public class RowData
		{
			public int ProfID;

			public string ProfName;

			public string Skill1;

			public string Skill2;

			public string Skill3;

			public string Skill4;

			public string ProfIcon;

			public string ProfPic;

			public string ProfHeadIcon;

			public string ProfHeadIcon2;

			public float FixedEnmity;

			public float EnmityCoefficient;

			public string Description;

			public uint PromoteExperienceID;

			public uint OperateLevel;

			public bool PromoteLR;

			public string ProfNameIcon;

			public string ProfIntro;

			public string ProfTypeIntro;

			public string ProfWord1;

			public string ProfWord2;
		}

		public List<ProfSkillTable.RowData> Table = new List<ProfSkillTable.RowData>();

		public ProfSkillTable.RowData GetByProfID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchProfID(key, 0, this.Table.Count - 1);
		}

		private ProfSkillTable.RowData BinarySearchProfID(int key, int min, int max)
		{
			ProfSkillTable.RowData rowData = this.Table[min];
			if (rowData.ProfID == key)
			{
				return rowData;
			}
			ProfSkillTable.RowData rowData2 = this.Table[max];
			if (rowData2.ProfID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ProfSkillTable.RowData rowData3 = this.Table[num];
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

		private void AddRowProfID(int key, ProfSkillTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ProfSkillTable.RowData rowData = this.Table[min];
			if (rowData.ProfID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ProfID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ProfSkillTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ProfSkillTable.RowData rowData2 = this.Table[max];
			if (rowData2.ProfID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ProfID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ProfSkillTable duplicate id:{0}  lineno: {1}", new object[]
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
			ProfSkillTable.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ProfSkillTable duplicate id:{0}  lineno: {1}", new object[]
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
				"ProfName",
				"Skill1",
				"Skill2",
				"Skill3",
				"Skill4",
				"ProfIcon",
				"ProfPic",
				"ProfHeadIcon",
				"ProfHeadIcon2",
				"FixedEnmity",
				"EnmityCoefficient",
				"Description",
				"PromoteExperienceID",
				"OperateLevel",
				"PromoteLR",
				"ProfNameIcon",
				"ProfIntro",
				"ProfTypeIntro",
				"ProfWord1",
				"ProfWord2"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ProfSkillTable.RowData rowData = new ProfSkillTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ProfID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ProfName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Skill1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Skill2))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Skill3))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Skill4))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.ProfIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.ProfPic))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.ProfHeadIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.ProfHeadIcon2))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.FixedEnmity))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.EnmityCoefficient))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.Description))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.PromoteExperienceID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.OperateLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.PromoteLR))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.ProfNameIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.ProfIntro))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.ProfTypeIntro))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.ProfWord1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[20]], ref rowData.ProfWord2))
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
			base.Write<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.Write<float>(writer, Fields[this.ColMap[10]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[11]], CVSReader.floatParse);
			base.Write<string>(writer, Fields[this.ColMap[12]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse);
			base.Write(writer, false, Fields[this.ColMap[15]]);
			base.Write<string>(writer, Fields[this.ColMap[16]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[17]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[18]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[19]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[20]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ProfSkillTable.RowData rowData = new ProfSkillTable.RowData();
			base.Read<int>(reader, ref rowData.ProfID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ProfName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Skill1, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Skill2, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Skill3, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Skill4, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.ProfIcon, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.ProfPic, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.ProfHeadIcon, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.ProfHeadIcon2, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<float>(reader, ref rowData.FixedEnmity, CVSReader.floatParse);
			this.columnno = 10;
			base.Read<float>(reader, ref rowData.EnmityCoefficient, CVSReader.floatParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.PromoteExperienceID, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.OperateLevel, CVSReader.uintParse);
			this.columnno = 14;
			base.Read(reader, ref rowData.PromoteLR);
			this.columnno = 15;
			base.Read<string>(reader, ref rowData.ProfNameIcon, CVSReader.stringParse);
			this.columnno = 16;
			base.Read<string>(reader, ref rowData.ProfIntro, CVSReader.stringParse);
			this.columnno = 17;
			base.Read<string>(reader, ref rowData.ProfTypeIntro, CVSReader.stringParse);
			this.columnno = 18;
			base.Read<string>(reader, ref rowData.ProfWord1, CVSReader.stringParse);
			this.columnno = 19;
			base.Read<string>(reader, ref rowData.ProfWord2, CVSReader.stringParse);
			this.columnno = 20;
			this.AddRowProfID(rowData.ProfID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
