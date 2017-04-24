using System;
using UILib;

public class XUIObject : XUIObjectBase
{
	private bool mParentCached;

	public override IXUIObject parent
	{
		get
		{
			if (!this.mParentCached)
			{
				XUIObjectBase xUIObjectBase = NGUITools.FindInParents<XUIObjectBase>(base.transform.parent.gameObject);
				if (null != xUIObjectBase)
				{
					base.parent = xUIObjectBase;
				}
				this.mParentCached = true;
			}
			return base.parent;
		}
		set
		{
			base.parent = value;
			this.mParentCached = true;
		}
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		if (null == base.transform.parent)
		{
			this.parent = null;
			return;
		}
	}
}
