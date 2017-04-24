using Gamesir;
using System;
using UnityEngine;
using XUtliPoolLib;

public class XGameSirControl : MonoBehaviour, IXGameSirControl
{
	private bool mIsOpen;

	public bool IsOpen
	{
		get
		{
			return this.mIsOpen;
		}
	}

	public void ShowGameSirDialog()
	{
		if (this.mIsOpen)
		{
			GamesirInput.Instance().OpenConnectDialog();
		}
	}

	public int GetGameSirState()
	{
		if (this.mIsOpen)
		{
			return GamesirInput.Instance().GetGameSirState();
		}
		return 0;
	}

	public float GetAxis(string axisName)
	{
		if (this.mIsOpen)
		{
			return GamesirInput.Instance().GetAxis(axisName);
		}
		return 0f;
	}

	public bool GetButton(string buttonName)
	{
		return this.mIsOpen && GamesirInput.Instance().GetButton(buttonName);
	}

	public void Init()
	{
	}

	private void Start()
	{
		GamesirInput.Instance().SetIconLocation(IconLocation.BOTTOM_CENTER);
		GamesirInput.Instance().setHiddenConnectIcon(true);
		GamesirInput.Instance().onStart();
		this.mIsOpen = true;
	}

	public void StartSir()
	{
		if (!this.IsConnected())
		{
			GamesirInput.Instance().AutoConnectToGCM();
		}
	}

	public void StopSir()
	{
		if (this.IsConnected())
		{
			GamesirInput.Instance().DisConnectGCM();
		}
	}

	public bool IsConnected()
	{
		return this.mIsOpen && this.GetGameSirState() == 3;
	}

	private void OnDestroy()
	{
		if (this.mIsOpen)
		{
			GamesirInput.Instance().OnDestory();
		}
	}

	private void OnApplicationQuit()
	{
		if (this.mIsOpen)
		{
			GamesirInput.Instance().OnQuit();
		}
	}
}
