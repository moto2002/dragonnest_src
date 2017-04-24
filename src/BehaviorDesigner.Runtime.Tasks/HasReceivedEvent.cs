using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=123"), TaskDescription("Returns success as soon as the event specified by eventName has been received."), TaskIcon("{SkinColor}HasReceivedEventIcon.png")]
	public class HasReceivedEvent : Conditional
	{
		[Tooltip("The name of the event to receive")]
		public SharedString eventName = string.Empty;

		[SharedRequired, Tooltip("Optionally store the first sent argument")]
		public SharedVariable storedValue1;

		[SharedRequired, Tooltip("Optionally store the second sent argument")]
		public SharedVariable storedValue2;

		[SharedRequired, Tooltip("Optionally store the third sent argument")]
		public SharedVariable storedValue3;

		private bool eventReceived;

		public override void OnAwake()
		{
			base.Owner.RegisterEvent(this.eventName.Value, new System.Action(this.ReceivedEvent));
			base.Owner.RegisterEvent<object>(this.eventName.Value, new Action<object>(this.ReceivedEvent));
			base.Owner.RegisterEvent<object, object>(this.eventName.Value, new Action<object, object>(this.ReceivedEvent));
			base.Owner.RegisterEvent<object, object, object>(this.eventName.Value, new Action<object, object, object>(this.ReceivedEvent));
		}

		public override TaskStatus OnUpdate()
		{
			return (!this.eventReceived) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnEnd()
		{
			this.eventReceived = false;
		}

		private void ReceivedEvent()
		{
			this.eventReceived = true;
		}

		private void ReceivedEvent(object arg1)
		{
			this.ReceivedEvent();
			if (this.storedValue1 != null && !this.storedValue1.IsNone)
			{
				this.storedValue1.SetValue(arg1);
			}
		}

		private void ReceivedEvent(object arg1, object arg2)
		{
			this.ReceivedEvent();
			if (this.storedValue1 != null && !this.storedValue1.IsNone)
			{
				this.storedValue1.SetValue(arg1);
			}
			if (this.storedValue2 != null && !this.storedValue2.IsNone)
			{
				this.storedValue2.SetValue(arg2);
			}
		}

		private void ReceivedEvent(object arg1, object arg2, object arg3)
		{
			this.ReceivedEvent();
			if (this.storedValue1 != null && !this.storedValue1.IsNone)
			{
				this.storedValue1.SetValue(arg1);
			}
			if (this.storedValue2 != null && !this.storedValue2.IsNone)
			{
				this.storedValue2.SetValue(arg2);
			}
			if (this.storedValue3 != null && !this.storedValue3.IsNone)
			{
				this.storedValue3.SetValue(arg3);
			}
		}

		public override void OnBehaviorComplete()
		{
			base.Owner.UnregisterEvent(this.eventName.Value, new System.Action(this.ReceivedEvent));
			base.Owner.UnregisterEvent<object>(this.eventName.Value, new Action<object>(this.ReceivedEvent));
			base.Owner.UnregisterEvent<object, object>(this.eventName.Value, new Action<object, object>(this.ReceivedEvent));
			base.Owner.UnregisterEvent<object, object, object>(this.eventName.Value, new Action<object, object, object>(this.ReceivedEvent));
		}

		public override void OnReset()
		{
			this.eventName = string.Empty;
		}
	}
}
