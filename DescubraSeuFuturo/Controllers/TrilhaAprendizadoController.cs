using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DescubraSeuFuturo.Data;
using DescubraSeuFuturo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DescubraSeuFuturo
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TrilhaAprendizadoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TrilhaAprendizadoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrilhaAprendizado>>> GetAll()
        {
            return Ok(await _context.TrilhasAprendizado.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TrilhaAprendizado>> GetById(int id)
        {
            var trilha = await _context.TrilhasAprendizado.FindAsync(id);
            if (trilha == null) return NotFound();
            return Ok(trilha);
        }

        [HttpPost]
        public async Task<ActionResult<TrilhaAprendizado>> Create([FromBody] TrilhaAprendizado trilha)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.TrilhasAprendizado.Add(trilha);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = trilha.Id }, trilha);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TrilhaAprendizado trilha)
        {
            if (id != trilha.Id)
                return BadRequest("ID não corresponde ao corpo.");

            var existing = await _context.TrilhasAprendizado.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Nome = trilha.Nome;
            existing.Descricao = trilha.Descricao;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var trilha = await _context.TrilhasAprendizado.FindAsync(id);
            if (trilha == null) return NotFound();

            _context.TrilhasAprendizado.Remove(trilha);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
