using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRepositoryPattern.Models;

namespace TestRepositoryPattern.Repositories
{
  public  interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        void CreateEmplyoee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
        void Save();




    }
}
