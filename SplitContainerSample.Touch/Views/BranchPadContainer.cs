
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Views;

namespace SplitContainerSample.Touch.Views
{
    public partial class BranchPadContainer : UIViewController, IPadContainer
    {
        public BranchPadContainer() : base("BranchPadContainer", null)
        {
        }

        protected override void Dispose(bool disposing)
        {
            BranchListView = null;
            BranchView = null;
            base.Dispose(disposing);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public BranchListView BranchListView
        {
            get { return _branchListView; }
            set
            {
                SwitchChildViewController(ref _branchListView, value, BranchListViewContainer);
            }
        }
        BranchListView _branchListView;

        public BranchView BranchView
        {
            get { return _branchView; }
            set
            {
                SwitchChildViewController(ref _branchView, value, BranchViewContainer);
            }
        }
        BranchView _branchView;

        private UIViewController SwitchChildViewController<T>(ref T assignViewController, UIViewController newViewController, UIView containerView)
            where T : UIViewController
        {
            if (assignViewController != null)
            {
                assignViewController.WillMoveToParentViewController(null);
                assignViewController.View.RemoveFromSuperview();
                assignViewController.RemoveFromParentViewController();
                assignViewController.Dispose();
            }
            assignViewController = newViewController as T;
            if (assignViewController != null) {
                AddChildViewController(assignViewController);
                assignViewController.View.Frame = BranchListViewContainer.Bounds;
                containerView.AddSubview(assignViewController.View);
                assignViewController.DidMoveToParentViewController(this);
            }
            return assignViewController;
        }
           

        #region IPadContainer implementation

        public bool ShowView(IMvxView view)
        {
            if (view is BranchListView)
            {
                BranchListView = view as BranchListView;
                return true;
            }
            if (view is BranchView)
            {
                BranchView = view as BranchView;
                return true;
            }
            return false;
        }

        #endregion
    }
}

