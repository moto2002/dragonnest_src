using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Popup List"), ExecuteInEditMode]
public class UIPopupList : UIWidgetContainer
{
	public enum Position
	{
		Auto,
		Above,
		Below
	}

	public delegate void LegacyEvent(string val);

	private const float animSpeed = 0.15f;

	public static UIPopupList current;

	public UIAtlas atlas;

	public UIFont bitmapFont;

	public Font trueTypeFont;

	public int fontSize = 16;

	public FontStyle fontStyle;

	public string backgroundSprite;

	public string highlightSprite;

	public UIPopupList.Position position;

	public List<string> items = new List<string>();

	public Vector2 padding = new Vector3(4f, 4f);

	public Color textColor = Color.white;

	public Color backgroundColor = Color.white;

	public Color highlightColor = new Color(0.882352948f, 0.784313738f, 0.5882353f, 1f);

	public bool isAnimated = true;

	public bool isLocalized;

	public List<EventDelegate> onChange = new List<EventDelegate>();

	[HideInInspector, SerializeField]
	private string mSelectedItem;

	private UIPanel mPanel;

	private GameObject mChild;

	private UISprite mBackground;

	private UISprite mHighlight;

	private UILabel mHighlightedLabel;

	private List<UILabel> mLabelList = new List<UILabel>();

	private float mBgBorder;

	[HideInInspector, SerializeField]
	private GameObject eventReceiver;

	[HideInInspector, SerializeField]
	private string functionName = "OnSelectionChange";

	[HideInInspector, SerializeField]
	private float textScale;

	[HideInInspector, SerializeField]
	private UIFont font;

	[HideInInspector, SerializeField]
	private UILabel textLabel;

	[NonSerialized]
	private UIKeyNavigation keys;

	[NonSerialized]
	private UILabel currentlbl;

	private UIPopupList.LegacyEvent mLegacyEvent;

	private bool mUseDynamicFont;

	public UnityEngine.Object ambigiousFont
	{
		get
		{
			if (this.trueTypeFont != null)
			{
				return this.trueTypeFont;
			}
			if (this.bitmapFont != null)
			{
				return this.bitmapFont;
			}
			return this.font;
		}
		set
		{
			if (value is Font)
			{
				this.trueTypeFont = (value as Font);
				this.bitmapFont = null;
				this.font = null;
			}
			else if (value is UIFont)
			{
				this.bitmapFont = (value as UIFont);
				this.trueTypeFont = null;
				this.font = null;
			}
		}
	}

	[Obsolete("Use EventDelegate.Add(popup.onChange, YourCallback) instead, and UIPopupList.current.value to determine the state")]
	public UIPopupList.LegacyEvent onSelectionChange
	{
		get
		{
			return this.mLegacyEvent;
		}
		set
		{
			this.mLegacyEvent = value;
		}
	}

	public bool isOpen
	{
		get
		{
			return this.mChild != null;
		}
	}

	public string value
	{
		get
		{
			return this.mSelectedItem;
		}
		set
		{
			this.mSelectedItem = value;
			if (this.mSelectedItem == null)
			{
				return;
			}
			if (this.mSelectedItem != null)
			{
				this.TriggerCallbacks();
			}
		}
	}

	[Obsolete("Use 'value' instead")]
	public string selection
	{
		get
		{
			return this.value;
		}
		set
		{
			this.value = value;
		}
	}

	private bool handleEvents
	{
		get
		{
			return this.keys == null || !this.keys.enabled;
		}
		set
		{
			if (this.keys != null)
			{
				this.keys.enabled = !value;
			}
		}
	}

	private bool isValid
	{
		get
		{
			return this.bitmapFont != null || this.trueTypeFont != null;
		}
	}

	private int activeFontSize
	{
		get
		{
			return (!(this.trueTypeFont != null) && !(this.bitmapFont == null)) ? this.bitmapFont.defaultSize : this.fontSize;
		}
	}

