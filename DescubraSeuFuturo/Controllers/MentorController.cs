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
    public class MentorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MentorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mentor>>> GetAll()
        {
            return Ok(await _context.Mentores.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Mentor>> GetById(int id)
        {
            var mentor = await _context.Mentores.FindAsync(id);

            if (mentor == null)
                return NotFound();

            return Ok(mentor);
        }

        [HttpPost]
        public async Task<ActionResult<Mentor>> Create([FromBody] Mentor mentor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Mentores.Add(mentor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = mentor.Id }, mentor);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Mentor mentor)
        {
            if (id != mentor.Id)
                return BadRequest("O ID da rota não corresponde ao ID enviado.");

            var existing = await _context.Mentores.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.Nome = mentor.Nome;
            existing.AreaAtuacao = mentor.AreaAtuacao;
            existing.Descricao = mentor.Descricao;
            existing.Contato = mentor.Contato;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mentor = await _context.Mentores.FindAsync(id);

            if (mentor == null)
                return NotFound();

            _context.Mentores.Remove(mentor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
