using System;

namespace XUtliPoolLib
{
	public interface IApolloManager
	{
		bool openMusic
		{
			get;
			set;
		}

		bool openSpeak
		{
			get;
			set;
		}

		void Init(int channel, string openid);

		void SetRealtimeMode();

		void ForbitMember(int memberId, bool bEnable);

		void JoinRoom(string url1, string url2, string url3, long roomId, long roomKey, short memberId);

		void JoinBigRoom(string urls, int role, uint busniessID, long roomid, long roomkey, short memberid);

		bool GetJoinRoomResult();

		bool GetJoinRoomBigResult();

		int[] GetMembersState(ref int size);

		void QuitRoom(long roomId, short memberId);

		void QuitBigRoom();

		int GetSpeakerVolume();

		void SetMusicVolum(int nVol);

		void SetGSDKEvent(int tag, bool status, string msg);

		void StartGSDK(int zoneid, string tag, string roomip);

		void EndGSDK();

		int InitApolloEngine(int ip1, int ip2, int ip3, int ip4, byte[] key, int len);

		int StartRecord(string filename);

		int StopApolloRecord();

		int GetApolloUploadStatus();

		int UploadRecordFile(string filename);

		string GetFileID();

		int GetMicLevel();

		int StartPlayVoice(string filepath);

		int StopPlayVoice();

		int SetApolloMode(int mode);
	}
}