	private float activeFontScale
	{
		get
		{
			return (!(this.trueTypeFont != null) && !(this.bitmapFont == null)) ? ((float)this.fontSize / (float)this.bitmapFont.defaultSize) : 1f;
		}
	}

	protected void TriggerCallbacks()
	{
		if (UIPopupList.current != this)
		{
			UIPopupList uIPopupList = UIPopupList.current;
			UIPopupList.current = this;
			if (this.mLegacyEvent != null)
			{
				this.mLegacyEvent(this.mSelectedItem);
			}
			if (EventDelegate.IsValid(this.onChange))
			{
				EventDelegate.Execute(this.onChange);
			}
			else if (this.eventReceiver != null && !string.IsNullOrEmpty(this.functionName))
			{
				this.eventReceiver.SendMessage(this.functionName, this.mSelectedItem, SendMessageOptions.DontRequireReceiver);
			}
			UIPopupList.current = uIPopupList;
		}
	}

	private void OnEnable()
	{
		if (EventDelegate.IsValid(this.onChange))
		{
			this.eventReceiver = null;
			this.functionName = null;
		}
		if (this.font != null)
		{
			if (this.font.isDynamic)
			{
				this.trueTypeFont = this.font.dynamicFont;
				this.fontStyle = this.font.dynamicFontStyle;
				this.mUseDynamicFont = true;
			}
			else if (this.bitmapFont == null)
			{
				this.bitmapFont = this.font;
				this.mUseDynamicFont = false;
			}
			this.font = null;
		}
		if (this.textScale != 0f)
		{
			this.fontSize = ((!(this.bitmapFont != null)) ? 16 : Mathf.RoundToInt((float)this.bitmapFont.defaultSize * this.textScale));
			this.textScale = 0f;
		}
		if (this.trueTypeFont == null && this.bitmapFont != null && this.bitmapFont.isDynamic)
		{
			this.trueTypeFont = this.bitmapFont.dynamicFont;
			this.bitmapFont = null;
		}
	}

	private void OnValidate()
	{
		Font x = this.trueTypeFont;
		UIFont uIFont = this.bitmapFont;
		this.bitmapFont = null;
		this.trueTypeFont = null;
		if (x != null && (uIFont == null || !this.mUseDynamicFont))
		{
			this.bitmapFont = null;
			this.trueTypeFont = x;
			this.mUseDynamicFont = true;
		}
		else if (uIFont != null)
		{
			if (uIFont.isDynamic)
			{
				this.trueTypeFont = uIFont.dynamicFont;
				this.fontStyle = uIFont.dynamicFontStyle;
				this.fontSize = uIFont.defaultSize;
				this.mUseDynamicFont = true;
			}
			else
			{
				this.bitmapFont = uIFont;
				this.mUseDynamicFont = false;
			}
		}
		else
		{
			this.trueTypeFont = x;
			this.mUseDynamicFont = true;
		}
	}

	private void Start()
	{
		if (this.textLabel != null)
		{
			EventDelegate.Add(this.onChange, new EventDelegate.Callback(this.textLabel.SetCurrentSelection));
			this.textLabel = null;
		}
		if (Application.isPlaying)
		{
			if (string.IsNullOrEmpty(this.mSelectedItem))
			{
				if (this.items.Count > 0)
				{
					this.value = this.items[0];
				}
			}
			else
			{
				string value = this.mSelectedItem;
				this.mSelectedItem = null;
				this.value = value;
			}
		}
		this.keys = base.GetComponent<UIKeyNavigation>();
		this.currentlbl = base.GetComponent<UILabel>();
	}

	private void OnLocalize()
	{
		if (this.isLocalized)
		{
			this.TriggerCallbacks();
		}
	}

