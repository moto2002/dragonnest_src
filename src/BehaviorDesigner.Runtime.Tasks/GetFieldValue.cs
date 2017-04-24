using System;
using System.Reflection;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=147"), TaskCategory("Reflection"), TaskDescription("Gets the value from the field specified. Returns success if the field was retrieved."), TaskIcon("{SkinColor}ReflectionIcon.png")]
	public class GetFieldValue : Action
	{
		[Tooltip("The GameObject to get the field on")]
		public SharedGameObject targetGameObject;

		[Tooltip("The component to get the field on")]
		public SharedString componentName;

		[Tooltip("The name of the field")]
		public SharedString fieldName;

		[RequiredField, Tooltip("The value of the field")]
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
			this.fieldValue.SetValue(field.GetValue(component));
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
