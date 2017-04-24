using System;

namespace com.tencent.gsdk
{
	public class FpsInfo
	{
		public string tag;

		public int avg;

		public int max;

		public int min;

		public int totalTimes;

		public int heavyTimes;

		public int lightTimes;

		public int cusTimes;

		public string fpsdots;

		public FpsInfo(string tag, int avg, int max, int min, int totalTimes, int heavyTimes, int lightTimes, int cusTimes, string fpsdots)
		{
			this.tag = tag;
			this.avg = avg;
			this.max = max;
			this.min = min;
			this.totalTimes = totalTimes;
			this.heavyTimes = heavyTimes;
			this.lightTimes = lightTimes;
			this.cusTimes = cusTimes;
			this.fpsdots = fpsdots;
		}

		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"场景ID：",
				this.tag,
				"，均值：",
				this.avg,
				"，最大值：",
				this.max,
				"，最小值：",
				this.min,
				"，统计次数：",
				this.totalTimes,
				"，严重抖动次数：",
				this.heavyTimes,
				"，轻微抖动次数：",
				this.lightTimes,
				"，自定义抖动次数：",
				this.cusTimes,
				"\n"
			});
		}
	}
}
