using System;

namespace Assets.SDK
{
	public sealed class InitNaverComponentAttribute : JoyYouComponentAttribute
	{
		public string URLScheme
		{
			get;
			private set;
		}

		public InitNaverComponentAttribute()
		{
			this.URLScheme = string.Empty;
		}

		public InitNaverComponentAttribute(string urlscheme)
		{
			this.URLScheme = urlscheme;
		}
	}
}
