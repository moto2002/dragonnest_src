using System;
using System.Collections.Generic;
using System.Text;
using UILib;
using UnityEngine;
using XUtliPoolLib;

public class XUILabelSymbol : XUIObject, IXUIObject, IXUILabelSymbol
{
	private enum Type
	{
		LST_NONE = -1,
		LST_IMAGE,
		LST_GUILD,
		LST_TEAM,
		LST_ITEM,
		LST_NAME,
		LST_PK,
		LST_UI,
		LST_SPECTATE,
		LST_ANIMATION
	}

	private class StringData : XDataBase
	{
		private int m_StartIndex;

		private int m_Length;

		private string m_Str;

		public XUILabelSymbol.Type type
		{
			get;
			set;
		}

		public int startIndex
		{
			get
			{
				return this.m_StartIndex;
			}
		}

		public int length
		{
			get
			{
				return this.m_Length;
			}
		}

		public string str
		{
			get
			{
				return this.m_Str;
			}
		}

		public bool Set(string s, int start_index, int len)
		{
			this.m_Str = s;
			this.m_StartIndex = start_index;
			this.m_Length = len;
			if (this.type == XUILabelSymbol.Type.LST_NONE)
			{
				return true;
			}
			int num = 1;
			for (int num2 = s.IndexOf(XUILabelSymbol._EscapedSeparator, start_index, len); num2 != -1; num2 = s.IndexOf(XUILabelSymbol._EscapedSeparator, num2 + 1, start_index + len - num2 - 1))
			{
				num++;
			}
			return (this.type == XUILabelSymbol.Type.LST_IMAGE && num == 2) || ((this.type == XUILabelSymbol.Type.LST_GUILD || this.type == XUILabelSymbol.Type.LST_PK) && num == 2) || (this.type == XUILabelSymbol.Type.LST_TEAM && num == 3) || (this.type == XUILabelSymbol.Type.LST_UI && num >= 2) || (this.type == XUILabelSymbol.Type.LST_SPECTATE && num == 3) || ((this.type == XUILabelSymbol.Type.LST_ITEM || this.type == XUILabelSymbol.Type.LST_NAME) && num == 3) || (this.type == XUILabelSymbol.Type.LST_ANIMATION && num == 3);
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XUILabelSymbol.StringData>.Recycle(this);
		}
	}

	private class SymbolData : XDataBase
	{
		public XUILabelSymbol.Type type;

		public int startIndex;

		public int endIndex;

		public virtual bool OnClick(int hitIndex, XUILabelSymbol labelSymbol)
		{
			return false;
		}

		public static bool IsImage(XUILabelSymbol.Type type)
		{
			return type == XUILabelSymbol.Type.LST_IMAGE;
		}

		public static bool IsAnimation(XUILabelSymbol.Type type)
		{
			return type == XUILabelSymbol.Type.LST_ANIMATION;
		}

		public static bool IsHyperLink(XUILabelSymbol.Type type)
		{
			return type != XUILabelSymbol.Type.LST_NONE && type != XUILabelSymbol.Type.LST_IMAGE;
		}
	}

	private class ImageSymbolData : XUILabelSymbol.SymbolData
	{
		public UISprite sprite;

		public ImageSymbolData()
		{
			this.type = XUILabelSymbol.Type.LST_IMAGE;
		}

		public string SetSprite(XUILabelSymbol labelSymbol, string str, int startIndex, int length, ref int usedSprite)
		{
			int num = str.IndexOf(XUILabelSymbol._EscapedSeparator, startIndex, length);
			if (num != -1)
			{
				string str2 = str.Substring(startIndex, num - startIndex);
				string spriteName = str.Substring(num + 1, length - (num - startIndex) - 1);
				if (usedSprite >= labelSymbol.SpriteList.Count)
				{
					this.sprite = NGUITools.AddChild<UISprite>(labelSymbol.gameObject);
					this.sprite.gameObject.AddComponent<XUISprite>();
					this.sprite.depth = labelSymbol.m_Label.depth;
					this.sprite.gameObject.layer = labelSymbol.gameObject.layer;
					this.sprite.pivot = UIWidget.Pivot.Left;
					labelSymbol.SpriteList.Add(this.sprite);
					usedSprite++;
				}
				else
				{
					this.sprite = labelSymbol.SpriteList[usedSprite++];
					this.sprite.gameObject.SetActive(true);
				}
				GameObject sharedResource = XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<GameObject>("atlas/UI/" + str2, ".prefab", true);
				this.sprite.atlas = ((!(sharedResource == null)) ? sharedResource.GetComponent<UIAtlas>() : null);
				this.sprite.spriteName = spriteName;
				this.sprite.MakePixelPerfect();
				if (labelSymbol.MaxImageHeight > 0 && this.sprite.height > labelSymbol.MaxImageHeight)
				{
					int num2 = this.sprite.width * labelSymbol.MaxImageHeight / this.sprite.height;
					int num3 = labelSymbol.MaxImageHeight;
					if ((num2 & 1) == 1)
					{
						num2++;
					}
					if ((num3 & 1) == 1)
					{
						num3++;
					}
					this.sprite.width = num2;
					this.sprite.height = num3;
				}
				int width = this.sprite.width;
				return labelSymbol._GetSpaceWithSameWidth(width);
			}
			return null;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XUILabelSymbol.ImageSymbolData>.Recycle(this);
		}
	}

