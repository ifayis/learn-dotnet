using Microsoft.AspNetCore.Mvc;
using review_week2.Model;
using review_week2.Services;

namespace review_week2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpPost]
        public IActionResult Add(Students student)
        {
            return Ok(_studentService.Add(student));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Students student)
        {
            var stu = _studentService.Update(id, student);
            if (stu == null) 
                return NotFound();

            return Ok(stu);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _studentService.Delete(id);
            if (!success) 
                return NotFound();

            return Ok();
        }
    }
}
