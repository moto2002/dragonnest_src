using System;

namespace Assets.SDK
{
	public interface ITencentWX
	{
		void WXShareLink(string url, string title, string description, string image, int scene);

		void WXShareRegister(string appId);
	}
}
