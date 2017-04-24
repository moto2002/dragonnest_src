using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class OnlineRewardTable : CVSReader
	{
		public class RowData
		{
			public uint time;

			public Seq2ListRef<uint> reward;

			public string RewardTip;
		}

		public List<OnlineRewardTable.RowData> Table = new List<OnlineRewardTable.RowData>();

		public OnlineRewardTable.RowData GetBytime(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchtime(key, 0, this.Table.Count - 1);
		}

		private OnlineRewardTable.RowData BinarySearchtime(uint key, int min, int max)
		{
			OnlineRewardTable.RowData rowData = this.Table[min];
			if (rowData.time == key)
			{
				return rowData;
			}
			OnlineRewardTable.RowData rowData2 = this.Table[max];
			if (rowData2.time == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			OnlineRewardTable.RowData rowData3 = this.Table[num];
			if (rowData3.time.CompareTo(key) > 0)
			{
				return this.BinarySearchtime(key, min, num);
			}
			if (rowData3.time.CompareTo(key) < 0)
			{
				return this.BinarySearchtime(key, num, max);
			}
			return rowData3;
		}

		private void AddRowtime(uint key, OnlineRewardTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			OnlineRewardTable.RowData rowData = this.Table[min];
			if (rowData.time.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.time == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: OnlineRewardTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			OnlineRewardTable.RowData rowData2 = this.Table[max];
			if (rowData2.time.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.time == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: OnlineRewardTable duplicate id:{0}  lineno: {1}", new object[]
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
			OnlineRewardTable.RowData rowData3 = this.Table[num];
			if (rowData3.time.CompareTo(key) > 0)
			{
				this.AddRowtime(key, row, min, num);
				return;
			}
			if (rowData3.time.CompareTo(key) < 0)
			{
				this.AddRowtime(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: OnlineRewardTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"time",
				"reward",
				"RewardTip"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			OnlineRewardTable.RowData rowData = new OnlineRewardTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.time))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.RewardTip))
			{
				return false;
			}
			this.AddRowtime(rowData.time, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			OnlineRewardTable.RowData rowData = new OnlineRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.time, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.RewardTip, CVSReader.stringParse);
			this.columnno = 2;
			this.AddRowtime(rowData.time, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
