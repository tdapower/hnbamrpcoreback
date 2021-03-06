﻿using MRPSystemBackend.API.LifeAssure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Main
{
    public interface IMainRepository
    {
        IEnumerable<Main> GetAllMainRecords();
        Main GetMainRecordById(int assureId);

        IEnumerable<Main> SearchMainData(SearchMain searchMain);
        IEnumerable<Main> SearchUnassignedMainData(SearchMain searchMain);
        MainSaveReturnObj SaveMain(Main main, Assure assure1, Assure assure2);
        MainSaveReturnObj AddMainRecord(Main assure);
        void UpdateMainRecord(Main assure);
        string GenerateProposalNo(string bankCode);
        void UpdateCustomerIdInMain(int mainId,int assureType,int assureId, IDbConnection connection);
    }
}
