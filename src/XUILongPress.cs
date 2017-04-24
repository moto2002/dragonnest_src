using System;
using UILib;
using UnityEngine;

public class XUILongPress : XUIObject, IXUIObject, IXUILongPress
{
	private SpriteClickEventHandler m_spriteLongPressEventHandler;

	private XUISprite m_XUISprite;

	private static readonly float _longClickDuration = 0.5f;

	private float _lastPress = -1f;

	private bool bPressed;

	public void RegisterSpriteLongPressEventHandler(SpriteClickEventHandler eventHandler)
	{
		if (eventHandler != null)
		{
			UIEventListener expr_11 = UIEventListener.Get(base.gameObject);
			expr_11.onPress = (UIEventListener.BoolDelegate)Delegate.Remove(expr_11.onPress, new UIEventListener.BoolDelegate(this.OnSpritePress));
			UIEventListener expr_3D = UIEventListener.Get(base.gameObject);
			expr_3D.onPress = (UIEventListener.BoolDelegate)Delegate.Combine(expr_3D.onPress, new UIEventListener.BoolDelegate(this.OnSpritePress));
			UIEventListener expr_69 = UIEventListener.Get(base.gameObject);
			expr_69.onDrag = (UIEventListener.VectorDelegate)Delegate.Remove(expr_69.onDrag, new UIEventListener.VectorDelegate(this.OnSpriteDrag));
			UIEventListener expr_95 = UIEventListener.Get(base.gameObject);
			expr_95.onDrag = (UIEventListener.VectorDelegate)Delegate.Combine(expr_95.onDrag, new UIEventListener.VectorDelegate(this.OnSpriteDrag));
		}
		this.m_spriteLongPressEventHandler = eventHandler;
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_XUISprite = base.GetComponent<XUISprite>();
		if (null == this.m_XUISprite)
		{
			Debug.LogError("null == XUISprite, " + base.gameObject.name);
		}
	}

	private void Update()
	{
		if (this.m_spriteLongPressEventHandler != null && this._lastPress > 0f && Time.time - this._lastPress > XUILongPress._longClickDuration)
		{
			this.m_spriteLongPressEventHandler(this.m_XUISprite);
			this._lastPress = -1f;
			this.bPressed = false;
			this.m_XUISprite.ClickCanceled = true;
		}
	}

	private void OnSpritePress(GameObject button, bool isPressed)
	{
		if (this.m_spriteLongPressEventHandler != null)
		{
			if (isPressed)
			{
				this._lastPress = Time.time;
				this.bPressed = true;
			}
			if (!isPressed)
			{
				this._lastPress = -1f;
			}
		}
	}

	private void OnSpriteDrag(GameObject button, Vector2 delta)
	{
		if (this.m_spriteLongPressEventHandler != null && this._lastPress > 0f)
		{
			this.bPressed = false;
			this._lastPress = -1f;
		}
	}
}
