using Assets.SDK;
using System;

namespace Assets.JoyYouSDK.NativeImpl.Android
{
	public class AdvertisementImpl4Android : IAdvertisement
	{
		private string mDefaultContentId = string.Empty;

		public AdvertisementImpl4Android(string propertyId, string defaultContentId, bool logEnable)
		{
			this.mDefaultContentId = defaultContentId;
		}

		void IAdvertisement.CreateBanner(int x, int y, int width, int height, ADV_SIZE size, string content)
		{
		}

		void IAdvertisement.BannerRefresh(int second)
		{
		}

		void IAdvertisement.RemoveBanner()
		{
		}

		void IAdvertisement.getAdvIDFA()
		{
		}
	}
}
