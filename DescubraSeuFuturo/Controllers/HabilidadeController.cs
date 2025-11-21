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
    public class HabilidadeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HabilidadeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habilidade>>> GetAll()
        {
            return Ok(await _context.Habilidades.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Habilidade>> GetById(int id)
        {
            var hab = await _context.Habilidades.FindAsync(id);
            if (hab == null) return NotFound();
            return Ok(hab);
        }

        [HttpPost]
        public async Task<ActionResult<Habilidade>> Create([FromBody] Habilidade habilidade)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Habilidades.Add(habilidade);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = habilidade.Id }, habilidade);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Habilidade habilidade)
        {
            if (id != habilidade.Id)
                return BadRequest("ID não corresponde ao corpo da requisição.");

            var existing = await _context.Habilidades.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.Nome = habilidade.Nome;
            existing.Descricao = habilidade.Descricao;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hab = await _context.Habilidades.FindAsync(id);
            if (hab == null) return NotFound();

            _context.Habilidades.Remove(hab);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
