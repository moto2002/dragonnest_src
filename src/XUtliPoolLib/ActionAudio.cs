using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ActionAudio : CVSReader
	{
		public class RowData
		{
			public string Prefab;

			public string[] Idle;

			public string[] Move;

			public string[] Jump;

			public string[] Fall;

			public string[] Dash;

			public string[] Charge;

			public string[] Freeze;

			public string[] Behit;

			public string[] Death;

			public string[] BehitFly;

			public string[] BehitRoll;

			public string[] BehitSuperArmor;
		}

		public List<ActionAudio.RowData> Table = new List<ActionAudio.RowData>();

		public ActionAudio.RowData GetByPrefab(string key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchPrefab(key, 0, this.Table.Count - 1);
		}

		private ActionAudio.RowData BinarySearchPrefab(string key, int min, int max)
		{
			ActionAudio.RowData rowData = this.Table[min];
			if (rowData.Prefab == key)
			{
				return rowData;
			}
			ActionAudio.RowData rowData2 = this.Table[max];
			if (rowData2.Prefab == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ActionAudio.RowData rowData3 = this.Table[num];
			if (rowData3.Prefab.CompareTo(key) > 0)
			{
				return this.BinarySearchPrefab(key, min, num);
			}
			if (rowData3.Prefab.CompareTo(key) < 0)
			{
				return this.BinarySearchPrefab(key, num, max);
			}
			return rowData3;
		}

		private void AddRowPrefab(string key, ActionAudio.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ActionAudio.RowData rowData = this.Table[min];
			if (rowData.Prefab.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.Prefab == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ActionAudio duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ActionAudio.RowData rowData2 = this.Table[max];
			if (rowData2.Prefab.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.Prefab == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ActionAudio duplicate id:{0}  lineno: {1}", new object[]
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
			ActionAudio.RowData rowData3 = this.Table[num];
			if (rowData3.Prefab.CompareTo(key) > 0)
			{
				this.AddRowPrefab(key, row, min, num);
				return;
			}
			if (rowData3.Prefab.CompareTo(key) < 0)
			{
				this.AddRowPrefab(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ActionAudio duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Prefab",
				"Idle",
				"Move",
				"Jump",
				"Fall",
				"Dash",
				"Charge",
				"Freeze",
				"Behit",
				"Death",
				"BehitFly",
				"BehitRoll",
				"BehitSuperArmor"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ActionAudio.RowData rowData = new ActionAudio.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Prefab))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Idle))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Move))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Jump))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Fall))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Dash))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Charge))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.Freeze))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.Behit))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.Death))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.BehitFly))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.BehitRoll))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.BehitSuperArmor))
			{
				return false;
			}
			this.AddRowPrefab(rowData.Prefab, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<string>(writer, Fields[this.ColMap[0]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[10]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[11]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[12]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ActionAudio.RowData rowData = new ActionAudio.RowData();
			base.Read<string>(reader, ref rowData.Prefab, CVSReader.stringParse);
			this.columnno = 0;
			base.ReadArray<string>(reader, ref rowData.Idle, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<string>(reader, ref rowData.Move, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.Jump, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadArray<string>(reader, ref rowData.Fall, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadArray<string>(reader, ref rowData.Dash, CVSReader.stringParse);
			this.columnno = 5;
			base.ReadArray<string>(reader, ref rowData.Charge, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadArray<string>(reader, ref rowData.Freeze, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<string>(reader, ref rowData.Behit, CVSReader.stringParse);
			this.columnno = 8;
			base.ReadArray<string>(reader, ref rowData.Death, CVSReader.stringParse);
			this.columnno = 9;
			base.ReadArray<string>(reader, ref rowData.BehitFly, CVSReader.stringParse);
			this.columnno = 10;
			base.ReadArray<string>(reader, ref rowData.BehitRoll, CVSReader.stringParse);
			this.columnno = 11;
			base.ReadArray<string>(reader, ref rowData.BehitSuperArmor, CVSReader.stringParse);
			this.columnno = 12;
			this.AddRowPrefab(rowData.Prefab, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
