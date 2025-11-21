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
    public class EmpregabilidadeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpregabilidadeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empregabilidade>>> GetAll()
        {
            var lista = await _context.Empregabilidades.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Empregabilidade>> GetById(int id)
        {
            var emp = await _context.Empregabilidades
                .FirstOrDefaultAsync(e => e.Id == id);

            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        [HttpPost]
        public async Task<ActionResult<Empregabilidade>> Create([FromBody] Empregabilidade empregabilidade)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Empregabilidades.Add(empregabilidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = empregabilidade.Id }, empregabilidade);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Empregabilidade empregabilidade)
        {
            if (id != empregabilidade.Id)
                return BadRequest("ID da rota não corresponde ao ID do corpo.");

            var existente = await _context.Empregabilidades.FindAsync(id);

            if (existente == null)
                return NotFound();

            existente.Area = empregabilidade.Area;
            existente.TaxaCrescimento = empregabilidade.TaxaCrescimento;
            existente.Fonte = empregabilidade.Fonte;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _context.Empregabilidades.FindAsync(id);

            if (emp == null)
                return NotFound();

            _context.Empregabilidades.Remove(emp);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
