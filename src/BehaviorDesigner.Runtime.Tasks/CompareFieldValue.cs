using System;
using System.Reflection;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=151"), TaskCategory("Reflection"), TaskDescription("Compares the field value to the value specified. Returns success if the values are the same."), TaskIcon("{SkinColor}ReflectionIcon.png")]
	public class CompareFieldValue : Conditional
	{
		[Tooltip("The GameObject to compare the field on")]
		public SharedGameObject targetGameObject;

		[Tooltip("The component to compare the field on")]
		public SharedString componentName;

		[Tooltip("The name of the field")]
		public SharedString fieldName;

		[Tooltip("The value to compare to")]
		public SharedVariable compareValue;

		public override TaskStatus OnUpdate()
		{
			if (this.compareValue == null)
			{
				Debug.LogWarning("Unable to compare field - compare value is null");
				return TaskStatus.Failure;
			}
			Type typeWithinAssembly = TaskUtility.GetTypeWithinAssembly(this.componentName.Value);
			if (typeWithinAssembly == null)
			{
				Debug.LogWarning("Unable to compare field - type is null");
				return TaskStatus.Failure;
			}
			Component component = base.GetDefaultGameObject(this.targetGameObject.Value).GetComponent(typeWithinAssembly);
			if (component == null)
			{
				Debug.LogWarning("Unable to compare the field with component " + this.componentName.Value);
				return TaskStatus.Failure;
			}
			FieldInfo field = component.GetType().GetField(this.fieldName.Value);
			object value = field.GetValue(component);
			if (value == null && this.compareValue.GetValue() == null)
			{
				return TaskStatus.Success;
			}
			return (!value.Equals(this.compareValue.GetValue())) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.componentName = null;
			this.fieldName = null;
			this.compareValue = null;
		}
	}
}
