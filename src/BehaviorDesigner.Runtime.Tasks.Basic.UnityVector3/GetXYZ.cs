using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector3
{
	[TaskCategory("Basic/Vector3"), TaskDescription("Stores the X, Y, and Z values of the Vector3.")]
	public class GetXYZ : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Vector3 to get the values of")]
		public SharedVector3 vector3Variable;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The X value")]
		public SharedFloat storeX;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The Y value")]
		public SharedFloat storeY;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The Z value")]
		public SharedFloat storeZ;

		public override TaskStatus OnUpdate()
		{
			this.storeX.Value = this.vector3Variable.Value.x;
			this.storeY.Value = this.vector3Variable.Value.y;
			this.storeZ.Value = this.vector3Variable.Value.z;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.vector3Variable = Vector3.zero;
			this.storeX = (this.storeY = (this.storeZ = 0f));
		}
	}
}
