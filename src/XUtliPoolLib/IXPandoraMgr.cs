using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IXPandoraMgr : IXInterface
	{
		void PandoraLogin(string openid, string acctype, string area, string areaID, string appId, string roleID, string accessToken, string payToken, string gameVersion, string platID);

		void PopPLPanel();

		void CloseAllPandoraPanel();

		void ClosePandoraTabPanel();

		void SetPandoraPanelParent(string panelName, GameObject panelParent);

		void PandoraDo(Dictionary<string, string> commandDict);

		void PandoraDoJson(string json);

		void PandoraInit(bool isProductEnvironment, string rootName = "");

		void PandoraLogout();

		void SetFont(Font font);

		string IsActivityPopReady();

		void NoticePandoraShareResult(string result);

		void LoadProgramAsset();

		void SetUserData(Dictionary<string, string> data);

		void SetGameCallback(Action<Dictionary<string, string>> callback);

		void SetJsonGameCallback(Action<string> callback);

		bool IsActivityTabShow(string tabName);

		bool IsActivityTabShowByContent(string tabContent);
	}
}
