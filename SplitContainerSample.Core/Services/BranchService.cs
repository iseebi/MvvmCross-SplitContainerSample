using SplitContainerSample.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace SplitContainerSample.Core.Services
{
    public interface IBranchService
    {
        List<Branch> Branches { get; }
        Branch LookupBranch(string code);
    }

    public class BranchService : IBranchService
    {
        public List<Branch> Branches { get; private set; }

        public BranchService()
        {
            Branches = new List<Branch>
            {
                new Branch { Code = "001", Name = "HQ", Address = "1-3-2 Himawari-cho" },
                new Branch { Code = "002", Name = "Aoba-cho", Address = "1-3-2 Aoba-cho" },
                new Branch { Code = "003", Name = "Kaede-cho", Address = "4-8-9 Kaede-cho" },
                new Branch { Code = "004", Name = "Icho-dori", Address = "1-6-8 Icho-dori" },
            };
        }

        public Branch LookupBranch(string code)
        {
            return Branches.FirstOrDefault(branch => branch.Code == code);
        }
    }
}

