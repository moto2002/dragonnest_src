using System;

public class XCutsceneWall : XWall
{
	public string CutScene;

	private bool _played;

	protected override void OnTriggered()
	{
		if (this._played)
		{
			return;
		}
		this._interface.PlayCutScene(this.CutScene);
		this._played = true;
	}
}
