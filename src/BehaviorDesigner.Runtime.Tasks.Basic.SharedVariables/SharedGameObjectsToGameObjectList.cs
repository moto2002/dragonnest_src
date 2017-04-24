using System;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Sets the SharedGameObjectList values from the GameObjects. Returns Success.")]
	public class SharedGameObjectsToGameObjectList : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObjects value")]
		public SharedGameObject[] gameObjects;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The SharedTransformList to set")]
		public SharedGameObjectList storedGameObjectList;

		public override void OnAwake()
		{
			this.storedGameObjectList.Value = new List<GameObject>();
		}

		public override TaskStatus OnUpdate()
		{
			if (this.gameObjects == null || this.gameObjects.Length == 0)
			{
				return TaskStatus.Failure;
			}
			this.storedGameObjectList.Value.Clear();
			for (int i = 0; i < this.gameObjects.Length; i++)
			{
				this.storedGameObjectList.Value.Add(this.gameObjects[i].Value);
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.gameObjects = null;
			this.storedGameObjectList = null;
		}
	}
}
