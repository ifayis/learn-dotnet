using Microsoft.AspNetCore.Mvc;
using week2_day5.Models;

namespace week2_day5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new()
        {
            new Employee { Id = 1, Name = "John", Age = 30, Department = "IT" }
        };

        [HttpGet]
        public IActionResult GetAll() => Ok(employees);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            return emp == null ? NotFound() : Ok(emp);
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            emp.Id = employees.Count + 1;
            employees.Add(emp);
            return Ok(emp);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee updated)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();

            emp.Name = updated.Name;
            emp.Age = updated.Age;
            emp.Department = updated.Department;
            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            employees.Remove(emp);
            return Ok("Deleted");
        }
    }
}
