using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XCameraEffectData : XBaseData
	{
		[DefaultValue(0f), SerializeField]
		public float Time;

		[DefaultValue(0f), SerializeField]
		public float FovAmp;

		[DefaultValue(0f), SerializeField]
		public float Frequency;

		[SerializeField]
		public CameraMotionSpace Coordinate;

		[DefaultValue(true), SerializeField]
		public bool ShakeX;

		[DefaultValue(true), SerializeField]
		public bool ShakeY;

		[DefaultValue(true), SerializeField]
		public bool ShakeZ;

		[DefaultValue(0f), SerializeField]
		public float AmplitudeX;

		[DefaultValue(0f), SerializeField]
		public float AmplitudeY;

		[DefaultValue(0f), SerializeField]
		public float AmplitudeZ;

		[DefaultValue(0f), SerializeField]
		public float At;

		[DefaultValue(false), SerializeField]
		public bool Random;

		[DefaultValue(false), SerializeField]
		public bool Combined;

		public XCameraEffectData()
		{
			this.ShakeX = true;
			this.ShakeY = true;
			this.ShakeZ = true;
		}
	}
}
