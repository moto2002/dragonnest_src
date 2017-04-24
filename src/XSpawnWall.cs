using System;

public class XSpawnWall : XWall
{
	public enum etrigger_type
	{
		once,
		always
	}

	public string exString;

	public XSpawnWall.etrigger_type TriggerType;

	protected override void OnTriggered()
	{
		if (this.exString != null && this.exString.Length > 0)
		{
			this._interface.SetExternalString(this.exString, this.TriggerType == XSpawnWall.etrigger_type.once);
		}
	}
}
