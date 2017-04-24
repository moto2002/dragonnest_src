using System;
using System.Collections.Generic;
using UnityEngine;

public struct UniWebViewMessage
{
	public string rawMessage
	{
		get;
		private set;
	}

	public string scheme
	{
		get;
		private set;
	}

	public string path
	{
		get;
		private set;
	}

	public Dictionary<string, string> args
	{
		get;
		private set;
	}

	public UniWebViewMessage(string rawMessage)
	{
		this.rawMessage = rawMessage;
		string[] array = rawMessage.Split(new string[]
		{
			"://"
		}, StringSplitOptions.None);
		if (array.Length >= 2)
		{
			this.scheme = array[0];
			string text = string.Empty;
			for (int i = 1; i < array.Length; i++)
			{
				text += array[i];
			}
			string[] array2 = text.Split(new char[]
			{
				"?"[0]
			});
			this.path = array2[0];
			this.args = new Dictionary<string, string>();
			if (array2.Length > 1)
			{
				string[] array3 = array2[1].Split(new char[]
				{
					"&"[0]
				});
				for (int j = 0; j < array3.Length; j++)
				{
					string text2 = array3[j];
					string[] array4 = text2.Split(new char[]
					{
						"="[0]
					});
					if (array4.Length > 1)
					{
						this.args[array4[0]] = WWW.UnEscapeURL(array4[1]);
					}
				}
			}
		}
		else
		{
			Debug.LogError("Bad url scheme. Can not be parsed to UniWebViewMessage: " + rawMessage);
		}
	}
}
