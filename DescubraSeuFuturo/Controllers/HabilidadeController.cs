using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DescubraSeuFuturo.Data;
using DescubraSeuFuturo.Models;

namespace DescubraSeuFuturo
{
    [ApiController]
    public class HabilidadeController : Controller
    {
        private readonly AppDbContext _context;

        public HabilidadeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Habilidade
        public async Task<IActionResult> Index()
        {
            return View(await _context.Habilidades.ToListAsync());
        }

        // GET: Habilidade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilidade = await _context.Habilidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habilidade == null)
            {
                return NotFound();
            }

            return View(habilidade);
        }

        // GET: Habilidade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habilidade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Tipo,Descricao")] Habilidade habilidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habilidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habilidade);
        }

        // GET: Habilidade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilidade = await _context.Habilidades.FindAsync(id);
            if (habilidade == null)
            {
                return NotFound();
            }
            return View(habilidade);
        }

        // POST: Habilidade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Tipo,Descricao")] Habilidade habilidade)
        {
            if (id != habilidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habilidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabilidadeExists(habilidade.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(habilidade);
        }

        // GET: Habilidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilidade = await _context.Habilidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habilidade == null)
            {
                return NotFound();
            }

            return View(habilidade);
        }

        // POST: Habilidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habilidade = await _context.Habilidades.FindAsync(id);
            if (habilidade != null)
            {
                _context.Habilidades.Remove(habilidade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabilidadeExists(int id)
        {
            return _context.Habilidades.Any(e => e.Id == id);
        }
    }
}
