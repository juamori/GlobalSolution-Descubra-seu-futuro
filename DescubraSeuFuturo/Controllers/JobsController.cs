using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using DescubraSeuFuturo.Data;
using DescubraSeuFuturo.Models;

namespace DescubraSeuFuturo
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<JobsController> _logger;

        public JobsController(AppDbContext db, ILogger<JobsController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // GET: api/v1/jobs
        [HttpGet]
        public ActionResult<IEnumerable<Job>> GetAll()
        {
            var jobs = _db.Jobs.ToList();
            _logger.LogInformation("GET /jobs - retornou {Count} vagas", jobs.Count);
            return Ok(jobs);
        }

        // GET: api/v1/jobs/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Job> GetById(int id)
        {
            var job = _db.Jobs.Find(id);

            if (job == null)
            {
                _logger.LogWarning("GET /jobs/{Id} - vaga não encontrada", id);
                return NotFound();
            }

            _logger.LogInformation("GET /jobs/{Id} - vaga encontrada", id);
            return Ok(job);
        }

        // POST: api/v1/jobs
        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job job)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("POST /jobs - dados inválidos");
                return BadRequest(ModelState);
            }

            _db.Jobs.Add(job);
            _db.SaveChanges();

            _logger.LogInformation("POST /jobs - vaga criada com Id {Id}", job.Id);

            return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
        }

        // PUT: api/v1/jobs/{id}
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Job job)
        {
            if (id != job.Id)
            {
                _logger.LogWarning("PUT /jobs/{Id} - id do corpo não bate", id);
                return BadRequest("Id do corpo não corresponde ao id da rota.");
            }

            var existingJob = _db.Jobs.Find(id);
            if (existingJob == null)
            {
                _logger.LogWarning("PUT /jobs/{Id} - vaga não encontrada", id);
                return NotFound();
            }

            existingJob.Titulo = job.Titulo;
            existingJob.Empresa = job.Empresa;
            existingJob.Local = job.Local;
            existingJob.Descricao = job.Descricao;
            existingJob.Salario = job.Salario;

            _db.SaveChanges();

            _logger.LogInformation("PUT /jobs/{Id} - vaga atualizada", id);

            return NoContent();
        }

        // DELETE: api/v1/jobs/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var job = _db.Jobs.Find(id);

            if (job == null)
            {
                _logger.LogWarning("DELETE /jobs/{Id} - vaga não encontrada", id);
                return NotFound();
            }

            _db.Jobs.Remove(job);
            _db.SaveChanges();

            _logger.LogInformation("DELETE /jobs/{Id} - vaga excluída", id);

            return NoContent();
        }
    }
}
