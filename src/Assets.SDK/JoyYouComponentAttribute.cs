using System;

namespace Assets.SDK
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public class JoyYouComponentAttribute : Attribute
	{
		public bool isDelayInit
		{
			get;
			protected set;
		}

		public bool isStaticLoad
		{
			get;
			protected set;
		}

		public JoyYouComponentAttribute()
		{
			this.isStaticLoad = true;
		}

		public virtual void DoInit()
		{
		}
	}
}