	private class AnimationSymbolData : XUILabelSymbol.SymbolData
	{
		public UISprite sprite;

		public UISpriteAnimation animation;

		public AnimationSymbolData()
		{
			this.type = XUILabelSymbol.Type.LST_ANIMATION;
		}

		public string SetSprite(XUILabelSymbol labelSymbol, string str, int startIndex, int length, ref int usedAnimation)
		{
			int num = str.IndexOf(XUILabelSymbol._EscapedSeparator, startIndex, length);
			int num2 = str.IndexOf(XUILabelSymbol._EscapedSeparator, num + 1, length + startIndex - num);
			if (num != -1)
			{
				string str2 = str.Substring(startIndex, num - startIndex);
				string namePrefix = str.Substring(num + 1, num2 - num - 1);
				int framesPerSecond = int.Parse(str.Substring(num2 + 1, length + startIndex - num2 - 1));
				if (usedAnimation >= labelSymbol.AnimationList.Count)
				{
					this.sprite = NGUITools.AddChild<UISprite>(labelSymbol.gameObject);
					this.animation = this.sprite.gameObject.AddComponent<UISpriteAnimation>();
					this.sprite.gameObject.AddComponent<XUISprite>();
					this.sprite.depth = labelSymbol.m_Label.depth;
					this.sprite.gameObject.layer = labelSymbol.gameObject.layer;
					this.sprite.pivot = UIWidget.Pivot.Left;
					labelSymbol.AnimationList.Add(this.sprite);
					usedAnimation++;
				}
				else
				{
					this.sprite = labelSymbol.AnimationList[usedAnimation++];
					this.animation = this.sprite.gameObject.GetComponent<UISpriteAnimation>();
					this.sprite.gameObject.SetActive(true);
				}
				GameObject sharedResource = XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<GameObject>("atlas/UI/" + str2, ".prefab", true);
				this.sprite.atlas = ((!(sharedResource == null)) ? sharedResource.GetComponent<UIAtlas>() : null);
				this.animation.namePrefix = namePrefix;
				this.animation.framesPerSecond = framesPerSecond;
				this.animation.Reset();
				this.sprite.MakePixelPerfect();
				int num3 = 0;
				if (labelSymbol.MaxImageHeight > 0 && this.sprite.height > labelSymbol.MaxImageHeight)
				{
					num3 = labelSymbol.MaxImageHeight;
				}
				else if (labelSymbol.MinImageHeight > 0 && this.sprite.height < labelSymbol.MinImageHeight)
				{
					num3 = labelSymbol.MinImageHeight;
				}
				if (num3 != 0)
				{
					int num4 = this.sprite.width * num3 / this.sprite.height;
					int num5 = num3;
					if ((num4 & 1) == 1)
					{
						num4++;
					}
					if ((num5 & 1) == 1)
					{
						num5++;
					}
					this.sprite.width = num4;
					this.sprite.height = num5;
				}
				int width = this.sprite.width;
				return labelSymbol._GetSpaceWithSameWidth(width);
			}
			return null;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XUILabelSymbol.AnimationSymbolData>.Recycle(this);
		}
	}

	private abstract class HyperLinkSymbolData : XUILabelSymbol.SymbolData
	{
		public string param;

		public virtual string Set(string wholeStr, int startIndex, int length, int separateIndex)
		{
			return null;
		}

		protected virtual bool OnClick(XUILabelSymbol labelSymbol)
		{
			return false;
		}

		public override bool OnClick(int hitIndex, XUILabelSymbol labelSymbol)
		{
			if (this.startIndex < hitIndex && this.endIndex > hitIndex)
			{
				XSingleton<XDebug>.singleton.AddLog(this.param, null, null, null, null, null, XDebugColor.XDebug_None);
				return this.OnClick(labelSymbol);
			}
			return false;
		}

		protected static string _MakeHyperLinkString(string mainStr, XUILabelSymbol.Type type, string color = "61eee6")
		{
			return string.Format(" [{0}][u]{1}[/u][-] ", color, mainStr);
		}

