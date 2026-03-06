using Microsoft.AspNetCore.Mvc;
using static bacics_of_implementation.Controllers.BaseController;

namespace bacics_of_implementation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        public class Person
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        static List<Person> person = new List<Person>
               {
               };
        [HttpGet]
        public IActionResult report()
        {
            return Ok(person);
        }

        [HttpPost]
        public IActionResult addreport(Person per)
        {
            person.Add(per);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult editreport(int id, Person edited)
        {
            var editperson = person.FirstOrDefault(p => p.id == id);
            editperson.name = edited.name;
            editperson.id = edited.id;
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult updatereport(int id, Person updated)
        {
            var updateperson = person.FirstOrDefault(p => p.id == id);
            updateperson.name = updated.name;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletereport(int id)
        {
            var removeperson = person.FirstOrDefault(p => p.id == id);
            if (removeperson == null)
            {
                return NotFound();
            }
            person.Remove(removeperson);
            return Ok();
        }
    }
}
