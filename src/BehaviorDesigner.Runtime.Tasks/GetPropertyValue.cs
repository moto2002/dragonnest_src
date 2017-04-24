using System;
using System.Reflection;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=148"), TaskCategory("Reflection"), TaskDescription("Gets the value from the property specified. Returns success if the property was retrieved."), TaskIcon("{SkinColor}ReflectionIcon.png")]
	public class GetPropertyValue : Action
	{
		[Tooltip("The GameObject to get the property of")]
		public SharedGameObject targetGameObject;

		[Tooltip("The component to get the property of")]
		public SharedString componentName;

		[Tooltip("The name of the property")]
		public SharedString propertyName;

		[RequiredField, Tooltip("The value of the property")]
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
			this.propertyValue.SetValue(property.GetValue(component, null));
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
