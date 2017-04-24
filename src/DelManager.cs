using System;
using UILib;
using UnityEngine;

public class DelManager
{
	public delegate void VoidDelegate();

	public delegate void BoolDelegate(bool state);

	public delegate void StringDelegate(string str);

	public delegate void FloatDelegate(float delta);

	public delegate void VectorDelegate(Vector2 delta);

	public delegate void ObjectDelegate(GameObject obj);

	public delegate void KeyCodeDelegate(KeyCode key);

	public delegate void GameObjDelegate(GameObject go);

	public delegate void BytesDelegate(byte[] bytes);

	public delegate void BtnDelegate(XUIButton btn);

	public delegate void SprDelegate(XUISprite spr);

	public static DelManager.GameObjDelegate onGoClick;

	public static ButtonClickEventHandler fButtonDelegate;

	public static ButtonClickEventHandler sButtonDelegate;

	public static SpriteClickEventHandler sprClickEventHandler;

	public static void Clear()
	{
		DelManager.fButtonDelegate = null;
		DelManager.sButtonDelegate = null;
		DelManager.onGoClick = null;
		DelManager.sprClickEventHandler = null;
	}
}
