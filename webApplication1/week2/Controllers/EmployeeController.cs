using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeService.GetEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var emp = _employeeService.GetEmployee(id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            _employeeService.AddEmployee(emp);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee emp)
        {
            if (!_employeeService.UpdateEmployee(id, emp)) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (!_employeeService.DeleteEmployee(id)) return NotFound();
            return Ok();
        }
    }
}
