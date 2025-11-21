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
    public class CursoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CursoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetAll()
        {
            var cursos = await _context.Cursos
                .Include(c => c.TrilhaAprendizado)
                .ToListAsync();

            return Ok(cursos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Curso>> GetById(int id)
        {
            var curso = await _context.Cursos
                .Include(c => c.TrilhaAprendizado)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (curso == null)
                return NotFound();

            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult<Curso>> Create([FromBody] Curso curso)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = curso.Id }, curso);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Curso curso)
        {
            if (id != curso.Id)
                return BadRequest("O ID do corpo não corresponde ao ID da rota.");

            var existing = await _context.Cursos.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.Nome = curso.Nome;
            existing.Plataforma = curso.Plataforma;
            existing.Link = curso.Link;
            existing.DuracaoHoras = curso.DuracaoHoras;
            existing.TrilhaAprendizadoId = curso.TrilhaAprendizadoId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);

            if (curso == null)
                return NotFound();

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
