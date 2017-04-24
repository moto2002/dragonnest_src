using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=16"), TaskDescription("Log is a simple task which will output the specified text and return success. It can be used for debugging."), TaskIcon("{SkinColor}LogIcon.png")]
	public class Log : Action
	{
		[Tooltip("Text to output to the log")]
		public SharedString text;

		[Tooltip("Is this text an error?")]
		public SharedBool logError;

		public override TaskStatus OnUpdate()
		{
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.text = string.Empty;
			this.logError = false;
		}
	}
}
