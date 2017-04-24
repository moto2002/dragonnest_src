using System;

public class XCylinderTrigger : XTrigger
{
	public enum etrigger_type
	{
		once,
		always
	}

	public string exString;

	public XCylinderTrigger.etrigger_type TriggerType;

	protected override void OnTriggered()
	{
		if (this.exString != null && this.exString.Length > 0)
		{
			this._interface.SetExternalString(this.exString, this.TriggerType == XCylinderTrigger.etrigger_type.once);
		}
	}
}
