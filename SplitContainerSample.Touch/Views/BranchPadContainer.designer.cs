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
	[Register ("BranchPadContainer")]
	partial class BranchPadContainer
	{
		[Outlet]
		MonoTouch.UIKit.UIView BranchListViewContainer { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView BranchViewContainer { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BranchListViewContainer != null) {
				BranchListViewContainer.Dispose ();
				BranchListViewContainer = null;
			}

			if (BranchViewContainer != null) {
				BranchViewContainer.Dispose ();
				BranchViewContainer = null;
			}
		}
	}
}
