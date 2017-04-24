using System;
using System.Collections.Generic;
using System.Text;

namespace com.tencent.pandora
{
	public class UserData
	{
		public string sRoleId = string.Empty;

		public string sOpenId = string.Empty;

		public string sServiceType = string.Empty;

		public string sAcountType = string.Empty;

		public string sArea = string.Empty;

		public string sPartition = string.Empty;

		public string sAppId = string.Empty;

		public string sAccessToken = string.Empty;

		public string sPayToken = string.Empty;

		public string sGameVer = string.Empty;

		public string sPlatID = string.Empty;

		public string sQQInstalled = string.Empty;

		public string sWXInstalled = string.Empty;

		public string sGameName = string.Empty;

		public string sSdkVersion = string.Empty;

		public string sParam0 = string.Empty;

		public string sParam1 = string.Empty;

		public bool IsRoleEmpty()
		{
			return string.IsNullOrEmpty(this.sRoleId);
		}

		public void Clear()
		{
			this.sRoleId = string.Empty;
			this.sOpenId = string.Empty;
			this.sServiceType = string.Empty;
			this.sAcountType = string.Empty;
			this.sArea = string.Empty;
			this.sPartition = string.Empty;
			this.sAppId = string.Empty;
			this.sAccessToken = string.Empty;
			this.sPayToken = string.Empty;
			this.sGameVer = string.Empty;
			this.sPlatID = string.Empty;
			this.sQQInstalled = string.Empty;
			this.sWXInstalled = string.Empty;
			this.sGameName = string.Empty;
			this.sSdkVersion = string.Empty;
			this.sParam0 = string.Empty;
			this.sParam1 = string.Empty;
		}

		public void Assign(Dictionary<string, string> data)
		{
			if (data.ContainsKey("sRoleId"))
			{
				this.sRoleId = data["sRoleId"];
			}
			if (data.ContainsKey("sOpenId"))
			{
				this.sOpenId = data["sOpenId"];
			}
			if (data.ContainsKey("sServiceType"))
			{
				this.sServiceType = data["sServiceType"];
			}
			if (data.ContainsKey("sAcountType"))
			{
				this.sAcountType = data["sAcountType"];
			}
			if (data.ContainsKey("sArea"))
			{
				this.sArea = data["sArea"];
			}
			if (data.ContainsKey("sPartition"))
			{
				this.sPartition = data["sPartition"];
			}
			if (data.ContainsKey("sAppId"))
			{
				this.sAppId = data["sAppId"];
			}
			if (data.ContainsKey("sAccessToken"))
			{
				this.sAccessToken = data["sAccessToken"];
			}
			if (data.ContainsKey("sPayToken"))
			{
				this.sPayToken = data["sPayToken"];
			}
			if (data.ContainsKey("sGameVer"))
			{
				this.sGameVer = data["sGameVer"];
			}
			if (data.ContainsKey("sPlatID"))
			{
				this.sPlatID = data["sPlatID"];
			}
			if (data.ContainsKey("sQQInstalled"))
			{
				this.sQQInstalled = data["sQQInstalled"];
			}
			if (data.ContainsKey("sWXInstalled"))
			{
				this.sWXInstalled = data["sWXInstalled"];
			}
			if (data.ContainsKey("sGameName"))
			{
				this.sGameName = data["sGameName"];
			}
			if (data.ContainsKey("sSdkVersion"))
			{
				this.sSdkVersion = data["sSdkVersion"];
			}
			if (data.ContainsKey("sParam0"))
			{
				this.sParam0 = data["sParam0"];
			}
			if (data.ContainsKey("sParam1"))
			{
				this.sParam1 = data["sParam1"];
			}
		}

		public void Refresh(Dictionary<string, string> data)
		{
			string text = data["sRoleId"];
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(this.sRoleId) || text != this.sRoleId)
			{
				return;
			}
			if (data.ContainsKey("sAccessToken"))
			{
				this.sAccessToken = data["sAccessToken"];
			}
			if (data.ContainsKey("sPayToken"))
			{
				this.sPayToken = data["sPayToken"];
			}
			Logger.Log("Refresh UserData: " + this.ToString());
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<color=#0000ff>UserData: ");
			stringBuilder.Append("sOpenId=");
			stringBuilder.Append(this.sOpenId);
			stringBuilder.Append("&sAcountType=");
			stringBuilder.Append(this.sAcountType);
			stringBuilder.Append("&sAppId=");
			stringBuilder.Append(this.sAppId);
			stringBuilder.Append("&sPlatID=");
			stringBuilder.Append(this.sPlatID);
			stringBuilder.Append("&sAppId=");
			stringBuilder.Append(this.sAppId);
			stringBuilder.Append("&sAccessToken=");
			stringBuilder.Append(this.sAccessToken);
			stringBuilder.Append("&sPayToken=");
			stringBuilder.Append(this.sPayToken);
			stringBuilder.Append("&sSdkVersion=");
			stringBuilder.Append(this.sSdkVersion);
			stringBuilder.Append("&sArea=");
			stringBuilder.Append(this.sArea);
			stringBuilder.Append("&sPartition=");
			stringBuilder.Append(this.sPartition);
			stringBuilder.Append("&sGameName=");
			stringBuilder.Append(this.sGameName);
			stringBuilder.Append("&sGameVer=");
			stringBuilder.Append(this.sGameVer);
			stringBuilder.Append("&sQQInstalled=");
			stringBuilder.Append(this.sQQInstalled);
			stringBuilder.Append("&sWXInstalled=");
			stringBuilder.Append(this.sWXInstalled);
			stringBuilder.Append("&sParam0=");
			stringBuilder.Append(this.sParam0);
			stringBuilder.Append("&sParam1=");
			stringBuilder.Append(this.sParam1);
			stringBuilder.Append("</color>");
			return stringBuilder.ToString();
		}
	}
}
