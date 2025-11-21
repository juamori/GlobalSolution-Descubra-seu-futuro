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
    public class SetorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SetorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setor>>> GetAll()
        {
            return Ok(await _context.Setores.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Setor>> GetById(int id)
        {
            var s = await _context.Setores.FindAsync(id);
            if (s == null) return NotFound();
            return Ok(s);
        }

        [HttpPost]
        public async Task<ActionResult<Setor>> Create([FromBody] Setor setor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Setores.Add(setor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = setor.Id }, setor);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Setor setor)
        {
            if (id != setor.Id)
                return BadRequest("ID não corresponde ao corpo da requisição.");

            var existing = await _context.Setores.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.Nome = setor.Nome;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var setor = await _context.Setores.FindAsync(id);
            if (setor == null) return NotFound();

            _context.Setores.Remove(setor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
