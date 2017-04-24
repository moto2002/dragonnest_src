using System;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Language Selection"), RequireComponent(typeof(UIPopupList))]
public class LanguageSelection : MonoBehaviour
{
	private UIPopupList mList;

	private void Start()
	{
		this.mList = base.GetComponent<UIPopupList>();
		if (Localization.knownLanguages != null)
		{
			this.mList.items.Clear();
			int i = 0;
			int num = Localization.knownLanguages.Length;
			while (i < num)
			{
				this.mList.items.Add(Localization.knownLanguages[i]);
				i++;
			}
			this.mList.value = Localization.language;
		}
		EventDelegate.Add(this.mList.onChange, new EventDelegate.Callback(this.OnChange));
	}

	private void OnChange()
	{
		Localization.language = UIPopupList.current.value;
	}
}