	private void Highlight(UILabel lbl, bool instant)
	{
		if (this.mHighlight != null)
		{
			TweenPosition component = lbl.GetComponent<TweenPosition>();
			if (component != null && component.enabled)
			{
				return;
			}
			this.mHighlightedLabel = lbl;
			UISpriteData atlasSprite = this.mHighlight.GetAtlasSprite();
			if (atlasSprite == null)
			{
				return;
			}
			float pixelSize = this.atlas.pixelSize;
			float num = (float)atlasSprite.borderLeft * pixelSize;
			float y = (float)atlasSprite.borderTop * pixelSize;
			Vector3 vector = lbl.cachedTransform.localPosition + new Vector3(-num, y, 1f);
			if (instant || !this.isAnimated)
			{
				this.mHighlight.cachedTransform.localPosition = vector;
			}
			else
			{
				TweenPosition.Begin(this.mHighlight.gameObject, 0.1f, vector).method = UITweener.Method.EaseOut;
			}
		}
	}

	private void OnItemHover(GameObject go, bool isOver)
	{
		if (isOver)
		{
			this.Highlight(this.currentlbl, false);
		}
	}

	private void Select(UILabel lbl, bool instant)
	{
		this.Highlight(lbl, instant);
		UIEventListener component = lbl.gameObject.GetComponent<UIEventListener>();
		this.value = (component.parameter as string);
		UIPlaySound[] components = base.GetComponents<UIPlaySound>();
		int i = 0;
		int num = components.Length;
		while (i < num)
		{
			UIPlaySound uIPlaySound = components[i];
			if (uIPlaySound.trigger == UIPlaySound.Trigger.OnClick)
			{
				NGUITools.PlaySound(uIPlaySound.audioClip, uIPlaySound.volume, 1f);
			}
			i++;
		}
	}

	private void OnItemPress(GameObject go, bool isPressed)
	{
		if (isPressed)
		{
			this.Select(go.GetComponent<UILabel>(), true);
		}
	}

