using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

public class XUIComboBox : XUIObject, IXUIObject, IXUIComboBox
{
	private Dictionary<int, string> items = new Dictionary<int, string>();

	private Dictionary<int, GameObject> itemObjects = new Dictionary<int, GameObject>();

	private UISprite itemtpl;

	private int count;

	private Transform droplist;

	private UIPlayTween close;

	private UILabel selecttext;

	private ComboboxClickEventHandler _callback;

	public void ModuleInit()
	{
		this.itemtpl = base.transform.FindChild("Difficulty/DropList/ItemTpl").GetComponent<UISprite>();
		this.itemtpl.gameObject.SetActive(false);
		this.droplist = base.transform.FindChild("Difficulty/DropList");
		this.droplist.gameObject.SetActive(false);
		this.selecttext = base.transform.FindChild("Difficulty/SelectedText").GetComponent<UILabel>();
		Transform transform = base.transform.FindChild("Difficulty/DropList/Close");
		if (transform != null)
		{
			this.close = transform.GetComponent<UIPlayTween>();
		}
		this.count = 0;
	}

	public void AddItem(string text, int value)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(this.itemtpl.gameObject) as GameObject;
		gameObject.SetActive(true);
		gameObject.name = value.ToString();
		gameObject.transform.parent = this.droplist;
		gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)this.count * this.itemtpl.height));
		gameObject.transform.localScale = Vector3.one;
		this.count++;
		UILabel component = gameObject.transform.FindChild("ItemText").GetComponent<UILabel>();
		component.text = text;
		this.items.Add(value, text);
		this.itemObjects.Add(value, gameObject);
		XUISprite component2 = gameObject.GetComponent<XUISprite>();
		component2.ID = (ulong)((long)value);
		component2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemSelect));
	}

	public GameObject GetItem(int value)
	{
		GameObject result = null;
		this.itemObjects.TryGetValue(value, out result);
		return result;
	}

	public void ClearItems()
	{
		foreach (KeyValuePair<int, GameObject> current in this.itemObjects)
		{
			UnityEngine.Object.Destroy(current.Value);
		}
		this.items.Clear();
		this.itemObjects.Clear();
		this.count = 0;
	}

	protected void OnItemSelect(IXUISprite sp)
	{
		if (this._callback != null)
		{
			this._callback((int)sp.ID);
		}
		if (this.close != null)
		{
			this.close.Play(true);
		}
		this.selecttext.text = this.items[(int)sp.ID];
	}

	public bool SelectItem(int value, bool withCallback)
	{
		string text = null;
		if (this.items.TryGetValue(value, out text))
		{
			this.selecttext.text = text;
			if (withCallback && this._callback != null)
			{
				this._callback(value);
			}
			return true;
		}
		return false;
	}

	public void RegisterSpriteClickEventHandler(ComboboxClickEventHandler eventHandler)
	{
		this._callback = eventHandler;
	}

	public void ResetState()
	{
		if (this.items.Count == 0)
		{
			this.selecttext.text = string.Empty;
		}
		this.droplist.gameObject.SetActive(false);
		using (Dictionary<int, string>.Enumerator enumerator = this.items.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				KeyValuePair<int, string> current = enumerator.Current;
				this.selecttext.text = current.Value;
				if (this._callback != null)
				{
					this._callback(current.Key);
				}
			}
		}
	}
}
