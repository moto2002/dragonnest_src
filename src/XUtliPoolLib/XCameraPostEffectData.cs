using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XCameraPostEffectData
	{
		[DefaultValue(0f), SerializeField]
		public float At;

		[DefaultValue(0f), SerializeField]
		public float End;

		[SerializeField]
		public string Effect;

		[SerializeField]
		public string Shader;

		[DefaultValue(false), SerializeField]
		public bool SolidBlack;

		[DefaultValue(0f), SerializeField]
		public float Solid_At;

		[DefaultValue(0f), SerializeField]
		public float Solid_End;
	}
}
