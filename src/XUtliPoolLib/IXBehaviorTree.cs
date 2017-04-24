using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IXBehaviorTree : IXInterface
	{
		void OnStartSkill(uint skillid);

		void OnEndSkill(uint skillid);

		void OnSkillHurt();

		void EnableBehaviorTree(bool enable);

		void SetManual(bool enable);

		float OnGetHeartRate();

		void TickBehaviorTree();

		bool SetBehaviorTree(string location);

		void SetTarget(Transform target);

		void SetNavPoint(Transform navpoint);

		void SetVariable(string name, object value);

		void SetIntByName(string name, int value);

		void SetFloatByName(string name, float value);

		void SetBoolByName(string name, bool value);

		void SetVector3ByName(string name, Vector3 value);

		void SetTransformByName(string name, Transform value);
	}
}
