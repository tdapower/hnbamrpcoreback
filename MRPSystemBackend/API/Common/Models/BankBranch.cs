using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Common.Models
{
    public class BankBranch
    {
        public int BankBranchId { get; set; }
        public int BankId { get; set; }
        public string BankBranchName { get; set; }

        public string BankCode { get; set; }
    }
}
