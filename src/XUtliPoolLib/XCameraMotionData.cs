using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XCameraMotionData : ICloneable
	{
		[DefaultValue(0f), SerializeField]
		public float At;

		public string Motion;

		public CameraMotionType MotionType = CameraMotionType.CameraBased;

		[SerializeField]
		public string Motion3D;

		[SerializeField]
		public CameraMotionType Motion3DType = CameraMotionType.CameraBased;

		[SerializeField]
		public string Motion2_5D;

		[SerializeField]
		public CameraMotionType Motion2_5DType = CameraMotionType.CameraBased;

		[DefaultValue(false), SerializeField]
		public bool LookAt_Target;

		[DefaultValue(true), SerializeField]
		public bool Follow_Position;

		[DefaultValue(false), SerializeField]
		public bool AutoSync_At_Begin;

		[SerializeField]
		public CameraMotionSpace Coordinate;

		public XCameraMotionData()
		{
			this.Follow_Position = true;
		}

		public object Clone()
		{
			return base.MemberwiseClone();
		}
	}
}
