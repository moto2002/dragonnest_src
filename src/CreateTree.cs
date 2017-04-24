using BehaviorDesigner.Runtime;
using System;
using UnityEngine;

public class CreateTree : MonoBehaviour
{
	public ExternalBehaviorTree behaviorTree;

	private void Start()
	{
		BehaviorTree behaviorTree = base.transform.gameObject.AddComponent<BehaviorTree>();
		behaviorTree.ExternalBehavior = this.behaviorTree;
		behaviorTree.StartWhenEnabled = false;
	}
}
