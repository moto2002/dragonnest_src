using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=145"), TaskCategory("Reflection"), TaskDescription("Invokes the specified method with the specified parameters. Can optionally store the return value. Returns success if the method was invoked."), TaskIcon("{SkinColor}ReflectionIcon.png")]
	public class InvokeMethod : Action
	{
		[Tooltip("The GameObject to invoke the method on")]
		public SharedGameObject targetGameObject;

		[Tooltip("The component to invoke the method on")]
		public SharedString componentName;

		[Tooltip("The name of the method")]
		public SharedString methodName;

		[Tooltip("The first parameter of the method")]
		public SharedVariable parameter1;

		[Tooltip("The second parameter of the method")]
		public SharedVariable parameter2;

		[Tooltip("The third parameter of the method")]
		public SharedVariable parameter3;

		[Tooltip("The fourth parameter of the method")]
		public SharedVariable parameter4;

		[Tooltip("Store the result of the invoke call")]
		public SharedVariable storeResult;

		public override TaskStatus OnUpdate()
		{
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
			List<object> list = new List<object>();
			List<Type> list2 = new List<Type>();
			for (int i = 0; i < 4; i++)
			{
				FieldInfo field = base.GetType().GetField("parameter" + (i + 1));
				SharedVariable sharedVariable;
				if ((sharedVariable = (field.GetValue(this) as SharedVariable)) == null)
				{
					break;
				}
				list.Add(sharedVariable.GetValue());
				list2.Add(sharedVariable.GetType().GetProperty("Value").PropertyType);
			}
			MethodInfo method = component.GetType().GetMethod(this.methodName.Value, list2.ToArray());
			if (method == null)
			{
				return TaskStatus.Failure;
			}
			object value = method.Invoke(component, list.ToArray());
			if (this.storeResult != null)
			{
				this.storeResult.SetValue(value);
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.componentName = null;
			this.methodName = null;
			this.parameter1 = null;
			this.parameter2 = null;
			this.parameter3 = null;
			this.parameter4 = null;
			this.storeResult = null;
		}
	}
}
