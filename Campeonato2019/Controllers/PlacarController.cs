using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Campeonato2019.Data;
using Campeonato2019.Models;

namespace Campeonato2019.Controllers
{
    public class PlacarController : Controller
    {
        private readonly Campeonato2019Context _context;

        public PlacarController(Campeonato2019Context context)
        {
            _context = context;
        }

        // GET: Placar
        public async Task<IActionResult> Index()
        {
            var campeonato2019Context = _context.Placar.Include(p => p.Atleta);
            return View(await campeonato2019Context.ToListAsync());
        }

        // GET: Placar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placar = await _context.Placar
                .Include(p => p.Atleta)
                .FirstOrDefaultAsync(m => m.PlacarId == id);
            if (placar == null)
            {
                return NotFound();
            }

            return View(placar);
        }

        // GET: Placar/Create
        public IActionResult Create()
        {
            ViewData["AtletaId"] = new SelectList(_context.Atleta, "AtletaId", "Nome");
            return View();
        }

        // POST: Placar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlacarId,AtletaId,Pontos,Data")] Placar placar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AtletaId"] = new SelectList(_context.Atleta, "AtletaId", "Nome", placar.AtletaId);
            return View(placar);
        }

        // GET: Placar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placar = await _context.Placar.FindAsync(id);
            if (placar == null)
            {
                return NotFound();
            }
            ViewData["AtletaId"] = new SelectList(_context.Atleta, "AtletaId", "Nome", placar.AtletaId);
            return View(placar);
        }

        // POST: Placar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlacarId,AtletaId,Pontos,Data")] Placar placar)
        {
            if (id != placar.PlacarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacarExists(placar.PlacarId))
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
            ViewData["AtletaId"] = new SelectList(_context.Atleta, "AtletaId", "Nome", placar.AtletaId);
            return View(placar);
        }

        // GET: Placar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placar = await _context.Placar
                .Include(p => p.Atleta)
                .FirstOrDefaultAsync(m => m.PlacarId == id);
            if (placar == null)
            {
                return NotFound();
            }

            return View(placar);
        }

        // POST: Placar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placar = await _context.Placar.FindAsync(id);
            _context.Placar.Remove(placar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacarExists(int id)
        {
            return _context.Placar.Any(e => e.PlacarId == id);
        }
    }
}
