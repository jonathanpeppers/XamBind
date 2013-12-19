using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace XamBind.iOS.Tests
{
	public partial class TestController : BindingController
	{
		public TestController (IntPtr handle) : base (handle)
		{
		}

		public UILabel GetLabel()
		{
			return Text;
		}

		public UIButton GetButton()
		{
			return Search;
		}

		public UITextField GetTextField()
		{
			return TextField;
		}

		public void Click()
		{
			Search.SendActionForControlEvents(UIControlEvent.TouchUpInside);
		}
	}
}
