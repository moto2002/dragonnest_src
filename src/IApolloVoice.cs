using System;

public interface IApolloVoice
{
	void Init();

	int _CreateApolloVoiceEngine(string appID, string openID = null);

	int _DestoryApolloVoiceEngine();

	int _SetMode(int nMode);

	int _Pause();

	int _Resume();

	int _SetCodec(int mode, int codec);

	int _GetMicLevel();

	int _SetSpeakerVolume(int nVol);

	int _GetSpeakerLevel();

	int _EnableLog(bool bEnable);

	int _TestMic();

	int _EnableCaptureMicrophone(bool bEnable);

	int _CaptureMicrophone(bool bEnable);

	int _JoinRoom(string url1, string url2, string url3, long roomId, long roomKey, short memberId, string OpenId, int nTimeOut);

	int _GetJoinRoomResult();

	int _QuitRoom(long roomId, short memberId, string OpenId);

	int _JoinBigRoom(string urls, int role, uint busniessID, long roomId, long roomKey, short memberId, string OpenId, int nTimeOut);

	int _GetJoinRoomBigResult();

	int _QuitBigRoom();

	int _OpenMic();

	int _CloseMic();

	int _OpenSpeaker();

	int _CloseSpeaker();

	int _GetMemberState(int[] memberState);

	int _SetMemberCount(int nCount);

	int _SetBGMPath(string path);

	int _StartBGMPlay();

	int _StopBGMPlay();

	int _PauseBGMPlay();

	int _ResumeBGMPlay();

	int _GetBGMPlayState();

	int _EnableNativeBGMPlay(bool bEnable);

	int _SetBGMVol(int nvol);

	int _DownMusicFile(string strUrl, string strPath, int nTimeout);

	int _GetDownloadMusicFileState();

	int _QuitDownMusicFile();

	int _StartRecord(string strFullPath);

	int _StopRecord(bool bAutoSend);

	int _GetFileID(byte[] fileKey);

	int _SendRecFile(string strFullPath);

	int _PlayFile(string strFullPath);

	int _DownloadVoiceFile(string strFullPath, string strFileID, bool bAutoPlay);

	int _ForbidMemberVoice(int nMemberId, bool bEnable);

	int _SetServiceInfo(int nIP0, int nIP1, int nIP2, int nIP3, int nPort, int nTimeout);

	int _SetAuthkey(byte[] strAuthkey, int nLength);

	int _GetVoiceDownloadState();

	int _GetVoiceUploadState();

	float _GetOfflineFileTime();

	uint _GetOfflineFileSize();

	int _GetPlayFileState();

	int _StopPlayFile();

	int _SetAudience(int[] audience);

	int _SetSubBID(string strSubBID);

	float _GetLostRate();

	int _SetAnchorUsed(bool bEnable);

	int _EnableSoftAec(bool bEnable);
}
