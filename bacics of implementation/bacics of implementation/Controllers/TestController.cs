using bacics_of_implementation.Service;
using Microsoft.AspNetCore.Mvc;
using bacics_of_implementation.Models;
using System.Threading.Tasks;

namespace bacics_of_implementation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ItestService Service;

        public TestController(ItestService testService)
        {
            Service = testService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Service.GetAllData());
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            return Ok(Service.GetById(id));
        }

        [HttpPost]
        public IActionResult Createitem(test tested)
        {
            return Ok(Service.create(tested));
        }

        [HttpPut("{id}")]
        public IActionResult Updateitem(int id, test tested)
        {
            return Ok(Service.update(id, tested));
        }

        [HttpDelete]
        public IActionResult delete(int id)
        {
            return Ok(Service.delete(id)); 
        }
    }
}
