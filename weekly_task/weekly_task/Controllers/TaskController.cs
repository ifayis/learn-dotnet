using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using weekly_Task.Models;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private static List<TaskItem> tasks = new();

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            task.Id = tasks.Count + 1;
            tasks.Add(task);
            return Ok(task);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(tasks);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskItem updated)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();
            task.Title = updated.Title;
            task.Description = updated.Description;
            task.Status = updated.Status;
            return Ok(task);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();
            tasks.Remove(task);
            return Ok(task);
        }
    }
}
