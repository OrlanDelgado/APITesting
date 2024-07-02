using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TareasApi.Data;
using TareasApi.Models;

namespace TareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly TareasContext _context;

        public TareasController(TareasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tareas>>> GetTareas()
        {
            var tareas = await _context.Tareas.Find(_ => true).ToListAsync();
            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tareas>> GetTarea(string id)
        {
            var tarea = await _context.Tareas.Find(t => t.Id == id).FirstOrDefaultAsync();

            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        [HttpPost]
        public async Task<ActionResult<Tareas>> PostTarea(Tareas tarea)
        {
            await _context.Tareas.InsertOneAsync(tarea);
            return CreatedAtAction("GetTarea", new { id = tarea.Id }, tarea);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarea(string id, Tareas updatedTarea)
        {
            var result = await _context.Tareas.ReplaceOneAsync(t => t.Id == id, updatedTarea);

            if (result.MatchedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(string id)
        {
            var result = await _context.Tareas.DeleteOneAsync(t => t.Id == id);

            if (result.DeletedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