		public static bool CreateHyperLinkSymbolData(XUILabelSymbol.StringData input, out XUILabelSymbol.SymbolData data, out string symbolString)
		{
			int num = input.str.IndexOf(XUILabelSymbol._EscapedSeparator, input.startIndex, input.length);
			if (num == -1)
			{
				data = null;
				symbolString = null;
				return false;
			}
			XUILabelSymbol.HyperLinkSymbolData hyperLinkSymbolData = null;
			switch (input.type)
			{
			case XUILabelSymbol.Type.LST_GUILD:
				hyperLinkSymbolData = XDataPool<XUILabelSymbol.GuildHyperLinkSymbolData>.GetData();
				break;
			case XUILabelSymbol.Type.LST_TEAM:
				hyperLinkSymbolData = XDataPool<XUILabelSymbol.TeamHyperLinkSymbolData>.GetData();
				break;
			case XUILabelSymbol.Type.LST_ITEM:
				hyperLinkSymbolData = XDataPool<XUILabelSymbol.ItemHyperLinkSymbolData>.GetData();
				break;
			case XUILabelSymbol.Type.LST_NAME:
				hyperLinkSymbolData = XDataPool<XUILabelSymbol.NameHyperLinkSymbolData>.GetData();
				break;
			case XUILabelSymbol.Type.LST_PK:
				hyperLinkSymbolData = XDataPool<XUILabelSymbol.PkHyperLinkSymbolData>.GetData();
				break;
			case XUILabelSymbol.Type.LST_UI:
				hyperLinkSymbolData = XDataPool<XUILabelSymbol.UIHyperLinkSymbolData>.GetData();
				break;
			case XUILabelSymbol.Type.LST_SPECTATE:
				hyperLinkSymbolData = XDataPool<XUILabelSymbol.SpectateHyperLinkSymbolData>.GetData();
				break;
			}
			symbolString = hyperLinkSymbolData.Set(input.str, input.startIndex, input.length, num);
			if (symbolString == null)
			{
				data = null;
				return false;
			}
			data = hyperLinkSymbolData;
			return true;
		}
	}

	private abstract class NormalHyperLinkSymbolData : XUILabelSymbol.HyperLinkSymbolData
	{
		public override string Set(string wholeStr, int startIndex, int length, int separateIndex)
		{
			this.param = wholeStr.Substring(separateIndex + 1, startIndex + length - separateIndex - 1);
			return XUILabelSymbol.HyperLinkSymbolData._MakeHyperLinkString(wholeStr.Substring(startIndex, separateIndex - startIndex), this.type, "61eee6");
		}
	}

