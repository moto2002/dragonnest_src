using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public class ApolloVoice_lib : IApolloVoice
{
	private static bool bInit;

	private static AndroidJavaClass mApolloVoice;

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceCreateEngine([MarshalAs(UnmanagedType.LPArray)] string appID, [MarshalAs(UnmanagedType.LPArray)] string openID);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceDestoryEngine();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceJoinRoom([MarshalAs(UnmanagedType.LPArray)] string url1, [MarshalAs(UnmanagedType.LPArray)] string url2, [MarshalAs(UnmanagedType.LPArray)] string url3, long roomId, long roomKey, short memberId, [MarshalAs(UnmanagedType.LPArray)] string openId, int nTimeOut);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceGetJoinRoomResult();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceQuitRoom(long roomId, short memberId, [MarshalAs(UnmanagedType.LPArray)] byte[] OpenId);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceOpenMic();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceCloseMic();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceOpenSpeaker();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceCloseSpeaker();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoicePause();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceResume();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceGetMemberState(int[] memberState, int nSize);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceSetMemberCount(int nCount);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceStartRecord([MarshalAs(UnmanagedType.LPArray)] string strFullPath);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceStopRecord(bool bAutoSend);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceGetFileID([MarshalAs(UnmanagedType.LPArray)] byte[] filekey, int nSize);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceSendRecFile([MarshalAs(UnmanagedType.LPArray)] string strFullPath);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceDownloadFile([MarshalAs(UnmanagedType.LPArray)] string strFullPath, [MarshalAs(UnmanagedType.LPArray)] string strFileID, bool bAutoPlay);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoicePlayFile([MarshalAs(UnmanagedType.LPArray)] string strFullPath);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceForbidMemberVoice(int nMemberId, bool bEnable);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceSetMode(int nMode);

	[DllImport("apollo_voice")]
	private static extern int ApolloGetMicLevel();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceSetSpeakerVolume(int nvol);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceGetPhoneMode();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceGetSpeakerLevel();

	[DllImport("apollo_voice")]
	private static extern uint ApolloVoiceGetOfflineFileSize();

	[DllImport("apollo_voice")]
	private static extern float ApolloVoiceGetOfflineFileTime();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceJoinBigRoom([MarshalAs(UnmanagedType.LPArray)] string urls, int role, uint businessID, long roomId, long roomKey, short memberId, [MarshalAs(UnmanagedType.LPArray)] string openId, int nTimeOut);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceGetJoinBigRoomResult();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceQuitBigRoom();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceSetAudience([MarshalAs(UnmanagedType.LPArray)] int[] audience, int count);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceSetBGMPath([MarshalAs(UnmanagedType.LPArray)] string path);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceStartBGMPlay();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceStopBGMPlay();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoicePauseBGMPlay();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceResumeBGMPlay();

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceEnableNativeBGMPlay(bool bEnable);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceSetBGMVol(int nvol);

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceGetBGMPlayState();

	public void Init()
	{
	}

	public int _CreateApolloVoiceEngine(string appID, string openID)
	{
		int num = ApolloVoice_lib.ApolloVoiceCreateEngine(appID, openID);
		if (num == 0)
		{
			ApolloVoice_lib.bInit = true;
		}
		return num;
	}

	public int _DestoryApolloVoiceEngine()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		ApolloVoice_lib.bInit = false;
		int num = ApolloVoice_lib.ApolloVoiceDestoryEngine();
		if (num == 0)
		{
			return 0;
		}
		return num;
	}

	public int _JoinRoom(string url1, string url2, string url3, long roomId, long roomKey, short memberId, string OpenId, int nTimeOut)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		int num = ApolloVoice_lib.ApolloVoiceJoinRoom(url1, url2, url3, roomId, roomKey, memberId, OpenId, nTimeOut);
		if (num == 0)
		{
			return 0;
		}
		return num;
	}

	public int _JoinBigRoom(string urls, int role, uint busniessID, long roomId, long roomKey, short memberId, string OpenId, int nTimeOut)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		int num = ApolloVoice_lib.ApolloVoiceJoinBigRoom(urls, role, busniessID, roomId, roomKey, memberId, OpenId, nTimeOut);
		if (num == 0)
		{
			return 0;
		}
		return num;
	}

	public int _GetJoinRoomBigResult()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceGetJoinBigRoomResult();
	}

	public int _QuitBigRoom()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceQuitBigRoom();
	}

	public int _GetJoinRoomResult()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceGetJoinRoomResult();
	}

	public int _QuitRoom(long roomId, short memberId, string OpenId)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		byte[] bytes = Encoding.ASCII.GetBytes(OpenId);
		int num = ApolloVoice_lib.ApolloVoiceQuitRoom(roomId, memberId, bytes);
		if (num == 0)
		{
			return 0;
		}
		return num;
	}

	public int _OpenMic()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		int num = ApolloVoice_lib.ApolloVoiceOpenMic();
		if (num == 0)
		{
			return 0;
		}
		return num;
	}

	public int _CloseMic()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		int num = ApolloVoice_lib.ApolloVoiceCloseMic();
		if (num == 0)
		{
			return 0;
		}
		return num;
	}

	public int _OpenSpeaker()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		int num = ApolloVoice_lib.ApolloVoiceOpenSpeaker();
		if (num == 0)
		{
			return 0;
		}
		return num;
	}

	public int _CloseSpeaker()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		int num = ApolloVoice_lib.ApolloVoiceCloseSpeaker();
		if (num == 0)
		{
			return 0;
		}
		return num;
	}

	public int _Resume()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		int num = ApolloVoice_lib.ApolloVoiceResume();
		if (num == 0)
		{
			return 0;
		}
		return num;
	}

	public int _Pause()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		int num = ApolloVoice_lib.ApolloVoicePause();
		if (num == 0)
		{
			return 0;
		}
		return num;
	}

	public int _GetMemberState(int[] memberState)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		int nSize = memberState.Length;
		int num = ApolloVoice_lib.ApolloVoiceGetMemberState(memberState, nSize);
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
			}
		}
		return num;
	}

	public int _StartRecord(string strFullPath)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceStartRecord(strFullPath);
	}

	public int _StopRecord(bool bAutoSend)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceStopRecord(bAutoSend);
	}

	public int _SetMemberCount(int nCount)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceSetMemberCount(nCount);
	}

	public int _GetFileID(byte[] fileKey)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		int nSize = fileKey.Length;
		return ApolloVoice_lib.ApolloVoiceGetFileID(fileKey, nSize);
	}

	public int _SendRecFile(string strFullPath)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceSendRecFile(strFullPath);
	}

	public int _PlayFile(string strFullPath)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoicePlayFile(strFullPath);
	}

	public int _DownloadVoiceFile(string strFullPath, string strFileID, bool bAutoPlay)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceDownloadFile(strFullPath, strFileID, bAutoPlay);
	}

	public int _ForbidMemberVoice(int nMemberId, bool bEnable)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceForbidMemberVoice(nMemberId, bEnable);
	}

	public int _SetMode(int nMode)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceSetMode(nMode);
	}

	public int _GetMicLevel()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloGetMicLevel();
	}

	public int _SetSpeakerVolume(int nVol)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceSetSpeakerVolume(nVol);
	}

	public int _GetSpeakerLevel()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceGetSpeakerLevel();
	}

	public uint _GetOfflineFileSize()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 0u;
		}
		return ApolloVoice_lib.ApolloVoiceGetOfflineFileSize();
	}

	public float _GetOfflineFileTime()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 0f;
		}
		return ApolloVoice_lib.ApolloVoiceGetOfflineFileTime();
	}

	public int _SetBGMPath(string path)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceSetBGMPath(path);
	}

	public int _StartBGMPlay()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceStartBGMPlay();
	}

	public int _StopBGMPlay()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceStopBGMPlay();
	}

	public int _PauseBGMPlay()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoicePauseBGMPlay();
	}

	public int _ResumeBGMPlay()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceResumeBGMPlay();
	}

	public int _EnableNativeBGMPlay(bool bEnable)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceEnableNativeBGMPlay(bEnable);
	}

	public int _SetBGMVol(int nvol)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceSetBGMVol(nvol);
	}

	public int _GetBGMPlayState()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceGetBGMPlayState();
	}

	public int _SetAudience(int[] audience)
	{
		return ApolloVoice_lib.ApolloVoiceSetAudience(audience, audience.Length);
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceSetServiceInfo(int nIP0, int nIP1, int nIP2, int nIP3, int nPort, int nTimeout);

	public int _SetServiceInfo(int nIP0, int nIP1, int nIP2, int nIP3, int nPort, int nTimeout)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceSetServiceInfo(nIP0, nIP1, nIP2, nIP3, nPort, nTimeout);
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceSetAuthkey([MarshalAs(UnmanagedType.LPArray)] byte[] strAuthkey, int nLength);

	public int _SetAuthkey(byte[] strAuthkey, int nLength)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceSetAuthkey(strAuthkey, nLength);
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceGetDownloadState();

	public int _GetVoiceDownloadState()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceGetDownloadState();
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceGetUploadState();

	public int _GetVoiceUploadState()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceGetUploadState();
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceTestMic();

	public int _TestMic()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 0;
		}
		return ApolloVoice_lib.ApolloVoiceTestMic();
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceGetPlayFileState();

	public int _GetPlayFileState()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceGetPlayFileState();
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceStopPlayFile();

	public int _StopPlayFile()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceStopPlayFile();
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceSetSubBID([MarshalAs(UnmanagedType.LPArray)] string cszSubBID, int nLength);

	public int _SetSubBID(string strSubBID)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceSetSubBID(strSubBID, strSubBID.Length);
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceEncodeWAVFileForPESQ([MarshalAs(UnmanagedType.LPArray)] string strSrcFile, [MarshalAs(UnmanagedType.LPArray)] string strDstFile);

	public int _EncodeWAVFile(string strSrcFile, string strDstFile)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceEncodeWAVFileForPESQ(strSrcFile, strDstFile);
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceDecodeToWAVEFile([MarshalAs(UnmanagedType.LPArray)] string strSrcFile, [MarshalAs(UnmanagedType.LPArray)] string strDstFile);

	public int _DecodeWAVFile(string strSrcFile, string strDstFile)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceDecodeToWAVEFile(strSrcFile, strDstFile);
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceGetWAVEFileProcessedState();

	public int _GetWAVEFileProcessedState()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceGetWAVEFileProcessedState();
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceEnableLog(bool bEnable);

	public int _EnableLog(bool bEnable)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceEnableLog(bEnable);
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceSetCodec(int mode, int codec);

	public int _SetCodec(int mode, int codec)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceSetCodec(mode, codec);
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceDownloadMusicFile([MarshalAs(UnmanagedType.LPArray)] string strUrl, [MarshalAs(UnmanagedType.LPArray)] string strPath, int nTimeout);

	public int _DownMusicFile(string strUrl, string strPath, int nTimeout)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceDownloadMusicFile(strUrl, strPath, nTimeout);
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceGetDownloadMusicFileState();

	public int _GetDownloadMusicFileState()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceGetDownloadMusicFileState();
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVocieSetAnchorUsed(bool bEnable);

	public int _SetAnchorUsed(bool bEnable)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVocieSetAnchorUsed(bEnable);
	}

	[DllImport("apollo_voice")]
	private static extern float ApolloVoiceGetLostRate();

	public float _GetLostRate()
	{
		return ApolloVoice_lib.ApolloVoiceGetLostRate();
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceEnableCaptureMicrophone(bool bEnable);

	public int _EnableCaptureMicrophone(bool bEnable)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceEnableCaptureMicrophone(bEnable);
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceQuitDownloadMusicFile();

	public int _QuitDownMusicFile()
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceQuitDownloadMusicFile();
	}

	[Conditional("DEBUG_VOICE")]
	private void ApolloVoiceLog(string logStr)
	{
		UnityEngine.Debug.Log(logStr);
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceCaptureMicrophone(bool bEnable);

	public int _CaptureMicrophone(bool bEnable)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceCaptureMicrophone(bEnable);
	}

	[DllImport("apollo_voice")]
	private static extern int ApolloVoiceEnableSoftAec(bool bEnable);

	public int _EnableSoftAec(bool bEnable)
	{
		if (!ApolloVoice_lib.bInit)
		{
			return 4;
		}
		return ApolloVoice_lib.ApolloVoiceEnableSoftAec(bEnable);
	}
}
