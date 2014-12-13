using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using SplitContainerSample.Core.Models;
using SplitContainerSample.Core.Services;

namespace SplitContainerSample.Core.ViewModels
{
    public class BranchViewModel : MvxViewModel
    {
        const string BranchParamterKey = "Branch";

        #region Services

        protected IBranchService BranchService { get; private set; }

        #endregion

        #region Properties

        public Branch Branch
        {
            get { return _branch; }
            private set
            {
                _branch = value;
                RaisePropertyChanged(() => Branch);
            }
        }
        Branch _branch;

        #endregion

        public BranchViewModel(IBranchService branchService)
        {
            BranchService = branchService;
        }

        #region ViewModel Lifecycle

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);
            Branch = BranchService.LookupBranch(parameters.Data[BranchParamterKey]);
        }

        #endregion

        #region Static methods

        public static IMvxBundle CreateParamter(Branch branch)
        {
            return new MvxBundle(new Dictionary<string, string> 
                {
                    { BranchParamterKey, branch.Code }
                });
        }

        #endregion
    }
}

