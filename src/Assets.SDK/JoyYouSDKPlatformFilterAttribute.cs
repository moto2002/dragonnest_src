using System;

namespace Assets.SDK
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public sealed class JoyYouSDKPlatformFilterAttribute : Attribute
	{
		public const string PLATFORM_NAME_NONE = "__NONE__";

		public const string PLATFORM_NAME_SY07073_ANDROID = "__Android_SY07073__";

		public const string PLATFORM_NAME_2144_ANDROID = "__Android_2144__";

		public const string PLATFORM_NAME_M37WAN_ANDROID = "__Android_M37WAN__";

		public const string PLATFORM_NAME_M4399_ANDROID = "__Android_M4399__";

		public const string PLATFORM_NAME_51SY_ANDROID = "__Android_51_Shouyou__";

		public const string PLATFORM_NAME_7XZ_ANDROID = "__Android_7XZ__";

		public const string PLATFORM_NAME_7K7K_ANDROID = "__Android_7K7K__";

		public const string PLATFORM_NAME_PK96_ANDROID = "__AndroidSDKPK96__";

		public const string PLATFORM_NAME_AIPAI_ANDROID = "__Android_AiPai__";

		public const string PLATFORM_NAME_ALITV_ANDROID = "__Android_AliTV__";

		public const string PLATFORM_NAME_ANZHI_ANDROID = "__Android_AnZhi__";

		public const string PLATFORM_NAME_BAIDU91_ANDROID = "__Android_Baidu91__";

		public const string PLATFORM_NAME_CAOHUA_ANDROID = "__Android_Caohua__";

		public const string PLATFORM_NAME_CHONGCHONG_ANDROID = "__Android_ChongChong__";

		public const string PLATFORM_NAME_COOLPAD_ANDROID = "__Android_Coolpad__";

		public const string PLATFORM_NAME_DIANXIN_ANDROID = "__Android_DianXin__";

		public const string PLATFORM_NAME_DOUDOU_ANDROID = "__Android_Doudou__";

		public const string PLATFORM_NAME_DOUYU_ANDROID = "__Android_Douyu__";

		public const string PLATFORM_NAME_DOWNJOY_ANDROID = "__Android_Downjoy__";

		public const string PLATFORM_NAME_DYOO_ANDROID = "__Android_Dyoo__";

		public const string PLATFORM_NAME_EFUN_ANDROID = "__Android_Efun__";

		public const string PLATFORM_NAME_GIONEE_ANDROID = "__Android_Gionee__";

		public const string PLATFORM_NAME_GUOPAN_ANDROID = "__Android_Guopan__";

		public const string PLATFORM_NAME_HARDCORE_ANDROID = "__Android_HardCore__";

		public const string PLATFORM_NAME_HUAWEI_ANDROID = "__Android_Huawei__";

		public const string PLATFORM_NAME_KAOPU_ANDROID = "__Android_Kaopu__";

		public const string PLATFORM_NAME_KOREAN_ANDROID = "__Android_Korean__";

		public const string PLATFORM_NAME_LENOVO_ANDROID = "__Android_Lenovo__";

		public const string PLATFORM_NAME_MEIZU_ANDROID = "__Android_MeiZu__";

		public const string PLATFORM_NAME_MUMAYI_ANDROID = "__Android_Mumayi__";

		public const string PLATFORM_NAME_MUZHIWAN_ANDROID = "__Android_MuZhiWan__";

		public const string PLATFORM_NAME_OPPO_ANDROID = "__Android_oppo__";

		public const string PLATFORM_NAME_PPS_ANDROID = "__Android_PPS__";

		public const string PLATFORM_NAME_PPTV_ANDROID = "__Android_PPTV__";

		public const string PLATFORM_NAME_PAPA_ANDROID = "__Android_Papa__";

		public const string PLATFORM_NAME_SDKBUSSD_ANDROID = "__AndroidSDKBUSSD__";

		public const string PLATFORM_NAME_SINA_ANDROID = "__Android_Sina__";

		public const string PLATFORM_NAME_SM_ANDROID = "__Android_Singapore&Malaysia__";

		public const string PLATFORM_NAME_SOGOU_ANDROID = "__Android_SoGou__";

		public const string PLATFORM_NAME_TC_ANDROID = "__Android_TC__";

		public const string PLATFORM_NAME_TENCENT_ANDROID = "__Android_Tencent__";

		public const string PLATFORM_NAME_TENCENT_YSDK_ANDROID = "__Android_TencentYSDK__";

		public const string PLATFORM_NAME_THAILAND_ANDROID = "__Android_Thailand__";

		public const string PLATFORM_NAME_UC_ANDROID = "__Android_UC__";

		public const string PLATFORM_NAME_UMIPAY_ANDROID = "__Android_Umipay__";

		public const string PLATFORM_NAME_VIVO_ANDROID = "__Android_Vivo__";

		public const string PLATFORM_NAME_WANDOUJIA_ANDROID = "__Android_WanDouJia__";

		public const string PLATFORM_NAME_XIAOMI_ANDROID = "__Android_Xiaomi__";

		public const string PLATFORM_NAME_YOUKU_ANDROID = "__Android_Youku__";

		public const string PLATFORM_NAME_QIHOO_ANDROID = "__Android_Qihoo__";

		public const string PLATFORM_NAME_JOYYOU = "__JoyYou__";

		public const string PLATFORM_NAME_2144 = "__2144__";

		public const string PLATFORM_NAME_WY51 = "__WY_51__";

		public const string PLATFORM_NAME_BAIDU91 = "__Baidu91__";

		public const string PLATFORM_NAME_DOWNJOY = "__Downjoy__";

		public const string PLATFORM_NAME_GIANT = "__GIANT__";

		public const string PLATFORM_NAME_GUOPAN = "__Guopan__";

		public const string PLATFORM_NAME_HAIMA = "__Haima__";

		public const string PLATFORM_NAME_KOREAN = "__Korean__";

		public const string PLATFORM_NAME_KUAIYONG = "__Kuaiyong__";

		public const string PLATFORM_NAME_PP = "__PP__";

		public const string PLATFORM_NAME_SDO_APPLE = "__SDO_APPLE__";

		public const string PLATFORM_NAME_SDO_JAILBREAK = "__SDO__JAILBREAK__";

		public const string PLATFORM_NAME_SM = "__Singapore&Malaysia__";

		public const string PLATFORM_NAME_TENCENT = "__Tencent__";

		public const string PLATFORM_NAME_THAILAND = "__Thailand__";

		public const string PLATFORM_NAME_TONGBU = "__Tongbutui__";

		public const string PLATFORM_NAME_XYSDK = "__XYSDK__";

		public const string PLATFORM_NAME_I4SDK = "__I4SDK__";

		public const string PLATFORM_NAME_ITOOLS = "__iTools__";

		public string PlatformName
		{
			get;
			private set;
		}

		public Type PlatformSettingsAttributeType
		{
			get;
			private set;
		}

		public JoyYouSDKPlatformFilterAttribute(string platformName)
		{
			this.PlatformName = platformName;
		}
	}
}