	private abstract class ColorHyperLinkSymbolData : XUILabelSymbol.HyperLinkSymbolData
	{
		public override string Set(string wholeStr, int startIndex, int length, int separateIndex)
		{
			int num = wholeStr.IndexOf(XUILabelSymbol._EscapedSeparator, separateIndex + 1, startIndex + length - separateIndex - 1);
			if (num == -1)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("The second separator is missing: ", wholeStr, null, null, null, null);
				return null;
			}
			string color = wholeStr.Substring(separateIndex + 1, num - separateIndex - 1);
			string text = wholeStr.Substring(startIndex, separateIndex - startIndex);
			XUILabelSymbol.s_TempSB.Length = 0;
			XUILabelSymbol.s_TempSB.Append(wholeStr, num + 1, startIndex + length - num - 1);
			XUILabelSymbol.s_TempSB.Append(XUILabelSymbol._EscapedSeparator);
			XUILabelSymbol.s_TempSB.Append(text);
			this.param = XUILabelSymbol.s_TempSB.ToString();
			return XUILabelSymbol.HyperLinkSymbolData._MakeHyperLinkString(text, this.type, color);
		}
	}

	private class GuildHyperLinkSymbolData : XUILabelSymbol.NormalHyperLinkSymbolData
	{
		public GuildHyperLinkSymbolData()
		{
			this.type = XUILabelSymbol.Type.LST_GUILD;
		}

		protected override bool OnClick(XUILabelSymbol labelSymbol)
		{
			if (labelSymbol.GuildClickHandler != null)
			{
				labelSymbol.GuildClickHandler(this.param);
				return true;
			}
			return false;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XUILabelSymbol.GuildHyperLinkSymbolData>.Recycle(this);
		}
	}

	private class TeamHyperLinkSymbolData : XUILabelSymbol.NormalHyperLinkSymbolData
	{
		public TeamHyperLinkSymbolData()
		{
			this.type = XUILabelSymbol.Type.LST_TEAM;
		}

		protected override bool OnClick(XUILabelSymbol labelSymbol)
		{
			if (labelSymbol.TeamClickHandler != null)
			{
				labelSymbol.TeamClickHandler(this.param);
				return true;
			}
			return false;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XUILabelSymbol.TeamHyperLinkSymbolData>.Recycle(this);
		}
	}

	private class ItemHyperLinkSymbolData : XUILabelSymbol.ColorHyperLinkSymbolData
	{
		public ItemHyperLinkSymbolData()
		{
			this.type = XUILabelSymbol.Type.LST_ITEM;
		}

		protected override bool OnClick(XUILabelSymbol labelSymbol)
		{
			if (labelSymbol.ItemClickHandler != null)
			{
				labelSymbol.ItemClickHandler(this.param);
				return true;
			}
			return false;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XUILabelSymbol.ItemHyperLinkSymbolData>.Recycle(this);
		}
	}

	private class NameHyperLinkSymbolData : XUILabelSymbol.ColorHyperLinkSymbolData
	{
		public NameHyperLinkSymbolData()
		{
			this.type = XUILabelSymbol.Type.LST_NAME;
		}

		protected override bool OnClick(XUILabelSymbol labelSymbol)
		{
			if (labelSymbol.NameClickHandler != null)
			{
				labelSymbol.NameClickHandler(this.param);
				return true;
			}
			return false;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XUILabelSymbol.NameHyperLinkSymbolData>.Recycle(this);
		}
	}

	private class PkHyperLinkSymbolData : XUILabelSymbol.NormalHyperLinkSymbolData
	{
		public PkHyperLinkSymbolData()
		{
			this.type = XUILabelSymbol.Type.LST_PK;
		}

		protected override bool OnClick(XUILabelSymbol labelSymbol)
		{
			if (labelSymbol.PkClickHandler != null)
			{
				labelSymbol.PkClickHandler(this.param);
				return true;
			}
			return false;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XUILabelSymbol.PkHyperLinkSymbolData>.Recycle(this);
		}
	}

	private class UIHyperLinkSymbolData : XUILabelSymbol.NormalHyperLinkSymbolData
	{
		public UIHyperLinkSymbolData()
		{
			this.type = XUILabelSymbol.Type.LST_UI;
		}

		protected override bool OnClick(XUILabelSymbol labelSymbol)
		{
			if (labelSymbol.UIClickHandler != null)
			{
				labelSymbol.UIClickHandler(this.param);
				return true;
			}
			return false;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XUILabelSymbol.UIHyperLinkSymbolData>.Recycle(this);
		}
	}

	private class SpectateHyperLinkSymbolData : XUILabelSymbol.NormalHyperLinkSymbolData
	{
		public SpectateHyperLinkSymbolData()
		{
			this.type = XUILabelSymbol.Type.LST_SPECTATE;
		}

		protected override bool OnClick(XUILabelSymbol labelSymbol)
		{
			if (labelSymbol.SpectateHandler != null)
			{
				labelSymbol.SpectateHandler(this.param);
				return true;
			}
			return false;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XUILabelSymbol.SpectateHyperLinkSymbolData>.Recycle(this);
		}
	}

	private HyperLinkClickEventHandler GuildClickHandler;

	private HyperLinkClickEventHandler TeamClickHandler;

	private HyperLinkClickEventHandler ItemClickHandler;

	private HyperLinkClickEventHandler NameClickHandler;

	private HyperLinkClickEventHandler PkClickHandler;

	private HyperLinkClickEventHandler SpectateHandler;

	private HyperLinkClickEventHandler UIClickHandler;

	private HyperLinkClickEventHandler DefaultClickHandler;

	private LabelSymbolClickEventHandler SymbolClickHandler;

	protected UILabel m_Label;

	protected BoxCollider m_collider;

	public int MaxImageHeight;

	public int MinImageHeight;

	public int ImageHeightAdjustment;

	public XUISprite BoardSprite;

	public int MinBoardWidth;

	public int MaxBoardWidth;

	public int BoardHeightOffset;

	public int BoardWidthOffset;

	public bool bAutoDisableBoxCollider;

	private StringBuilder m_OutputSB = new StringBuilder();

	private StringBuilder m_ResSB = new StringBuilder();

	private static StringBuilder s_TempSB = new StringBuilder();

	private List<XUILabelSymbol.StringData> m_StringData = new List<XUILabelSymbol.StringData>();

	private List<XUILabelSymbol.SymbolData> m_Symbols = new List<XUILabelSymbol.SymbolData>();

	private List<UISprite> m_SpriteList = new List<UISprite>();

	private List<UISprite> m_AnimationList = new List<UISprite>();

	private bool m_bBoxColliderCreator;

	private string _InputText;

	private static BetterList<Vector3> verts = new BetterList<Vector3>();

	private static BetterList<int> indices = new BetterList<int>();

	private static char _UniSpace = ' ';

	private static char _cSeparator = '|';

	private static char _EscapedSeparator = '\u001f';

	private static char _cLeftBracket = '[';

	private static char _EscapedLeftBracket = '\u0002';

	private static char _cRightBracket = ']';

	private static char _EscapedRightBracket = '\u0003';

	private float _UniSpaceWidth = -0.1f;

	private float _SpaceWidth = -0.1f;

	public List<UISprite> SpriteList
	{
		get
		{
			return this.m_SpriteList;
		}
	}

	public List<UISprite> AnimationList
	{
		get
		{
			return this.m_AnimationList;
		}
	}

	public string InputText
	{
		set
		{
			this._InputText = value;
			if (this._InputText == null)
			{
				this._InputText = string.Empty;
			}
			this.Parse();
			this.SetBoard();
		}
	}

	public IXUISprite IBoardSprite
	{
		get
		{
			return this.BoardSprite;
		}
	}

	public void SetBoard()
	{
		Vector2 vector = NGUIText.CalculatePrintedSize(this.m_Label.text, -1);
		vector.x += (float)this.BoardWidthOffset;
		if (this.BoardSprite != null)
		{
			if (this.MinBoardWidth != 0 && this.MaxBoardWidth != 0 && this.MaxBoardWidth >= this.MinBoardWidth)
			{
				if (vector.x <= (float)this.MinBoardWidth)
				{
					this.BoardSprite.spriteWidth = this.MinBoardWidth;
				}
				else if (vector.x > (float)this.MaxBoardWidth)
				{
					this.BoardSprite.spriteWidth = this.MaxBoardWidth;
				}
				else
				{
					this.BoardSprite.spriteWidth = (int)vector.x;
				}
			}
			else
			{
				this.BoardSprite.spriteWidth = (int)vector.x;
			}
			this.BoardSprite.spriteHeight = (int)vector.y + 20 + this.BoardHeightOffset;
		}
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_Label = base.GetComponent<UILabel>();
		this.m_Label.ProcessText();
		this.m_collider = this.m_Label.DefaultBoxCollider;
		if (null == this.m_Label)
		{
			Debug.LogError("null == m_Label");
		}
		if (this.m_collider != null)
		{
			UIEventListener uIEventListener = UIEventListener.Get(base.gameObject);
			UIEventListener expr_67 = uIEventListener;
			expr_67.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(expr_67.onClick, new UIEventListener.VoidDelegate(this.OnSymbolClick));
			UIEventListener expr_89 = uIEventListener;
			expr_89.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_89.onClick, new UIEventListener.VoidDelegate(this.OnSymbolClick));
		}
	}

	private void _CheckAttachments()
	{
		for (int i = this.m_SpriteList.Count - 1; i >= 0; i--)
		{
			if (this.m_SpriteList[i] == null)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("m_SpriteList[{0}] == null, while m_SpriteList.Count = {1}", i, this.m_SpriteList.Count), null, null, null, null, null);
				this.m_SpriteList.RemoveAt(i);
			}
		}
		for (int j = this.m_AnimationList.Count - 1; j >= 0; j--)
		{
			if (this.m_AnimationList[j] == null)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("m_AnimationList[{0}] == null, while m_AnimationList.Count = {1}", j, this.m_AnimationList.Count), null, null, null, null, null);
				this.m_AnimationList.RemoveAt(j);
			}
		}
	}

	public void UpdateDepth(int depth)
	{
		for (int i = 0; i < this.m_SpriteList.Count; i++)
		{
			if (this.m_SpriteList[i] != null)
			{
				this.m_SpriteList[i].depth = depth;
			}
		}
		for (int j = 0; j < this.m_AnimationList.Count; j++)
		{
			if (this.m_AnimationList[j] != null)
			{
				this.m_AnimationList[j].depth = depth;
			}
		}
	}

	private void OnSymbolClick(GameObject go)
	{
		bool flag = false;
		if (this.m_Symbols != null && this.m_Symbols.Count != 0)
		{
			int characterIndexAtPosition = this.m_Label.GetCharacterIndexAtPosition(UICamera.lastHit.point);
			if (characterIndexAtPosition >= 0)
			{
				for (int i = 0; i < this.m_Symbols.Count; i++)
				{
					XUILabelSymbol.SymbolData symbolData = this.m_Symbols[i];
					flag |= symbolData.OnClick(characterIndexAtPosition, this);
				}
			}
		}
		if (!flag && this.DefaultClickHandler != null)
		{
			this.DefaultClickHandler(null);
		}
		if (!flag && this.SymbolClickHandler != null)
		{
			this.SymbolClickHandler(this);
		}
	}

	public void Parse()
	{
		this.m_OutputSB.Length = 0;
		this._Separate();
		this._Parse();
		if (this.bAutoDisableBoxCollider && this.m_collider != null)
		{
			this.m_collider.enabled = false;
		}
		if (this.m_Symbols.Count <= 0)
		{
			return;
		}
		XUILabelSymbol.verts.Clear();
		XUILabelSymbol.indices.Clear();
		NGUIText.PrintCharacterPositions(this.m_Label.processedText, XUILabelSymbol.verts, XUILabelSymbol.indices);
		if (XUILabelSymbol.verts.size <= 0)
		{
			return;
		}
		this.m_Label.ApplyOffset(XUILabelSymbol.verts, 0);
		int i = 0;
		for (int j = 0; j < this.m_Symbols.Count; j++)
		{
			XUILabelSymbol.SymbolData symbolData = this.m_Symbols[j];
			if (XUILabelSymbol.SymbolData.IsImage(symbolData.type) || XUILabelSymbol.SymbolData.IsAnimation(symbolData.type))
			{
				UISprite sprite;
				if (XUILabelSymbol.SymbolData.IsImage(symbolData.type))
				{
					XUILabelSymbol.ImageSymbolData imageSymbolData = symbolData as XUILabelSymbol.ImageSymbolData;
					sprite = imageSymbolData.sprite;
				}
				else
				{
					XUILabelSymbol.AnimationSymbolData animationSymbolData = symbolData as XUILabelSymbol.AnimationSymbolData;
					sprite = animationSymbolData.sprite;
				}
				while (i < XUILabelSymbol.indices.size)
				{
					if (XUILabelSymbol.indices[i] == symbolData.startIndex)
					{
						sprite.transform.localPosition = XUILabelSymbol.verts[i] + new Vector3(0f, (float)this.ImageHeightAdjustment);
						break;
					}
					i++;
				}
				if (i == XUILabelSymbol.indices.size && sprite != null)
				{
					sprite.gameObject.SetActive(false);
				}
			}
			else if (XUILabelSymbol.SymbolData.IsHyperLink(symbolData.type))
			{
				if (this.m_collider == null)
				{
					this.m_collider = NGUITools.AddWidgetCollider(base.gameObject, this.m_Label, false);
					UIEventListener uIEventListener = UIEventListener.Get(base.gameObject);
					UIEventListener expr_1E5 = uIEventListener;
					expr_1E5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(expr_1E5.onClick, new UIEventListener.VoidDelegate(this.OnSymbolClick));
					UIEventListener expr_208 = uIEventListener;
					expr_208.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_208.onClick, new UIEventListener.VoidDelegate(this.OnSymbolClick));
					this.m_bBoxColliderCreator = true;
				}
				else
				{
					this.m_collider.enabled = true;
					if (this.m_bBoxColliderCreator)
					{
						NGUITools.UpdateWidgetCollider(this.m_Label, this.m_collider, false);
					}
				}
			}
		}
	}

	private int _FindClosingBracket(string s, int startIndex)
	{
		int length = s.Length;
		int num = 0;
		for (int i = startIndex; i < length; i++)
		{
			if (s[i] == XUILabelSymbol._EscapedLeftBracket)
			{
				num++;
			}
			else if (s[i] == XUILabelSymbol._EscapedRightBracket && --num < 0)
			{
				return i;
			}
		}
		return -1;
	}

	private void _Parse()
	{
		for (int i = 0; i < this.m_Symbols.Count; i++)
		{
			this.m_Symbols[i].Recycle();
		}
		this.m_Symbols.Clear();
		this.m_Label.text = string.Empty;
		this.m_Label.ProcessText();
		this.m_Label.UpdateDefaultPrintedSize();
		if (this._UniSpaceWidth < 0f)
		{
			this._UniSpaceWidth = NGUIText.CalculatePrintedSize(new string(XUILabelSymbol._UniSpace, 1), 1000).x;
			this._SpaceWidth = NGUIText.CalculatePrintedSize(" ", 1000).x;
			if (Mathf.Abs(this._SpaceWidth) < 0.01f)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("_SpaceWidth = ", this._SpaceWidth.ToString(), " gameobject = ", base.gameObject.ToString(), null, null);
			}
		}
		this._CheckAttachments();
		string text = string.Empty;
		int num = 0;
		int j = 0;
		int k = 0;
		int num2 = this.m_Label.width;
		if (this.m_Label.overflowMethod == UILabel.Overflow.ResizeFreely)
		{
			num2 = 10000;
		}
		string text2 = null;
		XUILabelSymbol.SymbolData symbolData = null;
		int l = 0;
		while (l < this.m_StringData.Count)
		{
			if (num != 0 && num >= text.Length)
			{
				break;
			}
			XUILabelSymbol.StringData stringData = this.m_StringData[l];
			if (XUILabelSymbol.SymbolData.IsImage(stringData.type))
			{
				XUILabelSymbol.ImageSymbolData data = XDataPool<XUILabelSymbol.ImageSymbolData>.GetData();
				text2 = data.SetSprite(this, stringData.str, stringData.startIndex, stringData.length, ref j);
				if (text2 != null)
				{
					symbolData = data;
					goto IL_224;
				}
				data.Recycle();
			}
			else if (XUILabelSymbol.SymbolData.IsAnimation(stringData.type))
			{
				XUILabelSymbol.AnimationSymbolData data2 = XDataPool<XUILabelSymbol.AnimationSymbolData>.GetData();
				text2 = data2.SetSprite(this, stringData.str, stringData.startIndex, stringData.length, ref k);
				if (text2 != null)
				{
					symbolData = data2;
					goto IL_224;
				}
				data2.Recycle();
			}
			else
			{
				if (XUILabelSymbol.SymbolData.IsHyperLink(stringData.type))
				{
					XUILabelSymbol.HyperLinkSymbolData.CreateHyperLinkSymbolData(stringData, out symbolData, out text2);
					goto IL_224;
				}
				goto IL_224;
			}
			IL_3B7:
			l++;
			continue;
			IL_224:
			if (text2 != null)
			{
				XUILabelSymbol.s_TempSB.Length = 0;
				XUILabelSymbol.s_TempSB.Append(text, num, text.Length - num);
				XUILabelSymbol.s_TempSB.Append(text2);
				int num3 = Mathf.CeilToInt(NGUIText.CalculatePrintedSize(XUILabelSymbol.s_TempSB.ToString(), num2 + 1000).x);
				if (num3 > num2)
				{
					symbolData.startIndex = text.Length + 1;
					num = text.Length + 1;
					XUILabelSymbol.s_TempSB.Length = 0;
					XUILabelSymbol.s_TempSB.Append(text);
					XUILabelSymbol.s_TempSB.Append('\n');
					XUILabelSymbol.s_TempSB.Append(text2);
					text = XUILabelSymbol.s_TempSB.ToString();
				}
				else
				{
					symbolData.startIndex = text.Length;
					XUILabelSymbol.s_TempSB.Length = 0;
					XUILabelSymbol.s_TempSB.Append(text);
					XUILabelSymbol.s_TempSB.Append(text2);
					text = XUILabelSymbol.s_TempSB.ToString();
				}
				symbolData.endIndex = symbolData.startIndex + text2.Length;
				this.m_Symbols.Add(symbolData);
				NGUIText.WrapText(text, out text, false);
				text2 = null;
				goto IL_3B7;
			}
			XUILabelSymbol.s_TempSB.Length = 0;
			XUILabelSymbol.s_TempSB.Append(text);
			XUILabelSymbol.s_TempSB.Append(stringData.str, stringData.startIndex, stringData.length);
			NGUIText.WrapText(XUILabelSymbol.s_TempSB.ToString(), out text, false);
			num = text.LastIndexOf('\n');
			if (num == -1)
			{
				num = 0;
				goto IL_3B7;
			}
			num++;
			goto IL_3B7;
		}
		while (j < this.m_SpriteList.Count)
		{
			this.m_SpriteList[j].gameObject.SetActive(false);
			j++;
		}
		while (k < this.m_AnimationList.Count)
		{
			this.m_AnimationList[k].gameObject.SetActive(false);
			k++;
		}
		this.m_Label.text = text;
	}

	private void _Separate()
	{
		for (int i = 0; i < this.m_StringData.Count; i++)
		{
			this.m_StringData[i].Recycle();
		}
		this.m_StringData.Clear();
		int num = 0;
		string text = (!string.IsNullOrEmpty(this._InputText)) ? this._InputText : string.Empty;
		int length = text.Length;
		XUILabelSymbol.Type type = XUILabelSymbol.Type.LST_NONE;
		for (int j = 0; j < length; j++)
		{
			if (this._InputText[j] == XUILabelSymbol._EscapedLeftBracket)
			{
				int num2 = this._FindClosingBracket(text, j + 1);
				if (num2 != -1 && num2 - j > 3)
				{
					int startIndex = j + 1;
					type = this._GetType(this._InputText, startIndex);
				}
				if (type != XUILabelSymbol.Type.LST_NONE)
				{
					XUILabelSymbol.StringData data = XDataPool<XUILabelSymbol.StringData>.GetData();
					data.type = type;
					if (data.Set(text, j + 4, num2 - j - 4))
					{
						if (j > num)
						{
							XUILabelSymbol.StringData data2 = XDataPool<XUILabelSymbol.StringData>.GetData();
							data2.type = XUILabelSymbol.Type.LST_NONE;
							data2.Set(text, num, j - num);
							this.m_StringData.Add(data2);
						}
						this.m_StringData.Add(data);
						num = num2 + 1;
						j = num2;
					}
					else
					{
						data.Recycle();
					}
					type = XUILabelSymbol.Type.LST_NONE;
				}
			}
		}
		if (num < length)
		{
			XUILabelSymbol.StringData data3 = XDataPool<XUILabelSymbol.StringData>.GetData();
			data3.type = XUILabelSymbol.Type.LST_NONE;
			data3.Set(text, num, length - num);
			this.m_StringData.Add(data3);
		}
	}

	private XUILabelSymbol.Type _GetType(string s, int startIndex)
	{
		if (XUILabelSymbol.strcmp(s, "im=", startIndex, 0) == 0)
		{
			return XUILabelSymbol.Type.LST_IMAGE;
		}
		if (XUILabelSymbol.strcmp(s, "gd=", startIndex, 0) == 0)
		{
			return XUILabelSymbol.Type.LST_GUILD;
		}
		if (XUILabelSymbol.strcmp(s, "tm=", startIndex, 0) == 0)
		{
			return XUILabelSymbol.Type.LST_TEAM;
		}
		if (XUILabelSymbol.strcmp(s, "it=", startIndex, 0) == 0)
		{
			return XUILabelSymbol.Type.LST_ITEM;
		}
		if (XUILabelSymbol.strcmp(s, "nm=", startIndex, 0) == 0)
		{
			return XUILabelSymbol.Type.LST_NAME;
		}
		if (XUILabelSymbol.strcmp(s, "pk=", startIndex, 0) == 0)
		{
			return XUILabelSymbol.Type.LST_PK;
		}
		if (XUILabelSymbol.strcmp(s, "ui=", startIndex, 0) == 0)
		{
			return XUILabelSymbol.Type.LST_UI;
		}
		if (XUILabelSymbol.strcmp(s, "sp=", startIndex, 0) == 0)
		{
			return XUILabelSymbol.Type.LST_SPECTATE;
		}
		if (XUILabelSymbol.strcmp(s, "an=", startIndex, 0) == 0)
		{
			return XUILabelSymbol.Type.LST_ANIMATION;
		}
		return XUILabelSymbol.Type.LST_NONE;
	}

	private static int strcmp(string left, string right, int leftStartIndex = 0, int rightStartIndex = 0)
	{
		int num = leftStartIndex;
		int num2 = rightStartIndex;
		while (num < left.Length && num2 < right.Length)
		{
			if (left[num] == right[num2])
			{
				num++;
				num2++;
			}
			else
			{
				if (left[num] < right[num2])
				{
					return -1;
				}
				return 1;
			}
		}
		return 0;
	}

	private string _GetSpaceWithSameWidth(int width)
	{
		if ((float)width < this._SpaceWidth)
		{
			return " ";
		}
		if ((float)width < 2f * this._SpaceWidth)
		{
			return "  ";
		}
		XUILabelSymbol.s_TempSB.Length = 0;
		int repeatCount = Mathf.CeilToInt(((float)width - 2f * this._SpaceWidth) / this._UniSpaceWidth);
		XUILabelSymbol.s_TempSB.Append(" ");
		XUILabelSymbol.s_TempSB.Append(XUILabelSymbol._UniSpace, repeatCount);
		XUILabelSymbol.s_TempSB.Append(" ");
		return XUILabelSymbol.s_TempSB.ToString();
	}

	public void RegisterTeamEventHandler(HyperLinkClickEventHandler eventHandler)
	{
		this.TeamClickHandler = eventHandler;
	}

	public void RegisterGuildEventHandler(HyperLinkClickEventHandler eventHandler)
	{
		this.GuildClickHandler = eventHandler;
	}

	public void RegisterItemEventHandler(HyperLinkClickEventHandler eventHandler)
	{
		this.ItemClickHandler = eventHandler;
	}

	public void RegisterNameEventHandler(HyperLinkClickEventHandler eventHandler)
	{
		this.NameClickHandler = eventHandler;
	}

	public void RegisterPkEventHandler(HyperLinkClickEventHandler eventHandler)
	{
		this.PkClickHandler = eventHandler;
	}

	public void RegisterUIEventHandler(HyperLinkClickEventHandler eventHandler)
	{
		this.UIClickHandler = eventHandler;
	}

	public void RegisterSpectateEventHandler(HyperLinkClickEventHandler eventHandler)
	{
		this.SpectateHandler = eventHandler;
	}

	public void RegisterDefaultEventHandler(HyperLinkClickEventHandler eventHandler)
	{
		this.DefaultClickHandler = eventHandler;
	}

	public void RegisterSymbolClickHandler(LabelSymbolClickEventHandler eventHandler)
	{
		this.SymbolClickHandler = eventHandler;
	}
}
