using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using SplitContainerSample.Core.Models;
using SplitContainerSample.Core.Services;

namespace SplitContainerSample.Core.ViewModels
{
    public class BranchListViewModel : MvxViewModel
    {
        #region Services

        protected IBranchService BranchService { get; private set; }

        #endregion

        #region Properties

        public List<Branch> Branches
        {
            get { return BranchService.Branches; }
        }

        public Branch SelectedBranch
        {
            get { return _selectedBranch; }
            set
            {
                _selectedBranch = value;
                if (_selectedBranch != null)
                {
                    ShowBranch(_selectedBranch);
                }
            }
        }
        Branch _selectedBranch;

        public MvxCommand<Branch> ShowBranchCommand
        {
            get
            {
                return _showBranchCommand ?? (_showBranchCommand = new MvxCommand<Branch>(ShowBranch));
            }
        }

        MvxCommand<Branch> _showBranchCommand;

        #endregion

        public BranchListViewModel(IBranchService branchService)
        {
            BranchService = branchService;
        }

        void ShowBranch(Branch branch)
        {
            ShowViewModel<BranchViewModel>(BranchViewModel.CreateParamter(branch));
        }
    }
}

