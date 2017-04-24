using System;

public class XTerminalWall : XWall
{
	public string exString;

	private bool reported;

	protected override void OnTriggered()
	{
		if (!this.reported && this.exString != null && this.exString.Length > 0)
		{
			this._interface.SetExternalString(this.exString, true);
			this.reported = true;
		}
	}
}
