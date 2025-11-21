using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DescubraSeuFuturo.Data;
using DescubraSeuFuturo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DescubraSeuFuturo
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CompetenciaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompetenciaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competencia>>> GetAll()
        {
            var competencias = await _context.Competencias
                .Include(c => c.Setor)
                .ToListAsync();

            return Ok(competencias);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Competencia>> GetById(int id)
        {
            var competencia = await _context.Competencias
                .Include(c => c.Setor)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (competencia == null)
                return NotFound();

            return Ok(competencia);
        }

        [HttpPost]
        public async Task<ActionResult<Competencia>> Create([FromBody] Competencia competencia)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Competencias.Add(competencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = competencia.Id }, competencia);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Competencia competencia)
        {
            if (id != competencia.Id)
                return BadRequest("O ID do corpo não corresponde ao ID da rota.");

            var existing = await _context.Competencias.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.Nome = competencia.Nome;
            existing.NivelDemanda = competencia.NivelDemanda;
            existing.Descricao = competencia.Descricao;
            existing.SetorId = competencia.SetorId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var competencia = await _context.Competencias.FindAsync(id);

            if (competencia == null)
                return NotFound();

            _context.Competencias.Remove(competencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
