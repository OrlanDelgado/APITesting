using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TareasApi.Models;
using TareasApi.Services;

namespace TareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TareasApi.Models.Task>> Get() => Ok(_taskService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<TareasApi.Models.Task> Get(int id)
        {
            var task = _taskService.GetById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<TareasApi.Models.Task> Create([FromBody] TareasApi.Models.Task task)
        {
            var createdTask = _taskService.Create(task);
            return CreatedAtAction(nameof(Get), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TareasApi.Models.Task task)
        {
            var existingTask = _taskService.GetById(id);
            if (existingTask == null) return NotFound();

            _taskService.Update(id, task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingTask = _taskService.GetById(id);
            if (existingTask == null) return NotFound();

            _taskService.Delete(id);
            return NoContent();
        }
    }
}
