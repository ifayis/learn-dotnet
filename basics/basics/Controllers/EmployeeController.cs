using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using basics.Models;


namespace basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new()
        {
            new Employee {Id = 1, Name = "John", Age = 30, Department = "IT"}
        };

        [HttpGet]
        public IActionResult All()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult ById(int id)
        {
            var emp = employees.FirstOrDefault(i => i.Id == id);
            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        [HttpPost]
        public IActionResult Add(Employee emp)
        {
            emp.Id = employees.Count + 1;
            employees.Add(emp);
            return Ok(emp);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee UpdateEmployee)
        {
            var emp = employees.FirstOrDefault(i => i.Id == id);
            if (emp == null)
                return NotFound();

            emp.Name = UpdateEmployee.Name;
            emp.Age = UpdateEmployee.Age;
            emp.Department = UpdateEmployee.Department;

            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(i => i.Id == id);
            if (emp == null)
                return NotFound();
            employees.Remove(emp);
            return Ok("deleted successfully");
        }
    }
}
