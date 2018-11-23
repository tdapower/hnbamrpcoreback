using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.WorkflowJob
{
    public class WorkflowJob
    {
        public string JobNo { get; set; }
        public string ProposalNo { get; set; }
        public string LifeAssure1NIC { get; set; }
        public string LifeAssure2NIC { get; set; }
        public string BankCode { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedUserCode { get; set; }

        public string AssignedUserCode { get; set; }
        public string ProposalNoUpdatedDate { get; set; }
        public int IsCancelled { get; set; }
        public string BrokerCode { get; set; }
        public int IsFastTrack { get; set; }
        public int ProposalModeId { get; set; }
        public string WorkflowType { get; set; }
        public int BusinessChannelId { get; set; }
        public int IsFreeCoverLimitProposal { get; set; }
        public int BankId { get; set; }
        public int BankBranchId { get; set; }



    }
}

