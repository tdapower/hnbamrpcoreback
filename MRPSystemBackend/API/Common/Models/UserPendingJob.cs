using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Common.Models
{
    public class UserPendingJob
    {

        public string UserCode { get; set; }
        public string UserName { get; set; }
        public int JobCount { get; set; }

    }
}
