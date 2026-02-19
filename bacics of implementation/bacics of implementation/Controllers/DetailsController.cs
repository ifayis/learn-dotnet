using bacics_of_implementation.Service;
using Microsoft.AspNetCore.Mvc;

namespace bacics_of_implementation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DetailsController : Controller
    {
        private readonly IDetailsService _detailsService;

        public DetailsController(IDetailsService service)
        {
            _detailsService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_detailsService.GetDetailsAsync());
        }
    }
}
