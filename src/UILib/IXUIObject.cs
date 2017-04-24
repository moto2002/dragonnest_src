using System;
using UnityEngine;

namespace UILib
{
	public interface IXUIObject
	{
		GameObject gameObject
		{
			get;
		}

		IXUIObject parent
		{
			get;
			set;
		}

		ulong ID
		{
			get;
			set;
		}

		bool Exculsive
		{
			get;
			set;
		}

		IXUIObject GetUIObject(string strName);

		bool IsVisible();

		void SetVisible(bool bVisible);

		void OnFocus();

		void Highlight(bool bTrue);
	}
}
