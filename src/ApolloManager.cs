using com.tencent.gsdk;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using XUtliPoolLib;

public class ApolloManager : MonoBehaviour, IApolloManager
{
	private static CApolloVoiceSys ApolloVoiceMgr = null;

	private static bool m_bCreateEngine = false;

	private bool _openMusic = true;

	private bool _openSpeak = true;

	private string mAppID = string.Empty;

	private string mOpenID = string.Empty;

	public static ApolloManager sington = null;

	public static byte[] m_strFileID = new byte[1024];

	private int cacheZoneID;

	private string cacheTag;

	private string cacheRoomIP;

	public bool openMusic
	{
		get
		{
			return this._openMusic;
		}
		set
		{
			this._openMusic = value;
			ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)((!value) ? ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._CloseSpeaker() : ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._OpenSpeaker());
			if (apolloVoiceErr == ApolloVoiceErr.APOLLO_VOICE_SUCC)
			{
				ApolloManager.m_bCreateEngine = true;
				XSingleton<XDebug>.singleton.AddLog(string.Format("openMusic Succ {0}", value), null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				string message = string.Format("openMusic Err is {0}", apolloVoiceErr);
				Debug.Log(message);
			}
		}
	}

	public bool openSpeak
	{
		get
		{
			return this._openSpeak;
		}
		set
		{
			this._openSpeak = value;
			ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)((!value) ? ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._CloseMic() : ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._OpenMic());
			if (apolloVoiceErr == ApolloVoiceErr.APOLLO_VOICE_SUCC)
			{
				ApolloManager.m_bCreateEngine = true;
				XSingleton<XDebug>.singleton.AddLog(string.Format("openSpeak Succ {0}", value), null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				string message = string.Format("openSpeak Err is {0}", apolloVoiceErr);
				Debug.Log(message);
			}
		}
	}

	private void Awake()
	{
		ApolloManager.sington = this;
	}

	private void OnDestroy()
	{
		ApolloManager.sington = null;
	}

	private void Start()
	{
		this.InitGSDK("1105309683");
	}

