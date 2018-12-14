using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Employee
{
    public class Employee
    {
        public int SeqId { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Department { get; set; }
    }
}