	private void OnKey(KeyCode key)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.handleEvents)
		{
			int num = this.mLabelList.IndexOf(this.mHighlightedLabel);
			if (num == -1)
			{
				num = 0;
			}
			if (key == KeyCode.UpArrow)
			{
				if (num > 0)
				{
					this.Select(this.mLabelList[num - 1], false);
				}
			}
			else if (key == KeyCode.DownArrow)
			{
				if (num + 1 < this.mLabelList.Count)
				{
					this.Select(this.mLabelList[num + 1], false);
				}
			}
			else if (key == KeyCode.Escape)
			{
				this.OnSelect(false);
			}
		}
	}

	private void OnSelect(bool isSelected)
	{
		if (!isSelected)
		{
			this.Close();
		}
	}

	public void Close()
	{
		if (this.mChild != null)
		{
			this.mLabelList.Clear();
			this.handleEvents = false;
			if (this.isAnimated)
			{
				UIWidget[] componentsInChildren = this.mChild.GetComponentsInChildren<UIWidget>();
				int i = 0;
				int num = componentsInChildren.Length;
				while (i < num)
				{
					UIWidget uIWidget = componentsInChildren[i];
					Color color = uIWidget.color;
					color.a = 0f;
					TweenColor.Begin(uIWidget.gameObject, 0.15f, color).method = UITweener.Method.EaseOut;
					i++;
				}
				Collider[] componentsInChildren2 = this.mChild.GetComponentsInChildren<Collider>();
				int j = 0;
				int num2 = componentsInChildren2.Length;
				while (j < num2)
				{
					componentsInChildren2[j].enabled = false;
					j++;
				}
				UnityEngine.Object.Destroy(this.mChild, 0.15f);
			}
			else
			{
				UnityEngine.Object.Destroy(this.mChild);
			}
			this.mBackground = null;
			this.mHighlight = null;
			this.mChild = null;
		}
	}

	private void AnimateColor(UIWidget widget)
	{
		Color color = widget.color;
		widget.color = new Color(color.r, color.g, color.b, 0f);
		TweenColor.Begin(widget.gameObject, 0.15f, color).method = UITweener.Method.EaseOut;
	}

	private void AnimatePosition(UIWidget widget, bool placeAbove, float bottom)
	{
		Vector3 localPosition = widget.cachedTransform.localPosition;
		Vector3 localPosition2 = (!placeAbove) ? new Vector3(localPosition.x, 0f, localPosition.z) : new Vector3(localPosition.x, bottom, localPosition.z);
		widget.cachedTransform.localPosition = localPosition2;
		GameObject gameObject = widget.gameObject;
		TweenPosition.Begin(gameObject, 0.15f, localPosition).method = UITweener.Method.EaseOut;
	}

	private void AnimateScale(UIWidget widget, bool placeAbove, float bottom)
	{
		GameObject gameObject = widget.gameObject;
		Transform cachedTransform = widget.cachedTransform;
		float num = (float)this.activeFontSize * this.activeFontScale + this.mBgBorder * 2f;
		cachedTransform.localScale = new Vector3(1f, num / (float)widget.height, 1f);
		TweenScale.Begin(gameObject, 0.15f, Vector3.one).method = UITweener.Method.EaseOut;
		if (placeAbove)
		{
			Vector3 localPosition = cachedTransform.localPosition;
			cachedTransform.localPosition = new Vector3(localPosition.x, localPosition.y - (float)widget.height + num, localPosition.z);
			TweenPosition.Begin(gameObject, 0.15f, localPosition).method = UITweener.Method.EaseOut;
		}
	}

	private void Animate(UIWidget widget, bool placeAbove, float bottom)
	{
		this.AnimateColor(widget);
		this.AnimatePosition(widget, placeAbove, bottom);
	}

	private void OnClick()
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.mChild == null && this.atlas != null && this.isValid && this.items.Count > 0)
		{
			this.mLabelList.Clear();
			if (this.mPanel == null)
			{
				this.mPanel = UIPanel.Find(base.transform);
				if (this.mPanel == null)
				{
					return;
				}
			}
			this.handleEvents = true;
			Transform transform = base.transform;
			Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(transform.parent, transform);
			this.mChild = new GameObject("Drop-down List");
			this.mChild.layer = base.gameObject.layer;
			Transform transform2 = this.mChild.transform;
			transform2.parent = transform.parent;
			transform2.localPosition = bounds.min;
			transform2.localRotation = Quaternion.identity;
			transform2.localScale = Vector3.one;
			this.mBackground = NGUITools.AddSprite(this.mChild, this.atlas, this.backgroundSprite);
			this.mBackground.pivot = UIWidget.Pivot.TopLeft;
			this.mBackground.depth = NGUITools.CalculateNextDepth(this.mPanel.gameObject);
			this.mBackground.color = this.backgroundColor;
			Vector4 border = this.mBackground.border;
			this.mBgBorder = border.y;
			this.mBackground.cachedTransform.localPosition = new Vector3(0f, border.y, 0f);
			this.mHighlight = NGUITools.AddSprite(this.mChild, this.atlas, this.highlightSprite);
			this.mHighlight.pivot = UIWidget.Pivot.TopLeft;
			this.mHighlight.color = this.highlightColor;
			UISpriteData atlasSprite = this.mHighlight.GetAtlasSprite();
			if (atlasSprite == null)
			{
				return;
			}
			float num = (float)atlasSprite.borderTop;
			float num2 = (float)this.activeFontSize;
			float activeFontScale = this.activeFontScale;
			float num3 = num2 * activeFontScale;
			float num4 = 0f;
			float num5 = -this.padding.y;
			int num6 = (!(this.bitmapFont != null)) ? this.fontSize : this.bitmapFont.defaultSize;
			List<UILabel> list = new List<UILabel>();
			int i = 0;
			int count = this.items.Count;
			while (i < count)
			{
				string text = this.items[i];
				UILabel uILabel = NGUITools.AddWidget<UILabel>(this.mChild);
				uILabel.pivot = UIWidget.Pivot.TopLeft;
				uILabel.bitmapFont = this.bitmapFont;
				uILabel.trueTypeFont = this.trueTypeFont;
				uILabel.fontSize = num6;
				uILabel.fontStyle = this.fontStyle;
				uILabel.text = ((!this.isLocalized) ? text : Localization.Get(text));
				uILabel.color = this.textColor;
				uILabel.cachedTransform.localPosition = new Vector3(border.x + this.padding.x, num5, 0f);
				uILabel.overflowMethod = UILabel.Overflow.ResizeFreely;
				uILabel.MakePixelPerfect();
				if (activeFontScale != 1f)
				{
					uILabel.cachedTransform.localScale = Vector3.one * activeFontScale;
				}
				list.Add(uILabel);
				num5 -= num3;
				num5 -= this.padding.y;
				num4 = Mathf.Max(num4, uILabel.printedSize.x);
				UIEventListener uIEventListener = UIEventListener.Get(uILabel.gameObject);
				uIEventListener.onHover = new UIEventListener.BoolDelegate(this.OnItemHover);
				uIEventListener.onPress = new UIEventListener.BoolDelegate(this.OnItemPress);
				uIEventListener.parameter = text;
				if (this.mSelectedItem == text || (i == 0 && string.IsNullOrEmpty(this.mSelectedItem)))
				{
					this.Highlight(uILabel, true);
				}
				this.mLabelList.Add(uILabel);
				i++;
			}
			num4 = Mathf.Max(num4, bounds.size.x * activeFontScale - (border.x + this.padding.x) * 2f);
			float num7 = num4 / activeFontScale;
			Vector3 center = new Vector3(num7 * 0.5f, -num2 * 0.5f, 0f);
			Vector3 size = new Vector3(num7, (num3 + this.padding.y) / activeFontScale, 1f);
			int j = 0;
			int count2 = list.Count;
			while (j < count2)
			{
				UILabel uILabel2 = list[j];
				BoxCollider boxCollider = NGUITools.AddWidgetCollider(uILabel2.gameObject);
				center.z = boxCollider.center.z;
				boxCollider.center = center;
				boxCollider.size = size;
				j++;
			}
			num4 += (border.x + this.padding.x) * 2f;
			num5 -= border.y;
			this.mBackground.width = Mathf.RoundToInt(num4);
			this.mBackground.height = Mathf.RoundToInt(-num5 + border.y);
			float num8 = 2f * this.atlas.pixelSize;
			float f = num4 - (border.x + this.padding.x) * 2f + (float)atlasSprite.borderLeft * num8;
			float f2 = num3 + num * num8;
			this.mHighlight.width = Mathf.RoundToInt(f);
			this.mHighlight.height = Mathf.RoundToInt(f2);
			bool flag = this.position == UIPopupList.Position.Above;
			if (this.position == UIPopupList.Position.Auto)
			{
				UICamera uICamera = UICamera.FindCameraForLayer(base.gameObject.layer);
				if (uICamera != null)
				{
					flag = (uICamera.cachedCamera.WorldToViewportPoint(transform.position).y < 0.5f);
				}
			}
			if (this.isAnimated)
			{
				float bottom = num5 + num3;
				this.Animate(this.mHighlight, flag, bottom);
				int k = 0;
				int count3 = list.Count;
				while (k < count3)
				{
					this.Animate(list[k], flag, bottom);
					k++;
				}
				this.AnimateColor(this.mBackground);
				this.AnimateScale(this.mBackground, flag, bottom);
			}
			if (flag)
			{
				transform2.localPosition = new Vector3(bounds.min.x, bounds.max.y - num5 - border.y, bounds.min.z);
			}
		}
		else
		{
			this.OnSelect(false);
		}
	}
}
