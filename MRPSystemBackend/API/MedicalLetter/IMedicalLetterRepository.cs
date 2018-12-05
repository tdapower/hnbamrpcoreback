using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.MedicalLetter
{
    public interface IMedicalLetterRepository
    {
        int CreateMedicalLetter(MedicalLetter medicalLetter);
      //  int CreateMedicalLetterWithTransaction(MedicalLetter medicalLetter, IDbConnection connection);
        MedicalLetter GetMedicalLetterById(int letterId);
        int UpdateMedicalLetter(MedicalLetter medicalLetter);
        void DeleteMedicalLetterTest(int medicalLetterId, IDbConnection connection);
    }
}
