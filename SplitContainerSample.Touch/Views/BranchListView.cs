using System;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using SplitContainerSample.Core.ViewModels;

namespace SplitContainerSample.Touch.Views
{
    public class BranchListView : MvxTableViewController, IPadContainerChild
    {
        MvxTableViewSource TableViewSource { get; set; }

        public new BranchListViewModel ViewModel 
        {
            get { return base.ViewModel as BranchListViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void Dispose(bool disposing)
        {
            if (TableViewSource != null)
            {
                TableView.Source = null;
                TableViewSource.Dispose();
            }
            base.Dispose(disposing);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableViewSource = new MvxStandardTableViewSource(TableView, "TitleText Name");
            TableView.Source = TableViewSource;

            var set = this.CreateBindingSet<BranchListView, BranchListViewModel>();
            set.Bind(TableViewSource).To(vm => vm.Branches);
            set.Bind(TableViewSource).For(v => v.SelectedItem).To(vm => vm.SelectedBranch);
            set.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                var indexPath = MonoTouch.Foundation.NSIndexPath.FromRowSection(0, 0);
                TableView.SelectRow(indexPath, false, UITableViewScrollPosition.None);
                TableViewSource.RowSelected(TableView, indexPath);
            }
        }

        #region IPadContainerChild implementation

        public Type ContainerType
        {
            get { return typeof(BranchPadContainer); }
        }

        #endregion
    }
}

