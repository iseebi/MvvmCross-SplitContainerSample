using System;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using SplitContainerSample.Core.ViewModels;

namespace SplitContainerSample.Touch.Views
{
    public partial class BranchView : MvxViewController, IPadContainerChild
    {
        public BranchView() : base("BranchView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<BranchView, BranchViewModel>();
            set.Bind(CodeLabel).To(vm => vm.Branch.Code);
            set.Bind(NameLabel).To(vm => vm.Branch.Name);
            set.Bind(AddressLabel).To(vm => vm.Branch.Address);
            set.Apply();
        }

        #region IPadContainerChild implementation

        public Type ContainerType
        {
            get { return typeof(BranchPadContainer); }
        }

        #endregion
    }
}

