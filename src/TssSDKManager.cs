using System;
using System.Runtime.InteropServices;
using UnityEngine;
using XUtliPoolLib;

public class TssSDKManager : MonoBehaviour, ITssSdk
{
	public static TssSDKManager sington;

	public readonly uint gameId = 2601u;

	public new readonly string tag = "TssSDKManager=>";

	public readonly uint sync = 2u;

	private bool isLogin;

	private float m_last;

	private void Awake()
	{
		TssSDKManager.sington = this;
	}

	private void Start()
	{
		Debug.Log(this.tag + " Tss init");
		TssSdk.TssSdkInit(this.gameId);
		this.m_last = Time.time;
	}

	private void OnDestroy()
	{
		TssSDKManager.sington = null;
	}

	private void Update()
	{
		if (this.isLogin && Time.time - this.m_last > this.sync)
		{
			this.m_last = Time.time;
			this.StartSendDataToSvr();
		}
	}

	public void OnLogin(int platf, string openId, uint worldId, string roleId)
	{
		this.isLogin = true;
		Debug.Log(string.Concat(new object[]
		{
			this.tag,
			" plat: ",
			platf,
			"openid:",
			openId,
			" worldid: ",
			worldId,
			" roleid: ",
			roleId
		}));
		if (platf == 3)
		{
			TssSdk.TssSdkSetUserInfoEx(TssSdk.EENTRYID.ENTRY_ID_QQ, openId, "1105309683", worldId, roleId);
		}
		else if (platf == 4)
		{
			TssSdk.TssSdkSetUserInfoEx(TssSdk.EENTRYID.ENTRY_ID_MM, openId, "wxfdab5af74990787a", worldId, roleId);
		}
		else
		{
			TssSdk.TssSdkSetUserInfoEx(TssSdk.EENTRYID.ENTRY_ID_OTHERS, openId, "guest100023", worldId, roleId);
		}
	}

	private void OnApplicationPause(bool pause)
	{
		Debug.Log(this.tag + " puase: " + pause);
		if (pause)
		{
			TssSdk.TssSdkSetGameStatus(TssSdk.EGAMESTATUS.GAME_STATUS_BACKEND);
		}
		else
		{
			TssSdk.TssSdkSetGameStatus(TssSdk.EGAMESTATUS.GAME_STATUS_FRONTEND);
		}
	}

	public void StartSendDataToSvr()
	{
		IntPtr intPtr = TssSdk.tss_get_report_data();
		if (intPtr != IntPtr.Zero)
		{
			TssSdk.AntiDataInfo antiDataInfo = new TssSdk.AntiDataInfo();
			if (TssSdk.Is64bit())
			{
				short num = Marshal.ReadInt16(intPtr, 0);
				long value = Marshal.ReadInt64(intPtr, 2);
				antiDataInfo.anti_data_len = (ushort)num;
				antiDataInfo.anti_data = new IntPtr(value);
			}
			else if (TssSdk.Is32bit())
			{
				short num2 = Marshal.ReadInt16(intPtr, 0);
				long value2 = (long)Marshal.ReadInt32(intPtr, 2);
				antiDataInfo.anti_data_len = (ushort)num2;
				antiDataInfo.anti_data = new IntPtr(value2);
			}
			else
			{
				Debug.LogError(this.tag + " TSSSDK NO INT TYPE");
			}
			if (this.SendDataToSvr(antiDataInfo))
			{
				TssSdk.tss_del_report_data(intPtr);
			}
		}
	}

	private bool SendDataToSvr(TssSdk.AntiDataInfo info)
	{
		byte[] array = new byte[(int)info.anti_data_len];
		Marshal.Copy(info.anti_data, array, 0, (int)info.anti_data_len);
		return this.DoSendDataToSvr(array, (uint)info.anti_data_len);
	}

	private bool DoSendDataToSvr(byte[] data, uint length)
	{
		Hotfix.PrintBytes("Send " + this.tag, data);
		ITssSdkSend @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<ITssSdkSend>(XSingleton<XCommon>.singleton.XHash("ITssSdkSend"));
		if (@interface != null)
		{
			@interface.SendDataToServer(data, length);
		}
		return true;
	}

	public void OnRcvWhichNeedToSendClientSdk(byte[] data, uint length)
	{
		Hotfix.PrintBytes("RCV " + this.tag, data);
		TssSdk.TssSdkRcvAntiData(data, (ushort)length);
	}
}
