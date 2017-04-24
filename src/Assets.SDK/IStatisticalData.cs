using System;

namespace Assets.SDK
{
	public interface IStatisticalData
	{
		void setLogEnable(bool bEnable);

		void initAppCPA(string appId, string channelId);

		void onRegister(string userId);

		void onLogin(string userId);

		void onPay(string userId, string orderId, int amount, string currency);

		void initStatisticalGame(string appId, string partnerId);

		bool isStandaloneGame();

		void setStandaloneGame(bool isSG);

		void initAccount(string accountId);

		void setAccountType(GameAccountType type);

		void setAccountName(string name);

		void setAccountLevel(int level);

		void setAccountGameServer(string gameServer);

		void setAccountGender(GameGender gender);

		void setAccountAge(int age);

		void accountPay(string messageId, string status, string accountID, string orderID, double currencyAmount, string currencyType, double virtualCurrencyAmount, long chargeTime, string iapID, string paymentType, string gameServer, string gameVersion, int level, string mission);

		void onAccountPurchase(string item, int itemNumber, double priceInVirtualCurrency);

		void onAccountUse(string item, int itemNumber);

		void onAccountMissionBegin(string missionId);

		void onAccountMissionCompleted(string missionId);

		void onAccountMissionFailed(string missionId, string cause);

		void onAccountCurrencyReward(double virtualCurrencyAmount, string reason);
	}
}
