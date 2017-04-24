using System;
using System.Collections;
using System.Collections.Generic;
using WeTest.U3DAutomation;

internal class a : IDictionaryEnumerator
{
	private IEnumerator<KeyValuePair<string, JsonData>> a;

	public object get_Current()
	{
		return this.get_Entry();
	}

	public DictionaryEntry get_Entry()
	{
		KeyValuePair<string, JsonData> current = this.a.Current;
		return new DictionaryEntry(current.Key, current.Value);
	}

	public object get_Key()
	{
		KeyValuePair<string, JsonData> current = this.a.Current;
		return current.Key;
	}

	public object get_Value()
	{
		KeyValuePair<string, JsonData> current = this.a.Current;
		return current.Value;
	}

	public a(IEnumerator<KeyValuePair<string, JsonData>> A_0)
	{
		this.a = A_0;
	}

	public bool MoveNext()
	{
		return this.a.MoveNext();
	}

	public void Reset()
	{
		this.a.Reset();
	}
}
