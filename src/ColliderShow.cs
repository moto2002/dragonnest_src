using System;
using UnityEngine;

public class ColliderShow : MonoBehaviour
{
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Collider[] componentsInChildren = base.gameObject.GetComponentsInChildren<Collider>();
		Collider[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			Collider collider = array[i];
			BoxCollider boxCollider = collider as BoxCollider;
			if (boxCollider != null)
			{
				Transform transform = boxCollider.transform;
				Matrix4x4 localToWorldMatrix = transform.localToWorldMatrix;
				Gizmos.matrix = localToWorldMatrix;
				Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
			}
			Gizmos.matrix = Matrix4x4.identity;
			CapsuleCollider capsuleCollider = collider as CapsuleCollider;
			if (capsuleCollider != null)
			{
				Transform transform2 = capsuleCollider.transform;
				Gizmos.DrawWireSphere(transform2.position + new Vector3(0f, 50f, 0f), transform2.localScale.x * capsuleCollider.radius);
			}
		}
	}
}
