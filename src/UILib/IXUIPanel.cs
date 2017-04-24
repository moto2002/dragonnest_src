using System;
using UnityEngine;

namespace UILib
{
	public interface IXUIPanel : IXUIObject
	{
		Vector2 offset
		{
			get;
			set;
		}

		Vector2 softness
		{
			get;
			set;
		}

		Vector4 ClipRange
		{
			get;
			set;
		}

		Action onMoveDel
		{
			get;
			set;
		}

		Component UIComponent
		{
			get;
		}

		void SetSize(float width, float height);

		void SetAlpha(float a);

		float GetAlpha();

		void SetDepth(int d);

		int GetDepth();

		Vector4 GetBaseRect();
	}
}
