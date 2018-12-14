using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Employee
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();

        int AddEmployee(Employee emp);
    }
}
