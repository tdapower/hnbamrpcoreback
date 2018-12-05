using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.MedicalLetter
{
    public class MedicalLetter
    {
        public int SeqId { get; set; }
        public int AssureId { get; set; }
        public int MainId { get; set; }
        public int HospitalId { get; set; }
        public string LetterDate { get; set; }
        public string LetterType { get; set; }
        public string SignPersonUserCode { get; set; }
        public string Document { get; set; }
        public string SystemDate { get; set; }
        public string GeneratedUser { get; set; }

        public List<int> SelectedMedicalTests { get; set; }
    }
}
