using System;
using System.Reflection;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=152"), TaskCategory("Reflection"), TaskDescription("Compares the property value to the value specified. Returns success if the values are the same."), TaskIcon("{SkinColor}ReflectionIcon.png")]
	public class ComparePropertyValue : Conditional
	{
		[Tooltip("The GameObject to compare the property of")]
		public SharedGameObject targetGameObject;

		[Tooltip("The component to compare the property of")]
		public SharedString componentName;

		[Tooltip("The name of the property")]
		public SharedString propertyName;

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
				Debug.LogWarning("Unable to compare property - type is null");
				return TaskStatus.Failure;
			}
			Component component = base.GetDefaultGameObject(this.targetGameObject.Value).GetComponent(typeWithinAssembly);
			if (component == null)
			{
				Debug.LogWarning("Unable to compare the property with component " + this.componentName.Value);
				return TaskStatus.Failure;
			}
			PropertyInfo property = component.GetType().GetProperty(this.propertyName.Value);
			object value = property.GetValue(component, null);
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
			this.propertyName = null;
			this.compareValue = null;
		}
	}
}
