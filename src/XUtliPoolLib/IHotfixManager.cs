using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IHotfixManager
	{
		void Dispose();

		bool DoLuaFile(string name);

		void TryFixMsglist();

		bool TryFixClick(HotfixMode _mode, string _path);

		bool TryFixNet(HotfixMode _mode, uint _udid, object body);

		bool TryFixRefresh(HotfixMode _mode, string _pageName, GameObject go);

		bool TryFixHandler(HotfixMode _mode, string _handlerName, GameObject go);

		void RegistedPtc(uint _type, byte[] body, int length);

		void OnEnterScene();

		void OnEnterSceneFinally();

		void OnAttachToHost();

		void OnReconnect();

		void OnDetachFromHost();
	}
}
