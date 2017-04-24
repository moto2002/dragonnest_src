using System;
using UnityEngine;

namespace UILib
{
	public interface IXUIScrollView : IXUIObject
	{
		void UpdatePosition();

		void ResetPosition();

		void SetPosition(float pos);

		void SetDragPositionX(float pos);

		void SetCustomMovement(Vector2 movement);

		void SetDragFinishDelegate(Delegate func);

		void SetAutoMove(float from, float to, float moveSpeed);

		bool RestrictWithinBounds(bool instant);

		void MoveAbsolute(Vector3 absolute);

		void MoveRelative(Vector3 relative);

		void NeedRecalcBounds();
	}
}
