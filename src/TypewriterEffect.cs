using System;
using UnityEngine;

[AddComponentMenu("NGUI/Examples/Typewriter Effect"), RequireComponent(typeof(UILabel))]
public class TypewriterEffect : MonoBehaviour
{
	public int charsPerSecond = 40;

	private UILabel mLabel;

	private string mText;

	private int mOffset;

	private float mNextChar;

	private bool mReset = true;

	private void OnEnable()
	{
		this.mReset = true;
	}

	private void Update()
	{
		if (this.mReset)
		{
			this.mOffset = 0;
			this.mReset = false;
			this.mLabel = base.GetComponent<UILabel>();
			this.mText = this.mLabel.processedText;
		}
		if (this.mOffset < this.mText.Length && this.mNextChar <= RealTime.time)
		{
			this.charsPerSecond = Mathf.Max(1, this.charsPerSecond);
			float num = 1f / (float)this.charsPerSecond;
			char c = this.mText[this.mOffset];
			if (c == '.' || c == '\n' || c == '!' || c == '?')
			{
				num *= 4f;
			}
			NGUIText.ParseSymbol(this.mText, ref this.mOffset);
			this.mNextChar = RealTime.time + num;
			this.mLabel.text = this.mText.Substring(0, ++this.mOffset);
		}
	}
}
