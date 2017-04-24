using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class DragonExpList : CVSReader
	{
		public class RowData
		{
			public uint SceneID;

			public string Description;

			public Seq2ListRef<uint> ChallengeReward;

			public Seq2ListRef<uint> WinReward;

			public string ResName;

			public int During;

			public string BuffIcon;

			public string BuffDes;

			public uint BossID;

			public uint SealLevel;

			public Seq2Ref<uint> SealBuff;

			public Seq2Ref<uint> ChapterID;

			public string WinHit;

			public float LimitPos;

			public float[] SnapPos;
		}

		public List<DragonExpList.RowData> Table = new List<DragonExpList.RowData>();

		public DragonExpList.RowData GetBySceneID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchSceneID(key, 0, this.Table.Count - 1);
		}

		private DragonExpList.RowData BinarySearchSceneID(uint key, int min, int max)
		{
			DragonExpList.RowData rowData = this.Table[min];
			if (rowData.SceneID == key)
			{
				return rowData;
			}
			DragonExpList.RowData rowData2 = this.Table[max];
			if (rowData2.SceneID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			DragonExpList.RowData rowData3 = this.Table[num];
			if (rowData3.SceneID.CompareTo(key) > 0)
			{
				return this.BinarySearchSceneID(key, min, num);
			}
			if (rowData3.SceneID.CompareTo(key) < 0)
			{
				return this.BinarySearchSceneID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowSceneID(uint key, DragonExpList.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			DragonExpList.RowData rowData = this.Table[min];
			if (rowData.SceneID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.SceneID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: DragonExpList duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			DragonExpList.RowData rowData2 = this.Table[max];
			if (rowData2.SceneID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.SceneID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: DragonExpList duplicate id:{0}  lineno: {1}", new object[]
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
			DragonExpList.RowData rowData3 = this.Table[num];
			if (rowData3.SceneID.CompareTo(key) > 0)
			{
				this.AddRowSceneID(key, row, min, num);
				return;
			}
			if (rowData3.SceneID.CompareTo(key) < 0)
			{
				this.AddRowSceneID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: DragonExpList duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SceneID",
				"Description",
				"ChallengeReward",
				"WinReward",
				"ResName",
				"During",
				"BuffIcon",
				"BuffDes",
				"BossID",
				"SealLevel",
				"SealBuff",
				"ChapterID",
				"WinHit",
				"LimitPos",
				"SnapPos"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			DragonExpList.RowData rowData = new DragonExpList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SceneID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Description))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.ChallengeReward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.WinReward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.ResName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.During))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.BuffIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.BuffDes))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.BossID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.SealLevel))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[10]], ref rowData.SealBuff, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[11]], ref rowData.ChapterID, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.WinHit))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.LimitPos))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.SnapPos))
			{
				return false;
			}
			this.AddRowSceneID(rowData.SceneID, rowData, 0, this.Table.Count - 1);
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
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[12]], CVSReader.stringParse);
			base.Write<float>(writer, Fields[this.ColMap[13]], CVSReader.floatParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[14]], CVSReader.floatParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			DragonExpList.RowData rowData = new DragonExpList.RowData();
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.ChallengeReward, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.WinReward, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.ResName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.During, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.BuffIcon, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.BuffDes, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.BossID, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.SealLevel, CVSReader.uintParse);
			this.columnno = 9;
			base.ReadSeq<uint>(reader, ref rowData.SealBuff, CVSReader.uintParse);
			this.columnno = 10;
			base.ReadSeq<uint>(reader, ref rowData.ChapterID, CVSReader.uintParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.WinHit, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<float>(reader, ref rowData.LimitPos, CVSReader.floatParse);
			this.columnno = 13;
			base.ReadArray<float>(reader, ref rowData.SnapPos, CVSReader.floatParse);
			this.columnno = 14;
			this.AddRowSceneID(rowData.SceneID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
