using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void AddEmployee(Employee emp);
        bool UpdateEmployee(int id, Employee emp);
        bool DeleteEmployee(int id);
    }
}
