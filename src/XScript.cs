using System;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

public class XScript : MonoBehaviour
{
	private IGameSysMgr m_GameSysMgr;

	public IGameSysMgr GameSysMgr
	{
		get
		{
			if (this.m_GameSysMgr == null || this.m_GameSysMgr.Deprecated)
			{
				this.m_GameSysMgr = XSingleton<XInterfaceMgr>.singleton.GetInterface<IGameSysMgr>(XSingleton<XCommon>.singleton.XHash("IGameSysMgr"));
			}
			return this.m_GameSysMgr;
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
		XSingleton<XShell>.singleton.Awake();
		XSingleton<XShell>.singleton.Start();
		XSingleton<XResourceLoaderMgr>.singleton.SetUnloadCallback(new BeforeUnityUnLoadResource(this.BeforeUnityUnloadResource));
	}

	private void Update()
	{
		XSingleton<XShell>.singleton.Update();
	}

	private void LateUpdate()
	{
		XSingleton<XShell>.singleton.PostUpdate();
	}

	private void OnApplicationQuit()
	{
		XSingleton<XShell>.singleton.Quit();
	}

	private void BeforeUnityUnloadResource()
	{
		FastList<Vector3>.ms_Pool.Clear();
		FastList<Vector2>.ms_Pool.Clear();
		FastList<Color32>.ms_Pool.Clear();
	}

	private void OnApplicationPause(bool pause)
	{
		if (this.GameSysMgr != null)
		{
			this.GameSysMgr.GamePause(pause);
		}
	}
}
