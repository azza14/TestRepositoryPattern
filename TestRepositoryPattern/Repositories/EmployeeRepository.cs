using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestRepositoryPattern.Models;

namespace TestRepositoryPattern.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
         public readonly TestRepositoryPattenEntities context;
        public EmployeeRepository(TestRepositoryPattenEntities _context)
        {
            context = _context;
        }
        public void CreateEmplyoee(Employee employee)
        {
            context.Employees.Add(employee);
            Save();
        }

        public void DeleteEmployee(int id)
        {
            var emp = context.Employees.Find(id);
            if (emp !=null)
            {
                context.Employees.Remove(emp);
            }
        }

        public Employee GetEmployeeById(int id)
        {
           return  context.Employees.Find(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            context.Entry(employee).State = EntityState.Modified;
        }
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}