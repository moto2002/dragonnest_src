using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
	[TaskCategory("Basic/Animator"), TaskDescription("Sets the float parameter on an animator. Returns Success.")]
	public class SetFloatParameter : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The name of the parameter")]
		public SharedString paramaterName;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The value of the float parameter")]
		public SharedFloat floatValue;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Should the value be reverted back to its original value after it has been set?")]
		public bool setOnce;

		private int hashID;

		private Animator animator;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.animator = defaultGameObject.GetComponent<Animator>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.animator == null)
			{
				UnityEngine.Debug.LogWarning("Animator is null");
				return TaskStatus.Failure;
			}
			this.hashID = Animator.StringToHash(this.paramaterName.Value);
			float @float = this.animator.GetFloat(this.hashID);
			this.animator.SetFloat(this.hashID, this.floatValue.Value);
			if (this.setOnce)
			{
				base.StartCoroutine(this.ResetValue(@float));
			}
			return TaskStatus.Success;
		}

		[DebuggerHidden]
		public IEnumerator ResetValue(float origVale)
		{
			SetFloatParameter.<ResetValue>c__Iterator1 <ResetValue>c__Iterator = new SetFloatParameter.<ResetValue>c__Iterator1();
			<ResetValue>c__Iterator.origVale = origVale;
			<ResetValue>c__Iterator.<$>origVale = origVale;
			<ResetValue>c__Iterator.<>f__this = this;
			return <ResetValue>c__Iterator;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.paramaterName = string.Empty;
			this.floatValue = 0f;
		}
	}
}