	public void Init(int platf, string openid)
	{
		this.mAppID = "guest100023";
		if (platf == 3)
		{
			this.mAppID = "1105309683";
		}
		else if (platf == 4)
		{
			this.mAppID = "wxfdab5af74990787a";
		}
		this.mOpenID = openid;
		this.SetGSDKUserName(platf, openid);
		if (ApolloManager.ApolloVoiceMgr != null)
		{
			Debug.Log("ApolloVoiceMgr Created");
		}
		else
		{
			ApolloManager.ApolloVoiceMgr = new CApolloVoiceSys();
			ApolloManager.ApolloVoiceMgr.SysInitial();
		}
		if (ApolloManager.ApolloVoiceMgr != null)
		{
			ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._CreateApolloVoiceEngine(this.mAppID, openid);
			if (apolloVoiceErr == ApolloVoiceErr.APOLLO_VOICE_SUCC)
			{
				ApolloManager.m_bCreateEngine = true;
				XSingleton<XDebug>.singleton.AddLog("CreateApolloVoiceEngine Succ", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				string message = string.Format("CreateApolloVoiceEngine Err is {0}", apolloVoiceErr);
				Debug.Log(message);
			}
		}
	}

	public void SetRealtimeMode()
	{
		if (ApolloManager.ApolloVoiceMgr != null)
		{
			ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._SetMode(0);
			if (apolloVoiceErr == ApolloVoiceErr.APOLLO_VOICE_SUCC)
			{
				ApolloManager.m_bCreateEngine = true;
				XSingleton<XDebug>.singleton.AddLog("apollo _SetMode Succ", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				string message = string.Format("apollo _SetMode Err is {0}", apolloVoiceErr);
				Debug.Log(message);
			}
		}
	}

	public void Capture(bool capture)
	{
		ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._CaptureMicrophone(capture);
		if (apolloVoiceErr == ApolloVoiceErr.APOLLO_VOICE_SUCC)
		{
			ApolloManager.m_bCreateEngine = true;
			Debug.Log("apollo capture Succ");
		}
		else
		{
			string message = string.Format("apollo capture Err is {0}", apolloVoiceErr);
			Debug.Log(message);
		}
	}

	public void ForbitMember(int memberId, bool bEnable)
	{
		if (ApolloManager.ApolloVoiceMgr != null)
		{
			ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._ForbidMemberVoice(memberId, bEnable);
			if (apolloVoiceErr == ApolloVoiceErr.APOLLO_VOICE_SUCC)
			{
				ApolloManager.m_bCreateEngine = true;
				XSingleton<XDebug>.singleton.AddLog("ForbitMember Succ", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				string message = string.Format("ForbitMember Err is {0}", apolloVoiceErr);
				Debug.Log(message);
			}
		}
	}

	public int[] GetMembersState(ref int size)
	{
		int[] array = new int[32];
		size = ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._GetMemberState(array);
		return array;
	}

	public void JoinRoom(string url1, string url2, string url3, long roomId, long roomKey, short memberId)
	{
		if (string.IsNullOrEmpty(this.mOpenID))
		{
			Debug.LogError("openid is nil");
			return;
		}
		ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._JoinRoom(url1, url2, url3, roomId, roomKey, memberId, this.mOpenID, 45000);
		if (apolloVoiceErr == ApolloVoiceErr.APOLLO_VOICE_SUCC)
		{
			ApolloManager.m_bCreateEngine = true;
			XSingleton<XDebug>.singleton.AddLog(string.Format("JoinRoom Succ {0}  {1}  {2} {3} {4} {5}", new object[]
			{
				roomId,
				roomKey,
				memberId,
				url1,
				url2,
				url3
			}), null, null, null, null, null, XDebugColor.XDebug_None);
		}
		else
		{
			string message = string.Format("JoinRoom Err is {0}", apolloVoiceErr);
			Debug.Log(message);
		}
	}

	public void JoinBigRoom(string urls, int role, uint busniessID, long roomid, long roomkey, short memberid)
	{
		if (string.IsNullOrEmpty(this.mOpenID))
		{
			Debug.LogError("openid is nil");
			return;
		}
		ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._JoinBigRoom(urls, role, busniessID, roomid, roomkey, memberid, this.mOpenID, 45000);
		if (apolloVoiceErr == ApolloVoiceErr.APOLLO_VOICE_SUCC)
		{
			ApolloManager.m_bCreateEngine = true;
			XSingleton<XDebug>.singleton.AddLog(string.Format("_JoinBigRoom Succ {0}  {1}  {2} {3} {4} {5}", new object[]
			{
				roomid,
				roomkey,
				urls,
				role,
				busniessID,
				memberid
			}), null, null, null, null, null, XDebugColor.XDebug_None);
		}
		else
		{
			string message = string.Format("_JoinBigRoom Err is {0}", apolloVoiceErr);
			Debug.Log(message);
		}
	}

	public bool GetJoinRoomResult()
	{
		bool result = false;
		if (ApolloManager.ApolloVoiceMgr != null)
		{
			ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._GetJoinRoomResult();
			if (apolloVoiceErr == ApolloVoiceErr.APOLLO_VOICE_JOIN_SUCC)
			{
				result = true;
				XSingleton<XDebug>.singleton.AddLog("Apollo GetJoinRoomResult Succ", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				string message = string.Format("Apollo GetJoinRoomResult is {0}", apolloVoiceErr);
				Debug.Log(message);
			}
		}
		return result;
	}

	public bool GetJoinRoomBigResult()
	{
		bool result = false;
		if (ApolloManager.ApolloVoiceMgr != null)
		{
			ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._GetJoinRoomBigResult();
			if (apolloVoiceErr == ApolloVoiceErr.APOLLO_VOICE_JOIN_SUCC)
			{
				result = true;
				XSingleton<XDebug>.singleton.AddLog("Apollo _GetJoinRoomBigResult Succ", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				string log = string.Format("Apollo _GetJoinRoomBigResult is {0}", apolloVoiceErr);
				XSingleton<XDebug>.singleton.AddLog(log, null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}
		return result;
	}

	public void QuitRoom(long roomId, short memberId)
	{
		if (string.IsNullOrEmpty(this.mOpenID))
		{
			Debug.LogError("openid is nil");
			return;
		}
		ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._QuitRoom(roomId, memberId, this.mOpenID);
		if (apolloVoiceErr == ApolloVoiceErr.APOLLO_VOICE_SUCC)
		{
			ApolloManager.m_bCreateEngine = true;
			XSingleton<XDebug>.singleton.AddLog(string.Format("QuitRoom Succ {0} {1}", roomId, memberId), null, null, null, null, null, XDebugColor.XDebug_None);
		}
		else
		{
			string log = string.Format("QuitRoom Err is {0}", apolloVoiceErr);
			XSingleton<XDebug>.singleton.AddLog(log, null, null, null, null, null, XDebugColor.XDebug_None);
		}
	}

	public void QuitBigRoom()
	{
		if (string.IsNullOrEmpty(this.mOpenID))
		{
			Debug.LogError("openid is nil");
			return;
		}
		ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._QuitBigRoom();
		if (apolloVoiceErr == ApolloVoiceErr.APOLLO_VOICE_SUCC)
		{
			ApolloManager.m_bCreateEngine = true;
			XSingleton<XDebug>.singleton.AddLog(string.Format("QuitBigRoom!", new object[0]), null, null, null, null, null, XDebugColor.XDebug_None);
		}
		else
		{
			string log = string.Format("QuitBigRoom Err is {0}", apolloVoiceErr);
			XSingleton<XDebug>.singleton.AddLog(log, null, null, null, null, null, XDebugColor.XDebug_None);
		}
	}

	public int GetSpeakerVolume()
	{
		if (ApolloManager.ApolloVoiceMgr != null)
		{
			return ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._GetMicLevel();
		}
		return 100;
	}

	public void SetMusicVolum(int nVol)
	{
		if (ApolloManager.ApolloVoiceMgr != null)
		{
			ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._SetSpeakerVolume(nVol);
			if (apolloVoiceErr == ApolloVoiceErr.APOLLO_VOICE_SUCC)
			{
				ApolloManager.m_bCreateEngine = true;
				XSingleton<XDebug>.singleton.AddLog(string.Format("SetMusicVolum Succ {0}", nVol), null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				string log = string.Format("SetMusicVolum Err is {0}", apolloVoiceErr);
				XSingleton<XDebug>.singleton.AddLog(log, null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}
	}

	private void OnApplicationPause(bool pause)
	{
		XSingleton<XDebug>.singleton.AddLog(string.Concat(new object[]
		{
			"apollo puase: ",
			pause,
			" mgr: ",
			ApolloManager.ApolloVoiceMgr != null
		}), null, null, null, null, null, XDebugColor.XDebug_None);
		if (ApolloManager.ApolloVoiceMgr != null)
		{
			if (pause)
			{
				ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._Pause();
				if (apolloVoiceErr == ApolloVoiceErr.APOLLO_VOICE_SUCC)
				{
					ApolloManager.m_bCreateEngine = true;
					XSingleton<XDebug>.singleton.AddLog(string.Format("OnApplicationPause pause true Succ", new object[0]), null, null, null, null, null, XDebugColor.XDebug_None);
				}
				else
				{
					string message = string.Format("OnApplicationPause Err is {0}", apolloVoiceErr);
					Debug.Log(message);
				}
			}
			else
			{
				ApolloVoiceErr apolloVoiceErr2 = (ApolloVoiceErr)ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._Resume();
				if (apolloVoiceErr2 == ApolloVoiceErr.APOLLO_VOICE_SUCC)
				{
					ApolloManager.m_bCreateEngine = true;
					Debug.Log(string.Format("OnApplicationPause pause false Succ", new object[0]));
				}
				else
				{
					string message2 = string.Format("OnApplicationPause Err is {0}", apolloVoiceErr2);
					Debug.Log(message2);
				}
			}
		}
		if (!pause)
		{
			if (!string.IsNullOrEmpty(this.cacheTag))
			{
				this.StartGSDK(this.cacheZoneID, this.cacheTag, this.cacheRoomIP);
			}
		}
		else if (!string.IsNullOrEmpty(this.cacheTag))
		{
			this.EndGSDK();
		}
	}

	public void InitGSDK(string mAppID)
	{
		GSDK.Init(mAppID, false, 1);
	}

	public void SetGSDKEvent(int tag, bool status, string msg)
	{
		GSDK.SetEvent(tag, status, msg);
	}

	public void SetGSDKUserName(int plat, string openid)
	{
		int plat2;
		if (plat == 3)
		{
			plat2 = 2;
		}
		else if (plat == 4)
		{
			plat2 = 1;
		}
		else
		{
			plat2 = 5;
		}
		GSDK.SetUserName(plat2, openid);
	}

	public void StartGSDK(int zoneid, string tag, string roomiP)
	{
		this.cacheZoneID = zoneid;
		this.cacheTag = tag;
		this.cacheRoomIP = roomiP;
		GSDK.Start(zoneid, tag, roomiP);
	}

	public void EndGSDK()
	{
		this.cacheTag = string.Empty;
		GSDK.End();
	}

	public int InitApolloEngine(int ip1, int ip2, int ip3, int ip4, byte[] key, int len)
	{
		ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._SetServiceInfo(ip1, ip2, ip3, ip4, 80, 60000);
		return ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._SetAuthkey(key, len);
	}

	public int StartRecord(string filename)
	{
		string strFullPath = Application.persistentDataPath + "/" + filename;
		return (ApolloManager.ApolloVoiceMgr == null) ? 0 : ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._StartRecord(strFullPath);
	}

	public int StopApolloRecord()
	{
		return (ApolloManager.ApolloVoiceMgr == null) ? 0 : ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._StopRecord(true);
	}

	public int GetApolloUploadStatus()
	{
		return (ApolloManager.ApolloVoiceMgr == null) ? 0 : ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._GetVoiceUploadState();
	}

	public int UploadRecordFile(string filename)
	{
		string text = Application.persistentDataPath + "/" + filename;
		byte[] array = File.ReadAllBytes(text);
		return ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._SendRecFile(text);
	}

	public string GetFileID()
	{
		ApolloVoiceErr apolloVoiceErr = (ApolloVoiceErr)ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._GetVoiceUploadState();
		if (apolloVoiceErr != ApolloVoiceErr.APOLLO_VOICE_SUCC)
		{
			return string.Empty;
		}
		if (ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._GetFileID(ApolloManager.m_strFileID) == 0)
		{
			return Encoding.Default.GetString(ApolloManager.m_strFileID);
		}
		return string.Empty;
	}

	public int GetMicLevel()
	{
		return (ApolloManager.ApolloVoiceMgr == null) ? 0 : ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._GetMicLevel();
	}

	public int StartPlayVoice(string filepath)
	{
		return (ApolloManager.ApolloVoiceMgr == null) ? 0 : ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._PlayFile(filepath);
	}

	public int StopPlayVoice()
	{
		return (ApolloManager.ApolloVoiceMgr == null) ? 0 : ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._StopPlayFile();
	}

	public int SetApolloMode(int mode)
	{
		return (ApolloManager.ApolloVoiceMgr == null) ? 0 : ApolloManager.ApolloVoiceMgr.CallApolloVoiceSDK._SetMode(mode);
	}
}
