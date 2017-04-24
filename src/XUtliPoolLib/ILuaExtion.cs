using System;

namespace XUtliPoolLib
{
	public interface ILuaExtion : IXInterface
	{
		void SetPlayerProprerty(string key, object value);

		object GetPlayeProprerty(string key);

		object CallPlayerMethod(bool isPublic, string method, params object[] args);

		object GetDocumentMember(string doc, string key, bool isPublic, bool isField);

		object GetDocumentStaticMember(string doc, string key, bool isPublic, bool isField);

		void SetDocumentMember(string doc, string key, object value, bool isPublic, bool isField);

		object CallDocumentMethod(string doc, bool isPublic, string method, params object[] args);

		object CallDocumentStaticMethod(string doc, bool isPublic, string method, params object[] args);

		object GetSingleMember(string className, string key, bool isPublic, bool isField, bool isStatic);

		void SetSingleMember(string className, string key, object value, bool isPublic, bool isField, bool isStatic);

		object CallSingleMethod(string className, bool isPublic, bool isStatic, string methodName, params object[] args);

		void RefreshPlayerName();

		Type GetType(string classname);

		object GetEnumType(string classname, string value);

		string GetStringTable(string key, params object[] args);

		string GetGlobalString(string key);

		XLuaLong Get(string str);
	}
}
