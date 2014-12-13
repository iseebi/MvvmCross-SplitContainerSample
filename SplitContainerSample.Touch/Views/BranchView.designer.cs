// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace SplitContainerSample.Touch.Views
{
	[Register ("BranchView")]
	partial class BranchView
	{
		[Outlet]
		MonoTouch.UIKit.UILabel AddressLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel CodeLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel NameLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CodeLabel != null) {
				CodeLabel.Dispose ();
				CodeLabel = null;
			}

			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}

			if (AddressLabel != null) {
				AddressLabel.Dispose ();
				AddressLabel = null;
			}
		}
	}
}
