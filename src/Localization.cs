using System;
using System.Collections.Generic;
using UnityEngine;

public static class Localization
{
	public static bool localizationHasBeenSet = false;

	private static string[] mLanguages = null;

	private static Dictionary<string, string> mOldDictionary = new Dictionary<string, string>();

	private static Dictionary<string, string[]> mDictionary = new Dictionary<string, string[]>();

	private static int mLanguageIndex = -1;

	private static string mLanguage;

	public static Dictionary<string, string[]> dictionary
	{
		get
		{
			if (!Localization.localizationHasBeenSet)
			{
				Localization.language = PlayerPrefs.GetString("Language", "English");
			}
			return Localization.mDictionary;
		}
		set
		{
			Localization.localizationHasBeenSet = (value != null);
			Localization.mDictionary = value;
		}
	}

	public static string[] knownLanguages
	{
		get
		{
			if (!Localization.localizationHasBeenSet)
			{
				Localization.LoadDictionary(PlayerPrefs.GetString("Language", "English"));
			}
			return Localization.mLanguages;
		}
	}

	public static string language
	{
		get
		{
			if (string.IsNullOrEmpty(Localization.mLanguage))
			{
				string[] knownLanguages = Localization.knownLanguages;
				Localization.mLanguage = PlayerPrefs.GetString("Language", (knownLanguages == null) ? "English" : knownLanguages[0]);
				Localization.LoadAndSelect(Localization.mLanguage);
			}
			return Localization.mLanguage;
		}
		set
		{
			if (Localization.mLanguage != value)
			{
				Localization.mLanguage = value;
				Localization.LoadAndSelect(value);
			}
		}
	}

	private static bool LoadDictionary(string value)
	{
		TextAsset textAsset = (!Localization.localizationHasBeenSet) ? (Resources.Load("Table/Local/Localization", typeof(TextAsset)) as TextAsset) : null;
		Localization.localizationHasBeenSet = true;
		if (textAsset != null && Localization.LoadCSV(textAsset))
		{
			return true;
		}
		if (string.IsNullOrEmpty(value))
		{
			return false;
		}
		textAsset = (Resources.Load(value, typeof(TextAsset)) as TextAsset);
		if (textAsset != null)
		{
			Localization.Load(textAsset);
			return true;
		}
		return false;
	}

	private static bool LoadAndSelect(string value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			if (Localization.mDictionary.Count == 0 && !Localization.LoadDictionary(value))
			{
				return false;
			}
			if (Localization.SelectLanguage(value))
			{
				return true;
			}
		}
		Localization.mOldDictionary.Clear();
		if (string.IsNullOrEmpty(value))
		{
			PlayerPrefs.DeleteKey("Language");
		}
		return false;
	}

	public static void Load(TextAsset asset)
	{
		ByteReader byteReader = new ByteReader(asset);
		Localization.Set(asset.name, byteReader.ReadDictionary());
	}

	public static bool LoadCSV(TextAsset asset)
	{
		ByteReader byteReader = new ByteReader(asset);
		BetterList<string> betterList = byteReader.ReadCSV();
		if (betterList.size < 2)
		{
			return false;
		}
		betterList[0] = "KEY";
		if (!string.Equals(betterList[0], "KEY"))
		{
			Debug.LogError("Invalid localization CSV file. The first value is expected to be 'KEY', followed by language columns.\nInstead found '" + betterList[0] + "'", asset);
			return false;
		}
		Localization.mLanguages = new string[betterList.size - 1];
		for (int i = 0; i < Localization.mLanguages.Length; i++)
		{
			Localization.mLanguages[i] = betterList[i + 1];
		}
		Localization.mDictionary.Clear();
		while (betterList != null)
		{
			Localization.AddCSV(betterList);
			betterList = byteReader.ReadCSV();
		}
		return true;
	}

	private static bool SelectLanguage(string language)
	{
		Localization.mLanguageIndex = -1;
		if (Localization.mDictionary.Count == 0)
		{
			return false;
		}
		string[] array;
		if (Localization.mDictionary.TryGetValue("KEY", out array))
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == language)
				{
					Localization.mOldDictionary.Clear();
					Localization.mLanguageIndex = i;
					Localization.mLanguage = language;
					PlayerPrefs.SetString("Language", Localization.mLanguage);
					UIRoot.Broadcast("OnLocalize");
					return true;
				}
			}
		}
		return false;
	}

	private static void AddCSV(BetterList<string> values)
	{
		if (values.size < 2)
		{
			return;
		}
		string[] array = new string[values.size - 1];
		for (int i = 1; i < values.size; i++)
		{
			array[i - 1] = values[i];
		}
		Localization.mDictionary.Add(values[0], array);
	}

	public static void Set(string languageName, Dictionary<string, string> dictionary)
	{
		Localization.mLanguage = languageName;
		PlayerPrefs.SetString("Language", Localization.mLanguage);
		Localization.mOldDictionary = dictionary;
		Localization.localizationHasBeenSet = false;
		Localization.mLanguageIndex = -1;
		Localization.mLanguages = new string[]
		{
			languageName
		};
		UIRoot.Broadcast("OnLocalize");
	}

	public static string Get(int key)
	{
		return Localization.Get(key.ToString());
	}

	public static string Get(string key)
	{
		if (!Localization.localizationHasBeenSet)
		{
			Localization.language = PlayerPrefs.GetString("Language", "English");
		}
		if (key == null)
		{
			return null;
		}
		string result;
		if (HotfixManager.Instance.hotmsglist.TryGetValue(key, out result))
		{
			return result;
		}
		string[] array;
		if (Localization.mLanguageIndex != -1 && Localization.mDictionary.TryGetValue(key, out array) && Localization.mLanguageIndex < array.Length)
		{
			return array[Localization.mLanguageIndex];
		}
		return key;
	}

	[Obsolete("Use Localization.Get instead")]
	public static string Localize(string key)
	{
		return Localization.Get(key);
	}

	public static bool Exists(string key)
	{
		if (Localization.mLanguageIndex != -1)
		{
			return Localization.mDictionary.ContainsKey(key);
		}
		return Localization.mOldDictionary.ContainsKey(key);
	}
}
