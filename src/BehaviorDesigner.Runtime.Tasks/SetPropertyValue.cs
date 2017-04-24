using System;
using System.Reflection;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=150"), TaskCategory("Reflection"), TaskDescription("Sets the property to the value specified. Returns success if the property was set."), TaskIcon("{SkinColor}ReflectionIcon.png")]
	public class SetPropertyValue : Action
	{
		[Tooltip("The GameObject to set the property on")]
		public SharedGameObject targetGameObject;

		[Tooltip("The component to set the property on")]
		public SharedString componentName;

		[Tooltip("The name of the property")]
		public SharedString propertyName;

		[Tooltip("The value to set")]
		public SharedVariable propertyValue;

		public override TaskStatus OnUpdate()
		{
			if (this.propertyValue == null)
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
			PropertyInfo property = component.GetType().GetProperty(this.propertyName.Value);
			property.SetValue(component, this.propertyValue.GetValue(), null);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.componentName = null;
			this.propertyName = null;
			this.propertyValue = null;
		}
	}
}
