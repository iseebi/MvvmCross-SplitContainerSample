using Cirrious.MvvmCross.ViewModels;

namespace SplitContainerSample.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        public MvxCommand GoBranchListCommand
        {
            get
            {
                return _goBranchListCommand ?? (_goBranchListCommand = new MvxCommand(() => ShowViewModel<BranchListViewModel>()));
            }
        }

        MvxCommand _goBranchListCommand;
    }
}
