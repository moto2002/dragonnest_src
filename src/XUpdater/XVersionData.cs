using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using XUtliPoolLib;

namespace XUpdater
{
	[Serializable]
	public class XVersionData : IComparable<XVersionData>
	{
		private static readonly string pattern = "^(\\d+).(\\d+).(\\d+)(.(\\d+)p(\\d+))?\\b";

		private static Regex r = new Regex(XVersionData.pattern);

		private uint _major_version;

		public uint Build_Version;

		public uint Minor_Version;

		public uint rc_Build_Version;

		public uint rc_Minor_Version;

		public uint MD5_Size = 1048576u;

		public BuildTarget Target_Platform;

		public List<XBundleData> Bundles = new List<XBundleData>();

		public List<XResPackage> Res = new List<XResPackage>();

		public List<XMetaResPackage> AB = new List<XMetaResPackage>();

		public List<XMetaResPackage> Scene = new List<XMetaResPackage>();

		public List<XMetaResPackage> FMOD = new List<XMetaResPackage>();

		public bool HasRCVersion
		{
			get
			{
				return this.rc_Build_Version > 0u || this.rc_Minor_Version > 0u;
			}
		}

		public bool IsNewly
		{
			get
			{
				return this.Build_Version == 0u && this.Minor_Version == 0u;
			}
		}

		public uint Major_Version
		{
			get
			{
				return this._major_version;
			}
		}

		public XVersionData()
		{
			this._major_version = XUpdater.Major_Version;
		}

		public XVersionData(uint major)
		{
			this._major_version = major;
		}

		public XVersionData(XVersionData rhs) : this()
		{
			this.VersionCopy(rhs);
		}

		public void VersionCopy(XVersionData rhs)
		{
			if (rhs == null)
			{
				this.Build_Version = 0u;
				this.Minor_Version = 0u;
				this.rc_Build_Version = 0u;
				this.rc_Minor_Version = 0u;
				return;
			}
			this.Build_Version = rhs.Build_Version;
			this.Minor_Version = rhs.Minor_Version;
			this.rc_Build_Version = rhs.rc_Build_Version;
			this.rc_Minor_Version = rhs.rc_Minor_Version;
		}

		public void RC()
		{
			if (this.HasRCVersion)
			{
				return;
			}
			this.rc_Build_Version = 1u;
		}

		public XVersionData Increment(bool rebuild)
		{
			XVersionData xVersionData = new XVersionData(this);
			if (rebuild)
			{
				if (this.HasRCVersion)
				{
					xVersionData.rc_Build_Version += 1u;
					xVersionData.rc_Minor_Version = 0u;
				}
				else
				{
					xVersionData.Build_Version += 1u;
					xVersionData.Minor_Version = 0u;
					xVersionData.rc_Build_Version = 0u;
					xVersionData.rc_Minor_Version = 0u;
				}
			}
			else if (this.HasRCVersion)
			{
				xVersionData.rc_Minor_Version += 1u;
			}
			else
			{
				xVersionData.Minor_Version += 1u;
				xVersionData.rc_Build_Version = 0u;
				xVersionData.rc_Minor_Version = 0u;
			}
			return xVersionData;
		}

		public override string ToString()
		{
			if (!this.HasRCVersion)
			{
				return string.Format("{0}.{1}.{2}", this._major_version, this.Build_Version, this.Minor_Version);
			}
			return string.Format("{0}.{1}.{2}.{3}p{4}", new object[]
			{
				this._major_version,
				this.Build_Version,
				this.Minor_Version,
				this.rc_Build_Version,
				this.rc_Minor_Version
			});
		}

		public static XVersionData Convert2Version(string version)
		{
			Match match = XVersionData.r.Match(version);
			if (match.Success)
			{
				XVersionData xVersionData = new XVersionData(uint.Parse(match.Groups[1].Value));
				xVersionData.Build_Version = uint.Parse(match.Groups[2].Value);
				xVersionData.Minor_Version = uint.Parse(match.Groups[3].Value);
				if (!string.IsNullOrEmpty(match.Groups[4].Value))
				{
					xVersionData.rc_Build_Version = uint.Parse(match.Groups[5].Value);
					xVersionData.rc_Minor_Version = uint.Parse(match.Groups[6].Value);
				}
				return xVersionData;
			}
			return null;
		}

		public int CompareTo(XVersionData other)
		{
			if (other == null)
			{
				return 1;
			}
			if (this._major_version != other.Major_Version)
			{
				return (int)(this._major_version - other.Major_Version);
			}
			if (this.Build_Version != other.Build_Version)
			{
				return (int)(this.Build_Version - other.Build_Version);
			}
			if (this.Minor_Version != other.Minor_Version)
			{
				return (int)(this.Minor_Version - other.Minor_Version);
			}
			if (this.rc_Build_Version != other.rc_Build_Version)
			{
				return (int)(this.rc_Build_Version - other.rc_Build_Version);
			}
			if (this.rc_Minor_Version == other.rc_Minor_Version)
			{
				return 0;
			}
			return (int)(this.rc_Minor_Version - other.rc_Minor_Version);
		}

		public bool CanUpdated(XVersionData other)
		{
			if (this._major_version == other.Major_Version && this.Build_Version == other.Build_Version)
			{
				if (this.Minor_Version != other.Minor_Version)
				{
					return !this.HasRCVersion && !other.HasRCVersion;
				}
				if (this.rc_Build_Version == other.rc_Build_Version)
				{
					return true;
				}
			}
			return false;
		}

		public bool NeedDownload(string version)
		{
			XVersionData xVersionData = XVersionData.Convert2Version(version);
			if (xVersionData == null)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Error bundle with name ", version, null, null, null, null);
				return false;
			}
			return this.CompareTo(xVersionData) < 0;
		}

		public XBundleData GetSpecificBundle(string name)
		{
			for (int i = 0; i < this.Bundles.Count; i++)
			{
				if (name == this.Bundles[i].Name)
				{
					return this.Bundles[i];
				}
			}
			return null;
		}
	}
}
