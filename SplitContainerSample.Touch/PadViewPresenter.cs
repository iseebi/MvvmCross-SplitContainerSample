using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using MonoTouch.UIKit;
using SplitContainerSample.Touch.Views;
using System;

namespace SplitContainerSample.Touch
{
    public class PadViewPresenter : MvxTouchViewPresenter
    {
        protected IPadContainer PadContainer
        {
            get
            {
                IPadContainer value = null;
                _padContainerHolder.TryGetTarget(out value);
                return value;
            }
            set
            {
                _padContainerHolder.SetTarget(value);
            }
        }
        WeakReference<IPadContainer> _padContainerHolder = new WeakReference<IPadContainer>(null);

        public PadViewPresenter(UIApplicationDelegate appDelegate, UIWindow window) : base(appDelegate, window)
        {
        }

        public override void Show(IMvxTouchView view)
        {
            if (view is IPadContainerChild)
            {
                var container = PadContainer;
                var child = view as IPadContainerChild;
                if ((container != null) && (container.GetType() == child.ContainerType))
                {
                    if (container.ShowView(view))
                    {
                        return;
                    }
                }
                container = child.ContainerType.GetConstructor(new Type[0]).Invoke(null) as IPadContainer;
                if (container == null)
                {
                    throw new InvalidOperationException();
                }
                var containerViewController = container as UIViewController;
                containerViewController.View.ToString(); // for load view
                if (container.ShowView(view))
                {
                    PadContainer = container;
                    this.MasterNavigationController.PushViewController(containerViewController, true);
                }
                else
                {
                    containerViewController.Dispose();
                    base.Show(view);
                }
            }
            else
            {
                base.Show(view);
            }
        }
    }
}

