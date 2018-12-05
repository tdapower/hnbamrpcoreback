using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Common.Models
{
    public class SignPerson
    {
        public int SeqId { get; set; }
        public string Name { get; set; }
        public string UserCode { get; set; }
        public string Designation { get; set; }
    }
}
