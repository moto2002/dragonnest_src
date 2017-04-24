using System;
using System.Reflection;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=149"), TaskCategory("Reflection"), TaskDescription("Sets the field to the value specified. Returns success if the field was set."), TaskIcon("{SkinColor}ReflectionIcon.png")]
	public class SetFieldValue : Action
	{
		[Tooltip("The GameObject to set the field on")]
		public SharedGameObject targetGameObject;

		[Tooltip("The component to set the field on")]
		public SharedString componentName;

		[Tooltip("The name of the field")]
		public SharedString fieldName;

		[Tooltip("The value to set")]
		public SharedVariable fieldValue;

		public override TaskStatus OnUpdate()
		{
			if (this.fieldValue == null)
			{
				return TaskStatus.Failure;
			}
			Type typeWithinAssembly = TaskUtility.GetTypeWithinAssembly(this.componentName.Value);
			if (typeWithinAssembly == null)
			{
				return TaskStatus.Failure;
			}
			Component component = base.GetDefaultGameObject(this.targetGameObject.Value).GetComponent(typeWithinAssembly);
			if (component == null)
			{
				return TaskStatus.Failure;
			}
			FieldInfo field = component.GetType().GetField(this.fieldName.Value);
			field.SetValue(component, this.fieldValue.GetValue());
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.componentName = null;
			this.fieldName = null;
			this.fieldValue = null;
		}
	}
}
