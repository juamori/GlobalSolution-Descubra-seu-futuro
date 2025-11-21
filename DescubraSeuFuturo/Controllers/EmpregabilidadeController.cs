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
    public class EmpregabilidadeController : Controller
    {
        private readonly AppDbContext _context;

        public EmpregabilidadeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Empregabilidade
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empregabilidades.ToListAsync());
        }

        // GET: Empregabilidade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregabilidade = await _context.Empregabilidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empregabilidade == null)
            {
                return NotFound();
            }

            return View(empregabilidade);
        }

        // GET: Empregabilidade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empregabilidade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Area,TaxaCrescimento,Fonte")] Empregabilidade empregabilidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empregabilidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empregabilidade);
        }

        // GET: Empregabilidade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregabilidade = await _context.Empregabilidades.FindAsync(id);
            if (empregabilidade == null)
            {
                return NotFound();
            }
            return View(empregabilidade);
        }

        // POST: Empregabilidade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Area,TaxaCrescimento,Fonte")] Empregabilidade empregabilidade)
        {
            if (id != empregabilidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empregabilidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpregabilidadeExists(empregabilidade.Id))
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
            return View(empregabilidade);
        }

        // GET: Empregabilidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregabilidade = await _context.Empregabilidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empregabilidade == null)
            {
                return NotFound();
            }

            return View(empregabilidade);
        }

        // POST: Empregabilidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empregabilidade = await _context.Empregabilidades.FindAsync(id);
            if (empregabilidade != null)
            {
                _context.Empregabilidades.Remove(empregabilidade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpregabilidadeExists(int id)
        {
            return _context.Empregabilidades.Any(e => e.Id == id);
        }
    }
}
