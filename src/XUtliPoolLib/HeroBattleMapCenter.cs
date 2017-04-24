using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class HeroBattleMapCenter : CVSReader
	{
		public class RowData
		{
			public uint SceneID;

			public uint CenterType;

			public Seq3Ref<float> Center;

			public float[] Param;

			public float ClientFxScalse;

			public string[] OccupantFx;

			public string[] MiniMapFx;

			public string[] OccSuccessFx;

			public string[] OccWinFx;

			public string MVPCutScene;

			public float[] MVPPos;
		}

		public List<HeroBattleMapCenter.RowData> Table = new List<HeroBattleMapCenter.RowData>();

		public HeroBattleMapCenter.RowData GetBySceneID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchSceneID(key, 0, this.Table.Count - 1);
		}

		private HeroBattleMapCenter.RowData BinarySearchSceneID(uint key, int min, int max)
		{
			HeroBattleMapCenter.RowData rowData = this.Table[min];
			if (rowData.SceneID == key)
			{
				return rowData;
			}
			HeroBattleMapCenter.RowData rowData2 = this.Table[max];
			if (rowData2.SceneID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			HeroBattleMapCenter.RowData rowData3 = this.Table[num];
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

		private void AddRowSceneID(uint key, HeroBattleMapCenter.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			HeroBattleMapCenter.RowData rowData = this.Table[min];
			if (rowData.SceneID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.SceneID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: HeroBattleMapCenter duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			HeroBattleMapCenter.RowData rowData2 = this.Table[max];
			if (rowData2.SceneID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.SceneID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: HeroBattleMapCenter duplicate id:{0}  lineno: {1}", new object[]
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
			HeroBattleMapCenter.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: HeroBattleMapCenter duplicate id:{0}  lineno: {1}", new object[]
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
				"CenterType",
				"Center",
				"Param",
				"ClientFxScalse",
				"OccupantFx",
				"MiniMapFx",
				"OccSuccessFx",
				"OccWinFx",
				"MVPCutScene",
				"MVPPos"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			HeroBattleMapCenter.RowData rowData = new HeroBattleMapCenter.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SceneID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.CenterType))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[2]], ref rowData.Center, CVSReader.floatParse, "3F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Param))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.ClientFxScalse))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.OccupantFx))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.MiniMapFx))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.OccSuccessFx))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.OccWinFx))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.MVPCutScene))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.MVPPos))
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
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.WriteSeq<float>(writer, Fields[this.ColMap[2]], CVSReader.floatParse, 3, "F");
			base.WriteArray<float>(writer, Fields[this.ColMap[3]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[4]], CVSReader.floatParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[10]], CVSReader.floatParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			HeroBattleMapCenter.RowData rowData = new HeroBattleMapCenter.RowData();
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.CenterType, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeq<float>(reader, ref rowData.Center, CVSReader.floatParse);
			this.columnno = 2;
			base.ReadArray<float>(reader, ref rowData.Param, CVSReader.floatParse);
			this.columnno = 3;
			base.Read<float>(reader, ref rowData.ClientFxScalse, CVSReader.floatParse);
			this.columnno = 4;
			base.ReadArray<string>(reader, ref rowData.OccupantFx, CVSReader.stringParse);
			this.columnno = 5;
			base.ReadArray<string>(reader, ref rowData.MiniMapFx, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadArray<string>(reader, ref rowData.OccSuccessFx, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<string>(reader, ref rowData.OccWinFx, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.MVPCutScene, CVSReader.stringParse);
			this.columnno = 9;
			base.ReadArray<float>(reader, ref rowData.MVPPos, CVSReader.floatParse);
			this.columnno = 10;
			this.AddRowSceneID(rowData.SceneID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
