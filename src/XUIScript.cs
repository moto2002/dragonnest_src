using System;
using UnityEngine;
using XUtliPoolLib;

public class XUIScript : MonoBehaviour
{
	private IXGameUI _game_ui;

	private void Awake()
	{
		this._game_ui = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXGameUI>(XSingleton<XCommon>.singleton.XHash("XGameUI"));
		this._game_ui.UICamera = base.gameObject.GetComponent<Camera>();
		Transform parent = base.transform.parent;
		this._game_ui.UIRoot = parent;
		UIRoot component = parent.GetComponent<UIRoot>();
		this._game_ui.Base_UI_Width = component.base_ui_width;
		this._game_ui.Base_UI_Height = component.base_ui_height;
		XSingleton<XUICommon>.singleton.Init(parent);
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
