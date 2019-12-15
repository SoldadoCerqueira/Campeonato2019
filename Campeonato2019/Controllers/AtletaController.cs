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
    public class AtletaController : Controller
    {
        private readonly Campeonato2019Context _context;

        public AtletaController(Campeonato2019Context context)
        {
            _context = context;
        }

        // GET: Atleta
        public async Task<IActionResult> Index()
        {
            return View(await _context.Atleta.ToListAsync());
        }

        // GET: Atleta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta
                .FirstOrDefaultAsync(m => m.AtletaId == id);
            if (atleta == null)
            {
                return NotFound();
            }

            return View(atleta);
        }

        // GET: Atleta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atleta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AtletaId,Nome,Idade,Nacionalidade")] Atleta atleta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atleta);
        }

        // GET: Atleta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta.FindAsync(id);
            if (atleta == null)
            {
                return NotFound();
            }
            return View(atleta);
        }

        // POST: Atleta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AtletaId,Nome,Idade,Nacionalidade")] Atleta atleta)
        {
            if (id != atleta.AtletaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtletaExists(atleta.AtletaId))
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
            return View(atleta);
        }

        // GET: Atleta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta
                .FirstOrDefaultAsync(m => m.AtletaId == id);
            if (atleta == null)
            {
                return NotFound();
            }

            return View(atleta);
        }

        // POST: Atleta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atleta = await _context.Atleta.FindAsync(id);
            _context.Atleta.Remove(atleta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtletaExists(int id)
        {
            return _context.Atleta.Any(e => e.AtletaId == id);
        }
    }
}
