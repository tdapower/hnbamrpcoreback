using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.MedicalTest
{
    public interface IMedicalTestRepository
    {
        IEnumerable<MedicalTest> GetMedicalTests();
    }
}
