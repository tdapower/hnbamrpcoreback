using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Hospital
{
    public class Hospital
    {
        [Required]
        public int SeqId { get; set; }
        public string HospitalCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string TelephoneNo { get; set; }
        public string Fax { get; set; }
        public string EMail { get; set; }
        public string Remarks { get; set; }
        public string RegisterUserCode { get; set; }
        public string RegisterDate { get; set; }

    }
}

