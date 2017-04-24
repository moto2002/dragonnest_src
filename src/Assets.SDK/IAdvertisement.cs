using System;

namespace Assets.SDK
{
	public interface IAdvertisement
	{
		void CreateBanner(int x, int y, int width, int height, ADV_SIZE size, string content);

		void BannerRefresh(int second);

		void RemoveBanner();

		void getAdvIDFA();
	}
}
