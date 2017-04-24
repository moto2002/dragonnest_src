using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=23"), TaskIcon("{SkinColor}EntryIcon.png")]
	public class EntryTask : ParentTask
	{
		public override int MaxChildren()
		{
			return 1;
		}
	}
}
