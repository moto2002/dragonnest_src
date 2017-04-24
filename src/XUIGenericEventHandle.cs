using System;
using UnityEngine;
using XUtliPoolLib;

public class XUIGenericEventHandle : MonoBehaviour
{
	private IXGameUI m_game_ui;

	private void Awake()
	{
		this.m_game_ui = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXGameUI>(XSingleton<XCommon>.singleton.XHash("XGameUI"));
	}

	private void OnClick()
	{
		this.m_game_ui.OnGenericClick();
	}
}
