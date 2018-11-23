using MRPSystemBackend.API.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Common
{
    public interface ICommonRepository
    {

        IEnumerable<Nationality> GetAllNationalities();
        Nationality GetNationalityById(int nationalityID);


        IEnumerable<Bank> GetAllBanks();
        IEnumerable<BankBranch> GetAllBankBranches();

        IEnumerable<BankBranch> GetBankBranchesOfBank(int bankId);
        IEnumerable<Broker> GetAllBrokers();
        IEnumerable<BusinessChannel> GetAllBusinessChannels();

        IEnumerable<ModeOfProposal> GetAllModeOfProposals();
        IEnumerable<MRPUser> GetAllMRPUsers();
        IEnumerable<UserPendingJob> GetPendingJobsOfUsers();


    }
}
