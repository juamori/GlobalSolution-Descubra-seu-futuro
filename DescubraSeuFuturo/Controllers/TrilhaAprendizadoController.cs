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
    public class TrilhaAprendizadoController : Controller
    {
        private readonly AppDbContext _context;

        public TrilhaAprendizadoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TrilhaAprendizado
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TrilhasAprendizado.Include(t => t.Competencia);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TrilhaAprendizado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilhaAprendizado = await _context.TrilhasAprendizado
                .Include(t => t.Competencia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trilhaAprendizado == null)
            {
                return NotFound();
            }

            return View(trilhaAprendizado);
        }

        // GET: TrilhaAprendizado/Create
        public IActionResult Create()
        {
            ViewData["CompetenciaId"] = new SelectList(_context.Competencias, "Id", "Id");
            return View();
        }

        // POST: TrilhaAprendizado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,CompetenciaId")] TrilhaAprendizado trilhaAprendizado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trilhaAprendizado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompetenciaId"] = new SelectList(_context.Competencias, "Id", "Id", trilhaAprendizado.CompetenciaId);
            return View(trilhaAprendizado);
        }

        // GET: TrilhaAprendizado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilhaAprendizado = await _context.TrilhasAprendizado.FindAsync(id);
            if (trilhaAprendizado == null)
            {
                return NotFound();
            }
            ViewData["CompetenciaId"] = new SelectList(_context.Competencias, "Id", "Id", trilhaAprendizado.CompetenciaId);
            return View(trilhaAprendizado);
        }

        // POST: TrilhaAprendizado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,CompetenciaId")] TrilhaAprendizado trilhaAprendizado)
        {
            if (id != trilhaAprendizado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trilhaAprendizado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrilhaAprendizadoExists(trilhaAprendizado.Id))
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
            ViewData["CompetenciaId"] = new SelectList(_context.Competencias, "Id", "Id", trilhaAprendizado.CompetenciaId);
            return View(trilhaAprendizado);
        }

        // GET: TrilhaAprendizado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilhaAprendizado = await _context.TrilhasAprendizado
                .Include(t => t.Competencia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trilhaAprendizado == null)
            {
                return NotFound();
            }

            return View(trilhaAprendizado);
        }

        // POST: TrilhaAprendizado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trilhaAprendizado = await _context.TrilhasAprendizado.FindAsync(id);
            if (trilhaAprendizado != null)
            {
                _context.TrilhasAprendizado.Remove(trilhaAprendizado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrilhaAprendizadoExists(int id)
        {
            return _context.TrilhasAprendizado.Any(e => e.Id == id);
        }
    }
}
