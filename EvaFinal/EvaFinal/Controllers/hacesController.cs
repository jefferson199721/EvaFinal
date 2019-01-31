using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvaFinal.Data;
using EvaFinal.Models;

namespace EvaFinal.Controllers
{
    public class hacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public hacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: haces
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Hacer.Include(h => h.alumnos).Include(h => h.examen);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: haces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hace = await _context.Hacer
                .Include(h => h.alumnos)
                .Include(h => h.examen)
                .SingleOrDefaultAsync(m => m.hacerid == id);
            if (hace == null)
            {
                return NotFound();
            }

            return View(hace);
        }

        // GET: haces/Create
        public IActionResult Create()
        {
            ViewData["NumMatricula"] = new SelectList(_context.Alumnos, "NumMatricula", "NumMatricula");
            ViewData["ExamenId"] = new SelectList(_context.Examen, "ExamenId", "ExamenId");
            return View();
        }

        // POST: haces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("hacerid,NumMatricula,ExamenId,Nota")] hace hace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumMatricula"] = new SelectList(_context.Alumnos, "NumMatricula", "NumMatricula", hace.NumMatricula);
            ViewData["ExamenId"] = new SelectList(_context.Examen, "ExamenId", "ExamenId", hace.ExamenId);
            return View(hace);
        }

        // GET: haces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hace = await _context.Hacer.SingleOrDefaultAsync(m => m.hacerid == id);
            if (hace == null)
            {
                return NotFound();
            }
            ViewData["NumMatricula"] = new SelectList(_context.Alumnos, "NumMatricula", "NumMatricula", hace.NumMatricula);
            ViewData["ExamenId"] = new SelectList(_context.Examen, "ExamenId", "ExamenId", hace.ExamenId);
            return View(hace);
        }

        // POST: haces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("hacerid,NumMatricula,ExamenId,Nota")] hace hace)
        {
            if (id != hace.hacerid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!haceExists(hace.hacerid))
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
            ViewData["NumMatricula"] = new SelectList(_context.Alumnos, "NumMatricula", "NumMatricula", hace.NumMatricula);
            ViewData["ExamenId"] = new SelectList(_context.Examen, "ExamenId", "ExamenId", hace.ExamenId);
            return View(hace);
        }

        // GET: haces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hace = await _context.Hacer
                .Include(h => h.alumnos)
                .Include(h => h.examen)
                .SingleOrDefaultAsync(m => m.hacerid == id);
            if (hace == null)
            {
                return NotFound();
            }

            return View(hace);
        }

        // POST: haces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hace = await _context.Hacer.SingleOrDefaultAsync(m => m.hacerid == id);
            _context.Hacer.Remove(hace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool haceExists(int id)
        {
            return _context.Hacer.Any(e => e.hacerid == id);
        }
    }
}
