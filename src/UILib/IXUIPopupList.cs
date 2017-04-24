using System;
using System.Collections.Generic;

namespace UILib
{
	public interface IXUIPopupList : IXUIObject
	{
		string value
		{
			get;
			set;
		}

		int currentIndex
		{
			get;
			set;
		}

		void SetOptionList(List<string> options);
	}
}
