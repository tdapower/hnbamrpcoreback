using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Hospital
{
    public interface IHospitalRepository
    {
        IEnumerable<Hospital> SearchHospitals(SearchHospital searchHospital);

        IEnumerable<Hospital> GetHospitals();
        Hospital GetHospitalById(int hospitalId);

        int AddHospital(Hospital hospital);
        int AddHospitalWithTransaction(Hospital hospital, IDbConnection connection);
        int UpdateHospital(Hospital hospital);

    }
}
