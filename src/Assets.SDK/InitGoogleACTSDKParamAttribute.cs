using System;

namespace Assets.SDK
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public sealed class InitGoogleACTSDKParamAttribute : Attribute
	{
		public bool is_use;

		public string my_id;

		public string my_label;

		public string my_value;

		public InitGoogleACTSDKParamAttribute(bool is_use, string my_id, string my_label, string my_value)
		{
			this.is_use = is_use;
			this.my_id = my_id;
			this.my_label = my_label;
			this.my_value = my_value;
		}
	}
}
